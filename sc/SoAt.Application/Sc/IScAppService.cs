namespace SoAt.Application.Sc;

public interface IScAppService
{
    Task<IEnumerable<ScAppDto>>      GetAppsAsync(int level = 1);
    Task<IEnumerable<ScMenuItemDto>> GetMenuAsync(string appName);
    Task<IEnumerable<ScBranchDto>>   GetBranchesAsync();
    Task<ScCenterInfoDto>            GetCenterInfoAsync();
}
