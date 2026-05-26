namespace SoAt.Application.Fin;

/// <summary>
/// Migration ของ Oracle package: pka_fin_daily
/// </summary>
public interface IFinDailyService
{
    /// <summary>
    /// fp_finance_date — วันที่การเงินปัจจุบัน จาก sc_fin_m_constant
    /// คืน null ถ้ายังไม่เปิดวัน (ignore=true mode)
    /// </summary>
    Task<DateTime?> GetFinanceDateAsync();

    /// <summary>
    /// fp_counter_opened — ตรวจสอบว่าเคาน์เตอร์ของ user นั้นเปิดแล้วหรือยัง
    /// คืน true = เปิดแล้ว ('1'), false = ยังไม่เปิด ('0')
    /// </summary>
    Task<bool> IsCounterOpenedAsync(string userId, string branchId);

    /// <summary>
    /// Session info สำหรับ footer — เทียบเท่า Oracle query เดิม:
    ///   SELECT fp_counter_opened, counter_split, branch_name, user_name FROM dual
    /// </summary>
    Task<SessionInfoDto?> GetSessionInfoAsync(string userId, string branchId);
}

public record SessionInfoDto(
    bool     CounterOpened,   // fp_counter_opened()
    bool     CounterSplit,    // si_security_user.counter_split = '1'
    string?  BranchName,      // sc_com_m_branch.branch_name
    string?  UserName,        // si_security_user.user_name
    DateTime? FinanceDate     // sc_fin_m_constant.finance_date
);
