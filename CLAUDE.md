# SoAt WebApp — Project Context

## โปรเจคนี้คืออะไร
ระบบสหกรณ์ออมทรัพย์ (Savings Cooperative) — migrate จาก legacy ไปสู่ modern stack ด้วย **Strangler Fig Pattern** (สร้าง module ใหม่ทีละตัว, ระบบเดิมยังทำงานระหว่าง migrate)

| | Legacy (`C:\SoAt_PEAN`) | Target (โปรเจคนี้) |
|---|---|---|
| Frontend | ASP.NET Web Forms + DevExpress 17.1.6 | React + TypeScript |
| Backend | C# .NET Framework 4.8 | .NET Core Web API |
| Database | Oracle 19c | PostgreSQL (Npgsql + EF Core migrations) |

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
  - return `sc.ComboItem` (combo.cs) → ส่ง frontend เป็น `ComboItemDto { code, name }`
- **`sc.combo.*` constants** — ใช้แทน SQL เขียนเอง, ตรวจ combo.cs ก่อนเสมอ
- **`sc.scCoop.ofParse(membership_no)`** — validate + pad zeros (size จาก sc_cnt_m_coop)
- **EF Core ใช้เฉพาะ Migrations** (schema) — ไม่ inject `AppDbContext` ใน service
- JWT สำหรับ authentication

### React + TypeScript
- strict TS, Component = PascalCase, module folder ตรง legacy เป๊ะ (case-sensitive) ที่ `src/pages/sc[Module]/index.tsx`
- Navigation: scCenter เป็น public landing, login popup เมื่อ click module icon
- DevExtreme React สำหรับ UI components
- **Format constants** — ทุก page กำหนดที่ top of file พร้อม comment อ้างอิง `sc.*`:
  ```ts
  const MASK_IDCARD = '9-9999-99999-99-9'           // sc.mask.maskIdCard
  const FMT_DATE_TH = { /* dd/mm/(yyyy+543) */ }     // sc.value.toStringTH — พ.ศ. display, ค.ศ. storage
  const FMT_MONEY = { format: '#,##0.00', min: 0 }   // sc.mask.maskDecimal
  const FMT_PERCENT2 = { format: '#,##0.00', min: 0, max: 100 } // sc.mask.maskPercent2
  ```
- **วันที่** → `FMT_DATE_TH` (พ.ศ. display, ค.ศ. storage) เสมอ
- **เลขบัตร ปชช.** → `mask: MASK_IDCARD` เสมอ | **เงิน** → `FMT_MONEY` | **จำนวนเต็ม** → `{ format: '#,##0' }` | **%** → `FMT_PERCENT2`
- **Dropdown** → type `ComboItemDto { code, name }` เสมอ

### React — Page Layout Pattern (page ซับซ้อนแยกไฟล์)
- `index.tsx` — orchestrator: state + layout constants + API calls
- `Header.tsx` — form หลัก (scrollable, flex:1, maxHeight: 55vh, overflowY: auto)
- `Detail.tsx` (optional), `Tabs.tsx` (แท็บเพิ่มเติม), `Operate.tsx` (ปุ่มวงกลม fixed width ขวาสุด)
- `types.ts` — interfaces + format constants ที่แชร์
- หน้าเรียบง่ายไม่ต้องครบทุก section (เช่น sctelnewbma ไม่มี Detail)
- **Layout constants** ใน `index.tsx`: `MASTER_WIDTH = '80%'` (content area), `BTN = 68→76px`
  - index wrapper: `width:100%, padding:'12px 16px'` | master: `MASTER_WIDTH, margin:'0 auto', flex, gap:10`
  - Left (Header+Tabs): `flex:1, minWidth:0, flexDirection:column, gap:10` | Right (Operate): `minWidth: BTN+8`
- **Material Icons** (`material-icons` npm, import ใน `main.tsx`): `<span className="material-icons">{icon}</span>` (text ligature). DevExtreme Button `icon` prop ใช้ CSS class → ไม่รองรับ ligature → ใช้ plain `<button>` + span แทน
- **Circular Buttons (Operate)** — plain `<button>` + `borderRadius:'50%'` + Material Icons span ข้างใน + label span ด้านล่าง

### DevExtreme Theme Rules (ห้ามละเมิด)
- เปลี่ยน theme → แก้แค่ import ใน `main.tsx` บรรทัดเดียว
- CSS override → แตะแค่ layout (border-radius, underline, icon-top) **ห้าม** override สี/focus/shadow
- **ห้ามแก้ `node_modules/`** — ใช้ `index.css` override
- ใช้ `currentColor` แทน hardcode สี | Scoped CSS ใส่ className (เช่น `dx-tab-icon-top`)

---

## Claude Working Rules (สำคัญมาก — ทำทุกครั้ง)
1. **อ่าน `sc/` ก่อนเขียนโค้ดใหม่เสมอ** (`mask.cs`, `value.cs`, `combo.cs`, `css.cs`, `att.cs`, `scCoop.cs`, `util.cs`, `db.cs`) — เพื่อรู้ว่ามี utility/constant อะไรแล้ว
2. **ถ้าไม่แน่ใจ ถามก่อน** — ห้ามคิดเองแล้วเขียนทันที ต้องรอ confirm
3. **UI ต้องเชื่อม C# ชัดเจน** — format constant ทุกตัวใน frontend มี comment อ้างอิง `sc.*` ที่มา
4. **ใช้ `sc.combo.*` แทน SQL เขียนเอง** — ตรวจ combo.cs ก่อน, dropdown code+name → `getComboAsync(sc.combo.xxx)`

---

## Architecture Decisions (ตัดสินใจแล้ว)
- **.NET Core layers:** `SoAt.API` (controllers) / `SoAt.Application` (DTO+services) / `SoAt.Infrastructure` (sc.db, persistence, deployers) / `SoAt.Core` (sc/* library)
- Backend: **`sc.db`** สำหรับ query+CRUD ทั้งหมด, **EF Core** สำหรับ Migrations เท่านั้น
- Dropdown: **`sc.db.getComboAsync` + `sc.combo.*`** — ไม่เขียน SQL เอง
- DB naming: คงชื่อ Oracle เดิม | EF Core snake_case: **manual loop** ใน OnModelCreating (EFCore.NamingConventions ไม่รองรับ EF Core 10)
- Auth: **JWT** (ยังไม่มี refresh token)
- UI lib: **DevExtreme React 25.2.7** (Community) | Theme: **`dx.carmine.css`** | Icons: **Material Icons** | Font: **Prompt** ทั้งระบบ (component ใช้ `fontFamily: 'inherit'`)

### ยังไม่ตัดสินใจ
- [ ] เริ่ม migrate module ไหนก่อน — [ ] Refresh Token — [ ] Module-level permission

---

## Database Deployers (รันตอน API startup)
ทุก deployer **idempotent** + **log-and-continue** (error ไม่ทำให้ API ตาย). PL team แก้ `.sql` ใน `Database/` แล้ว restart API → อัปเดต DB ทันที.

**ลำดับ Program.cs:** `MigrateAsync → TableDeployer → FunctionDeployer → TriggerDeployer → ViewDeployer → DatabaseSeeder`

| Deployer | Source | กลยุทธ์ |
|----------|--------|---------|
| TableDeployer    | `Database/Tables/**/*.sql`    | `CREATE TABLE IF NOT EXISTS` statement-by-statement, `z_fk_*.sql` ท้ายสุด |
| FunctionDeployer | `Database/Functions/**/*.sql` | `CREATE OR REPLACE FUNCTION` |
| TriggerDeployer  | `Database/Triggers/**/*.sql`  | `DROP TRIGGER IF EXISTS` + `CREATE` |
| ViewDeployer     | `Database/Views/**/*.sql`     | `CREATE OR REPLACE VIEW` |

**Skip codes (benign re-run):** 42P07=table exists, 42710=object exists, 42701=column exists, 42703=column not found (stale COMMENT), 42P16=multiple PK, 23505=type/function exists

---

## สถานะ Stack ใหม่ (2026-05-28)
- Backend: build clean (0 err/warn), JWT auth, sc.db migration สมบูรณ์
- Frontend: build clean, scCenter + 31 module placeholders, sctelnewbma clean code สมบูรณ์
- **DB deploy (Step 5):** Tables 1,460 / Functions 352 / Triggers 376 / Views 100 — API ที่ `http://localhost:5139`
- **ค้าง (Step 6):** Views fail 72 ตัว เพราะอ้าง Oracle package functions (~35 functions, 14 packages: pka_com_function, pka_srv_datetime, pka_dep, pka_estate, pka_hr_leave ...) ที่ยังไม่ migrate → ต้องสร้าง stub functions
