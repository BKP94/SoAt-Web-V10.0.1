using System;
using System.Collections.Generic;
using System.IO;
using DevExpress.XtraReports.UI;

// ─────────────────────────────────────────────────────────────────────────────
// sc.report — report helper (port 1:1 จาก legacy C:\SoAt_PEAN\sc\report.cs)
//
// วางใน SoAt.Core/sc ตาม convention (sc.* ทุกตัวอยู่รวมที่ Core, dev เปิดหาที่เดียว)
// เหมือน legacy ที่ report.cs อยู่ใน core library กลาง — ทุกระบบต้องเรียกรายงานได้
//   → Core อ้าง DevExpress reporting engine (DevExpress.Reporting.Core) เป็น dependency กลาง
//
// Deviation จาก legacy (บันทึกตามกฎ Legacy Fidelity):
//   - using System.Web / DevExpress.XtraReports.Web (WebForms) ถูกตัด — ไม่มีบน net10/Blazor
//     และ active code ไม่ได้ใช้ (อ้างเฉพาะใน comment เดิม)
//   - rcReport()/repArgumentObject() เปลี่ยนวิธีหา path ของ repQuery (ดู comment ในเมธอด)
// ─────────────────────────────────────────────────────────────────────────────

namespace sc
{
    public class report
    {
        public enum repAtts { catId, repId, args, rep_text, vs_path, sql, reportType, header3, coop_name, opdate }

        public static string repCode(string catId, string repId, string opdate)
        {
            return catId.Trim() + "-" + repId.Trim() + "-" + opdate.Trim();
        }
        //public static object repArguments
        //{
        //    get { return page.getSession(sc.att.session.repArguments); }
        //    set { sc.util.setSession(sc.att.session.repArguments, value); }
        //}

        //static object[] _rcObject;
        //static string _rcPath;
        public static object[]? rcReport(string vs_path)
        {
            //if(vs_path == _rcPath) {
            //    return _rcObject;
            //}

            // ── Deviation จาก legacy ──────────────────────────────────────────
            // legacy: ถอย AppDomain.BaseDirectory ขึ้น 1 ชั้น ไปหา shared C:\SoAt\repQuery\
            //         (ทุก IIS site แชร์ parent เดียว)
            //   string dirBase = AppDomain.CurrentDomain.BaseDirectory;            // C:\SoAt\scReport\
            //   dirBase = dirBase.Substring(0, dirBase.LastIndexOf('\\', ...));     // C:\SoAt
            //   string xmlName = dirBase + "\\repQuery\\" + vs_path.Replace(".", "\\") + ".xml";
            //
            // ใหม่: report host (เช่น scReport) เก็บ repQuery ในตัว project แล้ว copy เข้า output
            //       (csproj CopyToOutputDirectory) → runtime อ่านตรงจาก BaseDirectory\repQuery
            //       AppContext.BaseDirectory = bin ของ app ที่กำลังรัน (เป็น report host)
            // ──────────────────────────────────────────────────────────────────
            string dirBase = AppContext.BaseDirectory; // C:\...\scReport\bin\Debug\net10.0\

            //> ...\repQuery\rcTeller\memDetail\r_amnat_member_list_by_group_format.xml
            string xmlName = Path.Combine(dirBase, "repQuery", vs_path.Replace(".", "\\") + ".xml");

            return sc.xml.loadAbsolute(xmlName);

            // Load XML
            //_rcObject = sc.xml.loadAbsolute(xmlName);
            //_rcPath = vs_path;

            //return _rcObject;
        }
        public static string getProcedure(string vs_path)
        {
            object[]? xmlObject = rcReport(vs_path);

            // procedure
            if (xmlObject != null && xmlObject.Length == 2)
            {
                if (xmlObject[0] is Dictionary<string, object> xmlData && xmlData.ContainsKey("procedure"))
                {
                    return xmlData["procedure"].ToString()!;
                }
            }

            return string.Empty;
        }

        // ── executeProcedure — port 1:1 จาก popArgument.ascx.cs:ofExecuteProcedure (:802) ──
        //   driver-proc pattern: รายงานที่มี procedure="pkg.sp_xxx({key})" ต้อง EXECUTE proc
        //   (populate staging SC_REP_*) ก่อน แล้วค่อยรัน <sql> ที่ SELECT จาก staging นั้น.
        //   แทน token {id}/{id_1}=col1, {id_2}=col2 ด้วย dbValueT(value, type) — *ไม่หัก 543*
        //   (proc รับ พ.ศ. แล้วหักภายในเอง ต่างจาก SQL '!key!' ที่หัก 543 ใน composeReportSql).
        //   หมายเหตุ faithful: ต้องเรียกบน db ที่ commit ก่อน repView เปิด fill ผ่าน connection แยก
        public static void executeProcedure(string vs_path, IEnumerable<ReportArg> argsMeta,
            IDictionary<string, ReportArgInput> values, sc.db db)
        {
            var procedure = getProcedure(vs_path);
            if (string.IsNullOrWhiteSpace(procedure)) return;

            foreach (var arg in argsMeta)
            {
                if (!values.TryGetValue(arg.Key, out var inp) || inp == null) continue;
                var id = arg.Key;

                // colType → Type (mirror composeReportSql L266-268; legacy = getValue("col-"+type)+dbValueT)
                Type? t = arg.Type == "date" ? typeof(DateTime)
                        : (arg.Type == "integer" || arg.Type == "integer2"
                           || arg.Type == "decimal" || arg.Type == "decimal2") ? typeof(decimal)
                        : null;

                // col1 — แทนเมื่อมี token (faithful: legacy gate ที่ valr.ContainsKey("1") ไม่ใช่ null)
                if (procedure.Contains("{" + id + "}") || procedure.Contains("{" + id + "_1}"))
                {
                    var dbValue = sc.value.dbValueT(inp.Value1, t);
                    procedure = procedure.Replace("{" + id + "}", dbValue)
                                         .Replace("{" + id + "_1}", dbValue);
                }

                // col2 — แทนเมื่อ form มี col2 (legacy gate ที่ valr.ContainsKey("2") = HasCol2)
                if (inp.HasCol2 && procedure.Contains("{" + id + "_2}"))
                {
                    procedure = procedure.Replace("{" + id + "_2}", sc.value.dbValueT(inp.Value2, t));
                }
            }

            // Execute Procedure (เลียน legacy try/catch C336)
            try
            {
                db.pkProcedure(procedure);
            }
            catch (Exception ex)
            {
                throw new Exception("C336: ไม่สามารถประมวลผลเพื่อออกรายงาน " + Environment.NewLine
                    + "-----------------------------------------" + Environment.NewLine
                    + procedure + Environment.NewLine
                    + "-----------------------------------------" + Environment.NewLine
                    + ex.Message);
            }
        }

        public static string getColFocus(string vs_path)
        {
            object[]? xmlObject = rcReport(vs_path);

            // colfocus
            if (xmlObject != null && xmlObject.Length == 2)
            {
                if (xmlObject[0] is Dictionary<string, object> xmlData && xmlData.ContainsKey("colfocus"))
                {
                    return xmlData["colfocus"].ToString()!;
                }
            }

            return string.Empty;
        }
        public static string? getReportSQL(string vs_path)
        {
            object[]? xmlObject = rcReport(vs_path);

            // SQL Query
            string? query = null;
            if (xmlObject != null && xmlObject.Length == 2)
            {
                if (xmlObject[1] is Dictionary<string, object> xmlData && xmlData.ContainsKey("sql"))
                {
                    query = ((xmlData["sql"] as object[])![1] ?? string.Empty).ToString();
                }
            }

            return query;
        }
        // ── ReportArg — 1 argument ที่ parse จาก <arg> ใน repQuery XML ──────────────
        //   (class-expanded แล้ว + comboQuery แนบจาก <combo> ของรายงาน) มี accessor typed
        //   ให้ UI bind สะดวก แต่เก็บ Atts ดิบไว้ครบเพื่อความ faithful ต่อ legacy
        public class ReportArg
        {
            public string Key = string.Empty;                // ชื่อ arg (= column ถ้าไม่ระบุ)
            public Dictionary<string, object> Atts = new();  // attribute ดิบหลัง expand class

            string a(string key, string def = "")
            {
                if (Atts != null && Atts.TryGetValue(key, out var v) && v != null)
                {
                    var s = v.ToString();
                    return string.IsNullOrEmpty(s) ? def : s!;
                }
                return def;
            }
            public string Text       => a(attArg.text, Key);
            public string Clause     => a(attArg.clause, "and");
            public string Operator   => a(attArg.operator_, opertors.equal);
            public string Type       => a(attArg.type).ToLower();
            public string Table      => a(attArg.table);
            public string Column     => a(attArg.column, Key);
            public string Special    => a(attArg.special);
            public string Control    => a(attArg.control);
            public string Combo      => a(attArg.combo);
            public string ComboQuery => a(attArg.comboQuery);
            public string Default    => a(attArg.default_);
            public string NullText   => a(attArg.nulltext);
            public string HelpText   => a(attArg.helptext);
            public string Align      => a(attArg.align);
            public string Bleft      => a(attArg.bleft);
            public string Bright     => a(attArg.bright);
            public string SqlWhere   => a(attArg.sqlwhere, "1");
            public string SqlReplace => a(attArg.sqlreplace);
            public string NestWhere  => a(attArg.nestwhere);
            public string NestReplace=> a(attArg.nestreplace);
            public bool   NoHeader   => sc.value.toBoolean(a(attArg.noheader));
            public bool   MustValue  => sc.value.toBoolean(a(attArg.mustvalue));
            public bool   ReadOnly   => sc.value.toBoolean(a(attArg.readOnly));
        }

        // ── ReportArgInput — ค่าที่ผู้ใช้กรอกต่อ 1 arg (col1/col2 + ข้อความแสดงใน header3) ──
        //   เทียบ legacy args[key] = { "1":{value,text}, "2":{value,text} }
        public class ReportArgInput
        {
            public object? Value1;       // ค่า col1 (อาจเป็น List<object> สำหรับ in/multi-select)
            public string? Text1;        // ข้อความแสดงของ col1 (ใช้ใน header3)
            public object? Value2;       // ค่า col2 (between)
            public string? Text2;
            public bool HasCol2;         // legacy col2Active — มี col2 ในฟอร์มไหม
        }

        // ── ComposeResult — ผลของ composeReportSql ──
        public class ComposeResult
        {
            public string Sql = string.Empty;
            public string Header3 = string.Empty;
            public List<object> NestWhere = new();
            public Dictionary<string, object> NestReplace = new();
        }

        // ── getReportArgs — port 1:1 จาก popArgument.ascx.cs:getReportArgument (:37) ──
        //   อ่าน <arg> จาก repQuery XML, expand class= จาก repArguments.xml, แนบ comboQuery
        //   จาก <combo> ของรายงาน. คืน List (รักษาลำดับตาม XML) ให้ UI build ฟอร์ม
        public static List<ReportArg> getReportArgs(string vs_path)
        {
            var result = new List<ReportArg>();
            object[]? xmlObject = rcReport(vs_path);

            const string _class = "class";

            if (xmlObject != null && xmlObject.Length >= 2)
            {
                if (xmlObject[1] is Dictionary<string, object> xmlData && xmlData.ContainsKey("arg"))
                {
                    if ((xmlData["arg"] as object[])![1] is Dictionary<string, object> args)
                    {
                        // combo ที่กำหนดเฉพาะในรายงานตัวนี้
                        Dictionary<string, object>? combosInReport = null;
                        if (xmlData.ContainsKey("combo"))
                            combosInReport = (xmlData["combo"] as object[])![1] as Dictionary<string, object>;

                        foreach (var pairArg in args)
                        {
                            var attsItem = (pairArg.Value as object[])![0] as Dictionary<string, object>
                                           ?? new Dictionary<string, object>();

                            // expand class= → ดึง attribute จาก repArguments.xml มาเติม (ไม่ทับของเดิม)
                            if (attsItem.ContainsKey(_class))
                            {
                                string className = attsItem[_class].ToString()!;
                                var ra = repArgumentObject() as Dictionary<string, object>;
                                if (ra == null || !ra.ContainsKey(className))
                                    throw new Exception("C-arg:ไม่พบ Class=" + className);
                                var valsClass = (ra[className] as object[])![0] as Dictionary<string, object>;
                                if (valsClass != null)
                                    foreach (var pair in valsClass)
                                        if (!attsItem.ContainsKey(pair.Key.ToLower()))
                                            attsItem.Add(pair.Key.ToLower(), pair.Value);
                                attsItem.Remove(_class);
                            }

                            // แนบ comboQuery ของรายงานถ้า combo= ตรงชื่อ <combo> ในรายงาน
                            var comboName = sc.value.toString(attsItem, attArg.combo);
                            if (!string.IsNullOrWhiteSpace(comboName)
                                && combosInReport != null && combosInReport.ContainsKey(comboName)
                                && !attsItem.ContainsKey(attArg.comboQuery))
                            {
                                attsItem.Add(attArg.comboQuery, (combosInReport[comboName] as object[])![1]);
                            }

                            result.Add(new ReportArg { Key = pairArg.Key, Atts = attsItem });
                        }
                    }
                }
            }

            return result;
        }

        // ── composeReportSql — port 1:1 จาก popArgument.ascx.cs:ofCreateReport (:147) ──
        //   ประกอบ WHERE / sqlReplace / header3 / nestWhere / nestReplace จากค่าที่ผู้ใช้กรอก
        //   (ใช้ sc.value.sqlWhere ที่ preserve /*WHERE*/ → ต่อหลาย arg ได้)
        public static ComposeResult composeReportSql(
            string vs_path, IEnumerable<ReportArg> argsMeta,
            IDictionary<string, ReportArgInput> values)
        {
            string sql = getReportSQL(vs_path) ?? string.Empty;

            var res = new ComposeResult();
            string header3 = string.Empty;
            const string replacePre = "'!", replaceEnd = "!'";
            var nestReplace = new Dictionary<string, object>();
            var nestWhere = new List<object>();
            _nestSqlForView = string.Empty;

            foreach (var arg in argsMeta)
            {
                if (!values.TryGetValue(arg.Key, out var inp) || inp == null)
                    inp = new ReportArgInput();

                string _text     = arg.Text;
                string _clause   = arg.Clause;
                string _operator = arg.Operator;
                string _bleft    = arg.Bleft;
                string _bright   = arg.Bright;
                string _table    = arg.Table;
                string _column   = arg.Column;
                bool   _noheader = arg.NoHeader;
                string _colSpecila = arg.Special;
                string _type     = arg.Type;

                Type? t = _type == "date" ? typeof(DateTime)
                    : (_type == "integer" || _type == "integer2" || _type == "decimal" || _type == "decimal2") ? typeof(decimal)
                    : null;

                object? col1Value = inp.Value1, col2Value = inp.Value2;
                string? col1Text = inp.Text1, col2Text = inp.Text2;
                string? db1Value = null, db2Value = null;

                if (col1Value != null)
                {
                    if (_colSpecila == "year")        db1Value = (sc.value.toInteger(col1Value) - 543).ToString();
                    else if (_colSpecila == "tablename") db1Value = col1Value.ToString();
                    else                              db1Value = sc.value.dbValueT(col1Value, t);
                }
                bool col2Active = inp.HasCol2;
                if (col2Active && col2Value != null)
                {
                    if (_colSpecila == "year")        db2Value = (sc.value.toInteger(col2Value) - 543).ToString();
                    else if (_colSpecila == "tablename") db2Value = col2Value.ToString();
                    else                              db2Value = sc.value.dbValueT(col2Value, t);
                }

                bool col1Has = col1Value is List<object> c1l ? c1l.Count > 0
                    : !string.IsNullOrWhiteSpace((col1Value ?? string.Empty).ToString());
                bool col2Has = col2Value is List<object> c2l ? c2l.Count > 0
                    : !string.IsNullOrWhiteSpace((col2Value ?? string.Empty).ToString());

                // sqlWhere (ใช้ argWhere ที่ port operator switch ไว้แล้ว — ผลเท่ากับ legacy)
                if (sc.value.toBoolean(arg.SqlWhere) || sc.value.toBoolean(arg.NestWhere))
                {
                    string sqlWhere = argWhere(_operator, _table, _column, _text, _clause, _bleft, _bright, db1Value, db2Value);
                    if (!string.IsNullOrWhiteSpace(sqlWhere))
                    {
                        if (!sql.Contains(sc.db._WHERE))
                            throw new Exception("C-where:ไม่พบ /*WHERE*/ ใน query");
                        if (sc.value.toBoolean(arg.SqlWhere))
                            sql = sc.value.sqlWhere(sql, sqlWhere);
                        if (sc.value.toBoolean(arg.NestWhere))
                            nestWhere.Add(sqlWhere);
                    }
                }

                // sqlReplace — แทน '!key!' / '!key_1!' / '!key_2!' ด้วยค่า db (มี quote พร้อมจาก dbValueT)
                if (sc.value.toBoolean(arg.SqlReplace) || sc.value.toBoolean(arg.NestReplace))
                {
                    sql = sql.Replace(replacePre + arg.Key + replaceEnd, db1Value);
                    sql = sql.Replace(replacePre + arg.Key + "_1" + replaceEnd, db1Value);
                    if (sc.value.toBoolean(arg.NestReplace))
                    {
                        nestReplace[replacePre + arg.Key + replaceEnd] = db1Value!;
                        nestReplace[replacePre + arg.Key + "_1" + replaceEnd] = db1Value!;
                    }
                    if (col2Active)
                    {
                        sql = sql.Replace(replacePre + arg.Key + "_2" + replaceEnd, db2Value);
                        if (sc.value.toBoolean(arg.NestReplace))
                            nestReplace[replacePre + arg.Key + "_2" + replaceEnd] = db2Value!;
                    }
                }

                // header3
                if (!_noheader)
                {
                    string preHeader3 = " " + _text + ":";
                    if (_operator == opertors.between)
                    {
                        if (col1Has && col2Has) header3 += preHeader3 + col1Text + "-" + col2Text;
                        else if (col1Has) header3 += preHeader3 + "ตั้งแต่ " + col1Text;
                        else if (col2Has) header3 += preHeader3 + "ไม่เกิน " + col2Text;
                    }
                    else if (_operator == opertors.greaterThan)        { if (col1Has) header3 += preHeader3 + "มากกว่า " + col1Text; }
                    else if (_operator == opertors.greaterThanOrEqual) { if (col1Has) header3 += preHeader3 + "ตั้งแต่ " + col1Text; }
                    else if (_operator == opertors.lessThan)           { if (col1Has) header3 += preHeader3 + "น้อยกว่า " + col1Text; }
                    else if (_operator == opertors.lessThanOrEqual)    { if (col1Has) header3 += preHeader3 + "ไม่เกิน" + col1Text; }
                    else if (_operator == opertors.notEqual)           { if (col1Has) header3 += preHeader3 + "ไม่เท่ากับ " + col1Text; }
                    else                                               { if (col1Has) header3 += preHeader3 + col1Text; }
                }
            }

            res.Sql = sql;
            res.Header3 = header3;
            res.NestWhere = nestWhere;
            res.NestReplace = nestReplace;
            return res;
        }

        // ── tryResolveType / tryCreateReport / isMigrated ───────────────────────────
        //   DEVIATION จาก legacy (บันทึกตามกฎ Legacy Fidelity):
        //   legacy getType: Type.GetType("{vs_path},{firstSegment}") — assembly = segment แรก
        //     ของ vs_path (เช่น rcTeller) เพราะ legacy แต่ละ rc* เป็น assembly แยกตามชื่อนั้น
        //   ใหม่: report .cs ทั้งหมด migrate เข้า assembly เดียว `scReport` ใต้ namespace
        //     scReport.Reports.* (เช่น DB vs_path = "rcTeller.memDetail.X" → type จริง =
        //     "scReport.Reports.rcTeller.memDetail.X, scReport"). ลองหลาย candidate แล้ว
        //     คืน null อย่างนุ่มนวลถ้าไม่เจอ (รายงานยังไม่ถูก migrate — portal disable ปุ่มให้)
        const string REPORTS_ROOT_NS = "scReport.Reports";
        const string REPORTS_ASSEMBLY = "scReport";

        public static Type? tryResolveType(string vs_path)
        {
            if (string.IsNullOrWhiteSpace(vs_path)) return null;
            string firstSeg = vs_path.Contains('.') ? vs_path.Substring(0, vs_path.IndexOf('.')) : vs_path;
            foreach (var candidate in new[]
            {
                $"{REPORTS_ROOT_NS}.{vs_path}, {REPORTS_ASSEMBLY}", // stack ใหม่
                vs_path,                                            // assembly ปัจจุบัน (qualified เต็ม)
                $"{vs_path}, {firstSeg}",                           // รูปแบบ legacy เผื่อ assembly ชื่อตาม segment
            })
            {
                var t = Type.GetType(candidate, throwOnError: false);
                if (t != null) return t;
            }
            return null;
        }

        public static bool isMigrated(string vs_path) => tryResolveType(vs_path) != null;

        public static XtraReport? tryCreateReport(string vs_path)
        {
            var t = tryResolveType(vs_path);
            if (t == null) return null;
            try { return Activator.CreateInstance(t) as XtraReport; }
            catch { return null; }
        }

        // แปลง report instance → vs_path สำหรับ rcReport lookup (ตัด prefix namespace ของ stack ใหม่)
        //   legacy: namespace ของรายงาน == vs_path เป๊ะ → ToString()/FullName ใช้เป็น path ตรงได้
        //   ใหม่: ทุกรายงานอยู่ใต้ "scReport.Reports." → ตัด prefix นี้ออกได้ vs_path เดิม
        //   (ดู tryResolveType comment เรื่อง namespace prefix — deviation เดียวกัน)
        static string repVsPath(XtraReport r)
        {
            var full = r.GetType().FullName ?? r.GetType().Name;
            var prefix = REPORTS_ROOT_NS + ".";
            return full.StartsWith(prefix) ? full.Substring(prefix.Length) : full;
        }
        static string? getReportNest(string vs_path, string nestName)
        {
            //nestName = receipt_kfn-detail

            object[]? xmlObject = rcReport(vs_path);

            string? query = null;
            if (xmlObject != null && xmlObject.Length == 2)
            {
                if (xmlObject[1] is Dictionary<string, object> xmlData && xmlData.ContainsKey("sub"))
                {
                    if ((xmlData["sub"] as object[])![1] is Dictionary<string, object> xmlSub && xmlSub.ContainsKey(nestName))
                    {
                        if ((xmlSub[nestName] as object[])![1] is Dictionary<string, object> subSql && subSql.ContainsKey("sql"))
                        {
                            query = ((subSql["sql"] as object[])![1] ?? string.Empty).ToString();
                        }
                    }
                }
            }

            if (string.IsNullOrWhiteSpace(query))
            {
                xmlObject = rcReport("nestReport\\" + nestName);
                if (xmlObject != null && xmlObject.Length == 2)
                {
                    if (xmlObject[1] is Dictionary<string, object> xmlData && xmlData.ContainsKey("sql"))
                    {
                        query = ((xmlData["sql"] as object[])![1] ?? string.Empty).ToString();
                    }
                }
            }


            return query;
        }

        static object[]? _repArgumentObject;
        public static object? repArgumentObject(string tagName = "classes")
        {
            if (_repArgumentObject == null)
            {
                // ── Deviation จาก legacy (เหมือน rcReport) ────────────────────
                // legacy: shared C:\SoAt\repQuery\repArguments.xml (ถอย BaseDirectory ขึ้น 1 ชั้น)
                // ใหม่: repQuery\repArguments.xml ใน output ของ report host
                //   ⚠️ repArguments.xml ยังไม่ถูกย้ายมา (เป็น dependency ของ arg-class expansion
                //      ที่ใช้ตอน Step 5 — pilot นี้ <arg> ไม่มี class= จึงยังไม่ถูกเรียก)
                // ──────────────────────────────────────────────────────────────
                string dirBase = AppContext.BaseDirectory;

                //> ...\repQuery\repArguments.xml
                string xmlName = Path.Combine(dirBase, "repQuery", "repArguments.xml");
                //> Load XML
                _repArgumentObject = sc.xml.loadAbsolute(xmlName);
                if (_repArgumentObject == null)
                {
                    throw new Exception("C146:ไม่พบไฟล์ " + xmlName);
                }
            }

            object[] xmlObject = _repArgumentObject;
            if (xmlObject != null && xmlObject.Length == 2)
            {
                if (xmlObject[1] is Dictionary<string, object> ra && ra.ContainsKey(tagName))
                {
                    return (ra[tagName] as object[])![1] as Dictionary<string, object>;
                }
            }

            return null;
        }

        public struct opertors
        {
            public const string equal = "eq"; //เท่ากับ
            public const string lessThan = "lt";//น้อยกว่า
            public const string lessThanOrEqual = "le";//น้อยกว่าเท่ากับ
            public const string greaterThan = "gt";//มากกว่า
            public const string greaterThanOrEqual = "ge";//มากกว่าเท่ากับ
            public const string notEqual = "ne";//ไม่เท่ากับ
            public const string between = "bt";//ระหว่าง
            public const string inValues = "in"; // loan_type in ('Q','D')
            public const string like = "like"; // like '%text%'
        }
        public struct attArg
        {
            public const string text = "text"; // ข้อความที่แสดงข้างหน้า คอลัมล์ (ถ้าไม่ระบุจะให้ใช้ค่า key)
            public const string clause = "clause"; // and , or [and]
            public const string operator_ = "operator"; // eq, lt, le, gt, ge, ne, bt
            public const string table = "table"; // ชื่อ table ที่ใช้ในการ where (ถ้าระบุจะเอาไปเชื่อมกับ column โดยใช้ จุด คั่น เช่นถ้า column คือ loan_type จะได้ sc_lon_m_rule.loan_type )
            public const string column = "column"; // ชือคอลัมล์ที่ใช้ where (ถ้าไม่ระบุจะเอาค่า key)
            public const string special = "special";
            public const string type = "type"; // ประเภทข้อมูล
            public const string sqlwhere = "sqlwhere"; // 1-where [default:1]
            public const string sqlreplace = "sqlreplace"; // 1-replace [default:0]
            public const string combo = "combo"; // ชื่อคอมโบ (จะกำหนด control=ASPxComboBox อัตโนมัติ)
            public const string comboQuery = "comboQuery";//(Auto) sql ของ combo ที่กำหนดเฉพาะในรายงานตัวนี้
            public const string default_ = "default";
            public const string noheader = "noheader"; // 1-จะไม่แสดงใน header3
            public const string control = "control"; // ASPxComboBox,ASPxCheckBox,ASPxRadioButtonList,ASPxRadioButtonList2,ASPxMemo, [ASPxTextBox]
            public const string bleft = "bleft"; // วงเล็บซ้าย ((( ใส่กี่อันก็ได้
            public const string bright = "bright"; // วงเล็บขวา ))) ใส่กี่อันก็ได้
            public const string mustvalue = "mustvalue";// 1-ต้องกำหนดค่า
            public const string cascade = "cascade"; // combo ที่จะสั่ง callback
            public const string nestwhere = "nestwhere"; //1-ให้ where ใน subreport ด้วย
            public const string nestreplace = "nestreplace";// 1-ให้ replace ใน subreport ด้วย
            public const string align = "align"; // center ,right , left
            public const string nulltext = "nulltext"; // NullText
            public const string helptext = "helptext"; // HelpText
            public const string readOnly = "readonly";
            public const string comboReplace = "comboReplace";//ให้ replace ใน combo ด้วย
            public const string comboWhere = "comboWhere"; //ให้ where ใน comboQuery ด้วย
        }
        // ── argWhere — สร้าง WHERE fragment จาก 1 argument (port 1:1 จาก popArgument.ascx.cs:256-345) ──
        // คืน fragment พร้อม comment line (/*---[ text ]---*/) เอาไปรวมกับ sql ด้วย sc.value.sqlWhere()
        // คืน "" ถ้าไม่มีค่า filter (ผู้เรียกไม่ต้องแทนที่ /*WHERE*/)
        //   db1Value/db2Value = ค่าที่ format แล้ว (ผ่าน sc.value.dbValueT — มี quote ให้พร้อม)
        //   between: ใส่ครบ 2 → between; ใส่ตัวเดียว → >= หรือ <= ; like: strip quote แล้วครอบ '%...%'
        public static string argWhere(
            string operator_, string table, string column, string text,
            string clause = "and", string bleft = "", string bright = "",
            string? db1Value = null, string? db2Value = null)
        {
            db1Value ??= string.Empty;
            db2Value ??= string.Empty;
            bool col1Has = !string.IsNullOrWhiteSpace(db1Value);
            bool col2Has = !string.IsNullOrWhiteSpace(db2Value);

            string sqlPre = " " + clause + " " + bleft; // and, or  + ((((
            if (!string.IsNullOrWhiteSpace(table))
            {
                sqlPre += table + ".";
            }
            sqlPre += column;

            string sqlWhere = string.Empty;
            if (operator_ == opertors.between)
            {
                if (col1Has && col2Has) sqlWhere = " between " + db1Value + " and " + db2Value;
                else if (col1Has) sqlWhere = " >= " + db1Value;
                else if (col2Has) sqlWhere = " <= " + db2Value;
            }
            else if (operator_ == opertors.greaterThan) { if (col1Has) sqlWhere = " > " + db1Value; }
            else if (operator_ == opertors.greaterThanOrEqual) { if (col1Has) sqlWhere = " >= " + db1Value; }
            else if (operator_ == opertors.lessThan) { if (col1Has) sqlWhere = " < " + db1Value; }
            else if (operator_ == opertors.lessThanOrEqual) { if (col1Has) sqlWhere = " <= " + db1Value; }
            else if (operator_ == opertors.notEqual) { if (col1Has) sqlWhere = " != " + db1Value; }
            else if (operator_ == opertors.inValues) { if (col1Has) sqlWhere = " in " + db1Value; }
            else if (operator_ == opertors.like)
            {
                if (col1Has) sqlWhere = " like '%" + db1Value.Substring(1, db1Value.Length - 2) + "%'";
            }
            else { if (col1Has) sqlWhere = " = " + db1Value; } // เท่ากับ (default)

            if (string.IsNullOrWhiteSpace(sqlWhere))
            {
                return string.Empty;
            }

            string sqlEnd = bright; // ))))
            string sqlLine = "/*---------------------[  " + text + "  ]------------------------*/";
            return sqlLine + Environment.NewLine + sqlPre + sqlWhere + sqlEnd;
        }

        public static object? _nestWhere { get; set; }
        public static object? _nestReplace { get; set; }

        public static object? _nestSqlError { get; set; }
        public static object? _nestSqlForView { get; set; }

        static XtraReport? getXtraReport(string formName)
        {
            var type = Type.GetType(String.Format("{0},{1}", formName, formName.Substring(0, formName.IndexOf('.'))));
            try
            {
                return Activator.CreateInstance(type!) as XtraReport;
            }
            catch
            {
                return null;
            }
        }
        static Type getType(string vs_path)
        {
            //return Type.GetType(String.Format("{0},{1}", vs_path, vs_path.left('.')));

            var t = Type.GetType(String.Format("{0},{1}", vs_path, vs_path.Substring(0, vs_path.IndexOf('.'))));
            if (t == null)
            {

                // if (sc.app.appName == "scReport")
                // {
                throw new Exception("C415:Not found Sub-Report : " + vs_path);
                //}
                //else
                //{
                //    sc.log.addLineNest(sc.log.lineMain + "C415:Not found Sub-Report : " + vs_path);
                //}
            }

            return t;
        }

        public static void setResource(object sender, string vs_path)
        {
            Type t = getType(vs_path);

            if (t != null)
            {
                setResource(sender, t);
            }

        }
        public static void setResource(object sender, Type t)
        {

            ((XRSubreport)sender).ReportSource = Activator.CreateInstance(t) as XtraReport;

        }

        // ── repConnection wiring (Deviation จาก legacy — บันทึกตามกฎ Legacy Fidelity) ──
        // legacy: SqlDataSource อ้าง ConnectionName="repConnection" → resolve จาก
        //         web.config <connectionStrings> + DevExpress provider (Oracle) ที่ register ใน IIS
        // ใหม่ (net10/Blazor): ไม่มี web.config provider registration → set ConnectionParameters
        //         ตอน runtime จาก appsettings "ConnectionStrings:repConnection" (PostgreSQL)
        //         ก่อน Fill() ทุกครั้ง (main + nest ผ่าน dataBind จุดเดียว). DevExpress ใช้
        //         ConnectionParameters ที่ set ตรง → ข้าม ConnectionName lookup ทั้งหมด
        // ────────────────────────────────────────────────────────────────────────────
        public const string REP_CONNECTION = "repConnection";
        static bool _npgsqlFactoryRegistered;

        static void ensureRepConnection(DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource)
        {
            // ตั้งครั้งเดียวพอ — ถ้ามี ConnectionParameters เป็น PostgreSqlConnectionParameters แล้วข้าม
            if (sqlDataSource.ConnectionParameters is DevExpress.DataAccess.ConnectionParameters.PostgreSqlConnectionParameters)
                return;

            // ให้ DevExpress PostgreSQL provider หา Npgsql ADO.NET factory เจอ (DevExpress ไม่ผูก Npgsql เอง)
            if (!_npgsqlFactoryRegistered)
            {
                try { System.Data.Common.DbProviderFactories.RegisterFactory("Npgsql", Npgsql.NpgsqlFactory.Instance); }
                catch { /* ลงทะเบียนซ้ำ = ข้าม */ }
                _npgsqlFactoryRegistered = true;
            }

            var connStr = sc.app.getConnectionString(REP_CONNECTION);
            if (string.IsNullOrWhiteSpace(connStr))
                throw new Exception("C-repconn:ไม่พบ ConnectionStrings:" + REP_CONNECTION + " ใน appsettings");

            var csb = new Npgsql.NpgsqlConnectionStringBuilder(connStr);
            sqlDataSource.ConnectionParameters =
                new DevExpress.DataAccess.ConnectionParameters.PostgreSqlConnectionParameters(
                    csb.Host, csb.Port, csb.Database, csb.Username, csb.Password);
        }

        // ลบ SQL comment ออกจาก query ก่อนยัดลง DevExpress CustomSqlQuery
        //   เหตุ: DevExpress.DataAccess.Sql parser validate custom SQL ว่าเป็น SELECT ล้วน
        //         แต่ semantic parser ของมันสะดุด comment `--` (และ block `/* */` ที่หลงเหลือ)
        //         → โยน CustomSqlQueryValidationException "A custom SQL query should contain
        //         only SELECT statements." แม้ SQL รันบน PostgreSQL ได้ปกติ
        //   comment เป็น inert (ไม่กระทบความหมาย) → ตัดทิ้งได้โดยคง legacy fidelity ของ XML
        //   ตัดแบบ respect single-quote literal (กันค่า/ข้อความไทยใน '...' โดนแตะ); ตอน bind
        //   placeholder /*WHERE*/ ถูก sqlWhere() replace ไปก่อนแล้ว จึงไม่มี block comment เหลือที่ต้องกัน
        static string stripSqlComments(string? sql)
        {
            if (string.IsNullOrEmpty(sql)) return sql ?? "";
            var sb = new System.Text.StringBuilder(sql.Length);
            bool inStr = false;
            for (int i = 0; i < sql.Length; i++)
            {
                char c = sql[i];
                char n = i + 1 < sql.Length ? sql[i + 1] : '\0';
                if (inStr)
                {
                    sb.Append(c);
                    if (c == '\'')
                    {
                        if (n == '\'') { sb.Append(n); i++; } // escaped '' ภายใน literal
                        else inStr = false;
                    }
                    continue;
                }
                if (c == '\'') { inStr = true; sb.Append(c); continue; }
                if (c == '-' && n == '-')               // line comment -- ... ถึงท้ายบรรทัด
                {
                    while (i < sql.Length && sql[i] != '\n') i++;
                    if (i < sql.Length) sb.Append('\n'); // คง newline ไว้ (กันบรรทัดติดกัน)
                    continue;
                }
                if (c == '/' && n == '*')               // block comment /* ... */
                {
                    i += 2;
                    while (i + 1 < sql.Length && !(sql[i] == '*' && sql[i + 1] == '/')) i++;
                    i++; // ข้าม '/' ตัวปิด (loop จะ i++ อีกครั้งข้าม '*'? ปรับด้านล่าง)
                    continue;
                }
                sb.Append(c);
            }
            return sb.ToString();
        }

        // bind SQL ลง SqlDataSource ของ main report (เทียบ legacy popArgument.ascx.cs:481) +
        // ensure repConnection (net10 wiring). ไม่ Fill เอง — ปล่อยให้ DxReportViewer.CreateDocument() fill
        public static void bindReportSql(XtraReport xr, string sql)
        {
            if (xr?.DataSource is DevExpress.DataAccess.Sql.SqlDataSource sds
                && sds.Queries.Count > 0
                && sds.Queries[0] is DevExpress.DataAccess.Sql.CustomSqlQuery q)
            {
                ensureRepConnection(sds);
                q.Sql = stripSqlComments(sql);
            }
        }

        static void dataBind(XtraReport xr, string sql)
        {
            if (xr != null)
            {
                var skipTxtErr = "Error when trying to populate the datasource. The following exception was thrown:";
                try
                {
                    // Cast the DataSource to SqlDataSource and access the first query
                    var sqlDataSource = xr.DataSource as DevExpress.DataAccess.Sql.SqlDataSource;
                    var customSqlQuery = sqlDataSource?.Queries[0] as DevExpress.DataAccess.Sql.CustomSqlQuery;

                    if (customSqlQuery != null)
                    {
                        ensureRepConnection(sqlDataSource!);
                        customSqlQuery.Sql = stripSqlComments(sql);
                        sqlDataSource!.Fill();
                    }
                }
                catch (Exception ex)
                {
                    if (sc.app.appName == "scReport")
                    {
                        sc.report._nestSqlError += sc.log.lineMain + "C367 Sub-Report Query Failed: " + xr.Report.ToString() + Environment.NewLine;
                        sc.log.addLineNest(sc.log.lineMain + "C367 Sub-Report Query Failed: " + xr.Report.ToString() + Environment.NewLine);

                        Exception? currentException = ex;
                        while (currentException != null)
                        {
                            if (currentException.Message.Contains(skipTxtErr))
                            {
                                //skip
                            }
                            else
                            {
                                //error detail ให้แสดงในตอน createDocument แทน (popArgument.cs)
                                //sc.report._nestSqlError += Environment.NewLine;
                                //sc.report._nestSqlError += sc.log.lineMain + "(nest) Error: " + currentException.Message;
                            }
                            currentException = currentException.InnerException;
                        }
                    }
                    else
                    {
                        sc.log.addLineNest(sc.log.lineMain + "C367 Sub-Report Query Failed: " + xr.Report.ToString());
                        //throw new Exception(sc.log.lineMain + "C367 Sub-Report Query Failed: " + xr.Report.ToString() + Environment.NewLine);
                    }

                }
            }
        }
        public static void dataBind(XtraReport rep, object sender, string? sqlWhere = null, params object[] args)
        {
            var nestReport = (XRSubreport)sender;
            // ── DEVIATION (Legacy Fidelity): legacy ใช้ ReportSource.ToString() แล้วตัด substring
            //   หลังจุดสุดท้ายเพื่อเอาชื่อคลาส nest โดยอาศัยว่า ToString() คืน full type name และ
            //   namespace == vs_path. DX25 ToString() ของ XtraReport ไม่คืน full type name แล้ว
            //   → ใช้ GetType().Name ตรง ได้ชื่อคลาส nest ที่ถูกต้องเสมอ (= key ใน <sub> ของ XML)
            var nestName = nestReport.ReportSource.GetType().Name;

            //sql = new sc.db().sqlArgs(sql, vals);
            //var page = (sc.page)HttpContext.Current.Session[sc.att.session.repPage];


            // หา Query ของ nest จาก reqQuery
            // ระบบ scReport จาก XML
            // ระบบอื่นจาก ตัวรายงาน
            var sqlNest = sc.app.appName == "scReport" ? getReportNest(repVsPath(rep), nestName)
                : ((nestReport.ReportSource.DataSource as DevExpress.DataAccess.Sql.SqlDataSource)!.Queries[0] as DevExpress.DataAccess.Sql.CustomSqlQuery)!.Sql;

            //var sqlNest = getReportNest(rep.ToString(), nestName);
            //if (string.IsNullOrWhiteSpace(sqlNest))
            //{
            //    sqlNest = ((nestReport.ReportSource.DataSource as DevExpress.DataAccess.Sql.SqlDataSource).Queries[0] as DevExpress.DataAccess.Sql.CustomSqlQuery).Sql;
            //}

            if (string.IsNullOrWhiteSpace(sqlNest))
            {
                throw new Exception("C285:Not found Sub-Report Query : " + nestName);
            }

            if (!sqlNest.Contains(sc.db._WHERE))
            {
                if (sc.app.appName != "scReport")
                {
                    var errTxt = "C299 Not found /*WHERE*/ ใน Sub-Report Query : " + nestName;
                    throw new Exception(errTxt);
                }

            }

            // เขียนเองที่ befor print
            sqlNest = sc.value.sqlWhere(sqlNest, sqlWhere);

            // (USER INPUT)เอาค่าที่ต้องการ where จาก argument ไปให้ nest
            if (_nestWhere is List<object> nw)
            {
                foreach (object subWhere in nw)
                {
                    sqlNest = sc.value.sqlWhere(sqlNest, subWhere.ToString());
                }
            }
            //string sqlWhereArg = value.toString(util.getSession(_subSQL));
            //sqlNest = page.db.sqlWhere(sqlNest, sqlWhereArg, args);

            // แทนที่ค่า args ที่ส่งมาจาก BeforPrint
            sqlNest = sc.value.sqlArgs(sqlNest, args);

            // Replace
            if (_nestReplace is Dictionary<string, object> nr)
            {
                foreach (var pair in nr)
                {
                    sqlNest = sqlNest.Replace(pair.Key, pair.Value.ToString());
                }
            }

            // log
            var nestLog = "(" + nestName + ")[" + nestReport.Name + "]";
            //var replog = sc.att.session.repNestLogs + "-" + rep.ToString();
            //if (sc.util.getSession(sc.att.session.repNestLogs + "-" + rep.ToString()) is List<string> nestLogs)
            //{
            //    if (nestLogs.Contains(nestLog) == false)
            //    {
            //        nestLogs.Add(nestLog);
            //        sc.log.addLineNest(sc.log.lineMain + nestLog + Environment.NewLine + sqlNest);
            //    }
            //}
            //else
            //{
            //    sc.util.setSession(sc.att.session.repNestLogs + "-" + rep.ToString(), new List<string>() { nestLog });
            //    sc.log.addLineNest(sc.log.lineMain + nestLog + Environment.NewLine + sqlNest);
            //}

            sc.log.addLineNest(sc.log.lineMain + nestLog + Environment.NewLine + sqlNest);
            _nestSqlForView += Environment.NewLine + nestLog + Environment.NewLine + sqlNest;

            // databBind
            try
            {
                dataBind(nestReport.ReportSource, sqlNest);
            }
            catch (Exception)
            {
                //sc.log.addLineNest(sc.log.lineMain + nestLog
                //    + Environment.NewLine + "Error Sub-Report Query : "
                //    + Environment.NewLine + sqlNest
                //    + Environment.NewLine + ex.Message);
            }

        }
        public static void ofBeforePrint(XtraReport rep, object sender, params object[] args)
        {
            dataBind(rep, sender, null, args);
        }
        public static void setNestReport(XtraReport rep, object sender, Type t, string? sqlWhere = null, params object[] args)
        {
            if (t != null)
            {
                setResource(sender, t);
                dataBind(rep, sender, sqlWhere, args);
            }

        }
        public static void setNestReport(XtraReport rep, object sender, string vs_path, string? sqlWhere = null, params object[] args)
        {
            setResource(sender, vs_path.Replace('-', '_'));

            var subReport = ((XRSubreport)sender);
            if (subReport.ReportSource != null)
            {
                dataBind(rep, sender, sqlWhere, args);
            }


        }

        //databind nest overlap
        public static void ofBeforePrint(string rep, object sender, string? sqlWhere = null, params object[] args)
        {
            string formName = rep;

            var xr = getXtraReport(formName);
            xr!.Name = formName;
            if (xr == null)
            {
                throw new Exception("C519:Not found Main-Report : " + rep);
            }


            dataBind(xr, sender, sqlWhere, args);
        }


    }


}
