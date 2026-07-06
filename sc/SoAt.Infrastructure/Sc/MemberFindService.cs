using SoAt.Application.Sc;

namespace SoAt.Infrastructure.Sc;

// ── MemberFindService — เลียน legacy sc/ctr/popFindMember.ascx.cs (ofFind + dsDetail) ──
//   Oracle → PG: || null-safe ด้วย COALESCE, LIKE เหมือนเดิม (ทุกช่อง %x%)
//   member_group ใช้ param เดียวสองที่ (no หรือ name) — sc.db แทน {i} ทุกตำแหน่ง
public class MemberFindService(sc.dbFactory dbFactory) : IMemberFindService
{
    public async Task<List<MemberFindDto>> FindAsync(MemberFindFilter filter)
    {
        await using var scDb = dbFactory.create();

        // base query = dsDetail เดิม (member_group ประกอบ "no - name", salary_id จาก work_info)
        var sql = new System.Text.StringBuilder(@"
SELECT reg.membership_no,
       reg.approve_id,
       reg.member_name,
       reg.member_surname,
       COALESCE(reg.member_group_no, '') || ' - ' ||
         COALESCE((SELECT g.member_group_name FROM sc_mem_m_ucf_member_group g
                   WHERE g.member_group_no = reg.member_group_no), '') AS member_group,
       (SELECT w.salary_id FROM sc_mem_m_member_work_info w
        WHERE w.membership_no = reg.membership_no) AS salary_id,
       reg.id_card,
       reg.resign_code,
       reg.member_status_code
FROM sc_mem_m_membership_registered reg
WHERE 1 = 1");

        var args = new List<object?>();
        int i = 0;

        if (!string.IsNullOrWhiteSpace(filter.MembershipNo))
        {
            sql.Append(" AND reg.membership_no LIKE {" + i + "}");
            args.Add("%" + filter.MembershipNo.Trim() + "%"); i++;
        }
        if (!string.IsNullOrWhiteSpace(filter.MemberName))
        {
            sql.Append(" AND reg.member_name LIKE {" + i + "}");
            args.Add("%" + filter.MemberName.Trim() + "%"); i++;
        }
        if (!string.IsNullOrWhiteSpace(filter.MemberSurname))
        {
            sql.Append(" AND reg.member_surname LIKE {" + i + "}");
            args.Add("%" + filter.MemberSurname.Trim() + "%"); i++;
        }
        if (!string.IsNullOrWhiteSpace(filter.SalaryId))
        {
            sql.Append(@" AND EXISTS(SELECT NULL FROM sc_mem_m_member_work_info w
                          WHERE w.membership_no = reg.membership_no AND w.salary_id LIKE {" + i + "})");
            args.Add("%" + filter.SalaryId.Trim() + "%"); i++;
        }
        if (!string.IsNullOrWhiteSpace(filter.IdCard))
        {
            sql.Append(" AND reg.id_card LIKE {" + i + "}");
            args.Add("%" + filter.IdCard.Trim() + "%"); i++;
        }
        if (!string.IsNullOrWhiteSpace(filter.MemberGroup))
        {
            // param เดียวใช้สองที่ (เลขหน่วย หรือ ชื่อหน่วย) — sc.db แทน {i} ทุกตำแหน่ง
            sql.Append(@" AND EXISTS(SELECT NULL FROM sc_mem_m_ucf_member_group g
                          WHERE g.member_group_no = reg.member_group_no
                            AND (g.member_group_no LIKE {" + i + "} OR g.member_group_name LIKE {" + i + "}))");
            args.Add("%" + filter.MemberGroup.Trim() + "%"); i++;
        }
        // สถานะ: "0" (ปกติ) หรือ "3" (พ้นสภาพ) เท่านั้นที่กรอง — "1"/ว่าง = ทั้งหมด
        if (filter.MemberStatus is "0" or "3")
        {
            sql.Append(" AND reg.member_status_code = {" + i + "}");
            args.Add(filter.MemberStatus); i++;
        }

        sql.Append(" ORDER BY reg.membership_no");

        return await scDb.getListAsync<MemberFindDto>(sql.ToString(), args.ToArray());
    }
}
