using System.Diagnostics;
using System.Globalization;
using System.Text;
using Npgsql;
using NpgsqlTypes;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

// ============================================================================
// OraToPg — data-only full-refresh migrator: Oracle (PEAN) -> PostgreSQL (soatdb)
//
// - PG schema is the AUTHORITY (target tables/columns/types already migrated).
// - Copies data only. Does NOT touch functions/triggers/views/schema.
// - Disables FK + all triggers during load via session_replication_role=replica
//   (soat = superuser). TRUNCATE all targets first, then bulk COPY (binary).
// - Reconciles COUNT(*) Oracle vs PG per table.
//
// Usage:
//   dotnet run                 -> full refresh: TRUNCATE all + reload 1388 tables
//   dotnet run -- <table>      -> single table (proof / re-run a failed table)
//   dotnet run -- --like <p>   -> refresh every table whose name starts with <p>
//   dotnet run -- --after <t>  -> resume full refresh with tables AFTER <t> only
//   dotnet run -- --list       -> list intersection tables + Oracle row counts
//   dotnet run -- --reconcile  -> compare counts only (no writes)
// ============================================================================

static string Env(string k, string d) => Environment.GetEnvironmentVariable(k) is { Length: > 0 } v ? v : d;

string oraHost = Env("ORA_HOST", "192.168.101.29");
string oraPort = Env("ORA_PORT", "1521");
string oraSvc  = Env("ORA_SERVICE", "PEAN");
string oraUser = Env("ORA_USER", "dbo");
string oraPwd  = Env("ORA_PWD", "xsqlx");
// TNS descriptor (NOT EZConnect — Oracle.ManagedDataAccess.Core requires descriptor form)
string oraCs = $"User Id={oraUser};Password={oraPwd};Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={oraHost})(PORT={oraPort}))(CONNECT_DATA=(SERVICE_NAME={oraSvc})));Connection Timeout=120;";

string pgCs = Env("PG_CS", "Host=localhost;Port=5432;Database=soatdb;Username=soat;Password=soat1234;Timeout=60;Command Timeout=0;");

var argList = args.ToList();
bool listOnly      = argList.Remove("--list");
bool reconcileOnly = argList.Remove("--reconcile");
bool restoreSiApps = argList.Remove("--restore-siapps");
bool preflight     = argList.Remove("--preflight");
string? afterTable = null;
int afterIdx = argList.IndexOf("--after");
if (afterIdx >= 0 && afterIdx + 1 < argList.Count)
{
    afterTable = argList[afterIdx + 1];
    argList.RemoveRange(afterIdx, 2);
}
// --like <prefix>: refresh every table whose name starts with <prefix> (trailing
// '*' or '%' optional). Group refresh, e.g. --like sc_fin_  reloads all sc_fin_*.
string? likePrefix = null;
int likeIdx = argList.IndexOf("--like");
if (likeIdx >= 0 && likeIdx + 1 < argList.Count)
{
    likePrefix = argList[likeIdx + 1].TrimEnd('*', '%');
    argList.RemoveRange(likeIdx, 2);
}
string? only = argList.FirstOrDefault(a => !a.StartsWith("--"));

Console.OutputEncoding = Encoding.UTF8;
var sw = Stopwatch.StartNew();
Console.WriteLine($"OraToPg  Oracle={oraUser}@{oraSvc} ({oraHost}:{oraPort})  ->  PG=soatdb");
Console.WriteLine(new string('=', 78));

using var ora = new OracleConnection(oraCs);
using var pg  = new NpgsqlConnection(pgCs);
ora.Open();
pg.Open();

// ---- table sets --------------------------------------------------------------
var oraTables = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
using (var c = new OracleCommand("SELECT table_name FROM user_tables", ora))
using (var r = c.ExecuteReader())
    while (r.Read()) oraTables.Add(r.GetString(0).ToLowerInvariant());

var pgTables = new List<string>();
using (var c = new NpgsqlCommand(
    "SELECT table_name FROM information_schema.tables WHERE table_schema='public' AND table_type='BASE TABLE' ORDER BY table_name", pg))
using (var r = c.ExecuteReader())
    while (r.Read()) pgTables.Add(r.GetString(0));

// intersection (skip PG-only e.g. __EFMigrationsHistory)
var targets = pgTables.Where(t => oraTables.Contains(t)).ToList();

// EXCLUDE PG-managed auth/menu family (curated + transformed on PG side; NOT raw
// Oracle copies — reloading breaks login + menus). Restore via --restore-siapps.
// Skipped only when an explicit single table is named.
static bool IsPgManaged(string t) => t.StartsWith("si_security_", StringComparison.OrdinalIgnoreCase);
if (only == null)
{
    int before = targets.Count;
    targets = targets.Where(t => !IsPgManaged(t)).ToList();
    Console.WriteLine($"excluded {before - targets.Count} PG-managed si_security_* table(s) from refresh");
}

if (only != null)
{
    if (!targets.Contains(only, StringComparer.OrdinalIgnoreCase))
    {
        Console.WriteLine($"!! table '{only}' not in Oracle∩PG intersection. abort.");
        return 2;
    }
    targets = targets.Where(t => string.Equals(t, only, StringComparison.OrdinalIgnoreCase)).ToList();
}

// prefix-group refresh (--like). Filtered from the intersection AFTER the
// si_security_ exclusion above, so an accidental --like si_security_ stays empty.
if (likePrefix != null)
{
    targets = targets.Where(t => t.StartsWith(likePrefix, StringComparison.OrdinalIgnoreCase)).ToList();
    if (targets.Count == 0)
    {
        Console.WriteLine($"!! --like '{likePrefix}' matched 0 tables in Oracle∩PG intersection. abort.");
        return 2;
    }
    Console.WriteLine($"--like {likePrefix}: {targets.Count} matching table(s)");
}

// resume mode: keep only tables strictly AFTER the given one (same ordering as a
// full run: PG table_name ASC). Loaded tables before it are left untouched.
if (afterTable != null)
{
    int idx = targets.FindIndex(t => string.Equals(t, afterTable, StringComparison.OrdinalIgnoreCase));
    if (idx < 0)
    {
        Console.WriteLine($"!! --after table '{afterTable}' not in target list. abort.");
        return 2;
    }
    targets = targets.Skip(idx + 1).ToList();
    Console.WriteLine($"--after {afterTable}: resuming with {targets.Count} remaining table(s)");
}

Console.WriteLine($"targets: {targets.Count} table(s)  (Oracle {oraTables.Count} / PG {pgTables.Count})");

// ---- list / reconcile only ---------------------------------------------------
if (listOnly || reconcileOnly)
{
    long tor = 0, tpg = 0; int mism = 0;
    foreach (var t in targets)
    {
        long oc = OraCount(ora, t);
        long pc = reconcileOnly ? PgCount(pg, t) : -1;
        tor += oc; if (pc >= 0) tpg += pc;
        string flag = pc >= 0 && oc != pc ? "  <-- MISMATCH" : "";
        if (pc >= 0 && oc != pc) mism++;
        Console.WriteLine($"  {t,-45} ora={oc,10}{(pc >= 0 ? $"  pg={pc,10}" : "")}{flag}");
    }
    Console.WriteLine(new string('-', 78));
    Console.WriteLine($"  TOTAL ora={tor}{(reconcileOnly ? $"  pg={tpg}  mismatches={mism}" : "")}");
    return 0;
}

// ---- PRE-FLIGHT VALIDATION (no writes) ---------------------------------------
// For each target, detect Oracle data that would violate a PG constraint on load:
//   (a) NULL in a PG NOT NULL column, (b) string longer than PG varchar/char(n).
// One aggregate query per table. Reports offenders; touches no data.
if (preflight)
{
    return Preflight(ora, pg, targets);
}

// ---- RESTORE si_security_apps (PG-managed menu table) ------------------------
// Faithful reproduction of the removed DatabaseSeeder (commit 334be42):
//   level 1 = 32 hand-curated landing rows; level 2/3 = Oracle rows with
//   NVL(i_sequence,0)/NVL(order_no,0) and active = (active == "1").
// This table is NOT part of the blind Oracle full-refresh (PG data is transformed
// + curated). Run:  dotnet run -- --restore-siapps
if (restoreSiApps)
{
    RestoreSiApps(ora, pg);
    return 0;
}

// ---- FULL LOAD ---------------------------------------------------------------
// superuser session: disables FK + all triggers for this connection
using (var c = new NpgsqlCommand("SET session_replication_role = replica", pg)) c.ExecuteNonQuery();

// Phase 1: TRUNCATE all targets first (avoids CASCADE wiping an already-loaded table).
Console.WriteLine($"TRUNCATE {targets.Count} table(s) ...");
foreach (var chunk in Chunk(targets, 400))
{
    string sql = "TRUNCATE TABLE " + string.Join(",", chunk.Select(t => $"\"{t}\"")) + " CASCADE";
    using var c = new NpgsqlCommand(sql, pg) { CommandTimeout = 0 };
    c.ExecuteNonQuery();
}

// Phase 2: load each table
int done = 0, failed = 0, mismatch = 0;
long totalRows = 0;
var failures  = new List<string>();
var mismatches = new List<string>();

foreach (var t in targets)
{
    var tsw = Stopwatch.StartNew();
    try
    {
        // PG target columns (authority) in ordinal order
        var cols = new List<(string name, string udt)>();
        using (var c = new NpgsqlCommand(
            "SELECT column_name, udt_name FROM information_schema.columns " +
            "WHERE table_schema='public' AND table_name=@t ORDER BY ordinal_position", pg))
        {
            c.Parameters.AddWithValue("t", t);
            using var r = c.ExecuteReader();
            while (r.Read()) cols.Add((r.GetString(0), r.GetString(1)));
        }

        // Oracle columns present for this table (uppercase)
        var oraCols = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        using (var c = new OracleCommand("SELECT column_name FROM user_tab_columns WHERE table_name = :t", ora))
        {
            c.Parameters.Add(":t", t.ToUpperInvariant());
            using var r = c.ExecuteReader();
            while (r.Read()) oraCols.Add(r.GetString(0));
        }

        // copy only columns that exist on BOTH sides
        var copyCols = cols.Where(c => oraCols.Contains(c.name)).ToList();
        if (copyCols.Count == 0) { Console.WriteLine($"  {t,-45} (no common columns) skip"); continue; }

        string oraSelect = "SELECT " + string.Join(",", copyCols.Select(c => $"\"{c.name.ToUpperInvariant()}\"")) +
                           $" FROM \"{t.ToUpperInvariant()}\"";
        string copySql = $"COPY \"{t}\" (" + string.Join(",", copyCols.Select(c => $"\"{c.name}\"")) +
                         ") FROM STDIN (FORMAT BINARY)";

        long rows = 0;
        using (var oc = new OracleCommand(oraSelect, ora) { FetchSize = 8 * 1024 * 1024, InitialLOBFetchSize = -1 })
        using (var rdr = oc.ExecuteReader())
        using (var writer = pg.BeginBinaryImport(copySql))
        {
            while (rdr.Read())
            {
                writer.StartRow();
                for (int i = 0; i < copyCols.Count; i++)
                {
                    if (rdr.IsDBNull(i)) { writer.WriteNull(); continue; }
                    WriteCell(writer, copyCols[i].udt, GetOra(rdr, i));
                }
                rows++;
            }
            writer.Complete();
        }

        long oraCnt = OraCount(ora, t);
        totalRows += rows;
        done++;
        string flag = oraCnt != rows ? "  <-- MISMATCH" : "";
        if (oraCnt != rows) { mismatch++; mismatches.Add($"{t}: ora={oraCnt} pg={rows}"); }
        Console.WriteLine($"  [{done + failed,4}/{targets.Count}] {t,-45} {rows,9} rows  {tsw.Elapsed.TotalSeconds,6:F1}s{flag}");
    }
    catch (Exception ex)
    {
        failed++;
        failures.Add($"{t}: {ex.Message.Replace('\n', ' ')}");
        Console.WriteLine($"  [{done + failed,4}/{targets.Count}] {t,-45}  FAILED: {ex.Message.Split('\n')[0]}");
    }
}

using (var c = new NpgsqlCommand("SET session_replication_role = origin", pg)) c.ExecuteNonQuery();

Console.WriteLine(new string('=', 78));
Console.WriteLine($"done={done}  failed={failed}  mismatch={mismatch}  rows={totalRows:N0}  elapsed={sw.Elapsed.TotalMinutes:F1} min");
if (mismatches.Count > 0)
{
    Console.WriteLine("\n-- count mismatches --");
    foreach (var m in mismatches) Console.WriteLine("  " + m);
}
if (failures.Count > 0)
{
    Console.WriteLine("\n-- failures (re-run:  dotnet run -- <table>) --");
    foreach (var f in failures) Console.WriteLine("  " + f);
}
return failed > 0 ? 1 : 0;

// ============================================================================
// Dry-run constraint check. Returns 0 if clean, 1 if any violations found.
static int Preflight(OracleConnection ora, NpgsqlConnection pg, List<string> targets)
{
    Console.WriteLine($"PRE-FLIGHT: checking {targets.Count} table(s) for Oracle->PG constraint violations ...\n");
    var problems = new List<string>();
    int checkedTables = 0;

    foreach (var t in targets)
    {
        // PG columns: NOT NULL flag + varchar/char max length
        var pgCols = new List<(string name, string udt, bool notNull, int? maxLen)>();
        using (var c = new NpgsqlCommand(
            "SELECT column_name, udt_name, is_nullable, character_maximum_length " +
            "FROM information_schema.columns WHERE table_schema='public' AND table_name=@t", pg))
        {
            c.Parameters.AddWithValue("t", t);
            using var r = c.ExecuteReader();
            while (r.Read())
                pgCols.Add((r.GetString(0), r.GetString(1), r.GetString(2) == "NO",
                           r.IsDBNull(3) ? (int?)null : r.GetInt32(3)));
        }

        // Oracle columns present
        var oraCols = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        using (var c = new OracleCommand("SELECT column_name FROM user_tab_columns WHERE table_name = :t", ora))
        {
            c.Parameters.Add(":t", t.ToUpperInvariant());
            using var r = c.ExecuteReader();
            while (r.Read()) oraCols.Add(r.GetString(0));
        }

        // build one aggregate check query over columns that exist on both sides
        var sel = new List<string>();
        var meta = new List<(string alias, string col, string kind, int len)>();
        int k = 0;
        foreach (var (name, udt, notNull, maxLen) in pgCols)
        {
            if (!oraCols.Contains(name)) continue;
            string oc = $"\"{name.ToUpperInvariant()}\"";
            if (notNull)
            {
                string a = $"N{k}";
                sel.Add($"SUM(CASE WHEN {oc} IS NULL THEN 1 ELSE 0 END) {a}");
                meta.Add((a, name, "NULL->NOT NULL", 0)); k++;
            }
            if (maxLen is int ml && (udt == "varchar" || udt == "bpchar"))
            {
                string a = $"L{k}";
                sel.Add($"SUM(CASE WHEN {oc} IS NOT NULL AND LENGTH({oc}) > {ml} THEN 1 ELSE 0 END) {a}");
                meta.Add((a, name, $"len>{ml}", ml)); k++;
            }
        }
        if (sel.Count == 0) continue;
        checkedTables++;

        try
        {
            using var oc2 = new OracleCommand($"SELECT {string.Join(",", sel)} FROM \"{t.ToUpperInvariant()}\"", ora);
            using var r = oc2.ExecuteReader();
            if (r.Read())
            {
                for (int i = 0; i < meta.Count; i++)
                {
                    long cnt = r.IsDBNull(i) ? 0 : Convert.ToInt64(r.GetValue(i));
                    if (cnt > 0)
                        problems.Add($"{t}.{meta[i].col,-28} {meta[i].kind,-16} {cnt,10} row(s)");
                }
            }
        }
        catch (Exception ex)
        {
            problems.Add($"{t}: CHECK FAILED: {ex.Message.Split('\n')[0]}");
        }
    }

    Console.WriteLine(new string('=', 78));
    if (problems.Count == 0)
    {
        Console.WriteLine($"CLEAN — {checkedTables} table(s) with constraints checked, no violations. Safe to load.");
        return 0;
    }
    Console.WriteLine($"VIOLATIONS: {problems.Count} column-level issue(s) across checked tables:\n");
    foreach (var p in problems) Console.WriteLine("  " + p);
    Console.WriteLine("\nResolve (fix data / relax PG constraint / exclude table) before full load.");
    return 1;
}

// ============================================================================
// Restore si_security_apps — raw migrate ทุก level จาก Oracle (Oracle = source เดียว); แทน EF DatabaseSeeder เดิม
static void RestoreSiApps(OracleConnection ora, NpgsqlConnection pg)
{
    // migrate ดิบทั้งตารางจาก Oracle — ครบ 5 level (1 landing / 2 top-bar / 3 dropdown / 4 tab-group / 5 tab)
    //   ผู้ใช้ยืนยัน 2026-07-11: Oracle เป็น source เดียว เลิก hand-curate level-1 (scCremation/scScholarship ที่ PG เพิ่มเองหลุดออกตามเจตนา)
    //   ข้าม row i_level IS NULL (Oracle มี 'TakeControl' i_menu_id=0 — system junk; PG i_level NOT NULL รับไม่ได้ + ScAppService ไม่เคย query)
    //   type transform: Oracle FLOAT→PG int (menu_id/level/sequence/order/parent), CHAR→bool (active/postto_fin/c_begin_group)
    //   PG NOT NULL guard: order_no NULL 673 แถว → NVL 0; active/i_sequence Oracle ไม่มี null
    // ⚠️ POST-STEP บังคับถ้า re-run: level-5 s_url ที่ได้จาก Oracle เป็นชื่อ legacy 'u_tabpg_*'
    //    แต่ PanTabs.ResolveType คาดหวังชื่อ component .razor (PascalCase). หลังรันต้อง normalize:
    //      UPDATE si_security_apps SET s_url=replace(initcap(s_url),'_','') WHERE i_level=5 AND left(s_url,8)='u_tabpg_';
    //    (ทำครั้งแรกแล้ว 2026-07-11 — ปกติ si_security_apps finalized ใน PG, ไม่ควร re-run mode นี้ทับ)
    using (var c = new NpgsqlCommand("DELETE FROM si_security_apps", pg)) c.ExecuteNonQuery();

    int n = 0;
    using (var oc = new OracleCommand(
        "SELECT i_menu_id, i_parent_id, app_name, app_text, app_text_english, app_text_menu, active, " +
        "i_level, NVL(i_sequence,0), NVL(order_no,0), shot_app, icon_name, s_url, sub_app_name, remark, " +
        "postto_fin, c_begin_group " +
        "FROM si_security_apps WHERE i_level IS NOT NULL ORDER BY i_level, i_sequence", ora))
    using (var r = oc.ExecuteReader())
    {
        while (r.Read())
        {
            using var c = new NpgsqlCommand(
                "INSERT INTO si_security_apps (i_menu_id,i_parent_id,app_name,app_text,app_text_english,app_text_menu,active,i_level,i_sequence,order_no,shot_app,icon_name,s_url,sub_app_name,remark,postto_fin,c_begin_group) " +
                "VALUES (@id,@pid,@name,@txt,@en,@menu,@active,@lvl,@seq,@ord,@shot,@icon,@url,@sub,@rem,@pfin,@cbeg)", pg);
            c.Parameters.AddWithValue("id",   (int)r.GetDecimal(0));
            c.Parameters.AddWithValue("pid",  r.IsDBNull(1) ? DBNull.Value : (int)r.GetDecimal(1));
            c.Parameters.AddWithValue("name", r.IsDBNull(2) ? DBNull.Value : r.GetString(2));
            c.Parameters.AddWithValue("txt",  r.IsDBNull(3) ? DBNull.Value : r.GetString(3));
            c.Parameters.AddWithValue("en",   r.IsDBNull(4) ? DBNull.Value : r.GetString(4));
            c.Parameters.AddWithValue("menu", r.IsDBNull(5) ? DBNull.Value : r.GetString(5));
            c.Parameters.AddWithValue("active", !r.IsDBNull(6) && r.GetString(6).Trim() == "1");
            c.Parameters.AddWithValue("lvl",  (int)r.GetDecimal(7));
            c.Parameters.AddWithValue("seq",  (int)r.GetDecimal(8));
            c.Parameters.AddWithValue("ord",  (int)r.GetDecimal(9));
            c.Parameters.AddWithValue("shot", r.IsDBNull(10) ? DBNull.Value : r.GetString(10));
            c.Parameters.AddWithValue("icon", r.IsDBNull(11) ? DBNull.Value : r.GetString(11));
            c.Parameters.AddWithValue("url",  r.IsDBNull(12) ? DBNull.Value : r.GetString(12));
            c.Parameters.AddWithValue("sub",  r.IsDBNull(13) ? DBNull.Value : r.GetString(13));
            c.Parameters.AddWithValue("rem",  r.IsDBNull(14) ? DBNull.Value : r.GetString(14));
            // postto_fin/c_begin_group = nullable boolean; Oracle CHAR ('1'/'0'/'Y'/blank) → true/false/null
            c.Parameters.AddWithValue("pfin", ToNbool(r, 15));
            c.Parameters.AddWithValue("cbeg", ToNbool(r, 16));
            c.ExecuteNonQuery();
            n++;
        }
    }
    Console.WriteLine($"  si_security_apps migrated (all levels, raw from Oracle): {n} rows");
}

// Oracle CHAR flag → PG nullable bool: null/blank → null, '1'/'Y' → true, else false
static object ToNbool(OracleDataReader r, int i)
{
    if (r.IsDBNull(i)) return DBNull.Value;
    var v = r.GetString(i).Trim();
    if (v.Length == 0) return DBNull.Value;
    return v == "1" || v == "Y" || v == "y";
}

// ============================================================================
static long OraCount(OracleConnection ora, string t)
{
    using var c = new OracleCommand($"SELECT COUNT(*) FROM \"{t.ToUpperInvariant()}\"", ora);
    return Convert.ToInt64(c.ExecuteScalar());
}
static long PgCount(NpgsqlConnection pg, string t)
{
    using var c = new NpgsqlCommand($"SELECT COUNT(*) FROM \"{t}\"", pg) { CommandTimeout = 0 };
    return Convert.ToInt64(c.ExecuteScalar());
}

// Oracle value read with overflow guard for high-precision NUMBER (> .NET decimal)
static object GetOra(OracleDataReader r, int i)
{
    try { return r.GetValue(i); }
    catch (OverflowException)
    {
        var od = OracleDecimal.SetPrecision(r.GetOracleDecimal(i), 28);
        return od.Value;
    }
}

static void WriteCell(NpgsqlBinaryImporter w, string udt, object v)
{
    switch (udt)
    {
        case "int2":        w.Write(Convert.ToInt16(v), NpgsqlDbType.Smallint); break;
        case "int4":        w.Write(Convert.ToInt32(v), NpgsqlDbType.Integer); break;
        case "int8":        w.Write(Convert.ToInt64(v), NpgsqlDbType.Bigint); break;
        case "numeric":     w.Write(Convert.ToDecimal(v, CultureInfo.InvariantCulture), NpgsqlDbType.Numeric); break;
        case "float4":      w.Write(Convert.ToSingle(v, CultureInfo.InvariantCulture), NpgsqlDbType.Real); break;
        case "float8":      w.Write(Convert.ToDouble(v, CultureInfo.InvariantCulture), NpgsqlDbType.Double); break;
        case "bool":        w.Write(ToBool(v), NpgsqlDbType.Boolean); break;
        case "date":        w.Write(Convert.ToDateTime(v), NpgsqlDbType.Date); break;
        case "timestamp":   w.Write(DateTime.SpecifyKind(Convert.ToDateTime(v), DateTimeKind.Unspecified), NpgsqlDbType.Timestamp); break;
        case "timestamptz": w.Write(DateTime.SpecifyKind(Convert.ToDateTime(v), DateTimeKind.Utc), NpgsqlDbType.TimestampTz); break;
        case "uuid":        w.Write(ToGuid(v), NpgsqlDbType.Uuid); break;
        case "bytea":       w.Write(ToBytes(v), NpgsqlDbType.Bytea); break;
        case "interval":    w.Write((TimeSpan)v, NpgsqlDbType.Interval); break;
        case "bpchar":      w.Write(Convert.ToString(v) ?? "", NpgsqlDbType.Char); break;
        case "varchar":     w.Write(Convert.ToString(v) ?? "", NpgsqlDbType.Varchar); break;
        default:            w.Write(Convert.ToString(v) ?? "", NpgsqlDbType.Text); break; // text + anything else
    }
}

static bool ToBool(object v)
{
    if (v is bool b) return b;
    if (v is decimal d) return d != 0;
    if (v is int or long or short) return Convert.ToInt64(v) != 0;
    string s = Convert.ToString(v)!.Trim().ToUpperInvariant();
    return s is "Y" or "1" or "T" or "TRUE" or "ON";
}

static Guid ToGuid(object v)
{
    if (v is Guid g) return g;
    if (v is byte[] b) return Guid.ParseExact(Convert.ToHexString(b), "N");
    return Guid.Parse(Convert.ToString(v)!.Trim());
}

static byte[] ToBytes(object v)
{
    if (v is byte[] b) return b;
    if (v is OracleBlob ob) return ob.Value;
    return Encoding.UTF8.GetBytes(Convert.ToString(v) ?? "");
}

static IEnumerable<List<string>> Chunk(List<string> src, int n)
{
    for (int i = 0; i < src.Count; i += n) yield return src.GetRange(i, Math.Min(n, src.Count - i));
}
