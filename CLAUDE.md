# SoAt WebApp — Project Context

## โปรเจคนี้คืออะไร
ระบบสหกรณ์ออมทรัพย์ (Savings Cooperative) — migrate จาก legacy ไปสู่ modern stack ด้วย **Strangler Fig Pattern** (สร้าง module ใหม่ทีละตัว, ระบบเดิมยังทำงานระหว่าง migrate)

| | Legacy (`C:\SoAt_PEAN`) | Target (โปรเจคนี้) |
|---|---|---|
| Frontend | ASP.NET Web Forms + DevExpress 17.1.6 | **Blazor Server + DevExpress** |
| Backend | C# .NET Framework 4.8 | .NET Core (services เรียกตรงผ่าน DI) |
| Database | Oracle 19c | PostgreSQL (Npgsql + Dapper, schema คุมที่ pgAdmin) |

> **ทิศ frontend (ตัดสินใจ 2026-06-04):** เปลี่ยนจาก React/TypeScript → **Blazor Server + DevExpress**
> เหตุผล: ทีมถนัด C#, ผู้ใช้ใน intranet (จุดอ่อน Blazor Server ไม่กระทบ), และ reuse legacy XtraReports ~2,900 ตัวได้
> React (`frontend/`) ถูกลบออกแล้ว (commit `da07ed6`). **โครง Blazor scaffold แล้ว (2026-06-04)** + **ใส่ DevExpress.Blazor 25.2.7 แล้ว (2026-06-04)** — theme `office-white` (bs5) | ⚠️ license ปัจจุบันเป็น evaluation (build เตือน DX1000) ยังไม่ผ่าน license จริง

### โครงสร้าง repo (หลัง scaffold Blazor)
แต่ละ module = **Blazor Server app แยกตัวจริง** (รันแยก port ได้ เหมือน legacy ที่แต่ละ `sc*` แยก IIS site) — ยังไม่ login → เด้งไป **scCenter** (login กลาง)
```
SoAt.slnx                  ← solution ที่ root (รวมทุก project)
sc/                        ← service layer (เดิม backend/): SoAt.Core(sc/*) / Application / Infrastructure / Domain / API
scCenter/                  ← Blazor host: login + landing + รัน DB deployers (port 5100)
scTeller/                  ← module ตัวอย่าง (port 5110), folder ย่อยตรง legacy เช่น Pages/sctelnewbma/
```
- **Auth ข้าม app:** shared cookie `SoAt.Auth` + DataProtection key ring ร่วม (`%LOCALAPPDATA%\SoAt\keys`, `SetApplicationName("SoAt")`) → module อ่าน cookie ที่ scCenter เซ็นได้ (cookie ไม่แยกตาม port บน localhost). module ตั้ง `FallbackPolicy=RequireAuthenticatedUser` + `OnRedirectToLogin` → `{ScCenter:Url}/login?returnUrl=<absolute>`
- **scCenter เท่านั้นที่รัน deployers** (module assume DB พร้อม). Login = static SSR (`Account/Login.razor`) เรียก `IAuthService.AuthenticateAsync` แล้ว `HttpContext.SignInAsync`
- module ใหม่: `dotnet new blazor --interactivity Server --empty -o sc<Module>` ที่ root, copy auth block จาก `scTeller/Program.cs`, ref `sc/SoAt.*`, เพิ่มใน SoAt.slnx — **อย่าตั้ง folder ย่อยชื่อซ้ำ root namespace** (เช่น folder `scTeller` ใน project scTeller → namespace ชน)

**Legacy structure:** 65+ projects — `sc*` = แต่ละ module (scAccount, scAtm, scHr, scDeposit, scInvestment, ...), `rc*` = report ของแต่ละ module, `sc/` = core library กลาง. รายชื่อ module เต็มดูใน `C:\SoAt_PEAN\` — ชื่อ folder ใหม่ต้องตรง legacy เป๊ะ (case-sensitive).

---

## Oracle Database (Legacy — Read Only Reference)
```
Host: 192.168.101.29  Port: 1521  SID: pean  User: dbo  Pass: (ดู dbConn.xml)
sqlplus dbo/[password]@192.168.101.29:1521/pean
```
- ขนาด: 18.32 GB, 1,480 tables, 354 PL/SQL packages, 376 triggers
- Module ใหญ่สุด: SC_MEM 233 / SC_LON 171 / SC_HR 122 / SC_WEF 81 / SC_ACC 74 / SC_FIN 70 tables
- **Naming:** `sc_[module]_[type]_[name]` — type `m_`=Master/config, `t_`=Transaction (เช่น `sc_dep_m_creditor`, `sc_kep_t_monthly_receive`, `sc_cnt_m_coop`=coop config single-row)
- **PK หลัก:** `membership_no VARCHAR(15)` — เชื่อมทุก module

### Session State Pattern (สำคัญ)
Oracle เก็บ session state ใน package-level variables → PostgreSQL ใช้ `SET LOCAL` แทน:
```csharp
await conn.ExecuteAsync("SET LOCAL app.login_id = @id", new { id = userId });
await conn.ExecuteAsync("SET LOCAL app.login_br = @br", new { br = branchId });
```
```sql
-- Trigger: NEW.officer_id := current_setting('app.login_id', true);
```

### Migration จุดที่ต้องระวัง
- **Package variables** (`login_id`, `login_br`, ...) → `current_setting('app.xxx', true)`
- **BULK COLLECT** (`FETCH cur BULK COLLECT INTO ltab`) → `SELECT * INTO ltab FROM cur` — เขียนใหม่ทุกที่
- **Functions:** `NVL`→`COALESCE`, `SYSDATE`→`CURRENT_DATE`, `SYSTIMESTAMP`→`CURRENT_TIMESTAMP`, `FROM DUAL`→ลบ, `SYS_CONTEXT`→app layer, `DBMS_OUTPUT`→`RAISE NOTICE`
- **Triggers (376):** 304 TBIU (BEFORE INSERT/UPDATE — defaults+audit), 53 TM (AFTER — sync ไป SM_ shadow tables). เกือบทุกตัวเรียก `pka_com_login.login_id` → เปลี่ยนเป็น `current_setting()`

---

## Coding Guidelines

### PostgreSQL
- เงินใช้ `NUMERIC` (ไม่ใช่ FLOAT), flag ใช้ `BOOLEAN` (ไม่ใช่ CHAR(1))
- Naming: lowercase + underscore (คงชื่อ Oracle เดิม)
- audit columns ทุก table: `created_at`, `updated_at`, `created_by`, `updated_by`

### .NET Core API — `sc` namespace (`SoAt.Core/sc/`) เป็น primary library
ต้องการ utility ใดๆ ดูใน `sc/` ก่อน ถ้าไม่มีให้เพิ่มในไฟล์ที่เหมาะสม (db→`db.cs`, format→`value.cs`, security→`secure.cs`)
ไฟล์: `db`, `dbFactory`, `value`, `secure`, `log`, `app`, `util`, `mask`, `combo`, `json`, `xml`, `file`, `att`, `scCoop`, `service`, `css`, `ora`
- **`sc.dbFactory`** = Singleton — `dbFactory.create(userId, branchId)` ต่อ request
- **`sc.db`** — query/CRUD ทั้งหมด, auto-set session vars, `pkFunctionAsync`, `dbInsertAsync<T>` (reflection)
- **`sc.db.getComboAsync(comboValue)`** — dropdown ทุกตัวที่ต้องการแค่ code+name:
  - `"M=ชาย/F=หญิง"` → static key=value
  - `"#table|pk_col|desc_col[|type|filter]"` → query DB
  - `"select ... as item_code, ... as item_desc from ..."` → SQL ตรง
  - return `sc.ComboItem` (combo.cs) → Blazor component bind ตรง (Value=`code`, Text=`name`)
- **`sc.combo.*` constants** — ใช้แทน SQL เขียนเอง, ตรวจ combo.cs ก่อนเสมอ
- **`sc.scCoop.ofParse(membership_no)`** — validate + pad zeros (size จาก sc_cnt_m_coop)
- **ไม่มี EF Core แล้ว** (ถอดทั้งระบบ 2026-06-11) — schema ทั้งหมดคุมที่ pgAdmin, query+CRUD ผ่าน `sc.db` ตรง
- **Auth: cookie-based** (Blazor Server) — service เรียกตรงผ่าน DI, ไม่ผ่าน HTTP/JWT

### Blazor Server + DevExpress (frontend)
> โครง scaffold + ลง DevExpress.Blazor 25.2.7 แล้ว (2026-06-04). **Wiring จุดเดียวต่อ app:** csproj (`DevExpress.Blazor` + `.Themes`), `Program.cs` (`AddDevExpressBlazor()`), `_Imports.razor` (`@using DevExpress.Blazor`), `App.razor` (theme `<link>` อ่านจาก config). **เปลี่ยน theme = แก้ `appsettings.json` → `"DevExpress:Theme"` เท่านั้น** (ค่า: `office-white`/`blazing-berry`/`blazing-dark`/`purple`)
- Component = PascalCase `.razor`, module folder ตรง legacy เป๊ะ (case-sensitive)
- Navigation: scCenter เป็น public landing, login เมื่อเข้า module
- **Format/value ทุกตัวมาจาก `sc.*`** (อย่า hardcode ในหน้า) — ผูกกับ utility C# โดยตรง:
  - **วันที่** → `sc.value.toStringTH` — พ.ศ. display, ค.ศ. storage เสมอ
  - **เลขบัตร ปชช.** → `sc.mask.maskIdCard` (`9-9999-99999-99-9`)
  - **เงิน** → `sc.mask.maskDecimal` (`#,##0.00`) | **จำนวนเต็ม** → `#,##0` | **%** → `sc.mask.maskPercent2`
  - **Dropdown** → bind `sc.ComboItem` (Value=`code`, Text=`name`) จาก `sc.db.getComboAsync(sc.combo.*)`
- **DevExpress theme** — เปลี่ยน theme ที่จุดเดียว (config), ห้าม override สี/focus/shadow, แตะได้แค่ layout

### มาตรฐานโครงหน้าจอทุกเมนู (Page Architecture — บังคับใช้ทุก module/menu)
**ทุกหน้าเมนูแบ่งเป็น region:** `PanHead` (บน) / `PanDetail` (กลาง, optional) / `PanTabs` (ล่าง, optional) + **`PanOperate` bar (แนวตั้ง ขวา)** — แต่ละ region = **ไฟล์ `.razor` ของตัวเอง** ในโฟลเดอร์ module, ประกอบที่ `Page.razor`
- **ชื่อไฟล์ในแต่ละ module folder (บังคับเป๊ะ):** `Page.razor` (entry + `@page` route + `@rendermode InteractiveServer`), `PanHead.razor`, `PanDetail.razor`, `PanTabs.razor`, `PanOperate.razor` — ตัวอย่างจริง: `scTeller/Components/Pages/sctelnewbma/`. tag เรียกใช้ตรงชื่อไฟล์ เช่น `<PanHead ... />` `<PanTabs ... />`. ⚠️ **ชื่อ component ต้องขึ้นต้นตัวพิมพ์ใหญ่** (Razor RZ10011 — `pan*` ตัวเล็กไม่ผ่าน) จึงใช้ `Pan*`
- **Shared layout กลาง:** `scTeller/Components/Layout/PageRegions.razor` — รับ RenderFragment `HeaderContent`/`DetailContent`/`TabsContent`/`OperateContent`, จัด grid (ซ้าย region เรียงลง + PanOperate ขวา sticky). **region ไหนไม่ส่ง = ไม่ render** (เช่น sctelnewbma ไม่มี Detail)
- **State flow:** `Page.razor` เป็นเจ้าของ model + lookups ตัวเดียว → ส่งลง child ผ่าน `[Parameter]` (child เป็น dumb component, แก้ field ลงบน model ที่เป็น reference ร่วม). **`PanOperate` ยิง `EventCallback` กลับ** (`OnNew`/`OnOpen`/`OnSave`/`OnCancel`) ให้ Page จัดการ — child ไม่ persist เอง
- **PanOperate bar:** ปุ่มกลม class กลาง `.op-btn` (`.op-btn--danger` = แดง), ปัจจุบัน 4 ปุ่ม **New / Open / Save / Cancel**. icon ใช้ emoji ชั่วคราว
- **PanTabs = main composer เท่านั้น — แต่ละแท็บแยกเป็นไฟล์ใน `tabs/` sub-folder (บังคับทุกเมนูที่มี tabs):** เลียนโครง legacy (`panTabs.ascx` โหลด user control `u_tabpg_*.ascx` แต่ละตัว). `PanTabs.razor` มีแค่ `<DxTabs>` + `<DxTabPage>` ที่เรียก component ของแต่ละแท็บ — **ไม่ใส่ field/logic เองใน PanTabs**. แต่ละแท็บ = ไฟล์ `.razor` ใน `<module>/tabs/` ตั้งชื่อ **PascalCase ของชื่อ legacy** (เช่น `u_tabpg_newmem_bankinfo` → `UTabpgNewmemBankinfo.razor`). PanTabs ต้อง `@using <RootNs>.Components.Pages.<module>.tabs` เพื่อเรียกข้ามโฟลเดอร์. แท็บเป็น dumb component — รับ `Form`/`Lookups` ([Parameter]) แล้วแก้ลง model (reference ร่วม) ตรง เหมือน PanHead. ตัวอย่างจริง: `scTeller/Components/Pages/sctelnewbma/tabs/` (บัญชีธนาคาร = `DxGrid` edit-in-table, ครอบครัว/ส่งหุ้น-โอน = `DxFormLayout`)
- **CSS:** form helper (`.nb-*`) + `.op-*` ต้องอยู่ **global ที่ `wwwroot/app.css`** เพราะ scoped `.razor.css` ส่งไปถึง child component ไม่ได้. card/region chrome จัดโดย `PageRegions.razor.css`. ยังคงกฎ: ห้าม override DevExpress, แตะได้แค่ layout
- โมดูลใหม่: copy โครงไฟล์เหล่านี้จาก `sctelnewbma` (รวม `tabs/`) แล้วปรับเนื้อหา region ตามงานจริง

---

## Claude Working Rules (สำคัญมาก — ทำทุกครั้ง)
1. **อ่าน `sc/` ก่อนเขียนโค้ดใหม่เสมอ** (`mask.cs`, `value.cs`, `combo.cs`, `css.cs`, `att.cs`, `scCoop.cs`, `util.cs`, `db.cs`) — เพื่อรู้ว่ามี utility/constant อะไรแล้ว
2. **ถ้าไม่แน่ใจ ถามก่อน** — ห้ามคิดเองแล้วเขียนทันที ต้องรอ confirm
3. **UI ต้องเชื่อม C# ชัดเจน** — format/value ทุกตัวเรียกจาก `sc.*` ตรง (mask, value, combo) ไม่ hardcode ในหน้า
4. **ใช้ `sc.combo.*` แทน SQL เขียนเอง** — ตรวจ combo.cs ก่อน, dropdown code+name → `getComboAsync(sc.combo.xxx)`

---

## Architecture Decisions (ตัดสินใจแล้ว)
- **.NET Core layers (อยู่ใน `sc/`):** `SoAt.Application` (DTO+services) / `SoAt.Infrastructure` (sc.db, persistence, EF migrations, seeder) / `SoAt.Core` (sc/* library) / `SoAt.Domain`
  - **ตัด `SoAt.API` + JWT แล้ว (2026-06-04)** — Blazor app (scCenter/module) เรียก service ตรงผ่าน DI ไม่ผ่าน REST/controller. auth เหลือ cookie อย่างเดียว (`IAuthService.AuthenticateAsync`)
- Backend: **`sc.db`** สำหรับ query+CRUD ทั้งหมด (Npgsql/Dapper ตรง) — **ไม่มี EF Core** (ถอดทิ้ง 2026-06-11)
- Dropdown: **`sc.db.getComboAsync` + `sc.combo.*`** — ไม่เขียน SQL เอง
- DB naming: คงชื่อ Oracle เดิม (lowercase snake_case) — สร้าง/แก้ table ที่ pgAdmin โดยตรง
- **Frontend: Blazor Server + DevExpress** (เปลี่ยนจาก React 2026-06-04) | Auth: **cookie-based** (service ผ่าน DI)

### ยังไม่ตัดสินใจ
- [ ] register DevExpress license จริง (ตอนนี้ evaluation → DX1000 + watermark) — ห้าม redistribute จนกว่า license ผ่าน
- [ ] เริ่ม migrate module ไหนก่อน — [ ] Module-level permission
- [ ] federation strategy ของ `view_tel_get_creamation` (dblink 3 Oracle DB)
- [x] Scaffold โครง Blazor Server — **เสร็จ 2026-06-04** (scCenter host + scTeller module, cookie auth ข้าม app)
- [x] ใส่ DevExpress.Blazor 25.2.7 — **เสร็จ 2026-06-04** (theme office-white, config-driven, build 0 error)

---

## Database Schema (pgAdmin-managed — เปลี่ยน 2026-06-04)
**PostgreSQL เป็น source of truth ของ schema `sc_*`** (table/function/trigger/view ที่ migrate จาก Oracle). **PL team แก้ schema ที่ pgAdmin 4 โดยตรง** — ไม่มี SQL deployers + folder `Database/` อีกแล้ว (ลบทิ้ง 2026-06-04, กู้จาก git history commit `4f4a925`/`162c67d` ได้ถ้าต้องการ)

> เดิมใช้ "SQL-first deploy" (deployers ปั๊ม 2,378 .sql ทุก startup) — ช้า + ขัดกับ workflow จริงที่ PL ใช้ pgAdmin. เลิกใช้แล้ว

**`scCenter/Program.cs` startup ไม่แตะ DB แล้ว** — ทั้ง EF Migrations และ DatabaseSeeder ถอดออกหมด (2026-06-11). ทุก table (`sc_*` + auth `si_security_apps`/`si_security_user`) สร้าง+seed ที่ **pgAdmin โดยตรง**
> ⚠️ **rebuild DB เปล่า:** ต้องสร้าง schema + seed auth (user/menu) เองที่ pgAdmin ก่อนรันแอป — ไม่มี migrator คอยสร้างโครงให้แล้ว (โครงเดิม 2 ตาราง auth กู้ DDL จาก git history ก่อน commit ถอด EF ได้)

---

## สถานะ Stack ใหม่ (2026-06-04)
- Backend: build clean, sc.db migration สมบูรณ์ — service layer ย้ายเป็น `sc/` (เดิม `backend/`). **ตัด SoAt.API + JWT ทิ้งแล้ว** (Blazor เรียก service ตรงผ่าน DI)
- **Frontend: Blazor scaffold + DevExpress 25.2.7 แล้ว** — `scCenter` (host, :5100) + `scTeller` (module, :5110), cookie auth ข้าม app, build+run ผ่าน. theme `office-white` (config-driven, จุดเดียวที่ `appsettings DevExpress:Theme`). ⚠️ license ยังเป็น evaluation (DX1000)
- **DB schema:** คุมที่ **pgAdmin** แล้ว (ลบ SQL deployers + `Database/` 2026-06-04). schema เดิมที่ deploy ไว้ (Tables 1,460 / Functions 352+46 stub / Triggers 376 / Views 171) ยังอยู่ใน PG — จากนี้แก้ที่ pgAdmin
- **ประวัติ (git):** schema `.sql` ทั้งหมด + Step 6 (46 package stubs ใน `Database/Functions/_pkg_stubs/`) + 1 view defer (`VIEW_TEL_GET_CREAMATION` federate 3 Oracle DB) เก็บใน history commit `162c67d`/`4f4a925` — กู้คืนได้ถ้าต้องการ reference

### ถัดไป
1. register DevExpress license จริง (แทน evaluation) — DevExpress License Manager / `DevExpress_License.txt`
2. migrate module แรกขึ้น Blazor ด้วย DevExpress component (เช่น `sctelnewbma` ใน scTeller — มี service `ISctelnewbmaService` พร้อมแล้ว); UI bind `sc.*` (mask/value/combo) ตาม Coding Guidelines
3. ต่อ landing scCenter เข้า `IScAppService.GetAppsAsync()` แทนรายการ module ที่ hardcode
