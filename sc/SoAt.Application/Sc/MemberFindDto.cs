namespace SoAt.Application.Sc;

// ── ค้นหาทะเบียนสมาชิก (shared popup PopFindMember) — เลียน legacy sc/ctr/popFindMember ──
//   ใช้ร่วมได้ทุกเมนูที่ต้องเลือกสมาชิก (ไม่ผูก scteldet)

/// เงื่อนไขค้นหา (แต่ละช่องว่าง = ไม่กรอง). MemberStatus: "1"=ทั้งหมด / "0"=ปกติ / "3"=พ้นสภาพ
public class MemberFindFilter
{
    public string? MembershipNo  { get; set; }
    public string? MemberName    { get; set; }
    public string? MemberSurname { get; set; }
    public string? SalaryId      { get; set; }
    public string? IdCard        { get; set; }
    public string? MemberGroup   { get; set; }   // เลขหน่วย หรือ ชื่อหน่วย (บางส่วน)
    public string? MemberStatus  { get; set; } = "1";
}

/// 1 แถวผลค้นหา (map ตรง legacy dsDetail: membership_no / member_group ประกอบ "no - name" / salary_id subquery)
public record MemberFindDto(
    string  MembershipNo,
    string? ApproveId,
    string? MemberName,
    string? MemberSurname,
    string? MemberGroup,
    string? SalaryId,
    string? IdCard,
    string? ResignCode,
    string? MemberStatusCode);
