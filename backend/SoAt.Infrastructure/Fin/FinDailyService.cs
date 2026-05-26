using Dapper;
using SoAt.Application.Fin;
using SoAt.Infrastructure.Persistence;

namespace SoAt.Infrastructure.Fin;

/// <summary>
/// Thin wrapper — logic ทั้งหมดอยู่ใน PostgreSQL functions
/// PL team ดูแล: Database/Functions/pka_fin_daily/
/// Dev team ดูแล: file นี้ (แค่ call function + map result)
/// </summary>
public class FinDailyService(IDbConnectionFactory db) : IFinDailyService
{
    // Oracle: pka_fin_daily.fp_finance_date
    // PostgreSQL function: fp_finance_date(p_ignore => true)
    public async Task<DateTime?> GetFinanceDateAsync()
    {
        using var conn = await db.CreateAsync();
        return await conn.QuerySingleOrDefaultAsync<DateTime?>(
            "SELECT fp_finance_date(true)");
    }

    // Oracle: pka_fin_daily.fp_counter_opened
    // PostgreSQL function: fp_counter_opened()
    // ต้อง set session variables ก่อน (แทน pka_com_login package)
    public async Task<bool> IsCounterOpenedAsync(string userId, string branchId)
    {
        if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(branchId))
            return false;

        using var conn = await db.CreateAsync(userId, branchId);
        var result = await conn.QuerySingleAsync<string>(
            "SELECT fp_counter_opened()");
        return result == "1";
    }

    // Oracle equivalent:
    //   SELECT pka_fin_daily.fp_counter_opened as counter_opened,
    //          (SELECT counter_split FROM si_security_user WHERE user_id = :uid) AS counter_split,
    //          (SELECT branch_name  FROM sc_com_m_branch   WHERE branch_id = :br) AS branch_name,
    //          (SELECT user_name    FROM si_security_user  WHERE user_id = :uid) AS user_name
    //   FROM dual
    public async Task<SessionInfoDto?> GetSessionInfoAsync(string userId, string branchId)
    {
        if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(branchId))
            return null;

        // use session-aware connection so fp_counter_opened() can read app.login_id/login_br
        using var conn = await db.CreateAsync(userId, branchId);

        const string sql = @"
            SELECT
                fp_counter_opened()                                                        AS counter_opened,
                (SELECT counter_split FROM si_security_user WHERE user_id  = @uid)        AS counter_split,
                (SELECT branch_name   FROM sc_com_m_branch   WHERE branch_id = @branchId) AS branch_name,
                (SELECT user_name     FROM si_security_user WHERE user_id  = @uid)        AS user_name,
                fp_finance_date(true)                                                      AS finance_date";

        var row = await conn.QuerySingleOrDefaultAsync(sql, new { uid = userId, branchId });
        if (row is null) return null;

        return new SessionInfoDto(
            CounterOpened : (string?)row.counter_opened  == "1",
            CounterSplit  : (string?)row.counter_split   == "1",
            BranchName    : (string?)row.branch_name,
            UserName      : (string?)row.user_name,
            FinanceDate   : (DateTime?)row.finance_date
        );
    }
}
