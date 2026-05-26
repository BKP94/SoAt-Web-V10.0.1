/**
 * MasterLayout — shared shell for ALL pages (scCenter + every module)
 *
 * scCenter mode : <MasterLayout>…grid…</MasterLayout>
 * Module mode   : <MasterLayout appName="scTeller">…content…</MasterLayout>
 */
import { useEffect, useState } from 'react'
import { useNavigate } from 'react-router-dom'
import { useAuthStore } from '@/stores/authStore'
import web1 from '@/icon/imgMenu/web1.png'
import web2 from '@/icon/imgMenu/web2.png'

const iconMap = import.meta.glob<string>(
  '/src/icon/imgMenu/*.png',
  { eager: true, query: '?url', import: 'default' }
)
function getIconSrc(name: string | null | undefined) {
  if (!name) return ''
  return iconMap[`/src/icon/imgMenu/${name}`] ?? ''
}

interface MenuItem {
  iMenuId: number
  label: string
  iSequence: number
}

interface SessionInfo {
  counterOpened: boolean
  counterSplit:  boolean
  branchName:    string | null
  userName:      string | null
  financeDate:   string | null   // ISO date string from API
}

interface Props {
  appName?: string           // undefined → scCenter mode (no sub-menu)
  children?: React.ReactNode
}

// ── shared colours ────────────────────────────────────────────────────────────
const BG     = '#1a3760'
const ACTIVE = 'rgba(255,255,255,0.18)'
const HOVER  = 'rgba(255,255,255,0.08)'
const ACCENT = '#60a5fa'

// ── NavBtn — defined outside MasterLayout to avoid react/no-unstable-nested-components ──
interface NavBtnProps {
  seq: number
  label: string
  activeSeq: number
  onSelect: (seq: number) => void
}
function NavBtn({ seq, label, activeSeq, onSelect }: NavBtnProps) {
  const active = activeSeq === seq
  return (
    <button
      onClick={() => onSelect(seq)}
      style={{
        background: active ? ACTIVE : 'none',
        border: 'none',
        borderBottom: `2px solid ${active ? ACCENT : 'transparent'}`,
        color: '#fff',
        padding: '0 14px',
        height: '100%',
        cursor: 'pointer',
        fontSize: 14,
        fontWeight: 400,
        fontFamily: 'inherit',
        whiteSpace: 'nowrap',
        transition: 'background 0.15s',
        flexShrink: 0,
      }}
      onMouseEnter={e => { if (!active) e.currentTarget.style.background = HOVER }}
      onMouseLeave={e => { if (!active) e.currentTarget.style.background = 'none' }}
    >
      {label}
    </button>
  )
}

// ── format Thai date (DD/MM/YYYY+543) ────────────────────────────────────────
function toThaiDate(iso: string | null): string {
  if (!iso) return '-- / -- / ----'
  try {
    const d = new Date(iso)
    const dd   = String(d.getDate()).padStart(2, '0')
    const mm   = String(d.getMonth() + 1).padStart(2, '0')
    const yyyy = d.getFullYear() + 543
    return `${dd}/${mm}/${yyyy}`
  } catch {
    return '-- / -- / ----'
  }
}

// ─────────────────────────────────────────────────────────────────────────────

export default function MasterLayout({ appName, children }: Props) {
  const navigate                             = useNavigate()
  const { token, userId, branchId, logout }  = useAuthStore()

  // ── module-mode state ───────────────────────────────────────────────────────
  const [menuItems,  setMenuItems]  = useState<MenuItem[]>([])
  const [homeLabel,  setHomeLabel]  = useState('หน้าแรก')
  const [moduleIcon, setModuleIcon] = useState('')
  const [moduleTh,   setModuleTh]   = useState('')
  const [activeSeq,  setActiveSeq]  = useState(0)

  // ── shared state ────────────────────────────────────────────────────────────
  const [dbName,      setDbName]      = useState('...')
  const [sessionInfo, setSessionInfo] = useState<SessionInfo | null>(null)

  // ── fetch DB name ────────────────────────────────────────────────────────────
  useEffect(() => {
    fetch('/api/sc/dbname')
      .then(r => r.json())
      .then((d: { databaseName: string }) => setDbName(d.databaseName))
      .catch(() => setDbName('?'))
  }, [])

  // ── fetch footer session info (เมื่อ login แล้ว) ────────────────────────────
  useEffect(() => {
    if (!token) { setSessionInfo(null); return }
    fetch('/api/fin/session-info', {
      headers: { Authorization: `Bearer ${token}` },
    })
      .then(r => r.ok ? r.json() : null)
      .then((d: SessionInfo | null) => setSessionInfo(d))
      .catch(() => setSessionInfo(null))
  }, [token])

  // ── fetch module menu (module mode only) ──────────────────────────────────
  useEffect(() => {
    if (!appName) return

    // level-2 menu
    fetch(`/api/sc/menu?appName=${appName}`)
      .then(r => r.json())
      .then((d: { value?: MenuItem[] } | MenuItem[]) => {
        const items: MenuItem[] = Array.isArray(d)
          ? d
          : (d as { value: MenuItem[] }).value ?? []
        setHomeLabel(items.find(i => i.iSequence === 0)?.label ?? 'หน้าแรก')
        setMenuItems(items.filter(i => i.iSequence > 0))
      })
      .catch(() => {})

    // level-1 icon + Thai name
    fetch('/api/sc/apps?level=1')
      .then(r => r.json())
      .then((apps: { appName: string; appTextThai: string; iconName: string | null }[]) => {
        const found = apps.find(a => a.appName === appName)
        if (found) {
          setModuleIcon(getIconSrc(found.iconName))
          setModuleTh(found.appTextThai)
        }
      })
      .catch(() => {})
  }, [appName])

  const isModule = !!appName

  // ── footer: cash balance display logic (เหมือน legacy) ───────────────────
  const cashBalanceStyle: React.CSSProperties = {}
  let cashBalanceText = 'เงินสดในมือ : [----------]'
  if (sessionInfo) {
    if (sessionInfo.counterSplit) {
      // ไม่ใช่เจ้าหน้าที่การเงิน
      cashBalanceStyle.color   = 'rgba(255,255,255,0.4)'
      cashBalanceText = 'เงินสดในมือ : [ไม่ใช่เจ้าหน้าที่การเงิน]'
    } else if (sessionInfo.counterOpened) {
      // เปิดเคาน์เตอร์แล้ว (ใส่ตัวเลขจริงเมื่อมี endpoint fp_cash_balance)
      cashBalanceStyle.color = '#fff'
      cashBalanceText = 'เงินสดในมือ : [กำลังโหลด...]'
    } else {
      // เป็นการเงินแต่ยังไม่เปิดเคาน์เตอร์
      cashBalanceStyle.color = '#f97316'
      cashBalanceText = 'เงินสดในมือ : [ยังไม่เปิดเคาน์เตอร์]'
    }
  }

  return (
    <div style={{ minHeight: '100vh', display: 'flex', flexDirection: 'column', background: '#f0f2f5' }}>

      {/* ════════════════════════════════════════════════════════════════════════
          HEADER — single bar, identical on every page
          ════════════════════════════════════════════════════════════════════════ */}
      <header style={{
        background: BG, color: '#fff', flexShrink: 0,
        display: 'flex', alignItems: 'stretch',
        padding: '0 16px', height: 52,
      }}>

        {/* ── Left: logo only ──────────────────────────────────────────────── */}
        <div style={{ display: 'flex', alignItems: 'center', flexShrink: 0 }}>
          <img
            src={web1} alt="SO-AT" draggable={false}
            style={{ height: 40, objectFit: 'contain', cursor: 'pointer', flexShrink: 0 }}
            onClick={() => navigate('/')}
          />
        </div>

        {/* ── Center: spacer ───────────────────────────────────────────────── */}
        <div style={{ flex: 1 }} />

        {/* ── Menu items (module mode, ชิดขวา) ─────────────────────────────── */}
        {isModule && (
          <>
            <div style={{ display: 'flex', alignItems: 'stretch' }}>
              <NavBtn seq={0} label={`🏠 ${homeLabel}`} activeSeq={activeSeq} onSelect={setActiveSeq} />
              {menuItems.map(item => (
                <NavBtn
                  key={item.iMenuId}
                  seq={item.iSequence}
                  label={item.label}
                  activeSeq={activeSeq}
                  onSelect={setActiveSeq}
                />
              ))}
            </div>
            <div style={{ width: 1, height: 28, background: 'rgba(255,255,255,0.2)', alignSelf: 'center', margin: '0 8px' }} />
          </>
        )}

        {/* ── Right: logo / module info + user + power ─────────────────────── */}
        <div style={{ display: 'flex', alignItems: 'center', gap: 12, flexShrink: 0 }}>

          {/* scCenter mode: web2 logo */}
          {!isModule && (
            <img src={web2} alt="System" draggable={false}
              style={{ height: 40, objectFit: 'contain' }} />
          )}

          {/* Module mode: module name + icon */}
          {isModule && (
            <div style={{ display: 'flex', alignItems: 'center', gap: 8 }}>
              <div style={{ textAlign: 'right', lineHeight: 1.4 }}>
                <div style={{ fontSize: 13, fontWeight: 500 }}>{appName?.replace('sc', '')}</div>
                <div style={{ fontSize: 11, fontWeight: 400, opacity: 0.65 }}>{moduleTh}</div>
              </div>
              {moduleIcon && (
                <img src={moduleIcon} alt={appName} draggable={false}
                  style={{ width: 32, height: 32, objectFit: 'contain', opacity: 0.9 }} />
              )}
            </div>
          )}

          {/* Divider */}
          <div style={{ width: 1, height: 28, background: 'rgba(255,255,255,0.2)' }} />

          {/* User info — แสดง user_name + branch_name จาก session-info ถ้ามี */}
          {token && (
            <div style={{ textAlign: 'right', lineHeight: 1.4 }}>
              <div style={{ fontSize: 13, fontWeight: 400 }}>
                {sessionInfo?.userName ?? userId}
              </div>
              <div style={{ fontSize: 11, fontWeight: 400, opacity: 0.65 }}>
                {sessionInfo?.branchName ?? branchId}
              </div>
            </div>
          )}

          {/* Power button (module mode only) */}
          {isModule && (
            <button
              onClick={() => navigate('/')}
              title="กลับหน้าหลัก"
              style={{
                background: 'none', border: '2px solid rgba(255,255,255,0.3)',
                color: '#fff', width: 32, height: 32, borderRadius: '50%',
                cursor: 'pointer', display: 'flex', alignItems: 'center',
                justifyContent: 'center', fontSize: 15, flexShrink: 0,
                transition: 'all 0.15s',
              }}
              onMouseEnter={e => {
                e.currentTarget.style.borderColor = '#f87171'
                e.currentTarget.style.background  = 'rgba(248,113,113,0.15)'
                e.currentTarget.style.color       = '#f87171'
              }}
              onMouseLeave={e => {
                e.currentTarget.style.borderColor = 'rgba(255,255,255,0.3)'
                e.currentTarget.style.background  = 'none'
                e.currentTarget.style.color       = '#fff'
              }}
            >⏻</button>
          )}
        </div>
      </header>

      {/* ════════════════════════════════════════════════════════════════════════
          CONTENT
          ════════════════════════════════════════════════════════════════════════ */}
      <main style={{ flex: 1, minHeight: 0, overflow: 'auto', position: 'relative' }}>

        {/* Module home splash */}
        {isModule && activeSeq === 0 && (
          <div style={{
            position: 'absolute', inset: 0,
            display: 'flex', alignItems: 'center', justifyContent: 'center',
          }}>
            <div style={{ display: 'flex', alignItems: 'center', gap: 36 }}>
              {moduleIcon && (
                <img src={moduleIcon} alt={appName} draggable={false}
                  style={{ width: 130, height: 130, objectFit: 'contain', opacity: 0.8 }} />
              )}
              <div style={{ borderLeft: '3px solid #d1d5db', paddingLeft: 36 }}>
                <div style={{ fontSize: 52, fontWeight: 700, color: '#374151', lineHeight: 1 }}>
                  {appName?.replace('sc', '')}
                </div>
                <div style={{ fontSize: 18, fontWeight: 400, color: '#6b7280', marginTop: 10 }}>
                  {moduleTh}
                </div>
              </div>
            </div>
          </div>
        )}

        {/* scCenter content OR module sub-page content */}
        {(!isModule || activeSeq > 0) && children}
      </main>

      {/* ════════════════════════════════════════════════════════════════════════
          FOOTER — identical on every page
          ════════════════════════════════════════════════════════════════════════ */}
      <footer style={{
        background: BG, color: '#fff',
        padding: '0 20px', height: 34,
        display: 'flex', alignItems: 'center', flexShrink: 0,
        borderTop: '1px solid rgba(255,255,255,0.08)',
        overflow: 'hidden',
      }}>
        {/* wrapper: space-between, ทุกอย่างอยู่บรรทัดเดียว */}
        <div style={{
          display: 'flex', alignItems: 'center', justifyContent: 'space-between',
          fontSize: 12, fontWeight: 400, width: '100%', minWidth: 0,
        }}>

          {/* ── ซ้าย: items ทุกตัว nowrap, clip เมื่อเล็กเกิน ── */}
          <div style={{
            display: 'flex', alignItems: 'center', gap: 10,
            overflow: 'hidden', minWidth: 0, flexShrink: 1,
            whiteSpace: 'nowrap',
          }}>
            {/* ผู้ใช้งาน */}
            <span style={{ whiteSpace: 'nowrap', flexShrink: 0 }}>
              [{token ? userId : '?'}][{token ? (sessionInfo?.branchName ?? branchId ?? '?') : '?'}]
            </span>

            <span style={{ opacity: 0.3, flexShrink: 0 }}>|</span>

            {/* วันที่เงิน */}
            <span style={{ whiteSpace: 'nowrap', flexShrink: 0, color: sessionInfo?.financeDate ? '#fff' : 'rgba(255,255,255,0.4)' }}>
              วันที่เงิน : [{toThaiDate(sessionInfo?.financeDate ?? null)}]
            </span>

            <span style={{ opacity: 0.3, flexShrink: 0 }}>|</span>

            {/* เงินสดในมือ */}
            <span style={{ whiteSpace: 'nowrap', flexShrink: 0, ...cashBalanceStyle }}>
              {cashBalanceText}
            </span>

            <span style={{ opacity: 0.3, flexShrink: 0 }}>|</span>

            {/* ฐานข้อมูล */}
            <span style={{ whiteSpace: 'nowrap', flexShrink: 0 }}>
              ฐานข้อมูล : [{dbName}]
            </span>

            {token && (
              <>
                <span style={{ opacity: 0.3, flexShrink: 0 }}>|</span>
                <button
                  onClick={logout}
                  style={{
                    background: '#dc2626', border: 'none', color: '#fff',
                    padding: '2px 10px', borderRadius: 4, cursor: 'pointer',
                    fontSize: 11, fontFamily: 'inherit', fontWeight: 600,
                    flexShrink: 0, whiteSpace: 'nowrap',
                  }}
                >ออกจากระบบ</button>
              </>
            )}
          </div>

          {/* ── ขวา: copyright — ไม่ให้ถูกบีบ ── */}
          <div style={{ opacity: 0.4, fontSize: 11, flexShrink: 0, whiteSpace: 'nowrap', paddingLeft: 16 }}>
            Copyright © 2019 All Right Reserved SO-AT
          </div>
        </div>
      </footer>

    </div>
  )
}
