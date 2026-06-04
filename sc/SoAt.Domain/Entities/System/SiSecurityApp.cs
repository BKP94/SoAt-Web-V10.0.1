namespace SoAt.Domain.Entities.System;

public class SiSecurityApp
{
    public int IMenuId { get; set; }
    public string? AppName { get; set; }
    public string? AppText { get; set; }
    public string? AppTextEnglish { get; set; }
    public bool Active { get; set; }
    public int ILevel { get; set; }
    public int ISequence { get; set; }
    public int OrderNo { get; set; }
    public string? ShotApp { get; set; }
    public string? IconName { get; set; }
    public string? SUrl { get; set; }
    public int? IParentId { get; set; }
    public string? SubAppName { get; set; }
    public string? Remark { get; set; }
}
