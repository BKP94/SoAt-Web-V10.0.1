/**
 * sctelnewbma/Operate.tsx — ปุ่มกระทำ (วงกลม) แถวขวา
 *
 * ใช้ Material Icons (material-icons npm package)
 * — import 'material-icons/iconfont/material-icons.css' ใน main.tsx
 * — <span className="material-icons">{iconName}</span> เป็น text ligature
 *
 * icon names: https://fonts.google.com/icons
 */
import type { CSSProperties } from 'react'

export interface OperateProps {
  onNew:    () => void
  onOpen:   () => void
  onSave:   () => void
  onCancel: () => void
  saving:   boolean
}

const BTN = 68  // เส้นผ่านศูนย์กลาง (px)

interface CircleBtnProps {
  icon:      string   // Material Icons name เช่น "note_add", "folder_open"
  label:     string
  color:     string
  disabled?: boolean
  onClick:   () => void
  title?:    string
}

function CircleBtn({ icon, label, color, disabled = false, onClick, title }: CircleBtnProps) {
  const btnStyle: CSSProperties = {
    width:          BTN,
    height:         BTN,
    borderRadius:   '50%',
    background:     disabled ? '#d1d5db' : color,
    border:         'none',
    cursor:         disabled ? 'not-allowed' : 'pointer',
    display:        'flex',
    alignItems:     'center',
    justifyContent: 'center',
    boxShadow:      disabled ? 'none' : '0 2px 5px rgba(0,0,0,0.25)',
    outline:        'none',
    padding:        0,
    flexShrink:     0,
    transition:     'opacity 0.15s, box-shadow 0.15s',
  }

  return (
    <div style={{ display: 'flex', flexDirection: 'column', alignItems: 'center', gap: 4 }}>
      <button
        type="button"
        style={btnStyle}
        disabled={disabled}
        onClick={onClick}
        title={title}
        onMouseEnter={e => { if (!disabled) (e.currentTarget as HTMLButtonElement).style.opacity = '0.85' }}
        onMouseLeave={e => { (e.currentTarget as HTMLButtonElement).style.opacity = '1' }}
      >
        {/* Material Icons: ชื่อ icon เป็น text content ของ span */}
        <span className="material-icons" style={{ fontSize: 30, color: 'white', userSelect: 'none' }}>
          {icon}
        </span>
      </button>

      <span style={{
        fontSize:   11,
        fontWeight: 600,
        color:      disabled ? '#9ca3af' : '#374151',
        fontFamily: 'inherit',
      }}>
        {label}
      </span>
    </div>
  )
}

export default function Operate({ onNew, onOpen, onSave, onCancel, saving }: OperateProps) {
  return (
    <div style={{
      display:       'flex',
      flexDirection: 'column',
      gap:           14,
      paddingTop:    4,
      alignItems:    'center',
      minWidth:      BTN + 8,
    }}>
      {/* note_add   = เอกสารใหม่ + เครื่องหมายบวก */}
      <CircleBtn icon="note_add"     label="ใหม่"   color="#1a3760" onClick={onNew}    title="สร้างใหม่" />
      {/* folder_open = โฟลเดอร์เปิด */}
      <CircleBtn icon="folder_open"  label="เปิด"   color="#1a3760" onClick={onOpen}   title="เปิดเอกสาร" />
      {/* save        = floppy disk */}
      <CircleBtn icon="save"         label="บันทึก" color="#16a34a" onClick={onSave}   title="บันทึก" disabled={saving} />
      {/* cancel      = วงกลม X */}
      <CircleBtn icon="cancel_presentation"       label="ยกเลิก" color="#dc2626" onClick={onCancel} title="ยกเลิก" />
    </div>
  )
}
