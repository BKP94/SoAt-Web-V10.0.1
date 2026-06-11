namespace SoAt.Application.Sc;

public record ScAppDto(
    string AppName,
    string AppTextThai,
    string AppTextEnglish,
    bool Active,
    int ISequence,
    string? IconName
);

public record ScMenuItemDto(
    int     IMenuId,
    string  AppName,
    string  Label,       // AppTextEnglish (top bar)
    string  LabelTh,     // AppText Thai (dropdown)
    int     ISequence,
    string? IconName,
    string? SUrl,        // ชื่อ folder เช่น "scteldet"
    int     ILevel,      // 2 = top bar, 3 = dropdown item
    int?    IParentId    // level3 → IMenuId ของ level2 parent
);

public record ScBranchDto(
    string BranchId,
    string BranchName
);

// ข้อมูลแถบสถานะ scCenter (footer)
public record ScCenterInfoDto(
    string  CoopName,      // coop_name (จาก sc_cnt_m_coop)
    string  SysName,       // ชื่อ database ของ PG (Database= ใน connection string จาก appsettings.json เช่น soatdb)
    string? FinanceDate    // วันที่การเงิน (พ.ศ. แล้ว) — null ถ้าดึงไม่ได้
);
