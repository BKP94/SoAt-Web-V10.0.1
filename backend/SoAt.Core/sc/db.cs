using System.Data;
using System.Text;
using Dapper;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace sc
{
    /// <summary>
    /// sc.db — PostgreSQL version (เหมือนเดิมทุก method signature)
    /// สร้างใหม่ต่อ request/scope: new sc.db(connString, loginId, loginBr)
    /// </summary>
    public class db : IDisposable
    {
        // ─── Constants (เหมือนเดิม) ──────────────────────────────────────────────
        public const string _WHERE      = "/*WHERE*/";
        public const string _dbPreParam = "@param";
        public const string nullValue   = "null";
        public const string _AutoPrimaryKey = "APK";

        // ─── State ───────────────────────────────────────────────────────────────
        public enum dbExecuteState { None, Execute, Failure }
        public dbExecuteState _dbState { get; private set; }
        public string? _dbConnOpenError { get; private set; }
        public List<string> cmdExecute_track { get; } = new();

        private NpgsqlConnection? _conn;
        private NpgsqlTransaction? _trans;
        private readonly string _connectionString;
        private readonly string? _loginId;
        private readonly string? _loginBr;
        private readonly ILogger? _logger;
        private int _counter;

        public db(string connectionString, string? loginId = null, string? loginBr = null, ILogger? logger = null)
        {
            _connectionString = connectionString;
            _loginId = loginId;
            _loginBr = loginBr;
            _logger = logger ?? (sc.log._isActive ? null : null);
        }

        // ─── Connection ───────────────────────────────────────────────────────────

        private bool ofConnectionOpen()
        {
            if (_dbConnOpenError != null) return false;
            if (_conn != null) return true;
            try
            {
                _conn = new NpgsqlConnection(_connectionString);
                _conn.Open();
                _trans = _conn.BeginTransaction(IsolationLevel.ReadCommitted);

                if (!string.IsNullOrWhiteSpace(_loginId))
                    using (var cmd = new NpgsqlCommand($"SET LOCAL app.login_id = '{_loginId}'", _conn, _trans))
                        cmd.ExecuteNonQuery();
                if (!string.IsNullOrWhiteSpace(_loginBr))
                    using (var cmd = new NpgsqlCommand($"SET LOCAL app.login_br = '{_loginBr}'", _conn, _trans))
                        cmd.ExecuteNonQuery();

                _dbState = dbExecuteState.None;
                sc.log.addLine(sc.log.lineMain + "NpgsqlConnection [ Begin ]");
                return true;
            }
            catch (Exception ex)
            {
                _dbConnOpenError = ex.Message;
                sc.log.addLine("Open Database Error: " + ex.Message);
                return false;
            }
        }

        public void ofConnectionClose(string actionName, bool onError = false)
        {
            if (_conn == null) return;
            if (onError && _dbState == dbExecuteState.Execute)
                _dbState = dbExecuteState.Failure;

            if (_trans != null)
            {
                try
                {
                    if      (_dbState == dbExecuteState.Execute)  _trans.Commit();
                    else if (_dbState == dbExecuteState.Failure) _trans.Rollback();
                }
                finally { _trans.Dispose(); _trans = null; }
            }
            _conn.Dispose(); _conn = null;
            sc.log.addLine(sc.log.lineMain + $"NpgsqlConnection [ Dispose | {actionName} ]");
        }

        public void ofCommit()
        {
            if (_dbState != dbExecuteState.Execute || _trans == null) return;
            _trans.Commit();
            _dbState = dbExecuteState.None;
            sc.log.addLine(sc.log.lineMain + "NpgsqlConnection [ Commit ]");
        }
        public void ofRollback()
        {
            if (_dbState != dbExecuteState.Execute || _trans == null) return;
            _trans.Rollback();
            _dbState = dbExecuteState.None;
            sc.log.addLine(sc.log.lineMain + "NpgsqlConnection [ Rollback ]");
        }

        public void Dispose() => ofConnectionClose("Dispose");

        // ─── Parameter builder ───────────────────────────────────────────────────

        public (string finalSql, DynamicParameters finalParams) getSqlParams(string sqlQuery, params object?[] args)
        {
            var sql = sqlQuery;
            var dp  = new DynamicParameters();
            if (args != null)
            {
                for (int i = 0; i < args.Length; i++)
                {
                    if (!sql.Contains($"{{{i}}}")) continue;
                    var name = $"param{i}";
                    dp.Add(name, args[i] is DBNull ? null : args[i]);
                    sql = sql.Replace($"{{{i}}}", $"@{name}");
                }
            }
            // แทนที่ /*WHERE*/ ด้วย string ว่างถ้าไม่ได้ใส่
            sql = sql.Replace(_WHERE, string.Empty);
            return (sql, dp);
        }
        public (string finalSql, DynamicParameters finalParams) getSqlParams(string sqlQuery, string? where, params object?[] args)
        {
            var sql = sqlQuery.Replace(_WHERE, where ?? string.Empty);
            return getSqlParams(sql, args);
        }

        // ─── isQuery ─────────────────────────────────────────────────────────────

        public static bool isQuery(string? sql)
        {
            if (string.IsNullOrWhiteSpace(sql)) return false;
            if (sql.Contains(_WHERE)) return true;
            var s = sql.ToLower();
            return s.Contains("select") && s.Contains("from");
        }

        // ─── sqlArgs / sqlWhere ───────────────────────────────────────────────────

        public string sqlArgs(string sqlQuery, params object?[] args) => sc.value.sqlArgs(sqlQuery, args);
        public string sqlWhere(string sqlQuery, string? where, params object?[] args) => sc.value.sqlWhere(sqlQuery, where, args);
        public string sqlArg2Date(string col, object? datefr, object? dateto)
        {
            if (datefr == null && dateto == null) return string.Empty;
            if (datefr == null) return sqlArgs(col + " <= {0}", dateto);
            if (dateto == null) return sqlArgs(col + " >= {0}", datefr);
            return sqlArgs(col + " between {0} and {1}", datefr, dateto);
        }

        // ─── READ: getValue ───────────────────────────────────────────────────────

        public object? getValue(string sql, params object?[] args)
        {
            if (!ofConnectionOpen()) return null;
            _counter++;
            var logCode = $"[Scalar-{_counter}]";
            var (finalSql, dp) = isQuery(sql) ? getSqlParams(sql, args) : buildFunctionSelect(sql, args);
            sc.log.addLine(logCode + " > " + finalSql);
            try
            {
                var rc = _conn!.ExecuteScalar(finalSql, dp, _trans);
                sc.log.addLine(logCode + " = " + (rc ?? "[NULL]"));
                return rc is DBNull ? null : rc;
            }
            catch (Exception ex) { sc.log.addLine(logCode + " FAIL " + ex.Message); throw; }
        }
        public string getValueString(string sql, params object?[] args)   => sc.value.toString(getValue(sql, args));
        public int    getValueInteger(string sql, params object?[] args)   => sc.value.toInteger(getValue(sql, args));
        public decimal getValueDecimal(string sql, params object?[] args)  => sc.value.toDecimal(getValue(sql, args));
        public object? getValueDate(string sql, params object?[] args)     => sc.value.toDate(getValue(sql, args));

        // ─── READ: getValueR (1 row → Dictionary) ────────────────────────────────

        public Dictionary<string, object?> getValueR(string sql, params object?[] args)
        {
            var rows = getValueT(sql, args);
            if (rows == null || rows.Count == 0) return new(StringComparer.OrdinalIgnoreCase);
            return rows[0];
        }

        // ─── READ: getValueT (many rows → List<Dictionary>) ──────────────────────

        public List<Dictionary<string, object?>> getValueT(string sql, params object?[] args)
        {
            if (!ofConnectionOpen()) return new();
            _counter++;
            var logCode = $"[Reader-{_counter}]";
            var (finalSql, dp) = getSqlParams(sql, args);
            sc.log.addLine(logCode + " > " + finalSql);
            try
            {
                var rows = _conn!.Query(finalSql, dp, _trans);
                var result = rows.Select(row =>
                    ((IDictionary<string, object>)row).ToDictionary(
                        k => k.Key,
                        k => k.Value is DBNull ? null : k.Value,
                        StringComparer.OrdinalIgnoreCase)
                ).ToList();
                sc.log.addLine(logCode + " = " + result.Count + " rows.");
                return result;
            }
            catch (Exception ex) { sc.log.addLine(logCode + " FAIL " + ex.Message); throw; }
        }

        // ─── READ: getValueK (rows keyed by column) ───────────────────────────────

        public Dictionary<string, object?> getValueK(string keyColumns, string sql, params object?[] args)
        {
            var keys  = keyColumns.Split(';');
            var items = getValueT(sql, args);
            var result = new Dictionary<string, object?>(StringComparer.OrdinalIgnoreCase);
            foreach (var item in items)
            {
                var key = string.Join("|", keys.Select(k => sc.value.toString(item, k)));
                if (result.ContainsKey(key)) throw new Exception($"C649:คีย์ซ้ำ {key}");
                result[key] = item;
            }
            return result;
        }

        // ─── READ: getValueA (1 row → List of values) ────────────────────────────

        public List<object?> getValueA(string sql, params object?[] args)
        {
            var row = getValueR(sql, args);
            return row.Values.ToList();
        }

        // ─── READ: getValueList (many rows → List<string>) ───────────────────────

        public List<string> getValueList(string sql, params object?[] args)
        {
            return getValueT(sql, args)
                .Select(row => string.Join("|", row.Values.Select(v => v?.ToString() ?? "")))
                .ToList();
        }

        // ─── READ: getCount ───────────────────────────────────────────────────────

        public int getCount(string table, string? clause = null, params object?[] args)
            => sc.value.toInteger(getValue($"select count(1) from {table} {clause}", args));

        // ─── WRITE: dbInsert ──────────────────────────────────────────────────────

        public int dbInsert(string sql, params object?[] args) => _execute(sql, args);
        public int dbInsert(string tableName, Dictionary<string, object?> values)
        {
            var cols = getColumnAll(tableName);
            var colList = new List<string>();
            var dpInsert = new DynamicParameters();
            int pi = 0;
            foreach (var kv in values)
            {
                if (!cols.Any(c => c.Equals(kv.Key, StringComparison.OrdinalIgnoreCase))) continue;
                var pname = $"p{pi++}";
                colList.Add(kv.Key.ToLower());
                dpInsert.Add(pname, kv.Value);
            }
            if (colList.Count == 0) throw new Exception($"C719:ไม่พบคอลัมน์ของ table:{tableName}");
            var paramNames = Enumerable.Range(0, colList.Count).Select(i => $"@p{i}");
            var sql = $"INSERT INTO {tableName}({string.Join(",", colList)}) VALUES({string.Join(",", paramNames)})";
            return _executeRaw(sql, dpInsert);
        }
        public int dbInsert(string tableName, DataRow dr) => dbInsert(tableName, sc.value.toDictionary(dr));

        // ─── WRITE: dbUpdate ──────────────────────────────────────────────────────

        public int dbUpdate(string sql, params object?[] args) => _execute(sql, args);

        // ─── WRITE: dbDelete ──────────────────────────────────────────────────────

        public int dbDelete(string sql, params object?[] args) => _execute(sql, args);

        // ─── WRITE: pkProcedure (PostgreSQL CALL) ─────────────────────────────────

        public void pkProcedure(string spName, params object?[] args)
        {
            if (string.IsNullOrWhiteSpace(spName)) throw new Exception("C768:Invalid Procedure Name");
            if (!ofConnectionOpen()) return;
            _counter++;
            var logCode = $"[Procedure-{_counter}]";

            // สร้าง CALL proc(@param0, @param1, ...)
            var sql = spName;
            if (!sql.Contains('(') && args != null && args.Length > 0)
                sql += "(" + string.Join(",", Enumerable.Range(0, args.Length).Select(i => $"{{{i}}}")) + ")";

            var (finalSql, dp) = getSqlParams(sql, args);
            // PostgreSQL ใช้ CALL สำหรับ procedure, SELECT สำหรับ function
            if (!finalSql.TrimStart().StartsWith("SELECT", StringComparison.OrdinalIgnoreCase)
             && !finalSql.TrimStart().StartsWith("CALL", StringComparison.OrdinalIgnoreCase))
                finalSql = "CALL " + finalSql;

            sc.log.addLine(logCode + " > " + finalSql);
            try
            {
                _conn!.Execute(finalSql, dp, _trans);
                _dbState = dbExecuteState.Execute;
                sc.log.addLine(logCode + " = done.");
            }
            catch (Exception ex) { sc.log.addLine(logCode + " FAIL " + ex.Message); throw; }
        }

        // ─── READ: pkFunction (PostgreSQL SELECT func()) ──────────────────────────

        public object? pkFunction(string fnName, params object?[] args)
        {
            if (string.IsNullOrWhiteSpace(fnName)) throw new Exception("C811:Invalid Function Name");
            var sql = fnName;
            if (!sql.Contains('(') && args != null && args.Length > 0)
                sql += "(" + string.Join(",", Enumerable.Range(0, args.Length).Select(i => $"{{{i}}}")) + ")";

            // PostgreSQL: SELECT func() — ไม่ต้องมี FROM DUAL
            if (!sql.TrimStart().StartsWith("select", StringComparison.OrdinalIgnoreCase))
                sql = "SELECT " + sql;

            return getValue(sql, args);
        }

        // ─── Column metadata ──────────────────────────────────────────────────────

        public List<string> getColumnAll(string tableName)
        {
            if (!ofConnectionOpen()) return new();
            var parts = tableName.ToLower().Split('.');
            var schema = parts.Length > 1 ? parts[0] : "public";
            var table  = parts.Length > 1 ? parts[1] : parts[0];
            var sql = "SELECT column_name FROM information_schema.columns WHERE table_schema=@s AND table_name=@t ORDER BY ordinal_position";
            return _conn!.Query<string>(sql, new { s = schema, t = table }, _trans).ToList();
        }
        public List<string> getColumnKey(string tableName)
        {
            if (!ofConnectionOpen()) return new();
            var parts = tableName.ToLower().Split('.');
            var schema = parts.Length > 1 ? parts[0] : "public";
            var table  = parts.Length > 1 ? parts[1] : parts[0];
            var sql = @"SELECT kcu.column_name FROM information_schema.table_constraints tc
                JOIN information_schema.key_column_usage kcu
                ON tc.constraint_name = kcu.constraint_name AND tc.table_schema = kcu.table_schema
                WHERE tc.constraint_type = 'PRIMARY KEY' AND tc.table_schema=@s AND tc.table_name=@t
                ORDER BY kcu.ordinal_position";
            return _conn!.Query<string>(sql, new { s = schema, t = table }, _trans).ToList();
        }

        // ─── Internal execute ─────────────────────────────────────────────────────

        private int _execute(string sql, object?[] args)
        {
            if (!ofConnectionOpen()) return 0;
            _counter++;
            var logCode = $"[Execute-{_counter}]";
            var (finalSql, dp) = getSqlParams(sql, args);
            sc.log.addLine(logCode + " > " + sc.value.sqlArgs(sql, args));
            cmdExecute_track.Add(finalSql);
            try
            {
                var n = _conn!.Execute(finalSql, dp, _trans);
                _dbState = dbExecuteState.Execute;
                sc.log.addLine(logCode + " = " + n + " rows.");
                return n;
            }
            catch (Exception ex) { sc.log.addLine(logCode + " FAIL " + ex.Message); _dbState = dbExecuteState.Failure; throw; }
        }
        private int _executeRaw(string sql, DynamicParameters dp)
        {
            if (!ofConnectionOpen()) return 0;
            _counter++;
            var logCode = $"[Execute-{_counter}]";
            sc.log.addLine(logCode + " > " + sql);
            try
            {
                var n = _conn!.Execute(sql, dp, _trans);
                _dbState = dbExecuteState.Execute;
                sc.log.addLine(logCode + " = " + n + " rows.");
                return n;
            }
            catch (Exception ex) { sc.log.addLine(logCode + " FAIL " + ex.Message); _dbState = dbExecuteState.Failure; throw; }
        }
        private (string, DynamicParameters) buildFunctionSelect(string fnName, object?[] args)
        {
            var sql = fnName;
            if (!sql.Contains('(') && args != null && args.Length > 0)
                sql += "(" + string.Join(",", Enumerable.Range(0, args.Length).Select(i => $"{{{i}}}")) + ")";
            if (!sql.TrimStart().StartsWith("select", StringComparison.OrdinalIgnoreCase))
                sql = "SELECT " + sql;
            return getSqlParams(sql, args);
        }
    }
}
