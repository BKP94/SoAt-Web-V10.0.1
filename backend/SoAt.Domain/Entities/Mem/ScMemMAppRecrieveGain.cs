namespace SoAt.Domain.Entities.Mem;

/// <summary>
/// sc_mem_m_app_recrieve_gain — ผู้รับผลประโยชน์/ผู้รับโอน
/// Oracle typo: "recrieve" (kept as-is for table name)
/// </summary>
public class ScMemMAppRecrieveGain
{
    public string    ApplicationFormNo { get; set; } = null!; // PK part 1
    public int       SeqNo             { get; set; }           // PK part 2
    public string?   PrenameCode       { get; set; }
    public string?   GainName          { get; set; }
    public string?   GainSurname       { get; set; }
    public string?   ConcernCode       { get; set; }
    public string?   WefType           { get; set; }
    public decimal?  GainPercent       { get; set; }           // stored as decimal (0.xx)
    public string?   GainIdCard        { get; set; }
    public DateTime? BookDate          { get; set; }
    public int?      OrderNumber       { get; set; }
    public string?   GainAddress       { get; set; }
    public string?   GainTelephone     { get; set; }
    public string?   GainDesc          { get; set; }
}
