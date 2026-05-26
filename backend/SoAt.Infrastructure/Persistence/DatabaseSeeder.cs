using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using SoAt.Domain.Entities.Common;
using SoAt.Domain.Entities.Fin;
using SoAt.Domain.Entities.Mem;
using SoAt.Domain.Entities.System;

namespace SoAt.Infrastructure.Persistence;

public static class DatabaseSeeder
{
    // อ่านจาก appsettings.json → ConnectionStrings:OracleConnection
    static string OracleConnStr(IConfiguration config) =>
        config.GetConnectionString("OracleConnection") ?? "";

    public static async Task SeedAsync(AppDbContext db, IConfiguration config)
    {
        await SeedSecurityAppsAsync(db);
        await SeedSecurityAppsLevel2FromOracleAsync(db, config);
        await SeedSecurityAppsLevel3FromOracleAsync(db, config);   // ← level 3 แยก
        await SeedSecurityUsersFromOracleAsync(db, config);
        await SyncCounterSplitFromOracleAsync(db, config);
        await SeedBranchesFromOracleAsync(db, config);
        await SeedFinConstantFromOracleAsync(db, config);
        await SeedMemUcfFromOracleAsync(db, config);
    }

    static async Task SeedSecurityAppsAsync(AppDbContext db)
    {
        if (await db.SiSecurityApps.AnyAsync()) return;

        // Migrated from Oracle si_security_apps WHERE i_level = 1
        // active=true: enabled in scCenter; active=false: greyed out
        var apps = new List<SiSecurityApp>
        {
            new() { IMenuId = 4,    AppName = "scTeller",      AppText = "ระบบเจ้าหน้าที่ประจำหน่วย",        AppTextEnglish = "Teller",           Active = true,  ILevel = 1, ISequence = 1,   ShotApp = "TEL", IconName = "Teller.png"          },
            new() { IMenuId = 7,    AppName = "scApprove",     AppText = "ระบบผู้อนุมัติ",                   AppTextEnglish = "Approve",          Active = true,  ILevel = 1, ISequence = 2,   ShotApp = "APV", IconName = "Approve.png"         },
            new() { IMenuId = 5,    AppName = "scDeposit",     AppText = "ระบบเงินฝาก",                      AppTextEnglish = "Deposit",          Active = true,  ILevel = 1, ISequence = 3,   ShotApp = "DEP", IconName = "Deposit.png"         },
            new() { IMenuId = 6,    AppName = "scFinance",     AppText = "ระบบการเงิน",                      AppTextEnglish = "Finance",          Active = true,  ILevel = 1, ISequence = 4,   ShotApp = "FIN", IconName = "Finance.png"         },
            new() { IMenuId = 9,    AppName = "scKeeping",     AppText = "ระบบประมวลผล",                     AppTextEnglish = "Keeping",          Active = true,  ILevel = 1, ISequence = 5,   ShotApp = "KEP", IconName = "Keeping.png"         },
            new() { IMenuId = 8,    AppName = "scAccount",     AppText = "ระบบบัญชี",                        AppTextEnglish = "Account",          Active = true,  ILevel = 1, ISequence = 6,   ShotApp = "ACC", IconName = "Account.png"         },
            new() { IMenuId = 13,   AppName = "scReport",      AppText = "ระบบรายงาน",                       AppTextEnglish = "Report",           Active = true,  ILevel = 1, ISequence = 7,   ShotApp = "REP", IconName = "Report.png"          },
            new() { IMenuId = 11,   AppName = "scAdmin",       AppText = "ระบบผู้ดูแลระบบ",                  AppTextEnglish = "Administrator",    Active = true,  ILevel = 1, ISequence = 8,   ShotApp = "ADM", IconName = "Administrator.png"   },
            new() { IMenuId = 14,   AppName = "scCenter",      AppText = "ระบบบริหารงานหลักกรณ์",           AppTextEnglish = "Center",           Active = true,  ILevel = 1, ISequence = 50,  ShotApp = "CEN", IconName = "web.png"             },
            new() { IMenuId = 231,  AppName = "scTransbank",   AppText = "ระบบโอนเงินเข้าธนาคาร",           AppTextEnglish = "Transbank",        Active = true,  ILevel = 1, ISequence = 75,  ShotApp = "TRN", IconName = "Transbank.png"       },
            new() { IMenuId = 900,  AppName = "scEstate",      AppText = "ระบบทะเบียนหลักทรัพย์",           AppTextEnglish = "Estate",           Active = true,  ILevel = 1, ISequence = 90,  ShotApp = "EST", IconName = "Estate.png"          },
            new() { IMenuId = 1,    AppName = "scAtm",         AppText = "ระบบ ATM Off Line",                AppTextEnglish = "ATM Off Line",     Active = true,  ILevel = 1, ISequence = 100, ShotApp = "ATM", IconName = "ATM.png"             },
            new() { IMenuId = 2,    AppName = "scLaw",         AppText = "ระบบกฎหมาย",                       AppTextEnglish = "LAW",              Active = true,  ILevel = 1, ISequence = 110, ShotApp = "LAW", IconName = "LAW.png"             },
            new() { IMenuId = 16,   AppName = "scWelfare",     AppText = "ระบบสวัสดิการสมาชิก",              AppTextEnglish = "Welfare",          Active = true,  ILevel = 1, ISequence = 120, ShotApp = "WEF", IconName = "Welfare.png"         },
            new() { IMenuId = 236,  AppName = "scCoordinate",  AppText = "ระบบศูนย์ประสานงาน",               AppTextEnglish = "Coordinate",       Active = true,  ILevel = 1, ISequence = 125, ShotApp = "COR", IconName = "Coordinate.png"      },
            new() { IMenuId = 446,  AppName = "scMobile",      AppText = "ระบบ MobileApplication",           AppTextEnglish = "MobileRegis",      Active = true,  ILevel = 1, ISequence = 130, ShotApp = "MOB", IconName = "MobileRegis.png"     },
            new() { IMenuId = 607,  AppName = "scElections",   AppText = "ระบบเลือกตั้ง",                    AppTextEnglish = "Elections",        Active = true,  ILevel = 1, ISequence = 135, ShotApp = "ELT", IconName = "Elections.png"       },
            new() { IMenuId = 12,   AppName = "scPermit",      AppText = "ระบบผู้ให้สิทธิ์",                 AppTextEnglish = "Permission",       Active = true,  ILevel = 1, ISequence = 140, ShotApp = "PMT", IconName = "Permission.png"      },
            new() { IMenuId = 447,  AppName = "scProDATA",     AppText = "ระบบรับส่งไฟล์",                   AppTextEnglish = "ProDATA",          Active = true,  ILevel = 1, ISequence = 160, ShotApp = "PDT", IconName = "ProDATA.png"         },
            new() { IMenuId = 1000, AppName = "scInsurance",   AppText = "ระบบประกัน",                       AppTextEnglish = "Insurance",        Active = true,  ILevel = 1, ISequence = 170, ShotApp = "INS", IconName = "Insurance.png"       },
            new() { IMenuId = 453,  AppName = "scExp",         AppText = "ระบบครุภัณฑ์",                    AppTextEnglish = "Exp",              Active = true,  ILevel = 1, ISequence = 999, ShotApp = "EXP", IconName = "Exp.png"             },
            new() { IMenuId = 10,   AppName = "scFund",        AppText = "ระบบกองทุนผู้ค้ำ",                AppTextEnglish = "Fund",             Active = false, ILevel = 1, ISequence = 999, ShotApp = "FUN", IconName = "Fund.png"            },
            new() { IMenuId = 438,  AppName = "scKeepcoll",    AppText = "ระบบฝากเก็บฐานเงินผู้ค้ำ",       AppTextEnglish = "KeepColl",         Active = false, ILevel = 1, ISequence = 999, ShotApp = "KCL", IconName = "KeepColl.png"        },
            new() { IMenuId = 595,  AppName = "scBillpayment", AppText = "ระบบ Bill Payment",                AppTextEnglish = "BillPayment",      Active = false, ILevel = 1, ISequence = 999, ShotApp = "BPM", IconName = "BillPayment.png"     },
            new() { IMenuId = 500,  AppName = "scHr",          AppText = "ระบบบริหารงานบุคคล",              AppTextEnglish = "Human-Resources",  Active = false, ILevel = 1, ISequence = 999, ShotApp = "HR",  IconName = "Human-Resources.png" },
            new() { IMenuId = 285,  AppName = "scEdocument",   AppText = "ระบบ E-Document",                  AppTextEnglish = "E-document",       Active = false, ILevel = 1, ISequence = 999, ShotApp = "EDC", IconName = "e-document.png"      },
            new() { IMenuId = 557,  AppName = "scStock",       AppText = "ระบบวัสดุ",                        AppTextEnglish = "Stock-Resources",  Active = false, ILevel = 1, ISequence = 999, ShotApp = "STO", IconName = "Stock-Resources.png" },
            new() { IMenuId = 575,  AppName = "scEoffice",     AppText = "ระบบงานสารบรรณอิเล็กทรอนิกส์",   AppTextEnglish = "E-Office",         Active = false, ILevel = 1, ISequence = 999, ShotApp = "EOF", IconName = "e-Office.png"        },
            new() { IMenuId = 800,  AppName = "scInvestment",  AppText = "ระบบลงทุน",                        AppTextEnglish = "Investment",       Active = false, ILevel = 1, ISequence = 999, ShotApp = "INV", IconName = null                  },
            new() { IMenuId = 601,  AppName = "scRing2Me",     AppText = "ระบบ Ring2Me",                     AppTextEnglish = "Ring2Me",          Active = false, ILevel = 1, ISequence = 999, ShotApp = "R2M", IconName = "Ring2ME.png"         },
            // New modules not in legacy Oracle (added to new system)
            new() { IMenuId = 2000, AppName = "scScholarship", AppText = "ระบบทุนการศึกษา",                  AppTextEnglish = "Scholarship",      Active = true,  ILevel = 1, ISequence = 998, ShotApp = "SCH", IconName = "Scholarship.png"     },
            new() { IMenuId = 2001, AppName = "scCremation",   AppText = "ระบบฌาปนกิจ",                     AppTextEnglish = "Cremation",        Active = true,  ILevel = 1, ISequence = 997, ShotApp = "CRM", IconName = "Cremation.png"       },
        };

        db.SiSecurityApps.AddRange(apps);
        await db.SaveChangesAsync();
    }

    // seed ทั้ง level=2 (top bar) และ level=3 (dropdown items)
    static async Task SeedSecurityAppsLevel2FromOracleAsync(AppDbContext db, IConfiguration config)
    {
        if (await db.SiSecurityApps.AnyAsync(a => a.ILevel == 2)) return;

        try
        {
            await using var oraConn = new OracleConnection(OracleConnStr(config));
            await oraConn.OpenAsync();

            await using var cmd = oraConn.CreateCommand();
            cmd.CommandText = @"
                SELECT i_menu_id, i_parent_id, app_name, app_text, app_text_english,
                       active, i_level, NVL(i_sequence, 0), NVL(order_no, 0),
                       shot_app, icon_name, s_url, sub_app_name, remark
                FROM si_security_apps
                WHERE i_level IN (2, 3)
                ORDER BY i_level, i_sequence";

            await using var reader = await cmd.ExecuteReaderAsync();
            var items = new List<SiSecurityApp>();

            while (await reader.ReadAsync())
            {
                // columns: 0=i_menu_id, 1=i_parent_id, 2=app_name, 3=app_text,
                //          4=app_text_english, 5=active, 6=i_level, 7=i_sequence,
                //          8=order_no, 9=shot_app, 10=icon_name, 11=s_url,
                //          12=sub_app_name, 13=remark
                items.Add(new SiSecurityApp
                {
                    IMenuId        = (int)reader.GetDecimal(0),
                    IParentId      = reader.IsDBNull(1) ? null : (int)reader.GetDecimal(1),
                    AppName        = reader.IsDBNull(2)  ? null : reader.GetString(2),
                    AppText        = reader.IsDBNull(3)  ? null : reader.GetString(3),
                    AppTextEnglish = reader.IsDBNull(4)  ? null : reader.GetString(4),
                    Active         = !reader.IsDBNull(5) && reader.GetString(5) == "1",
                    ILevel         = (int)reader.GetDecimal(6),
                    ISequence      = reader.IsDBNull(7)  ? 0    : (int)reader.GetDecimal(7),
                    OrderNo        = reader.IsDBNull(8)  ? 0    : (int)reader.GetDecimal(8),
                    ShotApp        = reader.IsDBNull(9)  ? null : reader.GetString(9),
                    IconName       = reader.IsDBNull(10) ? null : reader.GetString(10),
                    SUrl           = reader.IsDBNull(11) ? null : reader.GetString(11),
                    SubAppName     = reader.IsDBNull(12) ? null : reader.GetString(12),
                    Remark         = reader.IsDBNull(13) ? null : reader.GetString(13),
                });
            }

            if (items.Count > 0)
            {
                db.SiSecurityApps.AddRange(items);
                await db.SaveChangesAsync();
            }
        }
        catch
        {
            // Oracle not reachable — level 2 menus will be empty
        }
    }

    // seed level=3 (dropdown sub-items)
    // force=false → skip ถ้ามีอยู่แล้ว
    // force=true  → ลบแล้ว insert ใหม่จาก Oracle (ใช้จาก /api/sc/sync-menu)
    public static async Task SeedSecurityAppsLevel3FromOracleAsync(
        AppDbContext db, IConfiguration config, bool force = false)
    {
        if (!force && await db.SiSecurityApps.AnyAsync(a => a.ILevel == 3)) return;
        if (force)
        {
            var old = db.SiSecurityApps.Where(a => a.ILevel == 3);
            db.SiSecurityApps.RemoveRange(old);
            await db.SaveChangesAsync();
        }

        try
        {
            await using var oraConn = new OracleConnection(OracleConnStr(config));
            await oraConn.OpenAsync();

            await using var cmd = oraConn.CreateCommand();
            cmd.CommandText = @"
                SELECT i_menu_id, i_parent_id, app_name, app_text, app_text_english,
                       active, i_level, NVL(i_sequence, 0), NVL(order_no, 0),
                       shot_app, icon_name, s_url, sub_app_name, remark
                FROM si_security_apps
                WHERE i_level = 3
                ORDER BY app_name, i_sequence";

            await using var reader = await cmd.ExecuteReaderAsync();
            var items = new List<SiSecurityApp>();

            while (await reader.ReadAsync())
            {
                items.Add(new SiSecurityApp
                {
                    IMenuId        = (int)reader.GetDecimal(0),
                    IParentId      = reader.IsDBNull(1)  ? null : (int)reader.GetDecimal(1),
                    AppName        = reader.IsDBNull(2)  ? null : reader.GetString(2),
                    AppText        = reader.IsDBNull(3)  ? null : reader.GetString(3),
                    AppTextEnglish = reader.IsDBNull(4)  ? null : reader.GetString(4),
                    Active         = !reader.IsDBNull(5) && reader.GetString(5) == "1",
                    ILevel         = (int)reader.GetDecimal(6),
                    ISequence      = reader.IsDBNull(7)  ? 0    : (int)reader.GetDecimal(7),
                    OrderNo        = reader.IsDBNull(8)  ? 0    : (int)reader.GetDecimal(8),
                    ShotApp        = reader.IsDBNull(9)  ? null : reader.GetString(9),
                    IconName       = reader.IsDBNull(10) ? null : reader.GetString(10),
                    SUrl           = reader.IsDBNull(11) ? null : reader.GetString(11),
                    SubAppName     = reader.IsDBNull(12) ? null : reader.GetString(12),
                    Remark         = reader.IsDBNull(13) ? null : reader.GetString(13),
                });
            }

            if (items.Count > 0)
            {
                db.SiSecurityApps.AddRange(items);
                await db.SaveChangesAsync();
            }
        }
        catch
        {
            // Oracle not reachable — level 3 dropdown menus will be empty
        }
    }

    static async Task SeedSecurityUsersFromOracleAsync(AppDbContext db, IConfiguration config)
    {
        if (await db.SiSecurityUsers.AnyAsync()) return;

        try
        {
            await using var oraConn = new OracleConnection(OracleConnStr(config));
            await oraConn.OpenAsync();

            await using var cmd = oraConn.CreateCommand();
            cmd.CommandText =
                "SELECT user_id, user_name, branch_id, passwords, close_status, group_id, programmer, admin_mode, counter_split " +
                "FROM si_security_user";

            await using var reader = await cmd.ExecuteReaderAsync();
            var users = new List<SiSecurityUser>();

            while (await reader.ReadAsync())
            {
                users.Add(new SiSecurityUser
                {
                    UserId      = reader.GetString(0),
                    UserName    = reader.IsDBNull(1) ? null : reader.GetString(1),
                    BranchId    = reader.IsDBNull(2) ? null : reader.GetString(2),
                    Passwords   = reader.IsDBNull(3) ? null : reader.GetString(3),
                    CloseStatus  = reader.IsDBNull(4) ? "0" : reader.GetString(4),
                    GroupId      = reader.IsDBNull(5) ? null : reader.GetString(5),
                    Programmer   = reader.IsDBNull(6) ? null : reader.GetString(6),
                    AdminMode    = reader.IsDBNull(7) ? null : reader.GetString(7),
                    CounterSplit = reader.IsDBNull(8) ? null : reader.GetString(8),
                });
            }

            if (users.Count > 0)
            {
                db.SiSecurityUsers.AddRange(users);
                await db.SaveChangesAsync();
            }
        }
        catch
        {
            // Oracle not reachable — si_security_user will remain empty
        }
    }

    // ── sync counter_split (อัปเดต rows ที่ NULL — ใช้ตอน column ถูก add ทีหลัง) ──
    static async Task SyncCounterSplitFromOracleAsync(AppDbContext db, IConfiguration config)
    {
        // ถ้าทุก row มี counter_split แล้ว ไม่ต้องทำอะไร
        if (!await db.SiSecurityUsers.AnyAsync(u => u.CounterSplit == null)) return;

        try
        {
            await using var oraConn = new OracleConnection(OracleConnStr(config));
            await oraConn.OpenAsync();

            await using var cmd = oraConn.CreateCommand();
            cmd.CommandText = "SELECT user_id, counter_split FROM si_security_user";

            await using var reader = await cmd.ExecuteReaderAsync();
            var map = new Dictionary<string, string?>();
            while (await reader.ReadAsync())
            {
                var uid = reader.GetString(0);
                var cs  = reader.IsDBNull(1) ? null : reader.GetString(1);
                map[uid] = cs;
            }

            // batch update ใน EF
            var users = await db.SiSecurityUsers
                .Where(u => u.CounterSplit == null)
                .ToListAsync();

            foreach (var u in users)
                if (map.TryGetValue(u.UserId, out var cs))
                    u.CounterSplit = cs;

            await db.SaveChangesAsync();
        }
        catch
        {
            // Oracle not reachable — counter_split stays null (treated as '0')
        }
    }

    // ── sc_com_m_branch ───────────────────────────────────────────────────────
    static async Task SeedBranchesFromOracleAsync(AppDbContext db, IConfiguration config)
    {
        if (await db.ScComMBranches.AnyAsync()) return;
        try
        {
            await using var conn = new OracleConnection(OracleConnStr(config));
            await conn.OpenAsync();
            await using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                SELECT branch_id, branch_name, base_status, postto_fin,
                       account_control, picture_2file, finance_branch
                FROM sc_com_m_branch
                ORDER BY branch_id";

            var branches = new List<ScComMBranch>();
            await using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                branches.Add(new ScComMBranch
                {
                    BranchId       = reader.GetString(0),
                    BranchName     = reader.IsDBNull(1) ? null : reader.GetString(1),
                    BaseStatus     = reader.IsDBNull(2) ? null : reader.GetString(2),
                    PosttoFin      = reader.IsDBNull(3) ? null : reader.GetString(3),
                    AccountControl = reader.IsDBNull(4) ? null : reader.GetString(4),
                    Picture2file   = reader.IsDBNull(5) ? null : reader.GetString(5),
                    FinanceBranch  = reader.IsDBNull(6) ? null : reader.GetString(6),
                });
            }

            if (branches.Count > 0)
            {
                db.ScComMBranches.AddRange(branches);
                await db.SaveChangesAsync();
            }
        }
        catch
        {
            // Oracle not reachable — sc_com_m_branch will remain empty
        }
    }

    // ── sc_fin_m_constant ─────────────────────────────────────────────────────
    static async Task SeedFinConstantFromOracleAsync(AppDbContext db, IConfiguration config)
    {
        if (await db.ScFinMConstants.AnyAsync()) return;
        try
        {
            await using var conn = new OracleConnection(OracleConnStr(config));
            await conn.OpenAsync();
            await using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT coop_no, finance_date FROM sc_fin_m_constant";

            await using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                db.ScFinMConstants.Add(new ScFinMConstant
                {
                    CoopNo       = reader.GetString(0),
                    FinanceDate  = reader.IsDBNull(1) ? null : reader.GetDateTime(1),
                });
                await db.SaveChangesAsync();
            }
        }
        catch
        {
            // Oracle not reachable — sc_fin_m_constant will remain empty
        }
    }

    // ── Mem UCF lookup tables + sc_cnt_m_coop ──────────────────────────────────
    // เปิด Oracle connection ครั้งเดียว แล้ว seed ทุก lookup table ของ sctelnewbma
    static async Task SeedMemUcfFromOracleAsync(AppDbContext db, IConfiguration config)
    {
        // ตรวจว่ามีตาราง UCF ที่ยังไม่มีข้อมูลหรือไม่
        bool anyNeeded =
            !await db.ScMemMUcfPrenames.AnyAsync()          ||
            !await db.ScMemMUcfMemberTypes.AnyAsync()       ||
            !await db.ScMemMUcfMemberGroups.AnyAsync()      ||
            !await db.ScMemMUcfElectionGroups.AnyAsync()    ||
            !await db.ScMemMUcfNationalities.AnyAsync()     ||
            !await db.ScMemMUcfMarriageStatuses.AnyAsync()  ||
            !await db.ScMemMUcfBloods.AnyAsync()            ||
            !await db.ScMemMUcfProvinces.AnyAsync()         ||
            !await db.ScMemMUcfDistricts.AnyAsync()         ||
            !await db.ScMemMUcfSubdistricts.AnyAsync()      ||
            !await db.ScMemMUcfApplicationTypes.AnyAsync()  ||
            !await db.ScMemMUcfConcerns.AnyAsync()          ||
            !await db.ScMemMUcfGroupPositions.AnyAsync()    ||
            !await db.ScMemMUcfPositions.AnyAsync()         ||
            !await db.ScCntMCoops.AnyAsync();

        if (!anyNeeded) return;

        try
        {
            await using var conn = new OracleConnection(OracleConnStr(config));
            await conn.OpenAsync();

            // ── sc_mem_m_ucf_prename ──────────────────────────────────────────
            if (!await db.ScMemMUcfPrenames.AnyAsync())
            {
                await using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT prename_code, prename, sex, marriage_status FROM sc_mem_m_ucf_prename ORDER BY prename_code";
                await using var r = await cmd.ExecuteReaderAsync();
                var rows = new List<ScMemMUcfPrename>();
                while (await r.ReadAsync())
                    rows.Add(new ScMemMUcfPrename
                    {
                        PrenameCode    = r.GetString(0),
                        Prename        = r.IsDBNull(1) ? null : r.GetString(1),
                        Sex            = r.IsDBNull(2) ? null : r.GetString(2),
                        MarriageStatus = r.IsDBNull(3) ? null : r.GetString(3),
                    });
                if (rows.Count > 0) { db.ScMemMUcfPrenames.AddRange(rows); await db.SaveChangesAsync(); }
            }

            // ── sc_mem_m_ucf_member_type ──────────────────────────────────────
            if (!await db.ScMemMUcfMemberTypes.AnyAsync())
            {
                await using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT mem_type_code, mem_type_desc, maximun_share, not_salary, mproc_apart FROM sc_mem_m_ucf_member_type ORDER BY mem_type_code";
                await using var r = await cmd.ExecuteReaderAsync();
                var rows = new List<ScMemMUcfMemberType>();
                while (await r.ReadAsync())
                    rows.Add(new ScMemMUcfMemberType
                    {
                        MemTypeCode  = r.GetString(0),
                        MemTypeDesc  = r.IsDBNull(1) ? null : r.GetString(1),
                        MaximunShare = r.IsDBNull(2) ? null : r.GetDecimal(2),
                        NotSalary    = r.IsDBNull(3) ? null : r.GetString(3),
                        MprocApart   = r.IsDBNull(4) ? null : r.GetString(4),
                    });
                if (rows.Count > 0) { db.ScMemMUcfMemberTypes.AddRange(rows); await db.SaveChangesAsync(); }
            }

            // ── sc_mem_m_ucf_member_group ─────────────────────────────────────
            if (!await db.ScMemMUcfMemberGroups.AnyAsync())
            {
                await using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT member_group_no, member_group_name, mem_type_default, not_sal, ingore_dropshr_rule FROM sc_mem_m_ucf_member_group ORDER BY member_group_no";
                await using var r = await cmd.ExecuteReaderAsync();
                var rows = new List<ScMemMUcfMemberGroup>();
                while (await r.ReadAsync())
                    rows.Add(new ScMemMUcfMemberGroup
                    {
                        MemberGroupNo      = r.GetString(0),
                        MemberGroupName    = r.IsDBNull(1) ? null : r.GetString(1),
                        MemTypeDefault     = r.IsDBNull(2) ? null : r.GetString(2),
                        NotSal             = r.IsDBNull(3) ? null : r.GetString(3),
                        IngoreDropshrRule  = r.IsDBNull(4) ? null : r.GetString(4),
                    });
                if (rows.Count > 0) { db.ScMemMUcfMemberGroups.AddRange(rows); await db.SaveChangesAsync(); }
            }

            // ── sc_mem_m_ucf_election_group ───────────────────────────────────
            if (!await db.ScMemMUcfElectionGroups.AnyAsync())
            {
                await using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT election_group, election_group_name, election_zone FROM sc_mem_m_ucf_election_group ORDER BY election_group";
                await using var r = await cmd.ExecuteReaderAsync();
                var rows = new List<ScMemMUcfElectionGroup>();
                while (await r.ReadAsync())
                    rows.Add(new ScMemMUcfElectionGroup
                    {
                        ElectionGroup     = r.GetString(0),
                        ElectionGroupName = r.IsDBNull(1) ? null : r.GetString(1),
                        ElectionZone      = r.IsDBNull(2) ? null : r.GetString(2),
                    });
                if (rows.Count > 0) { db.ScMemMUcfElectionGroups.AddRange(rows); await db.SaveChangesAsync(); }
            }

            // ── sc_mem_m_ucf_nationality ──────────────────────────────────────
            if (!await db.ScMemMUcfNationalities.AnyAsync())
            {
                await using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT nationality_code, nationality_description FROM sc_mem_m_ucf_nationality ORDER BY nationality_code";
                await using var r = await cmd.ExecuteReaderAsync();
                var rows = new List<ScMemMUcfNationality>();
                while (await r.ReadAsync())
                    rows.Add(new ScMemMUcfNationality
                    {
                        NationalityCode        = r.GetString(0),
                        NationalityDescription = r.IsDBNull(1) ? null : r.GetString(1),
                    });
                if (rows.Count > 0) { db.ScMemMUcfNationalities.AddRange(rows); await db.SaveChangesAsync(); }
            }

            // ── sc_mem_m_ucf_marriage_status ──────────────────────────────────
            // Oracle column: marriage_status_code (PK), marriage_status (description — not marriage_status_name)
            if (!await db.ScMemMUcfMarriageStatuses.AnyAsync())
            {
                await using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT marriage_status_code, marriage_status FROM sc_mem_m_ucf_marriage_status ORDER BY marriage_status_code";
                await using var r = await cmd.ExecuteReaderAsync();
                var rows = new List<ScMemMUcfMarriageStatus>();
                while (await r.ReadAsync())
                    rows.Add(new ScMemMUcfMarriageStatus
                    {
                        MarriageStatusCode = r.GetString(0),
                        MarriageStatusName = r.IsDBNull(1) ? null : r.GetString(1),
                    });
                if (rows.Count > 0) { db.ScMemMUcfMarriageStatuses.AddRange(rows); await db.SaveChangesAsync(); }
            }

            // ── sc_mem_m_ucf_blood ────────────────────────────────────────────
            if (!await db.ScMemMUcfBloods.AnyAsync())
            {
                await using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT blood_code, blood_desc FROM sc_mem_m_ucf_blood ORDER BY blood_code";
                await using var r = await cmd.ExecuteReaderAsync();
                var rows = new List<ScMemMUcfBlood>();
                while (await r.ReadAsync())
                    rows.Add(new ScMemMUcfBlood
                    {
                        BloodCode = r.GetString(0),
                        BloodDesc = r.IsDBNull(1) ? null : r.GetString(1),
                    });
                if (rows.Count > 0) { db.ScMemMUcfBloods.AddRange(rows); await db.SaveChangesAsync(); }
            }

            // ── sc_mem_m_ucf_province ─────────────────────────────────────────
            if (!await db.ScMemMUcfProvinces.AnyAsync())
            {
                await using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT province_code, province_name FROM sc_mem_m_ucf_province ORDER BY province_code";
                await using var r = await cmd.ExecuteReaderAsync();
                var rows = new List<ScMemMUcfProvince>();
                while (await r.ReadAsync())
                    rows.Add(new ScMemMUcfProvince
                    {
                        ProvinceCode = r.GetString(0),
                        ProvinceName = r.IsDBNull(1) ? null : r.GetString(1),
                    });
                if (rows.Count > 0) { db.ScMemMUcfProvinces.AddRange(rows); await db.SaveChangesAsync(); }
            }

            // ── sc_mem_m_ucf_district ─────────────────────────────────────────
            if (!await db.ScMemMUcfDistricts.AnyAsync())
            {
                await using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT district_code, district_name, province_code, post_code FROM sc_mem_m_ucf_district ORDER BY district_code";
                await using var r = await cmd.ExecuteReaderAsync();
                var rows = new List<ScMemMUcfDistrict>();
                while (await r.ReadAsync())
                    rows.Add(new ScMemMUcfDistrict
                    {
                        DistrictCode = r.GetString(0),
                        DistrictName = r.IsDBNull(1) ? null : r.GetString(1),
                        ProvinceCode = r.IsDBNull(2) ? null : r.GetString(2),
                        PostCode     = r.IsDBNull(3) ? null : r.GetString(3),
                    });
                if (rows.Count > 0) { db.ScMemMUcfDistricts.AddRange(rows); await db.SaveChangesAsync(); }
            }

            // ── sc_mem_m_ucf_subdistrict ──────────────────────────────────────
            if (!await db.ScMemMUcfSubdistricts.AnyAsync())
            {
                await using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT subdistrict_code, subdistrict_name, district_code FROM sc_mem_m_ucf_subdistrict ORDER BY subdistrict_code";
                await using var r = await cmd.ExecuteReaderAsync();
                var rows = new List<ScMemMUcfSubdistrict>();
                while (await r.ReadAsync())
                    rows.Add(new ScMemMUcfSubdistrict
                    {
                        SubdistrictCode = r.GetString(0),
                        SubdistrictName = r.IsDBNull(1) ? null : r.GetString(1),
                        DistrictCode    = r.IsDBNull(2) ? null : r.GetString(2),
                    });
                if (rows.Count > 0) { db.ScMemMUcfSubdistricts.AddRange(rows); await db.SaveChangesAsync(); }
            }

            // ── sc_mem_m_ucf_application_type ─────────────────────────────────
            if (!await db.ScMemMUcfApplicationTypes.AnyAsync())
            {
                await using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT appl_type_code, appl_type_name, application_fee, mem_type_code FROM sc_mem_m_ucf_application_type ORDER BY appl_type_code";
                await using var r = await cmd.ExecuteReaderAsync();
                var rows = new List<ScMemMUcfApplicationType>();
                while (await r.ReadAsync())
                    rows.Add(new ScMemMUcfApplicationType
                    {
                        ApplTypeCode   = r.GetString(0),
                        ApplTypeName   = r.IsDBNull(1) ? null : r.GetString(1),
                        ApplicationFee = r.IsDBNull(2) ? null : r.GetDecimal(2),
                        MemTypeCode    = r.IsDBNull(3) ? null : r.GetString(3),
                    });
                if (rows.Count > 0) { db.ScMemMUcfApplicationTypes.AddRange(rows); await db.SaveChangesAsync(); }
            }

            // ── sc_mem_m_ucf_concern ──────────────────────────────────────────
            // Oracle PK column: conceern_code (typo) → PostgreSQL: concern_code (fixed)
            if (!await db.ScMemMUcfConcerns.AnyAsync())
            {
                await using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT conceern_code, related_na FROM sc_mem_m_ucf_concern ORDER BY sort_order";
                await using var r = await cmd.ExecuteReaderAsync();
                var rows = new List<ScMemMUcfConcern>();
                while (await r.ReadAsync())
                    rows.Add(new ScMemMUcfConcern
                    {
                        ConcernCode = r.GetString(0),
                        RelatedNa   = r.IsDBNull(1) ? null : r.GetString(1),
                    });
                if (rows.Count > 0) { db.ScMemMUcfConcerns.AddRange(rows); await db.SaveChangesAsync(); }
            }

            // ── sc_mem_m_ucf_group_position ───────────────────────────────────
            if (!await db.ScMemMUcfGroupPositions.AnyAsync())
            {
                await using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT group_position, description, NVL(sort_order, 0) FROM sc_mem_m_ucf_group_position ORDER BY sort_order";
                await using var r = await cmd.ExecuteReaderAsync();
                var rows = new List<ScMemMUcfGroupPosition>();
                while (await r.ReadAsync())
                    rows.Add(new ScMemMUcfGroupPosition
                    {
                        GroupPosition = r.GetString(0),
                        Description   = r.IsDBNull(1) ? null : r.GetString(1),
                        SortOrder     = r.IsDBNull(2) ? null : (int)r.GetDecimal(2),
                    });
                if (rows.Count > 0) { db.ScMemMUcfGroupPositions.AddRange(rows); await db.SaveChangesAsync(); }
            }

            // ── sc_mem_m_ucf_position ─────────────────────────────────────────
            if (!await db.ScMemMUcfPositions.AnyAsync())
            {
                await using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT position_code, position_name, NVL(sort_order, 0) FROM sc_mem_m_ucf_position ORDER BY sort_order";
                await using var r = await cmd.ExecuteReaderAsync();
                var rows = new List<ScMemMUcfPosition>();
                while (await r.ReadAsync())
                    rows.Add(new ScMemMUcfPosition
                    {
                        PositionCode = r.GetString(0),
                        PositionName = r.IsDBNull(1) ? null : r.GetString(1),
                        SortOrder    = r.IsDBNull(2) ? null : (int)r.GetDecimal(2),
                    });
                if (rows.Count > 0) { db.ScMemMUcfPositions.AddRange(rows); await db.SaveChangesAsync(); }
            }

            // ── sc_cnt_m_coop (single-row config) ─────────────────────────────
            if (!await db.ScCntMCoops.AnyAsync())
            {
                await using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT coop_no, count_resign, auto_approve_newmem, mem_type_ongroup FROM sc_cnt_m_coop";
                await using var r = await cmd.ExecuteReaderAsync();
                if (await r.ReadAsync())
                {
                    db.ScCntMCoops.Add(new ScCntMCoop
                    {
                        CoopNo            = r.GetString(0),
                        CountResign       = r.IsDBNull(1) ? null : (int)r.GetDecimal(1),
                        AutoApproveNewmem = r.IsDBNull(2) ? null : r.GetString(2),
                        MemTypeOngroup    = r.IsDBNull(3) ? null : r.GetString(3),
                    });
                    await db.SaveChangesAsync();
                }
            }
        }
        catch
        {
            // Oracle not reachable — UCF lookup tables will remain empty
        }
    }
}
