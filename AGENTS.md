# AGENTS.md — กติกาสำหรับ AI ที่ทำงานฝั่ง UI (Codex)

> โปรเจคนี้ใช้ AI 2 ตัวแบ่งหน้าที่กัน — **ไฟล์นี้คือกติกาของฝั่ง UI**
>
> | ใคร | หน้าที่ |
> |---|---|
> | **Claude Code** | Backend, Database, API, Business Logic (`sc/`, services, SQL) |
> | **Codex (คุณ)** | Layout, Responsive, CSS, Component UI, Animation |
> | **เจ้าของโปรเจค** | ตรวจหน้าจอ + ตัดสินใจรับโค้ด |

## โปรเจคนี้คืออะไร (ย่อ)

ระบบสหกรณ์ออมทรัพย์ — migrate จาก legacy (`C:\SoAt_TNMA`, ASP.NET Web Forms + Oracle) มาเป็น **Blazor Server + DevExpress 26.1.3 + PostgreSQL**. แต่ละ module (`scCenter`, `scTeller`, `scKeeping`, ...) เป็น Blazor Server app แยกตัว รันแยก port, login กลางที่ scCenter (cookie ข้าม app)

## ขอบเขต — ห้ามข้ามเส้น

**แตะได้:** ไฟล์ `.razor` (เฉพาะส่วน markup/layout), `.razor.css`, `wwwroot/app.css`, `wwwroot/` assets, component UI ใหม่ที่เป็น presentation ล้วน

**ห้ามแตะ (งานของ Claude Code):**
- `sc/` ทั้งโฟลเดอร์ (SoAt.Core / Application / Infrastructure / Domain)
- โค้ด `@code { }` ส่วน logic: การเรียก service, query, save, validation, event handler ที่มี business logic
- SQL / database ทุกชนิด
- `Program.cs`, `appsettings.json`, csproj, DI wiring
- ถ้างาน UI ต้องการ property/method ใหม่จากฝั่ง C# → **หยุดแล้วบอกเจ้าของโปรเจค** อย่าเขียน backend เอง

## มาตรฐานบังคับ (ละเมิด = โค้ดไม่ถูกรับ)

### 1. DevExpress-first
- ปุ่ม/ฟอร์ม/ตาราง/แท็บ ใช้ DevExpress component ก่อนเสมอ: `DxButton`, `DxFormLayout`, `DxGrid`, `DxTabs`, `DxComboBox` ฯลฯ — **ห้าม** hardcode `<button>`/`<span>` ทำเองถ้ามี DX component ที่ตรง
- component ไม่ตรงคาด → ค้น property/API ของ DevExpress ให้จบก่อน อย่ารีบ workaround (เช่น `DxFormLayoutGroup` พับได้ต้องใส่ `ExpandButtonDisplayMode` ไม่ใช่เขียน caret เอง)
- สี/ไฮไลต์ในตาราง → ใช้ `CustomizeElement` ไม่ใช่ CSS ทับ

### 2. Theme — ห้าม override
- theme เป็น config-driven (`appsettings.json` → `DevExpress:Theme`, ปัจจุบัน `office-white`) — เปลี่ยน theme = แก้ config จุดเดียวเท่านั้น
- **ห้าม override สี / focus / shadow ของ DevExpress** — CSS แตะได้เฉพาะ **layout** (grid, spacing, ขนาด, จัดวาง)

### 3. Page Architecture (ทุกหน้าเมนู)
ทุกเมนูแบ่ง region เป็นไฟล์ของตัวเองในโฟลเดอร์ module (ชื่อบังคับเป๊ะ):
```
<module>/Page.razor        ← entry (@page route + @rendermode InteractiveServer) เจ้าของ model
<module>/PanHead.razor     ← ส่วนบน
<module>/PanDetail.razor   ← ส่วนกลาง (optional)
<module>/PanTabs.razor     ← composer ของแท็บเท่านั้น — ห้ามใส่ field/logic
<module>/PanOperate.razor  ← bar ปุ่มแนวตั้งขวา (New/Open/Save/Cancel, class .op-btn)
<module>/tabs/UTabpgXxx.razor ← แต่ละแท็บแยกไฟล์ (PascalCase จากชื่อ legacy u_tabpg_*)
```
- Layout กลาง: `Components/Layout/PageRegions.razor` (region ไหนไม่ส่ง = ไม่ render)
- Child เป็น dumb component: รับ `Form`/`Lookups` ผ่าน `[Parameter]` แก้ลง model reference ร่วม; `PanOperate` ยิง `EventCallback` กลับให้ Page — **ห้ามเปลี่ยน state flow นี้**
- ตัวอย่างจริง: `scTeller/Components/Pages/sctelnewbma/`

### 4. Format/ค่า ทุกตัวมาจาก `sc.*` — ห้าม hardcode ในหน้า
- วันที่ → `sc.value.toStringTH` (แสดง พ.ศ., เก็บ ค.ศ.)
- เลขบัตร ปชช. → `sc.mask.maskIdCard` | เงิน → `sc.mask.maskDecimal` | % → `sc.mask.maskPercent2`
- Dropdown ทุกช่อง → component กลาง `<ScCombo>` bind `sc.ComboItem` จาก `sc.db.getComboAsync(sc.combo.*)` — ห้ามสร้าง dropdown เอง/ห้าม hardcode รายการ
- ปรับ layout รอบ binding เดิมได้ แต่**ห้ามเปลี่ยน/ลบ binding ที่เรียก `sc.*`**

### 5. CSS
- font ทั้งโปรเจค = **Prompt เท่านั้น** (self-host แล้วทุก module) — ห้ามเพิ่ม font อื่น/ห้ามดึงจาก CDN
- helper class กลาง (`.nb-*`, `.op-*`) อยู่ **`wwwroot/app.css`** (global) — scoped `.razor.css` ส่งไม่ถึง child component
- card/region chrome อยู่ `PageRegions.razor.css`
- ชื่อ component/ไฟล์ `.razor` ต้องขึ้นต้นตัวพิมพ์ใหญ่ (Razor RZ10011)

### 6. อ้างอิงหน้าจอ legacy
- หน้าตา/โครงหน้าจอต้นแบบดูจาก legacy ที่ **`C:\SoAt_TNMA`** (Web Forms `.ascx`/`.aspx` ชื่อ folder ตรง module) — โครง 2 คอลัมน์/ลำดับ field ให้ใกล้ legacy แล้วค่อยปรับ modern
- ชื่อ folder module ใหม่ต้องตรง legacy เป๊ะ (case-sensitive)

## Build / Run / ตรวจงาน

- Solution: `SoAt.slnx` ที่ root — `dotnet build SoAt.slnx`
- รันดู: scCenter :5100 (login กลาง), scTeller :5110, module อื่นดู `launchSettings.json` ของแต่ละตัว
- test login: user `orn` / pass `2` (ต้องมี PostgreSQL docker `soat-postgres` รันอยู่)
- ก่อน build ใหม่ถ้า DLL lock: รัน `stop-dev.ps1`
- build มี warning `DX1000` (DevExpress evaluation license) = ปกติ ไม่ต้องแก้

## มารยาทการทำงานร่วมกัน

- **อย่าแก้/ลบ/refactor โค้ดฝั่ง logic ของ Claude Code** แม้จะดู "ไม่สวย" — ถ้าเห็นปัญหาให้บันทึกบอกเจ้าของโปรเจค
- commit เฉพาะเมื่อเจ้าของโปรเจคสั่ง — เจ้าของเป็นคนตัดสินใจรับโค้ด
- ตอบ/สื่อสารเป็นภาษาไทย
