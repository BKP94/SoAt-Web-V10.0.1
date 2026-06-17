namespace scReport.Services;

// ── RepCategoryService ───────────────────────────────────────────────────────
//   หน้าจอ "เพิ่ม/แก้ไขกลุ่มรายงาน" (เลียน legacy scReport/repCategory)
//   master–detail 2 ตาราง: si_rep_cats (กลุ่ม) → si_rep_reps (ข้อรายงาน) ของระบบงานหนึ่ง (cat_app)
//
//   ⚠ legacy เก็บ batch-delta ในกริด (sc.save อ่าน class "save-table"/"child-cat_id")
//      ฝั่ง Blazor เราติดตาม delta เอง (IsNew / OrigKey / Deleted) แล้ว upsert+delete
//      ในทรานแซกชันเดียว (db instance เดียว = 1 txn) — ผลลัพธ์ตรง legacy
//
//   Scope (ปิดงาน): โหลด 2 กริด + Save (insert/update/delete ทั้งสองตาราง) + Move (ย้ายกลุ่มรายงาน)
//             Export/Import (XML scStorage) ของ legacy — ยกเลิก ไม่ทำ (ตัดสินใจ 2026-06-17)
public class RepCategoryService
{
    private readonly sc.dbFactory _dbFactory;

    public RepCategoryService(sc.dbFactory dbFactory) => _dbFactory = dbFactory;

    // ── Load กลุ่ม (เลียน panListCat.ofLoadCat) ───────────────────────────────
    //   select * from si_rep_cats where cat_app = {APP} order by cat_app, nvl(sort_no,0), cat_id
    public async Task<List<CatRow>> LoadCatsAsync(string app)
    {
        await using var db = _dbFactory.create();
        return await LoadCatsAsync(db, app);
    }

    private static async Task<List<CatRow>> LoadCatsAsync(sc.db db, string app)
    {
        var rows = await db.getListAsync<CatRow>(@"
            select cat_id   as CatId,
                   cat_text as CatText,
                   cat_app  as CatApp,
                   active   as ActiveText,
                   sort_no  as SortNo
            from si_rep_cats
            where cat_app = {0}
            order by cat_app, coalesce(sort_no, 0), cat_id", app);
        foreach (var r in rows) r.MarkLoaded();
        return rows;
    }

    // ── Load ข้อรายงาน (เลียน panListRep.ofLoad) ──────────────────────────────
    //   select * from si_rep_reps where cat_id = {CAT} order by nvl(sort_no,0), rep_id
    public async Task<List<RepRow>> LoadRepsAsync(string catId)
    {
        await using var db = _dbFactory.create();
        return await LoadRepsAsync(db, catId);
    }

    private static async Task<List<RepRow>> LoadRepsAsync(sc.db db, string catId)
    {
        if (string.IsNullOrWhiteSpace(catId)) return new();
        var rows = await db.getListAsync<RepRow>(@"
            select cat_id   as CatId,
                   rep_id   as RepId,
                   rep_text as RepText,
                   vs_path  as VsPath,
                   active   as ActiveText,
                   sort_no  as SortNo
            from si_rep_reps
            where cat_id = {0}
            order by coalesce(sort_no, 0), rep_id", catId);
        foreach (var r in rows) r.MarkLoaded();
        return rows;
    }

    // ── Save (เลียน sc.save batch — upsert+delete ทั้งสองตารางใน txn เดียว) ────
    //   บันทึก: กลุ่มทั้งหมดของ app (gvCat) + ข้อรายงานของกลุ่มที่เลือก (gvRep)
    public async Task SaveAsync(RepCategoryModel m, string userId)
    {
        // validate ก่อนแตะ DB (เลียน legacy ตรวจ key ก่อน save)
        foreach (var c in m.Cats)
            if (string.IsNullOrWhiteSpace(c.CatId))
                throw new Exception("C-CAT:กรุณาระบุ รหัสกลุ่ม (cat_id)");
        foreach (var r in m.Reps)
        {
            if (string.IsNullOrWhiteSpace(r.RepId))
                throw new Exception("C-REP:กรุณาระบุ รหัสรายงาน (rep_id)");
            if (string.IsNullOrWhiteSpace(r.CatId))
                r.CatId = m.SelectedCatId ?? "";
        }

        await using var db = _dbFactory.create(userId);
        try
        {
            // ── si_rep_cats ──
            foreach (var key in m.DeletedCatKeys)
                await db.dbDeleteAsync("delete from si_rep_cats where cat_id = {0}", key);

            foreach (var c in m.Cats)
            {
                if (c.IsNew)
                    await db.dbInsertAsync(@"
                        insert into si_rep_cats (cat_id, cat_text, cat_app, active, sort_no)
                        values ({0},{1},{2},{3},{4})",
                        c.CatId.Trim(), c.CatText, m.App, c.ActiveSave, c.SortNoSave);
                else
                    await db.dbUpdateAsync(@"
                        update si_rep_cats set cat_id = {0}, cat_text = {1}, active = {2}, sort_no = {3}
                        where cat_id = {4}",
                        c.CatId.Trim(), c.CatText, c.ActiveSave, c.SortNoSave, c.OrigCatId);
                c.MarkLoaded();   // หลังบันทึก = row ที่มีอยู่จริงแล้ว
            }

            // ── si_rep_reps (เฉพาะกลุ่มที่เลือกอยู่) ──
            foreach (var (catId, repId) in m.DeletedRepKeys)
                await db.dbDeleteAsync(
                    "delete from si_rep_reps where cat_id = {0} and rep_id = {1}", catId, repId);

            foreach (var r in m.Reps)
            {
                if (r.IsNew)
                    await db.dbInsertAsync(@"
                        insert into si_rep_reps (cat_id, rep_id, rep_text, vs_path, active, sort_no)
                        values ({0},{1},{2},{3},{4},{5})",
                        r.CatId.Trim(), r.RepId.Trim(), r.RepText, r.VsPath, r.ActiveSave, r.SortNoSave);
                else
                    await db.dbUpdateAsync(@"
                        update si_rep_reps set cat_id = {0}, rep_id = {1}, rep_text = {2},
                                               vs_path = {3}, active = {4}, sort_no = {5}
                        where cat_id = {6} and rep_id = {7}",
                        r.CatId.Trim(), r.RepId.Trim(), r.RepText, r.VsPath, r.ActiveSave, r.SortNoSave,
                        r.OrigCatId, r.OrigRepId);
                r.MarkLoaded();
            }

            m.DeletedCatKeys.Clear();
            m.DeletedRepKeys.Clear();

            await db.ofConnectionCloseAsync("repCategory.save");
        }
        catch
        {
            await db.ofConnectionCloseAsync("repCategory.save-error", onError: true);
            throw;
        }
    }

    // ── Move: combo รหัสกลุ่มของ app (เลียน popMoveCat Page_Load) ──────────────
    public async Task<List<sc.ComboItem>> LoadMoveCatsAsync(string app)
    {
        await using var db = _dbFactory.create();
        var rows = await db.getListAsync<sc.ComboItem>(@"
            select cat_id              as code,
                   cat_id||' - '||cat_text as name
            from si_rep_cats
            where cat_app = {0}
            order by cat_id", app);
        return rows;
    }

    // ── Move: gen rep_id ใหม่ของกลุ่มปลายทาง (เลียน popMoveCat.change_cat_id) ──
    //   max(rep_id) ปัดขึ้นทวีคูณของ 5 แล้ว pad ซ้ายเป็น 3 หลัก
    public async Task<string> NextRepIdAsync(string catId)
    {
        await using var db = _dbFactory.create();
        var max = db.getValueInteger(
            "select coalesce(max(rep_id::int), 0) from si_rep_reps where cat_id = {0}", catId);
        var next = (max - (max % 5)) + 5;
        var text = next.ToString();
        if (text.Length < 3) text = text.PadLeft(3, '0');
        return text;
    }

    // ── Move: ย้ายข้อรายงานไปกลุ่มใหม่ (เลียน popMoveCat.ofSave) ───────────────
    public async Task MoveAsync(string oldCatId, string oldRepId, string newCatId, string newRepId, string userId)
    {
        await using var db = _dbFactory.create(userId);
        try
        {
            // ⚠ ส่ง args เป็น object?[] ชัดเจน — กัน overload resolution ไปเข้า
            //    dbUpdateAsync<T>(reflection) เมื่อ args ทุกตัวเป็น string (เลือก raw SQL overload)
            await db.dbUpdateAsync(@"
                update si_rep_reps set cat_id = {0}, rep_id = {1}
                where cat_id = {2} and rep_id = {3}",
                new object?[] { newCatId, newRepId, oldCatId, oldRepId });
            await db.ofConnectionCloseAsync("repCategory.move");
        }
        catch
        {
            await db.ofConnectionCloseAsync("repCategory.move-error", onError: true);
            throw;
        }
    }
}

// ── editable model (Page เป็นเจ้าของ, ส่งลง region ผ่าน [Parameter] reference ร่วม) ──
public class RepCategoryModel
{
    public string App { get; set; } = string.Empty;
    public List<CatRow> Cats { get; set; } = new();
    public string? SelectedCatId { get; set; }
    public List<RepRow> Reps { get; set; } = new();
    public string? SelectedRepId { get; set; }   // ข้อรายงานที่เลือก (สำหรับปุ่ม Move)

    // delta ลบ (เก็บ key เดิม เพื่อยิง DELETE ตอน Save)
    public List<string> DeletedCatKeys { get; } = new();
    public List<(string CatId, string RepId)> DeletedRepKeys { get; } = new();
}

// si_rep_cats — 1 แถว = 1 กลุ่มรายงาน
public class CatRow
{
    public string  CatId      { get; set; } = string.Empty;  // PK (ผู้ใช้กรอกเอง)
    public string? CatText    { get; set; }
    public string? CatApp     { get; set; }
    public string? ActiveText { get; set; }                  // char(1) '0'/'1' จาก DB
    public double? SortNo     { get; set; }

    // delta tracking: OrigCatId != null = row ที่โหลดมาจาก DB (UPDATE by OrigCatId), null = แถวใหม่ (INSERT)
    public string? OrigCatId { get; private set; }
    public bool IsNew => OrigCatId is null;
    public void MarkLoaded() => OrigCatId = CatId;

    // UI bind: active เป็น checkbox; sort_no เป็นตัวเลข
    public bool Active { get => ActiveText == "1"; set => ActiveText = value ? "1" : "0"; }
    public string ActiveSave => Active ? "1" : "0";
    public object? SortNoSave => SortNo.HasValue ? (int)SortNo.Value : (object?)null;
}

// si_rep_reps — 1 แถว = 1 ข้อรายงาน (PK composite cat_id + rep_id)
public class RepRow
{
    public string  CatId      { get; set; } = string.Empty;
    public string  RepId      { get; set; } = string.Empty;
    public string? RepText    { get; set; }
    public string? VsPath     { get; set; }
    public string? ActiveText { get; set; }
    public double? SortNo     { get; set; }

    public string? OrigCatId { get; private set; }
    public string? OrigRepId { get; private set; }
    public bool IsNew => OrigRepId is null;
    public void MarkLoaded() { OrigCatId = CatId; OrigRepId = RepId; }

    public bool Active { get => ActiveText == "1"; set => ActiveText = value ? "1" : "0"; }
    public string ActiveSave => Active ? "1" : "0";
    public object? SortNoSave => SortNo.HasValue ? (int)SortNo.Value : (object?)null;
}
