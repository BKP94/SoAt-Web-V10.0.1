namespace SoAt.Application.ScTeller;

public interface ISctelnewbmaService
{
    /// <summary>ดึง dropdown data ทั้งหมดสำหรับหน้าสมัครสมาชิก</summary>
    Task<SctelnewbmaLookupsDto> GetLookupsAsync();

    /// <summary>ดึงใบสมัครตาม application_form_no</summary>
    Task<ApplicationFormDto?> GetApplicationAsync(string applicationFormNo);

    /// <summary>สร้างใบสมัครใหม่ — gen application_form_no อัตโนมัติ</summary>
    Task<ApplicationFormSaveResult> CreateApplicationAsync(ApplicationFormDto dto, string userId, string branchId);

    /// <summary>อัปเดตใบสมัคร (ยังไม่ถูก approve)</summary>
    Task<ApplicationFormSaveResult> UpdateApplicationAsync(string applicationFormNo, ApplicationFormDto dto, string userId);

    /// <summary>ค้นหาใบสมัครที่บันทึกไว้ (popOpen) ตามเงื่อนไข filter</summary>
    Task<List<ApplicationSummaryDto>> SearchApplicationsAsync(ApplicationSearchFilter filter);

    /// <summary>รายการสถานะใบสมัคร (สำหรับ dropdown filter + แปลง code→ข้อความในตาราง)</summary>
    Task<List<ComboItemDto>> GetApplicationStatusesAsync();
}
