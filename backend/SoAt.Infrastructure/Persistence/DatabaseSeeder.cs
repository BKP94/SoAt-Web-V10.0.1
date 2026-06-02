using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Npgsql;
using Oracle.ManagedDataAccess.Client;
using SoAt.Domain.Entities.System;

namespace SoAt.Infrastructure.Persistence;

public static class DatabaseSeeder
{
    static string OracleConnStr(IConfiguration config) =>
        config.GetConnectionString("OracleConnection") ?? "";

    static string PgConnStr(IConfiguration config) =>
        config.GetConnectionString("DefaultConnection")!;

    public static async Task SeedAsync(AppDbContext db, IConfiguration config)
    {
        await SeedSecurityAppsAsync(db);
        await SeedSecurityAppsLevel2FromOracleAsync(db, config);
        await SeedSecurityAppsLevel3FromOracleAsync(db, config);
        await SeedSecurityUsersFromOracleAsync(db, config);
        await SyncCounterSplitFromOracleAsync(db, config);
        await SeedBranchesFromOracleAsync(config);
        await SeedFinConstantFromOracleAsync(config);
        await SeedMemUcfFromOracleAsync(config);
    }

    static async Task SeedSecurityAppsAsync(AppDbContext db)
    {
        if (await db.SiSecurityApps.AnyAsync()) return;

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
            new() { IMenuId = 2000, AppName = "scScholarship", AppText = "ระบบทุนการศึกษา",                  AppTextEnglish = "Scholarship",      Active = true,  ILevel = 1, ISequence = 998, ShotApp = "SCH", IconName = "Scholarship.png"     },
            new() { IMenuId = 2001, AppName = "scCremation",   AppText = "ระบบฌาปนกิจ",                     AppTextEnglish = "Cremation",        Active = true,  ILevel = 1, ISequence = 997, ShotApp = "CRM", IconName = "Cremation.png"       },
        };

        db.SiSecurityApps.AddRange(apps);
        await db.SaveChangesAsync();
    }

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
                    UserId       = reader.GetString(0),
                    UserName     = reader.IsDBNull(1) ? null : reader.GetString(1),
                    BranchId     = reader.IsDBNull(2) ? null : reader.GetString(2),
                    Passwords    = reader.IsDBNull(3) ? null : reader.GetString(3),
                    CloseStatus  = reader.IsDBNull(4) ? "0"  : reader.GetString(4),
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

    static async Task SyncCounterSplitFromOracleAsync(AppDbContext db, IConfiguration config)
    {
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
                map[reader.GetString(0)] = reader.IsDBNull(1) ? null : reader.GetString(1);

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

    // ── sc_com_m_branch ────────────────────────────────────────────────────────
    static async Task SeedBranchesFromOracleAsync(IConfiguration config)
    {
        try
        {
            await using var pg = new NpgsqlConnection(PgConnStr(config));
            await pg.OpenAsync();

            await using var check = new NpgsqlCommand("SELECT COUNT(*) FROM sc_com_m_branch", pg);
            if ((long)(await check.ExecuteScalarAsync())! > 0) return;

            await using var oraConn = new OracleConnection(OracleConnStr(config));
            await oraConn.OpenAsync();
            await using var cmd = oraConn.CreateCommand();
            cmd.CommandText = @"
                SELECT branch_id, branch_name, base_status, postto_fin,
                       account_control, picture_2file, finance_branch
                FROM sc_com_m_branch
                ORDER BY branch_id";

            await using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                await using var ins = new NpgsqlCommand(
                    "INSERT INTO sc_com_m_branch (branch_id, branch_name, base_status, postto_fin, account_control, picture_2file, finance_branch) " +
                    "VALUES (@b0,@b1,@b2,@b3,@b4,@b5,@b6) ON CONFLICT DO NOTHING", pg);
                ins.Parameters.AddWithValue("b0", reader.GetString(0));
                ins.Parameters.AddWithValue("b1", reader.IsDBNull(1) ? DBNull.Value : reader.GetString(1));
                ins.Parameters.AddWithValue("b2", reader.IsDBNull(2) ? DBNull.Value : reader.GetString(2));
                ins.Parameters.AddWithValue("b3", reader.IsDBNull(3) ? DBNull.Value : reader.GetString(3));
                ins.Parameters.AddWithValue("b4", reader.IsDBNull(4) ? DBNull.Value : reader.GetString(4));
                ins.Parameters.AddWithValue("b5", reader.IsDBNull(5) ? DBNull.Value : reader.GetString(5));
                ins.Parameters.AddWithValue("b6", reader.IsDBNull(6) ? DBNull.Value : reader.GetString(6));
                await ins.ExecuteNonQueryAsync();
            }
        }
        catch
        {
            // Oracle not reachable or table not yet created — skip silently
        }
    }

    // ── sc_fin_m_constant ──────────────────────────────────────────────────────
    static async Task SeedFinConstantFromOracleAsync(IConfiguration config)
    {
        try
        {
            await using var pg = new NpgsqlConnection(PgConnStr(config));
            await pg.OpenAsync();

            await using var check = new NpgsqlCommand("SELECT COUNT(*) FROM sc_fin_m_constant", pg);
            if ((long)(await check.ExecuteScalarAsync())! > 0) return;

            await using var oraConn = new OracleConnection(OracleConnStr(config));
            await oraConn.OpenAsync();
            await using var cmd = oraConn.CreateCommand();
            cmd.CommandText = "SELECT coop_no, finance_date FROM sc_fin_m_constant";

            await using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                await using var ins = new NpgsqlCommand(
                    "INSERT INTO sc_fin_m_constant (coop_no, finance_date) VALUES (@c0,@c1) ON CONFLICT DO NOTHING", pg);
                ins.Parameters.AddWithValue("c0", reader.GetString(0));
                ins.Parameters.AddWithValue("c1", reader.IsDBNull(1) ? DBNull.Value : reader.GetDateTime(1));
                await ins.ExecuteNonQueryAsync();
            }
        }
        catch
        {
            // Oracle not reachable or table not yet created — skip silently
        }
    }

    // ── Mem UCF lookup tables + sc_cnt_m_coop ─────────────────────────────────
    static async Task SeedMemUcfFromOracleAsync(IConfiguration config)
    {
        try
        {
            await using var pg = new NpgsqlConnection(PgConnStr(config));
            await pg.OpenAsync();

            await using var oraConn = new OracleConnection(OracleConnStr(config));
            await oraConn.OpenAsync();

            await SeedSimple2ColAsync(pg, oraConn,
                "sc_mem_m_ucf_prename",
                "SELECT prename_code, prename, sex, marriage_status FROM sc_mem_m_ucf_prename ORDER BY prename_code",
                "INSERT INTO sc_mem_m_ucf_prename (prename_code, prename, sex, marriage_status) VALUES (@c0,@c1,@c2,@c3) ON CONFLICT DO NOTHING",
                4);

            await SeedSimple2ColAsync(pg, oraConn,
                "sc_mem_m_ucf_member_type",
                "SELECT mem_type_code, mem_type_desc, maximun_share, not_salary, mproc_apart FROM sc_mem_m_ucf_member_type ORDER BY mem_type_code",
                "INSERT INTO sc_mem_m_ucf_member_type (mem_type_code, mem_type_desc, maximun_share, not_salary, mproc_apart) VALUES (@c0,@c1,@c2,@c3,@c4) ON CONFLICT DO NOTHING",
                5);

            await SeedSimple2ColAsync(pg, oraConn,
                "sc_mem_m_ucf_member_group",
                "SELECT member_group_no, member_group_name, mem_type_default, not_sal, ingore_dropshr_rule FROM sc_mem_m_ucf_member_group ORDER BY member_group_no",
                "INSERT INTO sc_mem_m_ucf_member_group (member_group_no, member_group_name, mem_type_default, not_sal, ingore_dropshr_rule) VALUES (@c0,@c1,@c2,@c3,@c4) ON CONFLICT DO NOTHING",
                5);

            await SeedSimple2ColAsync(pg, oraConn,
                "sc_mem_m_ucf_election_group",
                "SELECT election_group, election_group_name, election_zone FROM sc_mem_m_ucf_election_group ORDER BY election_group",
                "INSERT INTO sc_mem_m_ucf_election_group (election_group, election_group_name, election_zone) VALUES (@c0,@c1,@c2) ON CONFLICT DO NOTHING",
                3);

            await SeedSimple2ColAsync(pg, oraConn,
                "sc_mem_m_ucf_nationality",
                "SELECT nationality_code, nationality_description FROM sc_mem_m_ucf_nationality ORDER BY nationality_code",
                "INSERT INTO sc_mem_m_ucf_nationality (nationality_code, nationality_description) VALUES (@c0,@c1) ON CONFLICT DO NOTHING",
                2);

            await SeedSimple2ColAsync(pg, oraConn,
                "sc_mem_m_ucf_marriage_status",
                "SELECT marriage_status_code, marriage_status FROM sc_mem_m_ucf_marriage_status ORDER BY marriage_status_code",
                "INSERT INTO sc_mem_m_ucf_marriage_status (marriage_status_code, marriage_status) VALUES (@c0,@c1) ON CONFLICT DO NOTHING",
                2);

            await SeedSimple2ColAsync(pg, oraConn,
                "sc_mem_m_ucf_blood",
                "SELECT blood_code, blood_desc FROM sc_mem_m_ucf_blood ORDER BY blood_code",
                "INSERT INTO sc_mem_m_ucf_blood (blood_code, blood_desc) VALUES (@c0,@c1) ON CONFLICT DO NOTHING",
                2);

            await SeedSimple2ColAsync(pg, oraConn,
                "sc_mem_m_ucf_province",
                "SELECT province_code, province_name FROM sc_mem_m_ucf_province ORDER BY province_code",
                "INSERT INTO sc_mem_m_ucf_province (province_code, province_name) VALUES (@c0,@c1) ON CONFLICT DO NOTHING",
                2);

            await SeedSimple2ColAsync(pg, oraConn,
                "sc_mem_m_ucf_district",
                "SELECT district_code, district_name, province_code, post_code FROM sc_mem_m_ucf_district ORDER BY district_code",
                "INSERT INTO sc_mem_m_ucf_district (district_code, district_name, province_code, post_code) VALUES (@c0,@c1,@c2,@c3) ON CONFLICT DO NOTHING",
                4);

            await SeedSimple2ColAsync(pg, oraConn,
                "sc_mem_m_ucf_subdistrict",
                "SELECT subdistrict_code, subdistrict_name, district_code FROM sc_mem_m_ucf_subdistrict ORDER BY subdistrict_code",
                "INSERT INTO sc_mem_m_ucf_subdistrict (subdistrict_code, subdistrict_name, district_code) VALUES (@c0,@c1,@c2) ON CONFLICT DO NOTHING",
                3);

            await SeedSimple2ColAsync(pg, oraConn,
                "sc_mem_m_ucf_application_type",
                "SELECT appl_type_code, appl_type_name, application_fee, mem_type_code FROM sc_mem_m_ucf_application_type ORDER BY appl_type_code",
                "INSERT INTO sc_mem_m_ucf_application_type (appl_type_code, appl_type_name, application_fee, mem_type_code) VALUES (@c0,@c1,@c2,@c3) ON CONFLICT DO NOTHING",
                4);

            await SeedSimple2ColAsync(pg, oraConn,
                "sc_mem_m_ucf_concern",
                "SELECT conceern_code, related_na FROM sc_mem_m_ucf_concern ORDER BY sort_order",
                "INSERT INTO sc_mem_m_ucf_concern (concern_code, related_na) VALUES (@c0,@c1) ON CONFLICT DO NOTHING",
                2);

            await SeedSimple2ColAsync(pg, oraConn,
                "sc_mem_m_ucf_group_position",
                "SELECT group_position, description, NVL(sort_order, 0) FROM sc_mem_m_ucf_group_position ORDER BY sort_order",
                "INSERT INTO sc_mem_m_ucf_group_position (group_position, description, sort_order) VALUES (@c0,@c1,@c2) ON CONFLICT DO NOTHING",
                3);

            await SeedSimple2ColAsync(pg, oraConn,
                "sc_mem_m_ucf_position",
                "SELECT position_code, position_name, NVL(sort_order, 0) FROM sc_mem_m_ucf_position ORDER BY sort_order",
                "INSERT INTO sc_mem_m_ucf_position (position_code, position_name, sort_order) VALUES (@c0,@c1,@c2) ON CONFLICT DO NOTHING",
                3);

            await SeedSimple2ColAsync(pg, oraConn,
                "sc_cnt_m_coop",
                "SELECT coop_no, count_resign, auto_approve_newmem, mem_type_ongroup FROM sc_cnt_m_coop",
                "INSERT INTO sc_cnt_m_coop (coop_no, count_resign, auto_approve_newmem, mem_type_ongroup) VALUES (@c0,@c1,@c2,@c3) ON CONFLICT DO NOTHING",
                4);
        }
        catch
        {
            // Oracle not reachable or tables not yet created — skip silently
        }
    }

    // Generic helper: check if pg table is empty, then stream Oracle rows into it
    static async Task SeedSimple2ColAsync(
        NpgsqlConnection pg, OracleConnection oraConn,
        string pgTable, string oraSql, string pgInsertSql, int colCount)
    {
        try
        {
            await using var check = new NpgsqlCommand($"SELECT COUNT(*) FROM {pgTable}", pg);
            if ((long)(await check.ExecuteScalarAsync())! > 0) return;

            await using var cmd = oraConn.CreateCommand();
            cmd.CommandText = oraSql;
            await using var r = await cmd.ExecuteReaderAsync();

            while (await r.ReadAsync())
            {
                await using var ins = new NpgsqlCommand(pgInsertSql, pg);
                for (int i = 0; i < colCount; i++)
                    ins.Parameters.AddWithValue($"c{i}", r.IsDBNull(i) ? DBNull.Value : r.GetValue(i));
                await ins.ExecuteNonQueryAsync();
            }
        }
        catch
        {
            // Table not yet created by TableDeployer — skip silently
        }
    }
}
