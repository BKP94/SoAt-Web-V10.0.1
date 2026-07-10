namespace SoAt.Application.ScKeeping;

/// <summary>
/// เครื่องประมวลผลเรียกเก็บ/ผ่านรายการประจำเดือน (sckepmpm) —
/// port ตรงจาก legacy scKeeping/sckepmpm/pageForm.ascx.cs (ofPreProcess / ofProcess_mproc /
/// ofProcess_mpost / ofPostProcess). ทั้ง engine run ต้องอยู่ใน connection/transaction เดียว
/// (temp table = session state ของ Oracle package associative array → PG temp table).
/// </summary>
public interface ISckepmpmProcessService
{
    /// <summary>
    /// ประมวลผล 1 งวด (เรียกเก็บ = IsMpost false / ผ่านรายการ = IsMpost true).
    /// flow (legacy page.js ofProc): proc_mode=='M' → run อย่างเดียว (ไม่ toggle trigger);
    /// อื่นๆ → PreProcess → Run → PostProcess.
    /// </summary>
    Task ProcessAsync(SckepmpmProcessRequest req, string userId, string branchId);
}

/// <summary>
/// พารามิเตอร์ประมวลผล (ประกอบจากหน้าจอ Sckepmpm) — ปีเป็น ค.ศ. (frontend แปลง พ.ศ.→ค.ศ. ก่อนส่ง).
/// proc_value ประกอบเสร็จแล้วเหมือน legacy page.js ofProc (G = value1-value2).
/// </summary>
public sealed class SckepmpmProcessRequest
{
    public bool     IsMpost       { get; set; }

    public int      ReceiveYear   { get; set; }   // ค.ศ.
    public int      ReceiveMonth  { get; set; }
    public DateTime ReceiptDate   { get; set; }    // วันที่ใบเสร็จ
    public DateTime CalintDate    { get; set; }    // วันที่คิดดอก (mproc)
    public DateTime PostDate      { get; set; }    // วันที่ผ่านรายการ (mpost)

    public string   ProcMode      { get; set; } = "";   // A/G/M/K
    public string   ProcValue     { get; set; } = "";   // ประกอบแล้ว (G = v1-v2)

    /// วิธีเรียกเก็บ — ว่าง = ทั้งหมด (mpost วนทุกวิธีใน AllKeepMethods)
    public string?  KeepMethod    { get; set; }

    /// proc_code ที่ผู้ใช้ติ๊กเลือก (เรียงตามลำดับใน gvItem)
    public List<string> ProcSelected { get; set; } = new();

    /// วิธีเรียกเก็บทั้งหมด (mpost: keep_method ว่าง → วนทีละวิธี — legacy loop page.keep_method.Items)
    public List<string> AllKeepMethods { get; set; } = new();
}
