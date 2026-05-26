import { useState, useEffect } from 'react'
import { useNavigate } from 'react-router-dom'
import { useAuthStore } from '@/stores/authStore'
import MasterLayout from '@/components/MasterLayout'
import ModuleLoginModal from '@/components/ModuleLoginModal'

// Load all menu icons at build time so they're bundled and fingerprinted
const iconMap = import.meta.glob<string>(
  '/src/icon/imgMenu/*.png',
  { eager: true, query: '?url', import: 'default' }
)

function getIconSrc(iconName: string | null | undefined): string {
  if (!iconName) return ''
  return iconMap[`/src/icon/imgMenu/${iconName}`] ?? ''
}

// Path map — only routing info, no icon/color (those come from DB)
const MODULE_PATH: Record<string, string> = {
  scTeller:      '/scTeller',
  scApprove:     '/scApprove',
  scDeposit:     '/scDeposit',
  scFinance:     '/scFinance',
  scKeeping:     '/scKeeping',
  scAccount:     '/scAccount',
  scReport:      '/scReport',
  scAdmin:       '/scAdmin',
  scTransbank:   '/scTransbank',
  scEstate:      '/scEstate',
  scAtm:         '/scAtm',
  scLaw:         '/scLaw',
  scWelfare:     '/scWelfare',
  scCoordinate:  '/scCoordinate',
  scMobile:      '/scMobile',
  scElections:   '/scElections',
  scPermit:      '/scPermit',
  scProDATA:     '/scProDATA',
  scInsurance:   '/scInsurance',
  scExp:         '/scExp',
  scScholarship: '/scScholarship',
  scCremation:   '/scCremation',
  scKeepcoll:    '/scKeepcoll',
  scFund:        '/scFund',
  scBillpayment: '/scBillpayment',
  scHr:          '/scHr',
  scEdocument:   '/scEdocument',
  scStock:       '/scStock',
  scEoffice:     '/scEoffice',
  scInvestment:  '/scInvestment',
  scRing2Me:     '/scRing2Me',
}

interface Module {
  id: string
  nameEn: string
  nameTh: string
  path: string
  iconSrc: string
  enabled: boolean
}

export default function ScCenterPage() {
  const navigate = useNavigate()
  const { token } = useAuthStore()
  const [selectedModule, setSelectedModule] = useState<Module | null>(null)
  const [modules,        setModules]        = useState<Module[]>([])

  useEffect(() => {
    fetch('/api/sc/apps?level=1')
      .then(r => r.json())
      .then((apps: { appName: string; appTextThai: string; appTextEnglish: string; active: boolean; iSequence: number; iconName: string | null }[]) => {
        const built = apps
          .filter(a => a.appName !== 'scCenter')
          .map(a => ({
            id: a.appName,
            nameEn: a.appTextEnglish || a.appName,
            nameTh: a.appTextThai,
            path: MODULE_PATH[a.appName] ?? `/${a.appName}`,
            iconSrc: getIconSrc(a.iconName),
            enabled: a.active,
          }))
        setModules(built)
      })
      .catch(() => setModules([]))
  }, [])

  function handleModuleClick(mod: Module) {
    if (!mod.enabled) return
    if (token) {
      navigate(mod.path)
    } else {
      setSelectedModule(mod)
    }
  }

  return (
    <MasterLayout>

      {/* ── Module Grid ────────────────────────────────────────────────────── */}
      <div style={{ padding: '20px 24px', boxSizing: 'border-box', width: '100%' }}>
        {modules.length === 0 ? (
          <div style={{ textAlign: 'center', color: '#9ca3af', marginTop: 60, fontSize: 14 }}>
            กำลังโหลด...
          </div>
        ) : (
          <div style={{
            display: 'grid',
            // auto-fill: เพิ่ม/ลด column ตามพื้นที่ — min 130px/card, max ไม่เกิน 8 col
            gridTemplateColumns: 'repeat(auto-fill, minmax(130px, 1fr))',
            gap: 12,
            maxWidth: 1200,
            margin: '0 auto',
            width: '100%',
          }}>
            {modules.map((mod) => (
              <button
                key={mod.id}
                onClick={() => handleModuleClick(mod)}
                disabled={!mod.enabled}
                title={mod.enabled ? mod.nameTh : `${mod.nameTh} (ยังไม่เปิดใช้งาน)`}
                style={{
                  display: 'flex',
                  flexDirection: 'column',
                  alignItems: 'center',
                  justifyContent: 'center',
                  gap: 8,
                  padding: '14px 8px 10px',
                  background: '#fff',
                  border: '1px solid #e5e7eb',
                  borderRadius: 16,
                  cursor: mod.enabled ? 'pointer' : 'default',
                  opacity: mod.enabled ? 1 : 0.35,
                  transition: 'box-shadow 0.15s, transform 0.1s',
                  userSelect: 'none',
                  fontFamily: 'inherit',
                  minHeight: 130,
                }}
                onMouseEnter={(e) => {
                  if (!mod.enabled) return
                  e.currentTarget.style.boxShadow = '0 4px 12px rgba(0,0,0,0.15)'
                  e.currentTarget.style.transform = 'translateY(-2px)'
                }}
                onMouseLeave={(e) => {
                  e.currentTarget.style.boxShadow = 'none'
                  e.currentTarget.style.transform = 'none'
                }}
              >
                {/* Icon */}
                <div style={{ width: 64, height: 64, display: 'flex', alignItems: 'center', justifyContent: 'center', flexShrink: 0 }}>
                  {mod.iconSrc ? (
                    <img
                      src={mod.iconSrc}
                      alt={mod.nameEn}
                      style={{ width: 64, height: 64, objectFit: 'contain', filter: mod.enabled ? 'none' : 'grayscale(100%)' }}
                      draggable={false}
                    />
                  ) : (
                    <div style={{ width: 64, height: 64, borderRadius: '50%', background: '#e5e7eb' }} />
                  )}
                </div>

                {/* Module name */}
                <div style={{ textAlign: 'center', width: '100%', padding: '0 4px', boxSizing: 'border-box' }}>
                  <div style={{ fontSize: 11, fontWeight: 600, color: '#111827', lineHeight: 1.3,
                    overflow: 'hidden', textOverflow: 'ellipsis', whiteSpace: 'nowrap' }}>
                    {mod.nameEn}
                  </div>
                  <div style={{ fontSize: 10, color: '#6b7280', lineHeight: 1.4, marginTop: 2,
                    overflow: 'hidden', textOverflow: 'ellipsis', whiteSpace: 'nowrap' }}>
                    {mod.nameTh}
                  </div>
                </div>
              </button>
            ))}
          </div>
        )}
      </div>

      {/* ── Login Modal ────────────────────────────────────────────────────── */}
      {selectedModule && (
        <ModuleLoginModal
          module={{
            id:      selectedModule.id,
            label:   selectedModule.nameEn,
            nameTh:  selectedModule.nameTh,
            path:    selectedModule.path,
            iconSrc: selectedModule.iconSrc,
          }}
          onClose={() => setSelectedModule(null)}
        />
      )}

    </MasterLayout>
  )
}
