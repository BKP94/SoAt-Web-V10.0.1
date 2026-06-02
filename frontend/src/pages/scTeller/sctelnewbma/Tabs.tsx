/**
 * sctelnewbma/Tabs.tsx — แท็บข้อมูลเพิ่มเติมของสมาชิก
 *
 * Tabs:
 *   1. บัญชีธนาคาร       — ข้อมูลบัญชีรับเงินของสมาชิก
 *   2. ข้อมูลครอบครัว    — บิดา/มารดา/คู่สมรส/บุตร
 *   3. ข้อมูลการส่งหุ้น/โอน — การส่งหุ้นและการโอนหุ้น
 *
 * Tab style: icon-top + underline indicator (ดู CSS class .dx-tab-icon-top ใน index.css)
 * TODO: implement content จากระบบเก่า (sctelnewbma legacy)
 */
import TabPanel from 'devextreme-react/tab-panel'

interface TabItem {
  title: string
  icon:  string   // Material Icons ligature name
}

const TABS: TabItem[] = [
  { title: 'บัญชีธนาคาร',          icon: 'account_balance' },
  { title: 'ข้อมูลครอบครัว',        icon: 'people'          },
  { title: 'ข้อมูลการส่งหุ้น/โอน', icon: 'swap_horiz'      },
]

function TabTitle({ item }: { item: TabItem }) {
  return (
    <div style={{
      display:        'flex',
      flexDirection:  'column',
      alignItems:     'center',
      gap:            4,
      padding:        '4px 12px 2px',
      minWidth:       72,
    }}>
      <span className="material-icons" style={{ fontSize: 22 }}>
        {item.icon}
      </span>
      <span style={{ fontSize: 12, whiteSpace: 'nowrap' }}>
        {item.title}
      </span>
    </div>
  )
}

function Placeholder({ title }: { title: string }) {
  return (
    <div style={{ padding: '28px 0', textAlign: 'center', color: '#94a3b8', fontSize: 14 }}>
      🚧 {title} — อยู่ระหว่างพัฒนา
    </div>
  )
}

export default function Tabs() {
  return (
    <TabPanel
      dataSource={TABS}
      animationEnabled={false}
      className="dx-tab-icon-top"
      itemTitleRender={(item: TabItem) => <TabTitle item={item} />}
      itemRender={(item: TabItem) => <Placeholder title={item.title} />}
    />
  )
}
