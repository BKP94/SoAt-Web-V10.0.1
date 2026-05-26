namespace SoAt.Domain.Entities.Mem;

/// <summary>sc_mem_m_app_picture — รูปสมาชิก</summary>
public class ScMemMAppPicture
{
    public string  ApplicationFormNo { get; set; } = null!; // PK
    public byte[]? AppPicture        { get; set; }
}
