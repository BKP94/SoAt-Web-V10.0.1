using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace sc
{
    // ════════════════════════════════════════════════════════════════════════════
    //  sc.save — Central Save Engine
    //  เทียบ legacy sc.save.ofSave() (Web Forms สแกน control class="save table-xxx")
    //  Blazor ใช้ "metadata บน DTO" แทน: attribute บอก table/column → engine reflect
    //  อ่าน แล้วยิง INSERT/UPDATE ทุก node ในทรานแซกชันเดียว (sc.db 1 instance = 1 txn)
    //  ดู design: save.design.md
    // ════════════════════════════════════════════════════════════════════════════

    // ─── Attributes (= "CSS marker" เวอร์ชัน Blazor) ────────────────────────────

    /// <summary>object/list นี้ → table นี้. บน class = root table; บน property = child.</summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = false)]
    public sealed class SaveTableAttribute(string table) : Attribute
    {
        public string Table { get; } = table;
        /// <summary>column ใน child table ที่เก็บ key ของ parent (engine เติมให้)</summary>
        public string? ParentKey { get; set; }
        /// <summary>สำหรับ List → column ที่ใส่ลำดับ 1..N ให้เอง</summary>
        public string? SeqColumn { get; set; }
        /// <summary>bool prop ทั้งหมดของ node นี้เก็บเป็น char(1) '0'/'1' (legacy flag)</summary>
        public bool BoolAs01 { get; set; }
    }

    /// <summary>PK. ว่าง → INSERT (+gen ถ้ามี Generator); มีค่า → UPDATE</summary>
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class SaveKeyAttribute : Attribute
    {
        /// <summary>ชื่อ generator ใน SaveContext.Generators (เรียกเมื่อ key ว่าง)</summary>
        public string? Generator { get; set; }
    }

    /// <summary>override ชื่อ column (ปกติ auto PascalCase → snake_case)</summary>
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class SaveColumnAttribute(string name) : Attribute
    {
        public string Name { get; } = name;
    }

    /// <summary>ข้าม prop นี้ (lookups / computed / UI-only / จัดด้วย hook)</summary>
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class SaveIgnoreAttribute : Attribute { }

    /// <summary>validate ก่อนเซฟ — ว่าง/null → เก็บ error</summary>
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class SaveRequiredAttribute(string message) : Attribute
    {
        public string Message { get; } = message;
    }

    /// <summary>ค่า default (ปกติเฉพาะตอน insert) เมื่อ prop เป็น null</summary>
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class SaveDefaultAttribute(object value) : Attribute
    {
        public object Value { get; } = value;
        public bool InsertOnly { get; set; } = true;
    }

    // ─── Hook interface: skip row ที่ "ว่าง" (เทียบ HasWorkInfo/HasSpouseInfo legacy) ──

    /// <summary>node/row ที่ implement → ถ้า ShouldSave()=false engine ข้ามไม่เซฟ</summary>
    public interface ISaveRowFilter
    {
        bool ShouldSave();
    }

    // ─── Context / Result / Exception ───────────────────────────────────────────

    public sealed class SaveContext(string userId, string? branchId = null)
    {
        public string UserId { get; } = userId;
        public string? BranchId { get; } = branchId;
        /// <summary>key generator ต่อ call: key ชื่อตาม [SaveKey(Generator="...")]</summary>
        public Dictionary<string, Func<db, Task<string>>> Generators { get; } = new();
    }

    public sealed record SaveResult(string Key, bool IsInsert)
    {
        public string Message => IsInsert ? "บันทึกสำเร็จ" : "อัปเดตสำเร็จ";
    }

    /// <summary>required ไม่ครบ — Page จับแล้วโชว์ข้อความ (ยังไม่แตะ DB)</summary>
    public sealed class SaveValidationException(IReadOnlyList<string> errors)
        : Exception(errors.Count > 0 ? errors[0] : "ข้อมูลไม่ครบ")
    {
        public IReadOnlyList<string> Errors { get; } = errors;
        public string FirstMessage => Errors.Count > 0 ? Errors[0] : Message;
    }

    // ─── Engine ─────────────────────────────────────────────────────────────────

    /// <summary>Register: services.AddScoped&lt;sc.save&gt;() (Scoped ตาม dbFactory ที่ inject; _plans เป็น static)</summary>
    public sealed class save(dbFactory dbFactory)
    {
        private static readonly ConcurrentDictionary<Type, SavePlan> _plans = new();

        /// <summary>เซฟแบบจัดการ connection/transaction เอง (หน้าทั่วไป)</summary>
        public async Task<SaveResult> ofSaveAsync(object root, SaveContext ctx)
        {
            var plan = GetPlan(root.GetType());
            Validate(root, plan);

            var db = dbFactory.create(ctx.UserId, ctx.BranchId);
            try
            {
                var r = await SaveCoreAsync(db, root, plan, ctx);
                await db.ofConnectionCloseAsync("sc.save");
                return r;
            }
            catch
            {
                await db.ofConnectionCloseAsync("sc.save-error", onError: true);
                throw;
            }
        }

        /// <summary>เซฟใน transaction ที่ caller เปิดไว้ (ผสม business hook ได้ เช่น decode รูป)
        /// caller ต้อง ofConnectionCloseAsync เอง</summary>
        public async Task<SaveResult> ofSaveAsync(object root, db db, SaveContext ctx)
        {
            var plan = GetPlan(root.GetType());
            Validate(root, plan);
            return await SaveCoreAsync(db, root, plan, ctx);
        }

        // ─── core ────────────────────────────────────────────────────────────────

        private static async Task<SaveResult> SaveCoreAsync(db db, object root, SavePlan plan, SaveContext ctx)
        {
            var node = plan.Root;
            var deleted = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            // resolve key (insert ถ้าว่าง)
            var key = node.Key!.Prop.GetValue(root)?.ToString();
            var isInsert = string.IsNullOrWhiteSpace(key);
            if (isInsert && node.Key.Generator is { } genName)
            {
                if (!ctx.Generators.TryGetValue(genName, out var gen))
                    throw new Exception($"sc.save: ไม่พบ key generator '{genName}' ใน SaveContext.Generators");
                key = await gen(db);
                node.Key.Prop.SetValue(root, key);
            }

            // root row
            var values = BuildValues(root, node, isInsert, ctx);
            if (isInsert) await ExecInsertAsync(db, node.Table, values);
            else          await ExecUpdateAsync(db, node.Table, values, node.Key.Column, key);

            // children
            foreach (var ch in node.Children)
                await SaveChildAsync(db, ch, root, key!, isInsert, deleted, ctx);

            return new SaveResult(key!, isInsert);
        }

        private static async Task SaveChildAsync(
            db db, ChildMeta ch, object parent, string parentKey, bool parentIsInsert,
            HashSet<string> deleted, SaveContext ctx)
        {
            // update: ล้าง row เดิมของ table นี้ก่อน (ครั้งเดียวต่อ table — 3 address → table เดียว)
            if (!parentIsInsert && deleted.Add(ch.Table))
                await db.dbDeleteAsync($"DELETE FROM {ch.Table} WHERE {ch.ParentKey} = {{0}}", parentKey);

            var val = ch.Prop.GetValue(parent);

            switch (ch.Kind)
            {
                case ChildKind.Object:
                    if (val is null) return;
                    if (val is ISaveRowFilter f && !f.ShouldSave()) return;
                    {
                        var ov = BuildValues(val, ch.Node!, isInsert: true, ctx);
                        ov[ch.ParentKey!] = parentKey;
                        await ExecInsertAsync(db, ch.Table, ov);
                    }
                    return;

                case ChildKind.Scalar:
                    if (val is null) return;
                    {
                        var sv = new Dictionary<string, object?>(StringComparer.OrdinalIgnoreCase)
                        {
                            [ch.ParentKey!]    = parentKey,
                            [ch.ScalarColumn!] = val,
                        };
                        AddAudit(sv, isInsert: true, ctx);
                        await ExecInsertAsync(db, ch.Table, sv);
                    }
                    return;

                case ChildKind.List:
                    if (val is not IEnumerable list) return;
                    var seq = 0;
                    foreach (var item in list)
                    {
                        if (item is null) continue;
                        if (item is ISaveRowFilter rf && !rf.ShouldSave()) continue;
                        seq++;
                        var iv = BuildValues(item, ch.Node!, isInsert: true, ctx);
                        iv[ch.ParentKey!] = parentKey;
                        if (ch.SeqColumn is { } seqCol) iv[seqCol] = seq;
                        await ExecInsertAsync(db, ch.Table, iv);
                    }
                    return;
            }
        }

        // ─── value building ────────────────────────────────────────────────────────

        private static Dictionary<string, object?> BuildValues(object obj, NodeMeta node, bool isInsert, SaveContext ctx)
        {
            var d = new Dictionary<string, object?>(StringComparer.OrdinalIgnoreCase);
            foreach (var c in node.Columns)
            {
                var v = c.Prop.GetValue(obj);
                if (c.Bool01) v = sc.value.toString(v is bool b && b);  // bool → "1"/"0"
                if (v is null) continue;
                d[c.Column] = v;
            }
            foreach (var def in node.Defaults)
                if ((isInsert || !def.InsertOnly) && !d.ContainsKey(def.Column))
                    d[def.Column] = def.Value;

            AddAudit(d, isInsert, ctx);
            return d;
        }

        private static void AddAudit(Dictionary<string, object?> d, bool isInsert, SaveContext ctx)
        {
            var now = DateTime.UtcNow;
            if (isInsert)
            {
                d["created_at"] = now;
                d["created_by"] = ctx.UserId;
            }
            d["updated_at"] = now;
            d["updated_by"] = ctx.UserId;
        }

        // ─── SQL exec (ใช้ public db API + filter เฉพาะ column ที่มีจริง) ─────────────

        private static async Task<int> ExecInsertAsync(db db, string table, Dictionary<string, object?> values)
        {
            var cols = await db.getColumnAllAsync(table);
            var use  = values.Where(kv => cols.Any(c => c.Equals(kv.Key, StringComparison.OrdinalIgnoreCase))).ToList();
            if (use.Count == 0) return 0;
            var colList = string.Join(",", use.Select(kv => kv.Key));
            var ph      = string.Join(",", Enumerable.Range(0, use.Count).Select(i => $"{{{i}}}"));
            var sql     = $"INSERT INTO {table}({colList}) VALUES({ph})";
            return await db.dbInsertAsync(sql, use.Select(kv => kv.Value).ToArray());
        }

        private static async Task<int> ExecUpdateAsync(
            db db, string table, Dictionary<string, object?> values, string keyCol, string? keyVal)
        {
            var cols = await db.getColumnAllAsync(table);
            var setVals = values
                .Where(kv => !kv.Key.Equals(keyCol, StringComparison.OrdinalIgnoreCase)
                          && cols.Any(c => c.Equals(kv.Key, StringComparison.OrdinalIgnoreCase)))
                .ToList();
            if (setVals.Count == 0) return 0;
            var setClause = string.Join(",", setVals.Select((kv, i) => $"{kv.Key} = {{{i}}}"));
            var sql       = $"UPDATE {table} SET {setClause} WHERE {keyCol} = {{{setVals.Count}}}";
            var args      = setVals.Select(kv => kv.Value).Append(keyVal).ToArray();
            return await db.dbUpdateAsync(sql, args);
        }

        // ─── validation ──────────────────────────────────────────────────────────

        private static void Validate(object root, SavePlan plan)
        {
            var errs = new List<string>();
            foreach (var r in plan.Root.Requireds)
            {
                var v = r.Prop.GetValue(root);
                if (v is null || (v is string s && string.IsNullOrWhiteSpace(s)))
                    errs.Add(r.Message);
            }
            if (errs.Count > 0) throw new SaveValidationException(errs);
        }

        // ─── plan building (cache ต่อ Type) ────────────────────────────────────────

        private static SavePlan GetPlan(Type type) => _plans.GetOrAdd(type, t =>
        {
            var tableAttr = t.GetCustomAttribute<SaveTableAttribute>()
                ?? throw new Exception($"sc.save: type {t.Name} ไม่มี [SaveTable] บน class");
            return new SavePlan(BuildNode(t, tableAttr));
        });

        private static NodeMeta BuildNode(Type type, SaveTableAttribute tableAttr)
        {
            var node = new NodeMeta { Type = type, Table = tableAttr.Table };

            foreach (var prop in type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                     .Where(p => p.CanRead))
            {
                if (prop.GetCustomAttribute<SaveIgnoreAttribute>() is not null) continue;

                var childAttr = prop.GetCustomAttribute<SaveTableAttribute>();
                if (childAttr is not null)
                {
                    node.Children.Add(BuildChild(prop, childAttr));
                    continue;
                }

                // column ธรรมดา
                var col = new ColMeta
                {
                    Prop   = prop,
                    Column = prop.GetCustomAttribute<SaveColumnAttribute>()?.Name ?? db.ToSnakeCase(prop.Name),
                    Bool01 = tableAttr.BoolAs01 && IsBool(prop.PropertyType),
                };
                node.Columns.Add(col);

                if (prop.GetCustomAttribute<SaveKeyAttribute>() is { } keyAttr)
                    node.Key = new KeyMeta { Prop = prop, Column = col.Column, Generator = keyAttr.Generator };

                if (prop.GetCustomAttribute<SaveDefaultAttribute>() is { } def)
                    node.Defaults.Add(new DefMeta { Column = col.Column, Value = def.Value, InsertOnly = def.InsertOnly });

                if (prop.GetCustomAttribute<SaveRequiredAttribute>() is { } req)
                    node.Requireds.Add(new ReqMeta { Prop = prop, Message = req.Message });
            }
            return node;
        }

        private static ChildMeta BuildChild(PropertyInfo prop, SaveTableAttribute attr)
        {
            var t = prop.PropertyType;

            if (IsListType(t, out var elem))
                return new ChildMeta
                {
                    Prop = prop, Table = attr.Table, Kind = ChildKind.List,
                    ParentKey = attr.ParentKey, SeqColumn = attr.SeqColumn,
                    Node = BuildNode(elem, attr),
                };

            if (t.IsClass && t != typeof(string))
                return new ChildMeta
                {
                    Prop = prop, Table = attr.Table, Kind = ChildKind.Object,
                    ParentKey = attr.ParentKey,
                    Node = BuildNode(t, attr),
                };

            // scalar (decimal? ฯลฯ) → 1 column ใน child table
            return new ChildMeta
            {
                Prop = prop, Table = attr.Table, Kind = ChildKind.Scalar,
                ParentKey = attr.ParentKey,
                ScalarColumn = prop.GetCustomAttribute<SaveColumnAttribute>()?.Name ?? db.ToSnakeCase(prop.Name),
            };
        }

        private static bool IsBool(Type t) => t == typeof(bool) || t == typeof(bool?);

        private static bool IsListType(Type t, out Type elem)
        {
            elem = typeof(object);
            if (t == typeof(string)) return false;
            var ie = t.GetInterfaces().Append(t)
                      .FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEnumerable<>));
            if (ie is null) return false;
            elem = ie.GetGenericArguments()[0];
            return true;
        }

        // ─── plan metadata ─────────────────────────────────────────────────────────

        private sealed class SavePlan(NodeMeta root) { public NodeMeta Root { get; } = root; }

        private sealed class NodeMeta
        {
            public required Type Type;
            public required string Table;
            public KeyMeta? Key;
            public List<ColMeta> Columns = [];
            public List<DefMeta> Defaults = [];
            public List<ReqMeta> Requireds = [];
            public List<ChildMeta> Children = [];
        }

        private sealed class ColMeta { public required PropertyInfo Prop; public required string Column; public bool Bool01; }
        private sealed class KeyMeta { public required PropertyInfo Prop; public required string Column; public string? Generator; }
        private sealed class DefMeta { public required string Column; public required object Value; public bool InsertOnly; }
        private sealed class ReqMeta { public required PropertyInfo Prop; public required string Message; }

        private enum ChildKind { Object, List, Scalar }

        private sealed class ChildMeta
        {
            public required PropertyInfo Prop;
            public required string Table;
            public required ChildKind Kind;
            public string? ParentKey;
            public string? SeqColumn;
            public string? ScalarColumn;
            public NodeMeta? Node;
        }
    }
}
