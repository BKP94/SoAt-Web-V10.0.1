namespace scKeeping.Components.Pages.sckepmpm;

/// <summary>
/// State ของหน้า ประมวลผลเรียกเก็บ/ผ่านรายการ (sckepmpm) — เจ้าของคือ Sckepmpm.razor,
/// ส่งลง PanItem/PanMonth/PanOperate เป็น reference ร่วม (child = dumb component).
/// วันที่เก็บเป็น DateTime? (ค.ศ.) — display เป็น พ.ศ. ผ่าน sc.value.toStringTH
/// </summary>
public sealed class SckepmpmForm
{
    // ── PanItem (วิธีเรียกเก็บ + รายการประมวลผล) ─────────────────────────────
    /// วิธีเรียกเก็บ (sc_lon_m_ucf_install_method) — ว่าง = ทั้งหมด
    public string? keep_method { get; set; }

    /// รายการประมวลผล (sc_kep_m_ucf_process) — ติ๊กเลือก proc_code
    public List<ProcItem> Items { get; set; } = new();

    /// proc_code ที่ถูกติ๊กเลือก (ผูกกับ DxGrid SelectedDataItems)
    public IReadOnlyList<ProcItem> SelectedItems { get; set; } = new List<ProcItem>();

    // ── PanMonth (ประจำเดือน + รูปแบบการประมวลผล) ────────────────────────────
    public int?      receive_year  { get; set; }   // พ.ศ. (แสดง/กรอก) — store ลด 543
    public int?      receive_month { get; set; }
    public DateTime? receipt_date  { get; set; }    // วันที่ใบเสร็จ
    public DateTime? calint_date   { get; set; }    // วันที่คิดดอก (mproc)
    public DateTime? post_date     { get; set; }    // วันที่ผ่านรายการ (mpost)

    public string?   proc_mode     { get; set; }    // A=ทั้งหมด G=หน่วย M=รหัสสมาชิก K=กลุ่มประมวลผล
    public string?   proc_value_1  { get; set; }    // ค่าตาม proc_mode (หน่วย/สมาชิก/กลุ่ม)
    public string?   proc_value_2  { get; set; }    // group2 (เมื่อ proc_mode=G)
    public string?   member_name   { get; set; }    // ชื่อสมาชิก (แสดงเมื่อ proc_mode=M)
}

/// รายการประมวลผล 1 แถวใน gvItem
public sealed class ProcItem
{
    public string  proc_code   { get; set; } = "";
    public string? proc_detail { get; set; }
    public bool    selected    { get; set; }   // default ติ๊ก (month_proc_default / month_post_default)
}

/// <summary>
/// Lookups ที่ Sckepmpm (composite) โหลดครั้งเดียวแล้วส่งลง child
/// (แยกจาก state ที่ผู้ใช้แก้ — combo keep_method + flag ล็อก)
/// </summary>
public sealed class SckepmpmLookups
{
    /// วิธีเรียกเก็บ (sc_lon_m_ucf_install_method active_status='1' order sort_order)
    public List<sc.ComboItem> KeepMethods { get; set; } = new();

    /// legacy: ถ้ามีวิธีเดียว → ClientEnabled=false + auto-select (disable combo)
    public bool KeepMethodLocked { get; set; }
}

/// <summary>
/// วันที่ทำงาน (working dates) จาก pka_kep_mproc — legacy panMonth เรียกทุกครั้งที่ New/เปลี่ยนงวด.
/// ⚠️ Phase 1 (frontend): pka_kep_mproc.fp_working_* ยังไม่ migrate ลง PG (มาใน Phase 3 engine)
///    → เรียกแบบ guard: ถ้าฟังก์ชันยังไม่มีในฐาน = คืน null (ให้ผู้ใช้กรอกเอง) แทนที่จะพังทั้งหน้า.
///    เมื่อ Phase 3 สร้างฟังก์ชันครบ วันที่จะ auto-fill ทันทีโดยไม่ต้องแก้ frontend.
/// </summary>
public static class SckepmpmDates
{
    public static Task<DateTime?> WorkingReceiptAsync(sc.db db, int year, int month)
        => TryDateAsync(db, "pka_kep_mproc.fp_working_receipt_date", year, month);

    public static Task<DateTime?> WorkingCalintAsync(sc.db db, int year, int month)
        => TryDateAsync(db, "pka_kep_mproc.fp_working_calint_date", year, month);

    /// legacy change_receipt_date: คิดวันคิดดอกจากวันที่ใบเสร็จโดยตรง
    public static Task<DateTime?> WorkingCalintByDateAsync(sc.db db, DateTime receiptDate)
        => TryDateAsync(db, "pka_kep_mproc.fp_working_calint_date", receiptDate);

    private static async Task<DateTime?> TryDateAsync(sc.db db, string fn, params object?[] args)
    {
        try
        {
            //return sc.value.toDate(await db.getValueAsync(fn, args)) as DateTime?;
            return sc.value.toDate(await db.pkFunctionAsync(fn, args)) as DateTime?;
        }
        catch (Exception ex)
        {
            // ฟังก์ชัน engine ยังไม่พร้อมใน PG (Phase 3) — ไม่ให้ล้มทั้งหน้า
            sc.log.addLine($"[sckepmpm] {fn} unavailable (Phase 3 pending): {ex.Message}");
            return null;
        }
    }
}
