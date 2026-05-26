using Microsoft.EntityFrameworkCore;
using SoAt.Application.Sc;
using SoAt.Infrastructure.Persistence;

namespace SoAt.Infrastructure.Sc;

public class ScAppService(AppDbContext db) : IScAppService
{
    public async Task<IEnumerable<ScAppDto>> GetAppsAsync(int level = 1)
        => await db.SiSecurityApps
            .Where(a => a.ILevel == level)
            .OrderBy(a => a.ISequence)
            .Select(a => new ScAppDto(
                a.AppName ?? "",
                a.AppText ?? "",
                a.AppTextEnglish ?? "",
                a.Active,
                a.ISequence,
                a.IconName))
            .ToListAsync();

    // level=2 (top bar) + level=3 (dropdown children) for a module
    // seq=0 on level-2 = home item
    public async Task<IEnumerable<ScMenuItemDto>> GetMenuAsync(string appName)
        => await db.SiSecurityApps
            .Where(a => (a.ILevel == 2 || a.ILevel == 3) && a.AppName == appName)
            .OrderBy(a => a.ILevel).ThenBy(a => a.ISequence)
            .Select(a => new ScMenuItemDto(
                a.IMenuId,
                a.AppName ?? "",
                a.AppTextEnglish ?? a.AppText ?? "",
                a.AppText ?? a.AppTextEnglish ?? "",
                a.ISequence,
                a.IconName,
                a.SUrl,
                a.ILevel,
                a.IParentId))
            .ToListAsync();

    // สาขาทั้งหมดจาก sc_com_m_branch สำหรับ login modal dropdown
    public async Task<IEnumerable<ScBranchDto>> GetBranchesAsync()
        => await db.ScComMBranches
            .OrderBy(b => b.BranchId)
            .Select(b => new ScBranchDto(
                b.BranchId,
                b.BranchName ?? b.BranchId))
            .ToListAsync();
}
