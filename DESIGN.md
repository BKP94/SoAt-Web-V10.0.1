---
name: SoAt
description: ระบบบริหารงานสหกรณ์ออมทรัพย์ — เครื่องมือทำงานของเจ้าหน้าที่ บน Blazor Server + DevExpress (theme Fluent)
colors:
  paper: "oklch(0.975 0.003 250)"
  surface: "oklch(1 0 0)"
  sunken: "oklch(0.955 0.004 250)"
  line: "oklch(0.905 0.006 250)"
  line-strong: "oklch(0.82 0.008 250)"
  ink: "oklch(0.24 0.012 250)"
  ink-2: "oklch(0.40 0.012 250)"
  ink-3: "oklch(0.48 0.012 250)"
  accent: "oklch(0.50 0.13 250)"
  accent-strong: "oklch(0.44 0.13 250)"
  accent-ink: "oklch(1 0 0)"
  accent-soft: "oklch(0.955 0.02 250)"
  star: "oklch(0.62 0.15 70)"
  danger: "oklch(0.50 0.17 27)"
  danger-soft: "oklch(0.96 0.02 27)"
  success: "oklch(0.55 0.14 150)"
  focus: "oklch(0.55 0.16 250)"
  action-primary: "#0f6cbd"
  action-primary-hover: "#115ea3"
  action-primary-active: "#0c3b5e"
  action-danger: "#c50f1f"
  action-danger-hover: "#b10e1c"
  action-danger-active: "#960b18"
typography:
  headline:
    fontFamily: "Prompt, Segoe UI, Tahoma, sans-serif"
    fontSize: "1.375rem"
    fontWeight: 600
    lineHeight: 1.3
  subhead:
    fontFamily: "Prompt, Segoe UI, Tahoma, sans-serif"
    fontSize: "1.125rem"
    fontWeight: 600
    lineHeight: 1.3
  title:
    fontFamily: "Prompt, Segoe UI, Tahoma, sans-serif"
    fontSize: "0.9375rem"
    fontWeight: 600
    lineHeight: 1.35
  body:
    fontFamily: "Prompt, Segoe UI, Tahoma, sans-serif"
    fontSize: "0.9375rem"
    fontWeight: 400
    lineHeight: 1.55
  body-small:
    fontFamily: "Prompt, Segoe UI, Tahoma, sans-serif"
    fontSize: "0.8125rem"
    fontWeight: 400
    lineHeight: 1.55
  label:
    fontFamily: "Prompt, Segoe UI, Tahoma, sans-serif"
    fontSize: "0.75rem"
    fontWeight: 500
    lineHeight: 1.35
  mono:
    fontFamily: "ui-monospace, Consolas, Cascadia Mono, monospace"
    fontSize: "0.75rem"
rounded:
  s: "6px"
  m: "10px"
  button: "12px"
  l: "14px"
spacing:
  "1": "0.25rem"
  "2": "0.5rem"
  "3": "0.75rem"
  "4": "1rem"
  "5": "1.5rem"
  "6": "2rem"
  "7": "3rem"
components:
  button-primary:
    backgroundColor: "{colors.action-primary}"
    textColor: "{colors.accent-ink}"
    typography: "{typography.title}"
    rounded: "{rounded.button}"
    padding: "0.65rem 1.1rem"
    height: "44px"
  button-primary-hover:
    backgroundColor: "{colors.action-primary-hover}"
  button-primary-active:
    backgroundColor: "{colors.action-primary-active}"
  button-danger:
    backgroundColor: "{colors.action-danger}"
    textColor: "{colors.accent-ink}"
    rounded: "{rounded.button}"
    padding: "0.65rem 1.1rem"
    height: "44px"
  button-compact:
    backgroundColor: "{colors.action-primary}"
    textColor: "{colors.accent-ink}"
    rounded: "{rounded.button}"
    padding: "0.4rem 0.55rem"
    height: "36px"
  input:
    backgroundColor: "{colors.surface}"
    textColor: "{colors.ink}"
    typography: "{typography.body}"
    rounded: "{rounded.s}"
    padding: "0 0.75rem"
    height: "44px"
  card:
    backgroundColor: "{colors.surface}"
    textColor: "{colors.ink}"
    rounded: "{rounded.m}"
    padding: "0.5rem 0.5rem 0.5rem 0.75rem"
  card-hover:
    backgroundColor: "{colors.sunken}"
  badge:
    backgroundColor: "{colors.sunken}"
    textColor: "{colors.ink-2}"
    typography: "{typography.label}"
    rounded: "{rounded.s}"
    padding: "2px 0.5rem"
  dialog:
    backgroundColor: "{colors.surface}"
    rounded: "{rounded.l}"
    padding: "1.5rem"
    width: "25rem"
  operate-command:
    backgroundColor: "{colors.surface}"
    textColor: "{colors.ink}"
    typography: "{typography.body-small}"
    rounded: "{rounded.button}"
    padding: "0.5rem 0.25rem"
    height: "64px"
  operate-command-primary:
    backgroundColor: "{colors.action-primary}"
    textColor: "{colors.accent-ink}"
    rounded: "{rounded.button}"
    padding: "0.5rem 0.25rem"
    height: "64px"
---

# Design System: SoAt

## Overview

**Creative North Star: "The Cooperative Desk" (โต๊ะทำงานสหกรณ์)**

SoAt คือโต๊ะทำงานของเจ้าหน้าที่สหกรณ์ — เครื่องมือสำนักงานที่เป็นระเบียบ ใช้ต่อเนื่องทั้งวันได้โดยไม่ล้าตา พื้นผิวเป็นเทาอมฟ้าจางเกือบขาว แบ่งพื้นที่ด้วยเส้น 1px และระดับโทน ไม่ใช่เงาหรือไล่สี สีน้ำเงินเข้มของ Fluent ปรากฏเฉพาะจุดที่สั่งงาน (ปุ่มหลัก, ลิงก์, focus) เพื่อให้สายตาหาจุดลงมือได้ทันทีบนจอที่ข้อมูลหนาแน่น

ระบบนี้อยู่ใต้ DevExpress theme **Fluent** — component ของ DX (grid, form, combo, tabs, popup) เป็นผู้กำหนดหน้าตาส่วนใหญ่ และ SoAt เติมเฉพาะ chrome รอบๆ (rail, toolbar, การ์ด, กล่อง dialog ของเราเอง) ด้วย token ชุดเดียวที่โทนตรงกับ Fluent ความสวยวัดจากความแม่นยำ: ระยะ 4-pt, เป้ากด 44px, contrast ≥ 4.5:1 ทุกระดับตัวอักษร

**ที่มา:** มาตรฐานนี้ถอดจาก **scCenter launcher** (`scCenter/wwwroot/tokens.css`, `Home.razor.css`, `app.css`) และปุ่มกลาง `sc/SoAt.Blazor/wwwroot/soat.css`. หน้าตา module shell เดิม (sidebar กรมท่าไล่สี+ลายจุด, การ์ดมุม 18px, เงาฟ้านุ่ม, ปุ่ม Operate ม่วง/ชมพู ใน `sc*/wwwroot/app.css`) **เป็นของเก่าที่จะย้ายเข้ามาตรฐานนี้** — ห้ามต่อยอด

**Key Characteristics:**
- แบนที่สภาวะปกติ — แยกชั้นด้วยโทน paper → surface → sunken และเส้น `line`
- สีเน้นเดียว (น้ำเงิน Fluent) ใช้เฉพาะจุดสั่งงาน
- ตัวอักษร Prompt ตัวเดียวทั้งระบบ, น้ำหนัก 400–600
- เป้ากดขั้นต่ำ 44px, focus ring 2px ชัดเจน (keyboard-heavy)
- DevExpress Fluent คุมสี/focus/shadow ของ component — SoAt แตะแค่ layout

## Colors

โทนเย็นเป็นกลาง (hue 250) เกือบไร้ chroma บนพื้น + น้ำเงิน Fluent หนึ่งเดียวเป็นสีสั่งงาน — token ทั้งหมดเก็บเป็น OKLCH ใน `tokens.css` (canonical) ยกเว้นสีปุ่ม action ที่เป็น hex ของ Fluent ใน `soat.css`

### Primary
- **Fluent Working Blue** (`accent`): ลิงก์, ไอคอนหัวเรื่อง, สถานะเลือก — โทนเดียวกับ primary ของ Fluent; `accent-strong` สำหรับ hover/active บนพื้น accent; `accent-soft` เป็นพื้นอ่อนของสถานะเลือก
- **Action Blue** (`action-primary` → hover → active): พื้นปุ่มหลัก (`soat-btn`) — ตัวอักษรขาวผ่าน AA ทุกสถานะ (5.4 / 6.7 / 11.7 : 1)

### Neutral
- **Desk Paper** (`paper`): พื้นหลังหน้า และ toolbar ที่ติดบน
- **Clean Sheet** (`surface`): rail, การ์ด, dialog, ช่องกรอก
- **Recessed Tray** (`sunken`): hover/pressed ของการ์ด, badge, ที่ว่างของไอคอน, กล่องอ้างอิง
- **Hairline** (`line`) / **Firm Hairline** (`line-strong`): เส้นแบ่ง/ขอบการ์ด / ขอบช่องกรอก และ hover ของการ์ด
- **Ink** (`ink`) / **Ink Secondary** (`ink-2`) / **Ink Tertiary** (`ink-3`): ข้อความหลัก / คำอธิบาย / ป้ายรอง (`dt`, จำนวน, ชื่อภาษาอังกฤษ) — ทุกระดับ ≥ 4.5:1 บน surface และ paper

### State
- **Alert Red** (`danger` + `danger-soft`): ข้อผิดพลาด, ขอบช่องที่ invalid, แถบ error; **Danger Action** (`action-danger` → hover → active) สำหรับปุ่มทำลาย/ยกเลิก (6.1 / 7.0 / 8.9 : 1)
- **Confirm Green** (`success`): สถานะผ่าน validation
- **Focus Blue** (`focus`): focus ring ทุก element ที่เราสร้างเอง
- **Favorite Amber** (`star`): ดาวรายการโปรดใน launcher เท่านั้น
- Scrim (`oklch(0.22 0.015 250 / 0.5)`): ฉากหลัง dialog

### Named Rules
**The One Blue Rule.** สีน้ำเงินมีไว้บอกว่า "กดตรงนี้" เท่านั้น — ห้ามใช้เป็นพื้นตกแต่ง, ไล่สี, หรือแถบหัวการ์ด
**The Token-Only Rule.** หน้าและ component อ้างสีจาก token เท่านั้น — ห้าม hex/rgb inline ในหน้า (ยกเว้นตัวแปรปุ่มใน `soat.css` ซึ่งเป็นจุดเดียวที่ถือสี Fluent)
**The Ink-Not-Opacity Rule.** รายการที่ใช้ไม่ได้ ลดน้ำหนักด้วยการเปลี่ยนเป็น `ink-2` ไม่ใช่ลด opacity ของข้อความ — contrast ต้องคงอยู่

## Typography

**Body Font:** Prompt (fallback Segoe UI, Tahoma, sans-serif) — self-host ที่ `wwwroot/fonts/prompt.css`
**Mono Font:** ui-monospace / Consolas — เฉพาะรหัสอ้างอิง เช่น Request ID

**Character:** Prompt ตัวเดียวทั้งระบบ — เรขาคณิต อ่านง่ายทั้งไทยและตัวเลข ลำดับชั้นได้จากขนาดและน้ำหนัก 400/500/600 ไม่ใช่จากฟอนต์ที่สอง DevExpress รับ Prompt ผ่าน `--bs-body-font-family` / `--dxds-font-family-sans-serif`

### Hierarchy
- **Headline** (600, 1.375rem, 1.3): ชื่อหน้า/ชื่อ dialog ("ศูนย์รวมทุกระบบงาน", "เข้าสู่ระบบ")
- **Subhead** (600, 1.125rem, 1.3): headline บนจอแคบ ≤ 960px
- **Title** (600, 0.9375rem, 1.35): หัวกลุ่มรายการ, ปุ่ม
- **Body** (400–500, 0.9375rem, 1.35–1.6): ชื่อรายการ, ข้อความหลัก, ช่องกรอก
- **Body Small** (400–500, 0.8125rem, 1.55): คำอธิบาย, label ฟอร์ม, ค่าใน panel ข้อมูลระบบ
- **Label** (500–600, 0.75rem): ป้ายรอง, จำนวน, badge, หัวหมวด (letter-spacing .04em)

### Named Rules
**The Tabular Numbers Rule.** ตัวเลขที่เรียงหรือเทียบกัน (จำนวน, เบอร์โทร, ยอดเงิน) ใช้ `font-variant-numeric: tabular-nums`
**The No Italic Rule.** ภาษาไทยไม่ใช้ตัวเอียง — headline ตั้ง `font-style: normal` เสมอ
**The Wrap-Don't-Truncate Rule.** ชื่อ/ป้ายขึ้นบรรทัดใหม่ได้ (`overflow-wrap: anywhere`) แทนการตัด "…" เมื่อขยายตัวอักษร (WCAG 1.4.4)

## Layout

**Spacing:** สเกล 4-pt (`space-1`…`space-7` = 4 / 8 / 12 / 16 / 24 / 32 / 48px) — ใช้ token เท่านั้น

**Launcher (scCenter):** grid 2 คอลัมน์ — rail ซ้าย 17.5rem (sticky เต็มจอ, ตัวตนระบบ + panel ผู้ใช้/สาขา/วันที่การเงิน/ฐานข้อมูล + หมวด) | main (toolbar ค้นหาติดบน + รายการระบบเป็น index grid `auto-fill minmax(17rem, 1fr)` gap 8px)

**หน้าเมนูใน module (มาตรฐานบังคับ):** grid `minmax(0,1fr) | 104px` gap 16px — ซ้ายเรียง region `PanHead` / `PanDetail` / `PanTabs` ลงล่าง, ขวาเป็น `PanOperate` sticky. region ใดไม่ส่ง = ไม่ render. แต่ละ region ใช้การ์ดแบบเดียวกับ Card ด้านล่าง (surface + hairline + `rounded.m`, ไม่มีเงา) — ค่า 18px/เงาใน `PageRegions.razor.css` เดิมเป็นของเก่าที่ต้องย้าย

**ความหนาแน่น:** desktop intranet ใช้ทั้งวัน — หนาแน่นได้ แต่ทุกเป้ากด ≥ 44px (compact ในตาราง ≥ 36px)

**Responsive:** ≤ 960px rail ยุบเป็นแถบบน (panel ข้อมูล 2 คอลัมน์, หมวดเป็น grid) · ≤ 420px หมวด 2 คอลัมน์ ซ่อนไอคอนหมวด · ≤ 360px ลด padding rail. Desktop เป็นเป้าหลัก จอแคบต้องไม่พัง

## Elevation & Depth

แบนเป็นค่าเริ่มต้น — ความลึกมาจากระดับโทน (paper < surface, sunken สำหรับสภาวะกด) และเส้น hairline เงามีแค่สองที่: dialog ที่ลอยเหนือ scrim และปุ่ม action หลักที่ยกขึ้นเล็กน้อยเพื่อบอกว่ากดได้

### Shadow Vocabulary
- **Dialog lift** (`box-shadow: 0 24px 48px -16px oklch(0.22 0.02 250 / 0.28)`): login/dialog ของเราเอง
- **Action rest** (`0 2px 6px rgba(15,108,189,.22)`) / **Action hover** (`0 4px 10px rgba(15,108,189,.28)` + `translateY(-1px)`): ปุ่ม `soat-btn` หลักเท่านั้น (danger ใช้โทนแดงเดียวกัน; compact/ghost/disabled ไม่มีเงา)

### Named Rules
**The Flat-By-Default Rule.** การ์ด, region, rail, toolbar ไม่มีเงา — hover ตอบด้วยขอบเข้มขึ้น + พื้น sunken ไม่ใช่การยก
**The No-Gradient Rule.** ห้ามไล่สีบนปุ่มหรือพื้นผิว — จุดสว่างของ gradient เดิมทำ contrast ตกเหลือ 2.8–3.7:1

## Shapes

มุมมนพอดี ไม่กลมจนเป็นของเล่น: `rounded.s` 6px (ช่องกรอก, badge, focus outline รอบลิงก์), `rounded.m` 10px (การ์ด, panel, region), `rounded.button` 12px (ปุ่ม action), `rounded.l` 14px (dialog). ขอบ 1px hairline ทุกพื้นผิวที่อยู่บน paper. panel ข้อมูลแบบ key–value ใช้เทคนิค "gap 1px บนพื้น line" ให้ได้เส้นคั่นแถวคมโดยไม่ซ้อนขอบ

## Components

DevExpress component (DxButton, DxGrid, DxFormLayout, DxComboBox/`<ScCombo>`, DxTabs, DxPopup) **เลือกใช้ก่อนเสมอ** และปล่อยให้ Fluent คุมสี/focus/shadow — รายการด้านล่างคือส่วนที่ SoAt กำหนดเอง

### Buttons
- **Shape:** มุม 12px, สูงขั้นต่ำ 44px, กว้างขั้นต่ำ 104px, ตัวหนา 600
- **Primary (`CssClass="soat-btn"`):** พื้น Action Blue ตัวอักษรขาว + Action rest shadow
- **Hover / Active:** พื้นเข้มขึ้นหนึ่งขั้น + ยก 1px / พื้นเข้มสุด กลับที่เดิม (160ms)
- **Danger (`soat-btn--danger`):** ชุดเดียวกันโทนแดง
- **Secondary / Ghost (`RenderStyle.Secondary` / `soat-btn--ghost`):** ปล่อย Fluent theme คุมทั้งหมด ไม่มีเงา/ยก
- **Compact (`soat-btn--compact`, `po-openbtn`):** ในตาราง/ปุ่มเปิด — สูง 36px, ไม่มีเงา/ยก, ไม่บังคับความกว้าง
- **Disabled:** opacity .55, ไม่มีเงา, cursor not-allowed

### Cards / Containers
- **Corner Style:** 10px
- **Background:** surface บน paper; hover ขอบ `line-strong`, กด/hover ลิงก์ = `sunken`
- **Shadow Strategy:** ไม่มี (Flat-By-Default)
- **Border:** 1px `line`
- **Internal Padding:** 8px 8px 8px 12px, สูงขั้นต่ำ 60px (ไอคอน 40px + ชื่อไทย + ชื่ออังกฤษรอง)
- **Inactive:** ชื่อเป็น `ink-2`, ไอคอน grayscale, ไม่ตอบ hover

### Inputs / Fields
- **Style:** ใช้ DxTextBox/DxComboBox ตาม Fluent; ช่องที่สร้างเอง (login) = ขอบ 1px `line-strong`, มุม 6px, สูง 44px, label 0.8125rem/500 อยู่เหนือช่อง
- **Focus:** outline 2px `focus` offset 1px + ขอบเป็น `focus`
- **Error:** ขอบ `danger`; ข้อความ error เป็นกล่อง `danger-soft` ขอบ `danger` พร้อมไอคอน

### Navigation
- **Launcher rail:** หมวดเป็น DxButton เต็มความกว้าง ชิดซ้าย สูง 44px (ไอคอน + ชื่อ + จำนวน tabular)
- **Toolbar:** ติดบน พื้น paper เส้นล่าง hairline, ช่องค้นหากว้างสุด 36rem
- **Module navigation:** ยังเป็น sidebar กรมท่าแบบเก่า — **รอย้ายเข้ามาตรฐานนี้**

### Session Panel (signature)
panel key–value ใต้ตัวตนระบบ: ผู้ใช้งาน / สาขา / วันที่การเงิน / ฐานข้อมูล — `dt` เป็น Label `ink-3`, `dd` เป็น Body Small 500 ชิดขวา. บริบทนี้ต้องมองเห็นได้เสมอในทุกจอทำงาน

### Dialog
มุม 14px, กว้าง ≤ 25rem, padding 24px, Dialog lift + scrim, เข้าด้วย fade + rise 8px (180ms, `cubic-bezier(0.2, 0.7, 0.2, 1)`); reduced-motion = fade สั้นอย่างเดียว. ข้อความแจ้งเตือนทั่วไปใช้ `ScMessage` (modal กลางจอ)

### PanOperate — Command Stack
แถบคำสั่งแนวตั้งขวา sticky (คอลัมน์ 104px ของ `PageRegions`, padding 8px) ยิง `EventCallback` กลับ Page. สไตล์อยู่ที่ `soat.css` ที่เดียว (`.op-stack` / `.op-cmd`)
- **Markup:** `<div class="op-stack" role="toolbar" aria-orientation="vertical" aria-label="คำสั่ง…">` ครอบ `<DxButton>` ตรงๆ — ไม่มีหัวข้อ/wrapper/label แยก; ป้ายใช้ `Text=` (เป็น accessible name ในตัว), คำอธิบายเต็มใส่ `title`
- **Shape:** เต็มความกว้างคอลัมน์, สูงขั้นต่ำ 64px, มุม 12px, ไอคอน Bootstrap 20px (`sc.icon.*`) อยู่บน ป้าย 0.8125rem/500 อยู่ล่าง, ระยะห่างปุ่ม 8px; ป้ายยาวตัดบรรทัดตามคำไทย (ไม่ตัดด้วย …)
- **ลำดับความสำคัญ:** ปุ่มหลัก 1 ปุ่มต่อหน้า = `RenderStyle.Primary` + `op-cmd--primary` (ตัวหนา 600 + Action rest shadow, hover = Action hover shadow ไม่ยก) — **บันทึกเมื่อหน้ามีบันทึก**, ไม่มีให้ใช้คำสั่งหลักเดิมของหน้า (เช่น เพิ่มใหม่ / เปิดรายงาน / เริ่มใหม่)
- **รอง:** `RenderStyle.Secondary` + `Outline` — สีจาก Fluent ล้วน
- **ยกเลิก/ทำลาย:** `RenderStyle.Danger` + `Outline` + `op-cmd--danger` (เว้นบนเพิ่ม 8px แยกจากกลุ่ม); Fluent แสดงกลางๆ ตอนพัก และแดงเมื่อ hover — ไม่ override
- **Focus / Disabled:** ใช้ของ Fluent (outline 2px); disabled ไม่มีเงา cursor not-allowed
- **ห้าม:** ปุ่มกลม, gradient/แสงเรือง orbit, ม่วง `#5b4cf0` / ชมพู `#ff1f5a`, override `--dxbl-btn-*`

## Do's and Don'ts

### Do:
- **Do** ใช้ DevExpress component ก่อนเสมอ และแตะแค่ layout/ขนาดผ่าน helper class global ใน `app.css`
- **Do** อ้างสี/ฟอนต์/ระยะจาก token ใน `tokens.css`; ปุ่ม action ใช้ `CssClass="soat-btn"` จาก `soat.css` (แก้สไตล์ปุ่มที่ไฟล์นั้นที่เดียว)
- **Do** ให้ทุกเป้ากด ≥ 44px (compact ในตาราง ≥ 36px) และ element ที่สร้างเองมี `:focus-visible` outline 2px `focus`
- **Do** ใส่ `prefers-reduced-motion` ปิด transition/animation ทุกจุดที่มีการเคลื่อนไหว (120–180ms, ease-out)
- **Do** จำกัด hover ไว้ใต้ `@media (hover: hover)` เพื่อไม่ค้างสถานะบนจอสัมผัส

### Don't:
- **Don't** override `--dxbl-*` สี/focus/shadow ของ DevExpress (ยกเว้นภายใน `soat-btn` ที่กำหนดไว้แล้ว)
- **Don't** ใช้ gradient, ลายจุด, แสงเรือง หรือพื้นกรมท่าไล่สี (ภาษาภาพ module shell เดิม) ในหน้าใหม่
- **Don't** ใช้มุม 18px หรือเงาฟ้านุ่ม (`0 8px 24px rgba(56,87,148,.06)`) บนการ์ด/region
- **Don't** ใช้ม่วง `#5b4cf0` หรือชมพู `#ff1f5a` ที่ใดๆ
- **Don't** ใช้ฟอนต์อื่นนอกจาก Prompt หรือตัวเอียงกับภาษาไทย
- **Don't** ลด opacity ข้อความเพื่อแสดงสถานะใช้ไม่ได้ — เปลี่ยนเป็น `ink-2`
- **Don't** แสดงโลโก้/ชื่อสหกรณ์ลูกค้าบนหน้าจองาน (อยู่ในหน้าตั้งค่าเท่านั้น)
