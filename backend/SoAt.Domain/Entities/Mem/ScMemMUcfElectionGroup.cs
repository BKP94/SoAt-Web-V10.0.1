namespace SoAt.Domain.Entities.Mem;

/// <summary>sc_mem_m_ucf_election_group — กลุ่มเลือกตั้ง</summary>
public class ScMemMUcfElectionGroup
{
    public string  ElectionGroup     { get; set; } = null!; // PK
    public string? ElectionGroupName { get; set; }          // denormalized from election_zone
    public string? ElectionZone      { get; set; }          // FK → sc_mem_m_ucf_election_zone
}
