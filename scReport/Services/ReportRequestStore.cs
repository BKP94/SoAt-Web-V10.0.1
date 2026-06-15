using System.Collections.Concurrent;

namespace scReport.Services;

// ─────────────────────────────────────────────────────────────────────────────
// ReportRequestStore — เก็บ "คำขอเปิดรายงาน" ที่ประกอบ SQL เสร็จแล้ว ชั่วคราว
//   เพื่อส่งข้ามแท็บ (เลียน legacy ที่เก็บใน Session[sc.report.repCode(cat,rep,opdate)]
//   แล้วเปิด repViewer/page.aspx?...&TIME=opdate ในแท็บใหม่)
//
//   Blazor Server: แท็บใหม่ = circuit ใหม่ (คนละ SignalR) → ส่ง XtraReport ตรงไม่ได้
//   จึงเก็บแค่ {VsPath, Sql, Title} ไว้ที่ singleton นี้ คีย์ด้วย token (GUID = opdate ของเรา)
//   แล้วแท็บ viewer สร้าง report ใหม่ (tryCreateReport + bindReportSql) จาก token
// ─────────────────────────────────────────────────────────────────────────────
public sealed class ReportRequestStore
{
    // Entry = คำขอเปิดรายงาน 1 ครั้ง + ข้อมูลหัวรายงาน (เลียน legacy ofLoadReport ที่ set label runtime)
    //   CoopName→t_header_1, RepText→t_header_2, Header3→t_header_3, (CatId/RepId/LoginUser/CreatedAt)→t_header_publish_date
    public sealed record Entry(
        string VsPath, string Sql, string Title, DateTime CreatedAt,
        string CoopName, string RepText, string Header3,
        string CatId, string RepId, string LoginUser);

    static readonly TimeSpan Ttl = TimeSpan.FromMinutes(30);
    readonly ConcurrentDictionary<string, Entry> _items = new();

    // เก็บคำขอ → คืน token (เอาไปประกอบ url repView/{token})
    public string Put(string vsPath, string sql, string title,
        string coopName, string repText, string header3,
        string catId, string repId, string loginUser)
    {
        Sweep();
        var token = Guid.NewGuid().ToString("N");
        _items[token] = new Entry(vsPath, sql, title, DateTime.UtcNow,
            coopName, repText, header3, catId, repId, loginUser);
        return token;
    }

    // อ่านด้วย token (ไม่ลบ — refresh แท็บ viewer ซ้ำได้จนกว่าจะหมดอายุ)
    public Entry? Get(string token)
    {
        Sweep();
        return token is not null && _items.TryGetValue(token, out var e) ? e : null;
    }

    void Sweep()
    {
        var cutoff = DateTime.UtcNow - Ttl;
        foreach (var pair in _items)
            if (pair.Value.CreatedAt < cutoff)
                _items.TryRemove(pair.Key, out _);
    }
}
