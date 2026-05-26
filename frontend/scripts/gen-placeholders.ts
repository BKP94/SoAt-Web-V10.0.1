/**
 * gen-placeholders.ts
 * สร้าง placeholder index.tsx สำหรับทุก sub-page ใน si_security_apps
 *
 * วิธีรัน (ต้อง backend ทำงานอยู่):
 *   npx tsx scripts/gen-placeholders.ts
 *
 * หรือถ้าไม่มี tsx:
 *   npx ts-node --esm scripts/gen-placeholders.ts
 */

import fs   from 'fs'
import path from 'path'

const API_BASE  = 'http://localhost:5139'
const PAGES_DIR = path.resolve(__dirname, '../src/pages')

// ── extract folder name จาก Oracle sUrl ──────────────────────────────────────
// "../scteldet/page.aspx" → "scteldet"
function sUrlToFolder(sUrl: string | null): string | null {
  if (!sUrl) return null
  const m = sUrl.match(/\.\.?\/([^/]+)\//)
  return m ? m[1] : null
}

// ── placeholder template ──────────────────────────────────────────────────────
function makeTemplate(appName: string, folder: string, labelTh: string): string {
  return `/**
 * ${appName} / ${folder} — ${labelTh}
 * Placeholder — อยู่ระหว่างพัฒนา
 */
export default function ${capitalize(folder)}Page() {
  return (
    <div style={{ padding: 32 }}>
      <div style={{
        display: 'inline-flex', alignItems: 'center', gap: 12,
        background: '#eff6ff', border: '1px solid #bfdbfe',
        borderRadius: 8, padding: '12px 20px',
        color: '#1e40af', fontSize: 14,
      }}>
        <span style={{ fontSize: 20 }}>🚧</span>
        <div>
          <div style={{ fontWeight: 600 }}>{labelTh} ({folder})</div>
          <div style={{ fontSize: 12, opacity: 0.75, marginTop: 2 }}>อยู่ระหว่างพัฒนา</div>
        </div>
      </div>
    </div>
  )
}
`.replace('{labelTh}', labelTh).replace('{folder}', folder)
}

function capitalize(s: string) {
  return s.charAt(0).toUpperCase() + s.slice(1)
}

// ── main ──────────────────────────────────────────────────────────────────────
async function main() {
  // 1. ดึง module ทั้งหมด level=1
  const appsRes  = await fetch(`${API_BASE}/api/sc/apps?level=1`)
  const apps     = await appsRes.json() as { appName: string }[]

  let created = 0
  let skipped = 0

  for (const app of apps) {
    const { appName } = app
    if (!appName || appName === 'scCenter') continue

    // 2. ดึง menu level 2+3
    const menuRes  = await fetch(`${API_BASE}/api/sc/menu?appName=${appName}`)
    const menuItems = await menuRes.json() as {
      iLevel: number; sUrl: string | null; labelTh: string; label: string
    }[]

    const level3 = menuItems.filter(i => i.iLevel === 3)

    for (const item of level3) {
      const folder = sUrlToFolder(item.sUrl)
      if (!folder) continue

      const filePath = path.join(PAGES_DIR, appName, folder, 'index.tsx')

      if (fs.existsSync(filePath)) {
        skipped++
        continue
      }

      // สร้าง directory + file
      fs.mkdirSync(path.dirname(filePath), { recursive: true })
      const label = item.labelTh || item.label || folder
      fs.writeFileSync(filePath, makeTemplate(appName, folder, label), 'utf8')
      console.log(`  ✅ ${appName}/${folder}`)
      created++
    }
  }

  console.log(`\nสร้างใหม่: ${created} files | ข้าม (มีอยู่แล้ว): ${skipped} files`)
}

main().catch(e => { console.error(e); process.exit(1) })
