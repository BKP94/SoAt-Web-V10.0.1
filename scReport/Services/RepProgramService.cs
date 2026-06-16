using System.Xml;
using Microsoft.AspNetCore.Hosting;
using A = sc.report.attArg;   // type-alias: เข้าถึง const ของ struct attArg แบบสั้น

namespace scReport.Services;

// ── RepProgramService ───────────────────────────────────────────────────────
//   โหลด/บันทึกไฟล์ definition รายงาน (repQuery\...\*.xml) สำหรับหน้าจอ repProgram
//   เลียน legacy scReport/repProgram/panHead.ascx.cs (ofLoad/ofSave) + pan.cs (ofGetAttribute)
//
//   ⚠ ต่างจาก sc.report (read-only, อ่านจาก bin\repQuery): service นี้อ่าน+เขียน
//      ที่ "source" ของ project (ContentRoot\repQuery หรือ override "RepQuery:SourcePath")
//      เพื่อให้ผลแก้ไขเป็น source-of-truth รอด rebuild
//      (caveat: report viewer อ่าน bin → ต้อง rebuild ถึงจะเห็นผลตอนเปิดรายงาน)
//
//   Scope: Path/Procedure/Focus + Arguments(raw id/attr) + SQL + Sub + Combo + MIS Query
//          (column นิยาม + ค่าเริ่มต้น) — ครบตาม legacy panHead (popAttribute/popProcedure
//          เป็น builder popup เสริมในฝั่ง UI)
public class RepProgramService
{
    private readonly IWebHostEnvironment _env;

    public RepProgramService(IWebHostEnvironment env) => _env = env;

    // source repQuery folder — override ได้ด้วย config "RepQuery:SourcePath"
    private string SourceRoot()
    {
        var over = sc.app.getAppSettings("RepQuery:SourcePath");
        return string.IsNullOrWhiteSpace(over)
            ? Path.Combine(_env.ContentRootPath, "repQuery")
            : over;
    }

    // เลียน getFilePath(): vs_path ใช้ "." เป็นตัวคั่น path → repQuery\<path>.xml
    private string GetFilePath(string vsPath)
        => Path.Combine(SourceRoot(), vsPath.Replace(".", "\\") + ".xml");

    // runtime/bin repQuery folder — ที่ report viewer (sc.report) อ่านจริง (AppContext.BaseDirectory\repQuery)
    //   มิเรอร์ไฟล์ที่บันทึกมาที่นี่ด้วย → แก้ XML แล้วเปิดรายงานเห็นผลทันที ไม่ต้อง rebuild
    private static string GetRuntimeFilePath(string vsPath)
        => Path.Combine(AppContext.BaseDirectory, "repQuery", vsPath.Replace(".", "\\") + ".xml");

    // ── Load (เลียน ofLoad) ─────────────────────────────────────────────────
    public RepProgramModel Load(string vsPath)
    {
        var m = new RepProgramModel { VsPath = vsPath };
        var xmlName = GetFilePath(vsPath);
        if (!File.Exists(xmlName)) { m.FileExists = false; return m; }

        m.FileExists = true;
        var doc = new XmlDocument();
        doc.Load(xmlName);

        // root @procedure / @colfocus
        if (doc.SelectSingleNode("/root") is XmlElement root)
        {
            m.Procedure = root.GetAttribute("procedure");
            m.ColFocus  = root.GetAttribute("colfocus");
        }

        // SQL
        if (doc.SelectSingleNode("/root/sql") is { } sqlNode)
            m.Sql = sqlNode.InnerText;

        // ARG: id = element name, attr = สตริง ` name="value"` ต่อกัน (raw — แก้ตรงตาราง)
        if (doc.SelectSingleNode("/root/arg") is { } argNode)
            foreach (XmlNode pair in argNode.ChildNodes)
                if (pair is XmlElement arg)
                {
                    var attrs = string.Empty;
                    foreach (XmlAttribute a in arg.Attributes)
                        attrs += " " + a.Name + "=\"" + a.Value + "\"";
                    m.Args.Add(new RepArgRow { Id = arg.Name, Attr = attrs });
                }

        // Combo: name + InnerText (query)
        if (doc.SelectSingleNode("/root/combo") is { } comboNode)
            foreach (XmlNode pair in comboNode.ChildNodes)
                if (pair is XmlElement combo)
                    m.Combos.Add(new RepComboRow { Name = combo.Name, Query = combo.InnerText });

        // Sub: name + <sql> InnerText
        if (doc.SelectSingleNode("/root/sub") is { } subNode)
            foreach (XmlNode pair in subNode.ChildNodes)
                if (pair is XmlElement sub)
                    m.Subs.Add(new RepSubRow
                    {
                        Name  = sub.Name,
                        Query = sub.SelectSingleNode("sql")?.InnerText ?? string.Empty
                    });

        // MIS column นิยาม (เลียน ofLoad section "mis"): element name = column_name,
        //   children column_text / column_type / column_width
        if (doc.SelectSingleNode("/root/mis") is { } misNode)
            foreach (XmlNode pair in misNode.ChildNodes)
                if (pair is XmlElement mis)
                    m.MisColumns.Add(new RepMisColumn
                    {
                        Name  = mis.Name,
                        Text  = mis.SelectSingleNode("column_text")?.InnerText ?? string.Empty,
                        Type  = mis.SelectSingleNode("column_type")?.InnerText ?? string.Empty,
                        Width = mis.SelectSingleNode("column_width")?.InnerText ?? string.Empty
                    });

        // MIS ค่าเริ่มต้น (เลียน mis_default_value): แต่ละ <row> มี child ชื่อ = column_name,
        //   InnerText = ค่า; คอลัมน์ type=date เก็บเป็น ค.ศ. (dd/MM/yyyy) → แปลงเป็น พ.ศ. ตอนแสดง
        var dateCols = m.MisColumns
            .Where(c => c.Type == "date")
            .Select(c => c.Name)
            .ToHashSet(StringComparer.OrdinalIgnoreCase);
        if (doc.SelectSingleNode("/root/mis_default_value") is { } misValNode)
            foreach (XmlNode pair in misValNode.ChildNodes)
                if (pair is XmlElement rowEl)
                {
                    var row = new RepMisRow();
                    foreach (XmlNode c in rowEl.ChildNodes)
                        if (c is XmlElement col)
                        {
                            var v = col.InnerText;
                            if (dateCols.Contains(col.Name)) v = DateCeToBe(v);
                            row.Values[col.Name] = v;
                        }
                    m.MisRows.Add(row);
                }

        return m;
    }

    // ── Save (เลียน ofSave) ─────────────────────────────────────────────────
    //   host = NavigationManager host ("localhost" ตอน dev) — ใช้ guard C30
    public void Save(RepProgramModel m, string host)
    {
        // C30 guard (เลียน legacy serverEditQuery): localhost หรือ server ที่เปิด serverEditQuery=1
        var isLocal = string.Equals(host, "localhost", StringComparison.OrdinalIgnoreCase)
                      || host == "127.0.0.1" || host == "::1";
        var serverEdit = sc.app.getAppSettings("serverEditQuery") == "1";
        if (!isLocal && !serverEdit)
            throw new Exception("C30:Server ไม่ได้เปิดให้สามารถแก้ไข repQuery ได้");

        var xmlName = GetFilePath(m.VsPath);

        var doc = new XmlDocument();
        if (File.Exists(xmlName))
            doc.Load(xmlName);
        else
            doc.AppendChild(doc.CreateElement("root"));

        var root = doc.SelectSingleNode("root") as XmlElement
                   ?? throw new Exception("C30:โครงสร้าง XML ไม่ถูกต้อง (ไม่พบ root)");

        // procedure / colfocus (ลบก่อน set ใหม่ — ว่าง = ไม่ใส่)
        root.RemoveAttribute("procedure");
        if (!string.IsNullOrWhiteSpace(m.Procedure))
            root.SetAttribute("procedure", m.Procedure.Trim());
        root.RemoveAttribute("colfocus");
        if (!string.IsNullOrWhiteSpace(m.ColFocus))
            root.SetAttribute("colfocus", m.ColFocus.Trim());

        // ARG (validate C136/C194, parse attr ผ่าน ofGetAttribute)
        var argEl = doc.CreateElement("arg");
        foreach (var a in m.Args)
        {
            var id = (a.Id ?? string.Empty).Trim();
            if (string.IsNullOrWhiteSpace(id))
                throw new Exception("C136:กรุณาระบุ Argument ID");
            if (char.IsDigit(id[0]))
                throw new Exception("C194:Argument ID ต้องไม่ขึ้นต้นด้วย ตัวเลข(0-9)");

            var atts = ofGetAttribute(id, (a.Attr ?? string.Empty).Trim());
            var argEle = doc.CreateElement(id);
            foreach (var p in atts)
                if (!string.IsNullOrWhiteSpace(p.Value))
                    argEle.SetAttribute(p.Key.Trim(), p.Value);
            argEl.AppendChild(argEle);
        }

        // Combo (validate C176)
        var comboEl = doc.CreateElement("combo");
        foreach (var c in m.Combos)
        {
            var name = (c.Name ?? string.Empty).Trim();
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("C176:Invalid Combo-Name");
            var el = doc.CreateElement(name);
            el.InnerText = c.Query ?? string.Empty;
            comboEl.AppendChild(el);
        }

        // SQL
        var sqlEl = doc.CreateElement("sql");
        sqlEl.InnerText = m.Sql ?? string.Empty;

        // SUB (validate C166)
        var subEl = doc.CreateElement("sub");
        foreach (var s in m.Subs)
        {
            var name = (s.Name ?? string.Empty).Trim();
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("C166:Invalid SUB-NAME");
            var el = doc.CreateElement(name);
            var sq = doc.CreateElement("sql");
            sq.InnerText = s.Query ?? string.Empty;
            el.AppendChild(sq);
            subEl.AppendChild(el);
        }

        // MIS column นิยาม (เลียน ofSave section "mis") — element name = column_name (UPPER)
        var misEl = doc.CreateElement("mis");
        var misColNames = new List<string>();          // ชื่อคอลัมน์ (UPPER) ตามลำดับ
        var misDateCols = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        foreach (var c in m.MisColumns)
        {
            var name = (c.Name ?? string.Empty).Trim().ToUpper();
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("C176:Invalid Column-name");
            if (c.Type == "date") misDateCols.Add(name);

            var colEl = doc.CreateElement(name);
            AppendText(doc, colEl, "column_text", c.Text ?? string.Empty);
            AppendText(doc, colEl, "column_type", c.Type ?? string.Empty);
            AppendText(doc, colEl, "column_width", sc.value.toInteger(c.Width).ToString());
            misEl.AppendChild(colEl);
            misColNames.Add(name);
        }

        // MIS ค่าเริ่มต้น (เลียน mis_default_value) — แต่ละแถว = <row> มี child เฉพาะคอลัมน์ที่นิยามไว้
        //   คอลัมน์ date: เก็บกลับเป็น ค.ศ. (พ.ศ. → ค.ศ.)
        var misValEl = doc.CreateElement("mis_default_value");
        foreach (var rowModel in m.MisRows)
        {
            var rowEl = doc.CreateElement("row");
            foreach (var name in misColNames)
            {
                var v = rowModel.Get(name);
                if (misDateCols.Contains(name)) v = DateBeToCe(v);
                AppendText(doc, rowEl, name, v);
            }
            misValEl.AppendChild(rowEl);
        }

        // ล้าง child เดิม แล้ว append ใหม่ตามลำดับ arg → combo → sql → sub → (mis, mis_default_value)
        RemoveChild(root, "arg");
        RemoveChild(root, "combo");
        RemoveChild(root, "sql");
        RemoveChild(root, "sub");
        RemoveChild(root, "mis");
        RemoveChild(root, "mis_default_value");

        root.AppendChild(argEl);
        root.AppendChild(comboEl);
        root.AppendChild(sqlEl);
        root.AppendChild(subEl);

        // เลียน legacy: append mis เฉพาะเมื่อมีนิยามคอลัมน์ (ถ้ามี ค่าเริ่มต้นก็ append ตาม)
        if (m.MisColumns.Count > 0)
        {
            root.AppendChild(misEl);
            root.AppendChild(misValEl);
        }

        // บันทึกที่ source (source-of-truth รอด rebuild)
        Directory.CreateDirectory(Path.GetDirectoryName(xmlName)!);
        doc.Save(xmlName);

        // มิเรอร์ไป runtime/bin ที่ viewer อ่านจริง → ใช้งาน XML ได้ทันทีไม่ต้อง rebuild
        // (ข้ามถ้า source กับ runtime เป็น path เดียวกัน เพื่อกันเขียนซ้ำ)
        var runtimeName = GetRuntimeFilePath(m.VsPath);
        if (!string.Equals(Path.GetFullPath(runtimeName), Path.GetFullPath(xmlName),
                           StringComparison.OrdinalIgnoreCase))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(runtimeName)!);
            doc.Save(runtimeName);
        }
    }

    private static void AppendText(XmlDocument doc, XmlElement parent, string name, string text)
    {
        var el = doc.CreateElement(name);
        el.InnerText = text;
        parent.AppendChild(el);
    }

    // พ.ศ. (dd/MM/yyyy) → ค.ศ. : ปรับเฉพาะปี -543 (คงรูปแบบเดิมถ้าแปลงไม่ได้)
    private static string DateBeToCe(string th) => ShiftYear(th, -543);
    // ค.ศ. (dd/MM/yyyy) → พ.ศ. : ปรับเฉพาะปี +543
    private static string DateCeToBe(string ce) => ShiftYear(ce, +543);
    private static string ShiftYear(string s, int delta)
    {
        if (string.IsNullOrWhiteSpace(s)) return string.Empty;
        var p = s.Split('/');
        if (p.Length == 3 && int.TryParse(p[2], out var y))
            return $"{p[0]}/{p[1]}/{y + delta}";
        return s;
    }

    private static void RemoveChild(XmlElement root, string name)
    {
        if (root.SelectSingleNode(name) is { } n) root.RemoveChild(n);
    }

    // ── ofGetAttribute (port verbatim จาก pan.cs) ────────────────────────────
    //   แตก ` name="value"` เป็น dictionary; โยน C113/C120 ถ้ารูปแบบผิด
    private static Dictionary<string, string> ofGetAttribute(string id, string attr)
    {
        var atts = new Dictionary<string, string>();
        while (true)
        {
            int i = attr.IndexOf('=');
            if (i == -1) break;
            var attName = attr.Substring(0, i).Trim();          // ชื่อ attribute (ก่อน =)
            attr = attr.Substring(i + 1).Trim();                // ตัด name= ออก
            int j = attr.IndexOf('"', 1);                       // " ตัวที่ 2 (ปิดค่า)
            if (j == -1)
                throw new Exception("C113: ID:" + id + " > ใสค่า Attributes ไม่ถูกต้อง");
            var attValue = attr.Substring(1, j - 1);            // ค่าระหว่าง ""
            atts[attName] = attValue;
            attr = attr.Substring(j + 1).Trim();                // ส่วนที่เหลือ
        }
        if (!string.IsNullOrWhiteSpace(attr))
            throw new Exception("C120: ID:" + id + " > ใสค่า Attributes ไม่ถูกต้อง");
        return atts;
    }

    // ── builder popup helpers (popAttribute / popProcedure) ──────────────────

    // public wrapper สำหรับแตก attr ดิบ (ใช้ใน popProcedure เพื่อหา operator ของแต่ละ arg)
    public static Dictionary<string, string> ParseAttr(string id, string attr)
        => ofGetAttribute(id, attr ?? string.Empty);

    // เปิด attr string → dict สำหรับเปิด popAttribute (เลียน ofLoadAttr):
    //   ตัด class, ใส่ default sqlwhere=1 / column=id / text=id ถ้าว่าง
    public static Dictionary<string, string> LoadAttr(string id, string attr)
    {
        var atts = ofGetAttribute(id, attr ?? string.Empty);
        atts.Remove("class");

        // sqlwhere: ถ้าไม่ใช่ "0" (replace-only) → default "1"
        if (!atts.TryGetValue(sc.report.attArg.sqlwhere, out var sw) || sw != "0")
            atts[sc.report.attArg.sqlwhere] = "1";
        if (!atts.TryGetValue(sc.report.attArg.column, out var col) || string.IsNullOrWhiteSpace(col))
            atts[sc.report.attArg.column] = id;
        if (!atts.TryGetValue(sc.report.attArg.text, out var txt) || string.IsNullOrWhiteSpace(txt))
            atts[sc.report.attArg.text] = id;
        return atts;
    }

    // dict → attr string สำหรับ popAttribute "ตกลง" (เลียน ofFormAttr):
    //   ตัดค่าที่เป็น default ทิ้ง แล้วต่อเป็น ` name="value"` (เว้นวรรคคั่น)
    public static string FormAttr(string id, Dictionary<string, string> atts)
    {
        string S(string k) => atts.TryGetValue(k, out var v) ? (v ?? string.Empty) : string.Empty;

        atts.Remove("class");

        // sqlwhere: "1" = default (ตัดทิ้ง); อื่น ๆ = "0" (replace-only, เก็บไว้)
        if (S(A.sqlwhere) == "1") atts.Remove(A.sqlwhere); else atts[A.sqlwhere] = "0";

        if (S(A.text)     == id)                       atts.Remove(A.text);
        if (S(A.column)   == id)                       atts.Remove(A.column);
        if (S(A.clause)   == "and")                    atts.Remove(A.clause);
        if (S(A.operator_) == sc.report.opertors.equal) atts.Remove(A.operator_);
        if (S(A.type)     == "string")                 atts.Remove(A.type);
        if (S(A.control)  == "ASPxTextBox")            atts.Remove(A.control);

        // checkbox false → ตัดทิ้ง
        foreach (var k in new[] { A.sqlreplace, A.noheader, A.mustvalue, A.nestwhere,
                                  A.nestreplace, A.readOnly, A.comboReplace, A.comboWhere })
            if (!sc.value.toBoolean(S(k))) atts.Remove(k);

        var sb = new System.Text.StringBuilder();
        foreach (var pair in atts)
            if (!string.IsNullOrWhiteSpace(pair.Value))
            {
                if (sb.Length > 0) sb.Append(' ');
                sb.Append(pair.Key).Append("=\"").Append(pair.Value).Append('"');
            }
        return sb.ToString();
    }

    // แตก {token} ออกจากสตริง args ของ procedure (port verbatim จาก pan.cs ofGetArgument)
    public static List<string> ParseProcedureTokens(string args)
    {
        var argx = new List<string>();
        if (string.IsNullOrWhiteSpace(args)) return argx;
        while (true)
        {
            int i = args.IndexOf('{');
            if (i == -1) break;
            int j = args.IndexOf('}');
            var argName = args.Substring(i + 1, j - i - 1);
            if (!string.IsNullOrWhiteSpace(argName)) argx.Add(argName.Trim());
            args = args.Substring(j + 1);
        }
        if (!string.IsNullOrWhiteSpace(args))
            throw new Exception("C56:Procedure : " + args + " ไม่ถูกต้อง");
        return argx;
    }

    // โหลด class templates จาก repQuery\repArguments.xml /root/classes (เลียน popAttribute Page_Load)
    public List<RepArgClass> LoadArgClasses()
    {
        var list = new List<RepArgClass>();
        var path = Path.Combine(SourceRoot(), "repArguments.xml");
        if (!File.Exists(path)) return list;

        var doc = new XmlDocument();
        doc.Load(path);
        if (doc.SelectSingleNode("/root/classes") is { } classes)
            foreach (XmlNode n in classes.ChildNodes)
                if (n is XmlElement e)
                {
                    var rc = new RepArgClass { Name = e.Name, Text = e.GetAttribute(sc.report.attArg.text) };
                    foreach (XmlAttribute a in e.Attributes) rc.Attrs[a.Name] = a.Value;
                    list.Add(rc);
                }
        return list;
    }
}

// class template ของ repArgument (1 entry ใน repArguments.xml /root/classes)
public class RepArgClass
{
    public string Name { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public Dictionary<string, string> Attrs { get; set; } = new(StringComparer.OrdinalIgnoreCase);
}

// ── editable model (Page เป็นเจ้าของ, ส่งลง region/tab ผ่าน [Parameter]) ──────
public class RepProgramModel
{
    public string VsPath    { get; set; } = string.Empty;
    public string Procedure { get; set; } = string.Empty;
    public string ColFocus  { get; set; } = string.Empty;
    public string Sql       { get; set; } = string.Empty;

    public List<RepArgRow>    Args       { get; set; } = new();
    public List<RepComboRow>  Combos     { get; set; } = new();
    public List<RepSubRow>    Subs       { get; set; } = new();
    public List<RepMisColumn> MisColumns { get; set; } = new();
    public List<RepMisRow>    MisRows    { get; set; } = new();

    public bool FileExists { get; set; }
}

public class RepArgRow   { public string Id   { get; set; } = string.Empty; public string Attr  { get; set; } = string.Empty; }
public class RepComboRow { public string Name { get; set; } = string.Empty; public string Query { get; set; } = string.Empty; }
public class RepSubRow   { public string Name { get; set; } = string.Empty; public string Query { get; set; } = string.Empty; }

// MIS column นิยาม (1 แถว = 1 คอลัมน์ของรายงาน MIS)
public class RepMisColumn
{
    public string Name  { get; set; } = string.Empty;  // column_name (UPPER ตอน save)
    public string Text  { get; set; } = string.Empty;  // column_text (caption)
    public string Type  { get; set; } = string.Empty;  // ""/string/decimal2/integer2/date
    public string Width { get; set; } = string.Empty;  // column_width (int)
}

// MIS ค่าเริ่มต้น (1 แถว) — ค่าเก็บตามชื่อคอลัมน์ (key = RepMisColumn.Name)
public class RepMisRow
{
    public Dictionary<string, string> Values { get; set; } = new(StringComparer.OrdinalIgnoreCase);
    public string Get(string key) => Values.TryGetValue(key, out var v) ? v : string.Empty;
    public void   Set(string key, string? v) => Values[key] = v ?? string.Empty;
}
