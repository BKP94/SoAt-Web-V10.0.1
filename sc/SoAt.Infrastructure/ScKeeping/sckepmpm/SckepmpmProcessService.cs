using SoAt.Application.ScKeeping;

namespace SoAt.Infrastructure.ScKeeping;

/// <summary>
/// port ตรงจาก legacy scKeeping/sckepmpm/pageForm.ascx.cs.
///
/// legacy sc.db.cmdExecuteCommand.LooperByFunction → port เป็น sc.db.looperByFunctionAsync
///   (นับ count จาก countFn ครั้งเดียว → ยิง sp N รอบผ่าน NpgsqlBatch batch 1000 = เทียบ Oracle ArrayBindCount,
///    log ครั้งเดียวต่อ looper ไม่ใช่ต่อแถว). LoopAsync ในไฟล์นี้เป็น thin wrapper เรียก db method
///   · mproc: ไม่มี LooperAtLast → args เดิมทุกรอบ (SP เดินเคอร์เซอร์ผ่าน temp table เอง)
///   · mpost: LooperAtLast=true → append index i เป็น arg สุดท้ายทุกรอบ
///
/// ⚠️ temp table = session state → ทั้ง run ต้องอยู่ connection/transaction เดียว
///   sc.db 1 instance = 1 connection + 1 transaction ค้างจน Dispose/Commit → temp table (ON COMMIT DROP) รอด
///   PreProcess/PostProcess (toggle trigger) = คนละ transaction (ต้อง commit การ toggle ก่อน/หลัง engine)
/// </summary>
public class SckepmpmProcessService(sc.dbFactory dbFactory) : ISckepmpmProcessService
{
    // legacy: const int salary_time = 1;
    private const int SalaryTime = 1;

    public async Task ProcessAsync(SckepmpmProcessRequest req, string userId, string branchId)
    {
        await EnsureEngineReadyAsync(userId, branchId);   // guard Phase 3 (PL ยังไม่ครบ → แจ้งแทน error ดิบ)

        // legacy page.js ofProc: proc_mode=='M' → run อย่างเดียว (ไม่ toggle trigger)
        if (req.ProcMode == "M")
        {
            await RunAsync(req, userId, branchId);
            return;
        }

        await PreProcessAsync(userId, branchId);
        await RunAsync(req, userId, branchId);
        await PostProcessAsync(req.IsMpost, userId, branchId);
    }

    // ── ofPreProcess: เปิด/ปิด constraint+trigger ก่อนประมวลผล (เหมือนกันทั้ง mproc/mpost) ──
    private async Task PreProcessAsync(string userId, string branchId)
    {
        var db = dbFactory.create(userId, branchId);
        try
        {
            await db.pkProcedureAsync("pka_kep.sp_constraints_prepare", "PRE_PROC");
            await db.ofConnectionCloseAsync("Sckepmpm-PreProcess");
        }
        catch
        {
            await db.ofConnectionCloseAsync("Sckepmpm-PreProcess-Error", onError: true);
            throw;
        }
    }

    // ── ofPostProcess: คืนสถานะ constraint+trigger หลังประมวลผล (mproc=POST_PROC / mpost=POST_POST) ──
    private async Task PostProcessAsync(bool isMpost, string userId, string branchId)
    {
        var db = dbFactory.create(userId, branchId);
        try
        {
            await db.pkProcedureAsync("pka_kep.sp_constraints_prepare", isMpost ? "POST_POST" : "POST_PROC");
            await db.ofConnectionCloseAsync("Sckepmpm-PostProcess");
        }
        catch
        {
            await db.ofConnectionCloseAsync("Sckepmpm-PostProcess-Error", onError: true);
            throw;
        }
    }

    // ── run: engine หลัก — held-open db ตัวเดียวตลอด run (temp table session state) ──
    private async Task RunAsync(SckepmpmProcessRequest req, string userId, string branchId)
    {
        var db = dbFactory.create(userId, branchId);
        try
        {
            if (req.IsMpost) await RunMpostAsync(db, req);
            else             await RunMprocAsync(db, req);

            await db.ofConnectionCloseAsync("Sckepmpm-Run");   // commit
        }
        catch (Exception ex)
        {
            // log full exception ตรงนี้ (in-flow ของ programmer gate — AsyncLocal ไม่ไหลกลับถึง catch ฝั่ง razor)
            sc.log.addLine($"[sckepmpm] run error: {ex}");
            // pkProcedureAsync ไม่ set _dbState=Failure เอง → บังคับ rollback กันงานค้าง commit บางส่วน
            await db.ofConnectionCloseAsync("Sckepmpm-Run-Error", onError: true);
            throw;
        }
    }

    // ── ofProcess_mproc (ประมวลผลเรียกเก็บ) ─────────────────────────────────────────
    private static async Task RunMprocAsync(sc.db db, SckepmpmProcessRequest req)
    {
        int year = req.ReceiveYear, month = req.ReceiveMonth;

        // วันที่ใบเสร็จ/คิดดอก → PG proc pka_kep_mproc.* ประกาศ param เป็น DATE (adt_rec/adt_cal date)
        //   ส่ง DateOnly เพื่อให้ Npgsql bind เป็น `date` ตรง signature (DateTime → timestamp = ไม่ match
        //   → 42883 does not exist). NB: ฝั่ง mpost proc ประกาศเป็น timestamp จึงคง DateTime (req.PostDate)
        DateOnly recDate = DateOnly.FromDateTime(req.ReceiptDate);
        DateOnly calDate = DateOnly.FromDateTime(req.CalintDate);

        // 0) init engine session state — สร้าง/ล้าง temp table ที่แทน Oracle package associative arrays
        //    PG-migration necessity (ไม่มีใน legacy): Oracle init array ให้อัตโนมัติ,
        //    PG ต้อง CREATE TEMP TABLE ก่อนใช้ → engine_begin ทำหน้าที่นี้ ต้องเป็น call แรกเสมอ
        await db.pkProcedureAsync("pka_kep_mproc.sp_engine_begin");

        // 1) ติดตั้งวิธีเรียกเก็บ
        await db.pkProcedureAsync("pka_kep_mproc.sp_mproc_install_kepmethod", req.KeepMethod);

        // 2) เตรียมหัวรายการ
        await db.pkProcedureAsync("pka_kep_mproc.sp_stmain_prepare",
            year, month, SalaryTime, req.ProcMode, req.ProcValue);

        // 3) ลบของเดิมของแต่ละ proc_code ที่เลือก
        foreach (var procCode in req.ProcSelected)
            await db.pkProcedureAsync("pka_kep_mproc.sp_stmain_delold",
                year, month, SalaryTime, procCode);

        // 4) ลบแถวว่าง  5) รวบรวมสมาชิกเข้าประมวลผล
        await db.pkProcedureAsync("pka_kep_mproc.sp_stmain_delempty", year, month, SalaryTime);
        await db.pkProcedureAsync("pka_kep_mproc.sp_stmain_collector", year, month, SalaryTime);

        // 6) ประมวลผลทีละ proc_code — ยกเว้น MRT/REC/REP (แยกทำท้ายสุด)
        bool foundMRT = false, foundREC = false, foundREP = false;
        foreach (var procCode in req.ProcSelected)
        {
            if (procCode == "MRT") { foundMRT = true; continue; }
            if (procCode == "REC") { foundREC = true; continue; }
            if (procCode == "REP") { foundREP = true; continue; }

            await db.pkProcedureAsync("pka_kep_mproc.sp_stcode_prepare",
                procCode, year, month, SalaryTime);
            await LoopAsync(db, "pka_kep_mproc.fp_stcode_count()", System.Array.Empty<object?>(),
                appendIndex: false,
                sp: "pka_kep_mproc.sp_stcode_run",
                spArgs: new object?[] { procCode, year, month, SalaryTime, recDate, calDate, "0" });
        }

        // 7) บันทึกหัวรายการ
        await db.pkProcedureAsync("pka_kep_mproc.sp_stmain_save", year, month, calDate);

        // 8) MRT — ปรับปรุงยอด (ต้องทำหลัง save)
        if (foundMRT)
        {
            await db.pkProcedureAsync("pka_kep_mproc.sp_stcode_prepare", "MRT", year, month, SalaryTime);
            await LoopAsync(db, "pka_kep_mproc.fp_stcode_count()", System.Array.Empty<object?>(),
                appendIndex: false,
                sp: "pka_kep_mproc.sp_stcode_run",
                spArgs: new object?[] { "MRT", year, month, SalaryTime, recDate, calDate, "0" });
        }

        // 9) REC — ออกใบเสร็จ
        if (foundREC)
        {
            const string receiptStype = "2";
            const int receiptBegin = 0;
            await db.pkProcedureAsync("pka_kep_mproc.sp_stcode_receipt_prepare",
                year, month, req.ProcMode, req.ProcValue, receiptStype, receiptBegin, SalaryTime);
            await LoopAsync(db, "pka_kep_mproc.fp_stcode_count()", System.Array.Empty<object?>(),
                appendIndex: false,
                sp: "pka_kep_mproc.sp_stcode_receipt_run",
                spArgs: new object?[] { year, month });
            await db.pkProcedureAsync("pka_kep_mproc.sp_stcode_receipt_save", year, month);
        }

        // 10) REP — จัดทำงบหน้าเรียกเก็บ
        if (foundREP)
            await db.pkProcedureAsync("pka_rep_kep.sp_receipt_report", year, month, "KEP");

        // 11) สรุปยอดรวม
        await db.pkProcedureAsync("pka_kep_mproc.sp_stmain_summary",
            year, month, recDate, calDate, SalaryTime);
    }

    // ── ofProcess_mpost (ประมวลผลผ่านรายการ) ────────────────────────────────────────
    private static async Task RunMpostAsync(sc.db db, SckepmpmProcessRequest req)
    {
        // 0) init engine session state (ดู note RunMprocAsync) — ครั้งเดียวต่อ run ก่อนวน method
        await db.pkProcedureAsync("pka_kep_mpost.sp_engine_begin");

        // legacy: ls_MultiProcessAtOneReceipt = "0" (บล็อก ora.isActive เป็น no-op ค่าคงที่ "0")
        await db.pkProcedureAsync("pka_kep_mpost.sp_MultiProcessAtOneReceipt", "0");

        if (string.IsNullOrWhiteSpace(req.KeepMethod))
        {
            // วิธีเรียกเก็บว่าง → วนทุกวิธี (legacy loop page.keep_method.Items)
            foreach (var method in req.AllKeepMethods)
                await RunMpostMethodAsync(db, req, method);
        }
        else
        {
            await RunMpostMethodAsync(db, req, req.KeepMethod);
        }
    }

    // ── ofProcess_mpost(vals, keep_method) — ต่อ 1 วิธีเรียกเก็บ ──
    private static async Task RunMpostMethodAsync(sc.db db, SckepmpmProcessRequest req, string keepMethod)
    {
        int year = req.ReceiveYear, month = req.ReceiveMonth;

        await db.pkProcedureAsync("pka_kep_mpost.sp_stmain_prepare",
            year, month, req.ProcMode, req.ProcValue, keepMethod, req.PostDate);
        await db.pkProcedureAsync("pka_kep_mpost.sp_stmain_loader", year, month, keepMethod);

        // ไม่มีแถวใบเสร็จให้ผ่านรายการ → ข้ามวิธีนี้
        if (sc.value.toInteger(await db.pkFunctionAsync("pka_kep_mpost.fp_itabrow_rh_count()")) == 0)
            return;

        // ผ่านรายการทีละ proc_code — LooperAtLast=true (append i)
        foreach (var procCode in req.ProcSelected)
            await LoopAsync(db, "pka_kep_mpost.fp_stcode_count", new object?[] { procCode },
                appendIndex: true,
                sp: "pka_kep_mpost.sp_stcode_run",
                spArgs: new object?[] { procCode });

        await db.pkProcedureAsync("pka_kep_mpost.sp_stmain_save", year, month, req.PostDate);
        await db.pkProcedureAsync("pka_kep_mpost.sp_posted_loader", year, month, keepMethod);

        // ผ่านรายการ posted ทีละแถว — LooperAtLast=true (append i)
        await LoopAsync(db, "pka_kep_mpost.fp_itabrow_rh_count()", System.Array.Empty<object?>(),
            appendIndex: true,
            sp: "pka_kep_mpost.sp_posted_run",
            spArgs: System.Array.Empty<object?>());

        await db.pkProcedureAsync("pka_kep_mpost.sp_mpost_clear_instance()");
    }

    // ── LooperByFunction: delegate ไป sc.db.looperByFunctionAsync (port legacy cmdExecuteCommand.LooperByFunction) ──
    //   appendIndex=true → LooperAtLast: ต่อ index i เป็น arg สุดท้ายทุกรอบ; false → args เดิมทุกรอบ
    //   lib ยิง N รอบผ่าน NpgsqlBatch (batch 1000 = round-trip น้อย + log ครั้งเดียว) แทน Oracle ArrayBindCount
    private static Task LoopAsync(
        sc.db db, string countFn, object?[] countArgs,
        bool appendIndex, string sp, object?[] spArgs)
        => db.looperByFunctionAsync(countFn, countArgs, sp, spArgs, looperAtLast: appendIndex);

    // ── guard: engine PL ยังไม่ครบ (Phase 3) → แจ้งข้อความชัดเจน แทน error "function does not exist" ดิบ ──
    private async Task EnsureEngineReadyAsync(string userId, string branchId)
    {
        await using var db = dbFactory.create(userId, branchId);
        var ready = sc.value.toInteger(await db.getValueAsync(
            @"select count(*) from pg_proc p
                join pg_namespace n on n.oid = p.pronamespace
               where n.nspname = 'pka_kep_mproc' and p.proname = 'sp_stmain_prepare'"));
        if (ready == 0)
            throw new InvalidOperationException(
                sc.msg.C("ส่วนประมวลผล (engine PL) ยังไม่พร้อมใช้งาน — อยู่ระหว่างพัฒนา (Phase 3)"));
    }
}
