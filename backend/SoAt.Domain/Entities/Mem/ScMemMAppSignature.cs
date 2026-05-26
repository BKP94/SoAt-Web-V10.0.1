namespace SoAt.Domain.Entities.Mem;

/// <summary>sc_mem_m_app_signature — ลายเซ็น</summary>
public class ScMemMAppSignature
{
    public string  ApplicationFormNo { get; set; } = null!; // PK
    public byte[]? AppSignature      { get; set; }
}
