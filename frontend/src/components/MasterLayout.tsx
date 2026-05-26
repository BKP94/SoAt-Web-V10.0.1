/**
 * MasterLayout — shared shell for ALL pages (scCenter + every module)
 *
 * scCenter mode : <MasterLayout>…grid…</MasterLayout>
 * Module mode   : <MasterLayout appName="scTeller">…content…</MasterLayout>
 *
 * Menu structure (from si_security_apps):
 *   level=2, seq=0   → home item (label shown on home button)
 *   level=2, seq>0   → top-bar tab; if it has level-3 children → dropdown
 *   level=3          → dropdown item; iParentId = iMenuId of level-2 parent
 *                      sUrl = sub-folder name, e.g. "scteldet"
 *                      → dynamically loads /src/pages/{appName}/{sUrl}/index.tsx
 */
import React, { useEffect, useRef, useState } from 'react'
import { useNavigate } from 'react-router-dom'
import { useAuthStore } from '@/stores/authStore'
import web1 from '@/icon/imgMenu/web1.png'
import web2 from '@/icon/imgMenu/web2.png'

// ── icon map ─────────────────────────────────────────────────────────────────
const iconMap = import.meta.glob<string>(
  '/src/icon/imgMenu/*.png',
  { eager: true, query: '?url', import: 'default' }
)
function getIconSrc(name: string | null | undefined) {
  if (!name) return ''
  return iconMap[`/src/icon/imgMenu/${name}`] ?? ''
}

// ── dynamic sub-page loader ───────────────────────────────────────────────────
// Grabs every index.tsx one level under any sc* module folder
// eslint-disable-next-line @typescript-eslint/no-explicit-any
const subPageModules = import.meta.glob<{ default: React.ComponentType<any> }>(
  '/src/pages/sc*/*/index.tsx'
)

// ── types ─────────────────────────────────────────────────────────────────────
interface MenuItem {
  iMenuId:   number
  appName:   string
  label:     string        // AppTextEnglish — top-bar / English title
  labelTh:   string        // AppTextThai    — dropdown Thai label
  iSequence: number
  iconName:  string | null
  sUrl:      string | null // sub-folder name for level-3 pages
  iLevel:    number        // 2 = top bar, 3 = dropdown
  iParentId: number | null // level-3 → iMenuId of level-2 parent
}

interface SessionInfo {
  counterOpened: boolean
  counterSplit:  boolean
  branchName:    string | null
  userName:      string | null
  financeDate:   string | null   // ISO date string
}

interface Props {
  appName?: string           // undefined → scCenter mode
  children?: React.ReactNode
}

// ── shared colours ─────────────────────────────────────────────────────────────
const BG     = '#1a3760'
const ACTIVE = 'rgba(255,255,255,0.18)'
const HOVER  = 'rgba(255,255,255,0.08)'
const ACCENT = '#60a5fa'

// ── extract folder name from Oracle sUrl ─────────────────────────────────────
// Oracle stores "../scteldet/page.aspx" → we need "scteldet"
function sUrlToFolder(sUrl: string | null | undefined): string | null {
  if (!sUrl) return null
  const m = sUrl.match(/\.\.?\/([^/]+)\//)
  return m ? m[1] : null
}

// ── Thai date helper ──────────────────────────────────────────────────────────
function toThaiDate(iso: string | null): string {
  if (!iso) return '-- / -- / ----'
  try {
    const d    = new Date(iso)
    const dd   = String(d.getDate()).padStart(2, '0')
    const mm   = String(d.getMonth() + 1).padStart(2, '0')
    const yyyy = d.getFullYear() + 543
    return `${dd}/${mm}/${yyyy}`
  } catch {
    return '-- / -- / ----'
  }
}

// ── TopNavItem ────────────────────────────────────────────────────────────────
// A single level-2 top-bar button. If it has level-3 sub-items it shows a
// hover dropdown.  isActive = true when this tab owns the current page.
interface TopNavItemProps {
  item:         MenuItem
  subItems:     MenuItem[]             // level-3 children (may be empty)
  isActive:     boolean
  activeSUrl:   string | null          // currently open sub-page sUrl
  onClickLeaf:  (item: MenuItem) => void
  onClickSub:   (sub: MenuItem)  => void
}

function TopNavItem({
  item, subItems, isActive, activeSUrl, onClickLeaf, onClickSub,
}: TopNavItemProps) {
  const hasDropdown = subItems.length > 0
  const [open, setOpen] = useState(false)
  const wrapRef = useRef<HTMLDivElement>(null)

  return (
    <div
      ref={wrapRef}
      style={{ position: 'relative', height: '100%', display: 'flex', alignItems: 'stretch' }}
      onMouseEnter={() => hasDropdown && setOpen(true)}
      onMouseLeave={() => setOpen(false)}
    >
      {/* top-bar button */}
      <button
        onClick={() => hasDropdown ? setOpen(o => !o) : onClickLeaf(item)}
        style={{
          background:   isActive ? ACTIVE : 'none',
          border:       'none',
          borderBottom: `2px solid ${isActive ? ACCENT : 'transparent'}`,
          color:        '#fff',
          padding:      '0 14px',
          height:       '100%',
          cursor:       'pointer',
          fontSize:     14,
          fontWeight:   400,
          fontFamily:   'inherit',
          whiteSpace:   'nowrap',
          transition:   'background 0.15s',
          flexShrink:   0,
          display:      'flex',
          alignItems:   'center',
          gap:          4,
        }}
        onMouseEnter={e => { if (!isActive) e.currentTarget.style.background = HOVER }}
        onMouseLeave={e => { if (!isActive) e.currentTarget.style.background = 'none' }}
      >
        {item.label}
        {hasDropdown && <span style={{ fontSize: 10, opacity: 0.7 }}>▾</span>}
      </button>

      {/* dropdown panel */}
      {hasDropdown && open && (
        <div style={{
          position:     'absolute',
          top:          '100%',
          left:         0,
          minWidth:     220,
          background:   '#1e3a5f',
          borderRadius: '0 0 6px 6px',
          boxShadow:    '0 6px 20px rgba(0,0,0,0.4)',
          zIndex:       200,
          paddingBottom: 4,
        }}>
          {subItems.map(sub => {
            const subActive = activeSUrl === sub.sUrl
            return (
              <button
                key={sub.iMenuId}
                onClick={() => { onClickSub(sub); setOpen(false) }}
                style={{
                  display:     'block',
                  width:       '100%',
                  textAlign:   'left',
                  background:  subActive ? ACTIVE : 'none',
                  border:      'none',
                  borderLeft:  subActive ? `3px solid ${ACCENT}` : '3px solid transparent',
                  color:       '#fff',
                  padding:     '9px 18px',
                  cursor:      'pointer',
                  fontSize:    13,
                  fontFamily:  'inherit',
                  whiteSpace:  'nowrap',
                }}
                onMouseEnter={e => { if (!subActive) e.currentTarget.style.background = HOVER }}
                onMouseLeave={e => { e.currentTarget.style.background = subActive ? ACTIVE : 'none' }}
              >
                {sub.labelTh || sub.label}
              </button>
            )
          })}
        </div>
      )}
    </div>
  )
}

// ─────────────────────────────────────────────────────────────────────────────

export default function MasterLayout({ appName, children }: Props) {
  const navigate                            = useNavigate()
  const { token, userId, branchId, logout } = useAuthStore()

  // ── module-mode state ──────────────────────────────────────────────────────
  const [menuItems,  setMenuItems]  = useState<MenuItem[]>([])
  const [homeLabel,  setHomeLabel]  = useState('หน้าแรก')
  const [moduleIcon, setModuleIcon] = useState('')
  const [moduleTh,   setModuleTh]   = useState('')

  // activePage: sUrl of current sub-page (null = home splash)
  const [activePage, setActivePage] = useState<string | null>(null)
  // activeL2: iMenuId of the active level-2 tab (for underline highlight)
  const [activeL2,   setActiveL2]   = useState<number | null>(null)

  // dynamically-loaded sub-page component
  // eslint-disable-next-line @typescript-eslint/no-explicit-any
  const [SubPage,    setSubPage]    = useState<React.ComponentType<any> | null>(null)
  const [pageLoading, setPageLoading] = useState(false)

  // ── shared state ───────────────────────────────────────────────────────────
  const [dbName,      setDbName]      = useState('...')
  const [sessionInfo, setSessionInfo] = useState<SessionInfo | null>(null)

  // ── fetch DB name ──────────────────────────────────────────────────────────
  useEffect(() => {
    fetch('/api/sc/dbname')
      .then(r => r.json())
      .then((d: { databaseName: string }) => setDbName(d.databaseName))
      .catch(() => setDbName('?'))
  }, [])

  // ── fetch footer session info ──────────────────────────────────────────────
  useEffect(() => {
    if (!token) { setSessionInfo(null); return }
    fetch('/api/fin/session-info', {
      headers: { Authorization: `Bearer ${token}` },
    })
      .then(r => r.ok ? r.json() : null)
      .then((d: SessionInfo | null) => setSessionInfo(d))
      .catch(() => setSessionInfo(null))
  }, [token])

  // ── fetch module menu (level 2 + 3) ────────────────────────────────────────
  useEffect(() => {
    if (!appName) return
    // reset page state when switching modules
    setActivePage(null)
    setActiveL2(null)
    setSubPage(null)

    fetch(`/api/sc/menu?appName=${appName}`)
      .then(r => r.json())
      .then((d: MenuItem[] | { value: MenuItem[] }) => {
        const items: MenuItem[] = Array.isArray(d)
          ? d
          : (d as { value: MenuItem[] }).value ?? []
        const home = items.find(i => i.iLevel === 2 && i.iSequence === 0)
        setHomeLabel(home?.labelTh || home?.label || 'หน้าแรก')
        setMenuItems(items)
      })
      .catch(() => {})

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

  // ── dynamically load sub-page when activePage changes ────────────────────
  useEffect(() => {
    if (!activePage || !appName) { setSubPage(null); return }
    const key    = `/src/pages/${appName}/${activePage}/index.tsx`
    const loader = subPageModules[key]
    if (loader) {
      setPageLoading(true)
      loader()
        .then(m => setSubPage(() => m.default))
        .catch(() => setSubPage(null))
        .finally(() => setPageLoading(false))
    } else {
      // page file doesn't exist yet
      setSubPage(null)
    }
  }, [activePage, appName])

  // ── derived: menu grouped by level ────────────────────────────────────────
  const level2Items = menuItems.filter(i => i.iLevel === 2 && i.iSequence > 0)

  const level3ByParent: Record<number, MenuItem[]> = {}
  for (const item of menuItems) {
    if (item.iLevel === 3 && item.iParentId != null) {
      if (!level3ByParent[item.iParentId]) level3ByParent[item.iParentId] = []
      level3ByParent[item.iParentId].push(item)
    }
  }

  const isModule = !!appName

  // ── nav handlers ──────────────────────────────────────────────────────────
  function handleHome() {
    setActivePage(null)
    setActiveL2(null)
    setSubPage(null)
  }

  function handleClickL2(item: MenuItem) {
    setActivePage(sUrlToFolder(item.sUrl))
    setActiveL2(item.iMenuId)
  }

  function handleClickSub(sub: MenuItem, parentMenuId: number) {
    setActivePage(sUrlToFolder(sub.sUrl))
    setActiveL2(parentMenuId)
  }

  // ── footer: cash balance display ──────────────────────────────────────────
  const cashBalanceStyle: React.CSSProperties = {}
  let cashBalanceText = 'เงินสดในมือ : [----------]'
  if (sessionInfo) {
    if (sessionInfo.counterSplit) {
      cashBalanceStyle.color = 'rgba(255,255,255,0.4)'
      cashBalanceText = 'เงินสดในมือ : [ไม่ใช่เจ้าหน้าที่การเงิน]'
    } else if (sessionInfo.counterOpened) {
      cashBalanceStyle.color = '#fff'
      cashBalanceText = 'เงินสดในมือ : [กำลังโหลด...]'
    } else {
      cashBalanceStyle.color = '#f97316'
      cashBalanceText = 'เงินสดในมือ : [ยังไม่เปิดเคาน์เตอร์]'
    }
  }

  // ── render ────────────────────────────────────────────────────────────────
  return (
    <div style={{ minHeight: '100vh', display: 'flex', flexDirection: 'column', background: '#f0f2f5' }}>

      {/* ══════════════════════════════════════════════════════════════════════
          HEADER
          ══════════════════════════════════════════════════════════════════════ */}
      <header style={{
        background: BG, color: '#fff', flexShrink: 0,
        display: 'flex', alignItems: 'stretch',
        padding: '0 16px', height: 52,
        position: 'relative', zIndex: 50,   // ← ให้ dropdown (zIndex:200) โผล่เหนือ <main>
      }}>

        {/* logo */}
        <div style={{ display: 'flex', alignItems: 'center', flexShrink: 0 }}>
          <img
            src={web1} alt="SO-AT" draggable={false}
            style={{ height: 40, objectFit: 'contain', cursor: 'pointer', flexShrink: 0 }}
            onClick={() => navigate('/')}
          />
        </div>

        {/* spacer */}
        <div style={{ flex: 1 }} />

        {/* level-2 nav bar (module mode only) */}
        {isModule && (
          <>
            <div style={{ display: 'flex', alignItems: 'stretch' }}>

              {/* Home button */}
              <button
                onClick={handleHome}
                style={{
                  background:   activePage === null ? ACTIVE : 'none',
                  border:       'none',
                  borderBottom: `2px solid ${activePage === null ? ACCENT : 'transparent'}`,
                  color:        '#fff',
                  padding:      '0 14px',
                  height:       '100%',
                  cursor:       'pointer',
                  fontSize:     14,
                  fontWeight:   400,
                  fontFamily:   'inherit',
                  whiteSpace:   'nowrap',
                  flexShrink:   0,
                }}
                onMouseEnter={e => { if (activePage !== null) e.currentTarget.style.background = HOVER }}
                onMouseLeave={e => { if (activePage !== null) e.currentTarget.style.background = 'none' }}
              >
                🏠 {homeLabel}
              </button>

              {/* level-2 items (with optional level-3 dropdowns)
                  NOTE: Oracle stores level-3.iParentId = level-2.iSequence (not iMenuId) */}
              {level2Items.map(item => (
                <TopNavItem
                  key={item.iMenuId}
                  item={item}
                  subItems={level3ByParent[item.iSequence] ?? []}
                  isActive={activeL2 === item.iMenuId}
                  activeSUrl={activePage}
                  onClickLeaf={handleClickL2}
                  onClickSub={sub => handleClickSub(sub, item.iMenuId)}
                />
              ))}
            </div>

            <div style={{
              width: 1, height: 28, background: 'rgba(255,255,255,0.2)',
              alignSelf: 'center', margin: '0 8px',
            }} />
          </>
        )}

        {/* right side: logo / module info + user + power */}
        <div style={{ display: 'flex', alignItems: 'center', gap: 12, flexShrink: 0 }}>

          {!isModule && (
            <img src={web2} alt="System" draggable={false}
              style={{ height: 40, objectFit: 'contain' }} />
          )}

          {isModule && (
            <div style={{ display: 'flex', alignItems: 'center', gap: 8 }}>
              <div style={{ textAlign: 'right', lineHeight: 1.4 }}>
                <div style={{ fontSize: 13, fontWeight: 500 }}>
                  {appName?.replace('sc', '')}
                </div>
                <div style={{ fontSize: 11, fontWeight: 400, opacity: 0.65 }}>
                  {moduleTh}
                </div>
              </div>
              {moduleIcon && (
                <img src={moduleIcon} alt={appName} draggable={false}
                  style={{ width: 32, height: 32, objectFit: 'contain', opacity: 0.9 }} />
              )}
            </div>
          )}

          <div style={{ width: 1, height: 28, background: 'rgba(255,255,255,0.2)' }} />

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

      {/* ══════════════════════════════════════════════════════════════════════
          CONTENT
          ══════════════════════════════════════════════════════════════════════ */}
      <main style={{ flex: 1, minHeight: 0, overflow: 'auto', position: 'relative' }}>

        {/* Module home splash (activePage === null) */}
        {isModule && activePage === null && (
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

        {/* Module sub-page (activePage !== null) */}
        {isModule && activePage !== null && (
          pageLoading
            ? (
              <div style={{ padding: 32, color: '#9ca3af', fontSize: 13 }}>
                กำลังโหลด {activePage}…
              </div>
            )
            : SubPage
              ? <SubPage />
              : (
                <div style={{
                  padding: 32,
                  display: 'flex', alignItems: 'center', gap: 10,
                  color: '#6b7280', fontSize: 13,
                }}>
                  <span style={{ fontSize: 20 }}>🚧</span>
                  <span>หน้า <strong>{activePage}</strong> อยู่ระหว่างพัฒนา</span>
                </div>
              )
        )}

        {/* scCenter content (or any other children) */}
        {!isModule && children}
      </main>

      {/* ══════════════════════════════════════════════════════════════════════
          FOOTER
          ══════════════════════════════════════════════════════════════════════ */}
      <footer style={{
        background: BG, color: '#fff',
        padding: '0 20px', height: 34,
        display: 'flex', alignItems: 'center', flexShrink: 0,
        borderTop: '1px solid rgba(255,255,255,0.08)',
        overflow: 'hidden',
      }}>
        <div style={{
          display: 'flex', alignItems: 'center', justifyContent: 'space-between',
          fontSize: 12, fontWeight: 400, width: '100%', minWidth: 0,
        }}>

          {/* left: user info, clipped when window is narrow */}
          <div style={{
            display: 'flex', alignItems: 'center', gap: 10,
            overflow: 'hidden', minWidth: 0, flexShrink: 1,
            whiteSpace: 'nowrap',
          }}>
            <span style={{ whiteSpace: 'nowrap', flexShrink: 0 }}>
              [{token ? userId : '?'}][{token ? (sessionInfo?.branchName ?? branchId ?? '?') : '?'}]
            </span>

            <span style={{ opacity: 0.3, flexShrink: 0 }}>|</span>

            <span style={{
              whiteSpace: 'nowrap', flexShrink: 0,
              color: sessionInfo?.financeDate ? '#fff' : 'rgba(255,255,255,0.4)',
            }}>
              วันที่เงิน : [{toThaiDate(sessionInfo?.financeDate ?? null)}]
            </span>

            <span style={{ opacity: 0.3, flexShrink: 0 }}>|</span>

            <span style={{ whiteSpace: 'nowrap', flexShrink: 0, ...cashBalanceStyle }}>
              {cashBalanceText}
            </span>

            <span style={{ opacity: 0.3, flexShrink: 0 }}>|</span>

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

          {/* right: copyright */}
          <div style={{
            opacity: 0.4, fontSize: 11, flexShrink: 0,
            whiteSpace: 'nowrap', paddingLeft: 16,
          }}>
            Copyright © 2019 All Right Reserved SO-AT
          </div>
        </div>
      </footer>

    </div>
  )
}
