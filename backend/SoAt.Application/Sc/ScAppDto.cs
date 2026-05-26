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
    int IMenuId,
    string AppName,
    string Label,
    int ISequence,
    string? IconName,
    string? Url
);

public record ScBranchDto(
    string BranchId,
    string BranchName
);
