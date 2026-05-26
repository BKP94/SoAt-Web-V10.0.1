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
