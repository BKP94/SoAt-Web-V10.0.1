using SoAt.Application.Fin;

namespace SoAt.Infrastructure.Fin;

/// <summary>
/// Thin wrapper — logic ทั้งหมดอยู่ใน PostgreSQL functions
/// PL team ดูแล: Database/Functions/pka_fin_daily/
/// Dev team ดูแล: file นี้ (แค่ call function + map result)
/// </summary>
public class FinDailyService(sc.dbFactory dbFactory) : IFinDailyService
{
    // Oracle: pka_fin_daily.fp_finance_date
    public async Task<DateTime?> GetFinanceDateAsync()
    {
        await using var scDb = dbFactory.create();
        return (DateTime?)await scDb.pkFunctionAsync("fp_finance_date", true);
    }

    // Oracle: pka_fin_daily.fp_counter_opened
    // ต้อง set session variables ก่อน (แทน pka_com_login package)
    public async Task<bool> IsCounterOpenedAsync(string userId, string branchId)
    {
        if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(branchId))
            return false;

        await using var scDb = dbFactory.create(userId, branchId);
        return sc.value.toString(await scDb.pkFunctionAsync("fp_counter_opened")) == "1";
    }

    // Oracle equivalent:
    //   SELECT pka_fin_daily.fp_counter_opened, counter_split, branch_name, user_name FROM dual
    public async Task<SessionInfoDto?> GetSessionInfoAsync(string userId, string branchId)
    {
        if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(branchId))
            return null;

        await using var scDb = dbFactory.create(userId, branchId);

        var row = await scDb.getOneAsync<SessionInfoRow>(@"
            SELECT
                fp_counter_opened()                                                        AS counter_opened,
                (SELECT counter_split FROM si_security_user WHERE user_id  = {0})         AS counter_split,
                (SELECT branch_name   FROM sc_com_m_branch   WHERE branch_id = {1})       AS branch_name,
                (SELECT user_name     FROM si_security_user WHERE user_id   = {0})        AS user_name,
                fp_finance_date(true)                                                      AS finance_date",
            userId, branchId);

        if (row is null) return null;

        return new SessionInfoDto(
            CounterOpened : row.CounterOpened == "1",
            CounterSplit  : row.CounterSplit  == "1",
            BranchName    : row.BranchName,
            UserName      : row.UserName,
            FinanceDate   : row.FinanceDate
        );
    }

    private class SessionInfoRow
    {
        public string?   CounterOpened { get; init; }
        public string?   CounterSplit  { get; init; }
        public string?   BranchName    { get; init; }
        public string?   UserName      { get; init; }
        public DateTime? FinanceDate   { get; init; }
    }
}
