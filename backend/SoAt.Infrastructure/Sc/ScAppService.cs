using SoAt.Application.Sc;

namespace SoAt.Infrastructure.Sc;

public class ScAppService(sc.dbFactory dbFactory) : IScAppService
{
    public async Task<IEnumerable<ScAppDto>> GetAppsAsync(int level = 1)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<ScAppDto>(@"
            SELECT app_name,
                   app_text          AS app_text_thai,
                   app_text_english,
                   active,
                   i_sequence,
                   icon_name
            FROM si_security_apps
            WHERE i_level = {0}
            ORDER BY i_sequence",
            level);
    }

    // level=2 (top bar) + level=3 (dropdown children) for a module
    public async Task<IEnumerable<ScMenuItemDto>> GetMenuAsync(string appName)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<ScMenuItemDto>(@"
            SELECT i_menu_id,
                   app_name,
                   COALESCE(app_text_english, app_text, '') AS label,
                   COALESCE(app_text, app_text_english, '') AS label_th,
                   i_sequence,
                   icon_name,
                   s_url,
                   i_level,
                   i_parent_id
            FROM si_security_apps
            WHERE (i_level = 2 OR i_level = 3) AND app_name = {0}
            ORDER BY i_level, i_sequence",
            appName);
    }

    // สาขาทั้งหมดจาก sc_com_m_branch สำหรับ login modal dropdown
    public async Task<IEnumerable<ScBranchDto>> GetBranchesAsync()
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<ScBranchDto>(@"
            SELECT branch_id,
                   COALESCE(branch_name, branch_id) AS branch_name
            FROM sc_com_m_branch
            ORDER BY branch_id");
    }
}
