/**
 * scReport / main — ระบบรายงาน
 * Placeholder — อยู่ระหว่างพัฒนา (ยังไม่มี menu data จาก Oracle)
 */
export default function ScReportMainPage() {
  return (
    <div style={{ padding: 32 }}>
      <div style={{
        display: 'inline-flex', alignItems: 'center', gap: 12,
        background: '#fefce8', border: '1px solid #fde68a',
        borderRadius: 8, padding: '12px 20px',
        color: '#92400e', fontSize: 14,
      }}>
        <span style={{ fontSize: 20 }}>⚙️</span>
        <div>
          <div style={{ fontWeight: 600 }}>ระบบรายงาน</div>
          <div style={{ fontSize: 12, opacity: 0.75, marginTop: 2 }}>ยังไม่มีข้อมูลเมนูจาก Oracle</div>
        </div>
      </div>
    </div>
  )
}
