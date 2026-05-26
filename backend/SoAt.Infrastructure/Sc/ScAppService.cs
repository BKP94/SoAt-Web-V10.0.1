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

    // level=2 items for a module — seq=0 is home, seq>0 are menu items
    public async Task<IEnumerable<ScMenuItemDto>> GetMenuAsync(string appName)
        => await db.SiSecurityApps
            .Where(a => a.ILevel == 2 && a.AppName == appName)
            .OrderBy(a => a.ISequence)
            .Select(a => new ScMenuItemDto(
                a.IMenuId,
                a.AppName ?? "",
                a.AppTextEnglish ?? a.AppText ?? "",
                a.ISequence,
                a.IconName,
                a.SUrl))
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
