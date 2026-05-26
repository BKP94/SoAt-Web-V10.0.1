# SoAt WebApp — Project Context

## โปรเจคนี้คืออะไร
ระบบสหกรณ์ออมทรัพย์ (Savings Cooperative) กำลังอยู่ระหว่างการ migrate จาก legacy stack ไปสู่ modern stack

---

## Legacy System (C:\SoAt_PEAN)

### Stack เดิม
- **Frontend**: ASP.NET Web Forms + DevExpress 17.1.6
- **Backend**: C# .NET Framework 4.8
- **Database**: Oracle 19c
- **Solution**: `SoAt_PEAN.sln` — 65+ projects

### โครงสร้าง Projects เดิม
```
sc/              ← Core library (db, log, json, page, session, security)
Boundary/        ← External boundary layer
Business/        ← Business logic
Common/          ← Shared utilities
Database/        ← Data access layer
Model/           ← Data models
scCenter/        ← Landing page (module selector)
scAccount/       ← บัญชี
scAdmin/         ← ผู้ดูแลระบบ
scApprove/       ← อนุมัติ
scAtm/           ← ATM
scBillpayment/   ← ชำระบิล
scCoordinate/    ← ประสานงาน
scCremation/     ← ฌาปนกิจ
scDeposit/       ← เงินฝาก
scEdocument/     ← เอกสารอิเล็กทรอนิกส์
scElections/     ← เลือกตั้ง
scEoffice/       ← สำนักงาน e-Office
scEstate/        ← อสังหาริมทรัพย์
scExp/           ← ค่าใช้จ่าย
scFinance/       ← การเงิน
scFund/          ← กองทุน
scHr/            ← บุคลากร
scInsurance/     ← ประกัน
scInvestment/    ← การลงทุน
scKeepcoll/      ← เก็บเงินกู้
scKeeping/       ← ออมทรัพย์
scLaw/           ← กฎหมาย
scMobile/        ← แอปพลิเคชัน
scPermit/        ← ใบอนุญาต
scProDATA/       ← ประมวลผลข้อมูล
scReport/        ← รายงาน
scRing2Me/       ← Ring2Me
scScholarship/   ← ทุนการศึกษา
scStock/         ← หุ้น
scTeller/        ← เหรัญญิก
scTransbank/     ← โอนเงิน
scWelfare/       ← สวัสดิการ
rcAccount/       ← Report modules (rc prefix = รายงานของแต่ละ module)
rcAdmin/
rcApprove/
rcAtm/
rcContract/
rcCoordinate/
rcDeposit/
rcEdocument/
rcElections/
rcEoffice/
rcFinance/
rcFund/
rcHr/
rcInsurance/
rcInvestment/
rcKeepColl/
rcKeeping/
rcLaw/
rcProdata/
rcRing2Me/
rcScholarship/
rcStock/
rcTeller/
rcTransbank/
rcWelfare/
repQuery/        ← Shared query definitions ที่ rc* modules ใช้ร่วมกัน
rxForm/          ← Report form viewer/renderer
```

### sc Core Library (C:\SoAt_PEAN\sc\)
Class กลางที่ทุก sc* และ rc* module ใช้ร่วมกัน — จะ migrate เป็น .NET Core services:
```
app.cs      ← Application settings / config
att.cs      ← File attachments
combo.cs    ← Dropdown/ComboBox data helpers
control.cs  ← UI control utilities
css.cs      ← CSS class helpers
db.cs       ← Database access (Oracle connection wrapper)
file.cs     ← File I/O utilities
global.cs   ← Global constants / shared state
json.cs     ← JSON serialization helpers
log.cs      ← Logging
mask.cs     ← Input masking / number formatting
master.cs   ← Master page base class
ora.cs      ← Oracle-specific utilities (ต้องแปลงเป็น PostgreSQL)
page.cs     ← Page base class (แทน code-behind ทุกหน้า)
pageHome.cs ← Home/landing page base
pageInfo.cs ← Page metadata
report.cs   ← Report utilities (DevExpress report wrappers)
scClient.cs ← Client-side script helpers
scCoop.cs   ← Cooperative-specific business helpers
secure.cs   ← Security / permission checks
service.cs  ← Service call helpers
util.cs     ← General utilities
value.cs    ← Value formatting / conversion (เงิน, วันที่, ฯลฯ)
xml.cs      ← XML serialization helpers
```

---

## Target Stack (โปรเจคใหม่นี้)

### Stack ใหม่
- **Frontend**: React + TypeScript
- **Backend**: .NET Core Web API (C#)
- **Database**: PostgreSQL

### Architecture
```
React (TypeScript)
    ↓ HTTP/REST
.NET Core API
    ↓ Npgsql / EF Core
PostgreSQL
```

### Session State Pattern
Oracle เดิมเก็บ session state ใน Package-level variables
PostgreSQL ใหม่ต้องใช้ pattern นี้:
```csharp
// .NET Core — ทุก request ต้อง set ก่อน query
await conn.ExecuteAsync("SET LOCAL app.login_id = @id", new { id = userId });
await conn.ExecuteAsync("SET LOCAL app.login_br = @br", new { br = branchId });
```
```sql
-- PostgreSQL Trigger อ่านค่าแบบนี้แทน pka_com_login.login_id
NEW.officer_id := current_setting('app.login_id', true);
NEW.branch_id  := current_setting('app.login_br', true);
```

---

## Oracle Database (Legacy — Read Only Reference)

### Connection
```
Host:  192.168.101.29
Port:  1521
SID:   pean
User:  dbo
Pass:  (ดูจาก dbConn.xml หรือ environment variable)
```

### ขนาด Database
```
Total size:   18.32 GB
Tables:       1,480 tables
PL/SQL Packages: 354 packages
Triggers:     376 triggers
```

### Table Naming Convention
```
sc_[module]_[type]_[name]

module: mem, lon, dep, kep, fin, hr, wef, acc, atm, crem, inv, shr, fdm, ...
type:   m_ = Master/Config table
        t_ = Transaction table

ตัวอย่าง:
  sc_mem_m_resign_requestment   ← member resign master
  sc_dep_m_creditor             ← deposit account master
  sc_lon_m_loan_card            ← loan contract master
  sc_kep_t_monthly_receive      ← keeping monthly transaction
  sc_fin_vourcher_head          ← finance voucher header
  sc_cnt_m_coop                 ← cooperative config (single row)
```

### Primary Key หลัก
`membership_no VARCHAR(15)` — เชื่อมทุก module

### Module ขนาด (จำนวน tables)
| Module | Tables | ระบบ |
|--------|--------|------|
| SC_MEM | 233 | สมาชิก |
| SC_LON | 171 | เงินกู้ |
| SC_HR  | 122 | บุคลากร |
| SC_WEF | 81  | สวัสดิการ |
| SC_ACC | 74  | บัญชี |
| SC_FIN | 70  | การเงิน |
| SC_DEP | 61  | เงินฝาก |
| SC_INV | 48  | การลงทุน |
| SC_ATM | 37  | ATM |
| SC_KEP | 29  | ออมทรัพย์รายเดือน |

### Tables ที่มีข้อมูลเยอะ (Top 5)
```
SC_REP_MEM_SHARE_LOAN_BAL    15.4M rows
SC_REP_MEM_SHARE_LOAN_YEAR   12.7M rows
SC_CLS_CONFIRM_INSURE        11.6M rows
SC_MEM_M_INSURE_DET          11.1M rows
SC_ATM_LON_DETAIL             4.2M rows
```

---

## Migration Strategy

### แนวทาง: Strangler Fig Pattern
ไม่ rewrite ทั้งหมดทีเดียว — สร้าง module ใหม่ใน stack ใหม่ทีละตัว
ระบบเดิมยังทำงานอยู่ระหว่าง migrate

### Database Migration (Oracle → PostgreSQL)
```
1. Schema migration    → ใช้ ora2pg (~60% auto)
2. Data migration      → ora2pg + manual verify
3. Packages migration  → แยก logic ออกมาใน .NET Core Services
4. Trigger migration   → แปลง :new/:old → NEW/OLD + session variable pattern
```

### สิ่งที่ต้องระวังใน Migration

**Package-level variables** (ต้องออกแบบใหม่)
```sql
-- Oracle: ตัวแปร session อยู่ใน package
login_id    varchar2(16);
login_br    varchar2(6);
window_active varchar2(100);

-- PostgreSQL: ใช้ SET LOCAL แทน
current_setting('app.login_id', true)
current_setting('app.login_br', true)
```

**BULK COLLECT** (ต้องเขียนใหม่ทุกที่)
```sql
-- Oracle
FETCH cur BULK COLLECT INTO ltab;

-- PostgreSQL
SELECT * INTO ltab FROM cur;
```

**Oracle-specific functions** (แปลงได้)
```
NVL()           → COALESCE()
SYSDATE         → CURRENT_DATE
SYSTIMESTAMP    → CURRENT_TIMESTAMP
FROM DUAL       → ลบออก
SYS_CONTEXT()   → ย้ายไป app layer
DBMS_OUTPUT     → RAISE NOTICE
```

**Trigger pattern** (376 triggers)
- 304 TBIU triggers = BEFORE INSERT/UPDATE สำหรับ set defaults + audit
- 53 TM triggers = AFTER triggers สำหรับ sync ไป SM_ shadow tables
- เกือบทุกตัวเรียก `pka_com_login.login_id` → ต้องเปลี่ยนเป็น `current_setting()`

---

## Coding Guidelines

### PostgreSQL
- ใช้ `NUMERIC` แทน `FLOAT` สำหรับเงิน
- ใช้ `BOOLEAN` แทน `CHAR(1)` สำหรับ flag fields
- Naming: lowercase + underscore (เหมือน Oracle เดิม)
- ใส่ audit columns ทุก table: `created_at`, `updated_at`, `created_by`, `updated_by`

### .NET Core API
- ใช้ Dapper สำหรับ query ที่ซับซ้อน (ใกล้เคียงกับ stored proc เดิม)
- ใช้ EF Core สำหรับ CRUD ทั่วไป
- ทุก endpoint ต้อง set PostgreSQL session variables ก่อน query
- JWT สำหรับ authentication (แทน Oracle session)

### React + TypeScript
- ใช้ strict TypeScript
- Component naming: PascalCase
- ชื่อ module folder ตรงกับชื่อ legacy project: `scAccount`, `scAtm`, `scHr`, `scInvestment` ฯลฯ (ตัวพิมพ์เล็ก/ใหญ่ต้องตรงเป๊ะ)
- แต่ละ module อยู่ที่ `src/pages/sc[Module]/index.tsx`
- Navigation: scCenter เป็น public landing page, login popup ขึ้นเมื่อ click module icon
- DevExtreme React สำหรับ UI components (DataGrid, Form, Chart ฯลฯ)

---

## การเชื่อมต่อ Oracle (สำหรับ reference/migration เท่านั้น)
```bash
# ใช้ sqlplus
sqlplus dbo/[password]@192.168.101.29:1521/pean

# query ตัวอย่าง
SELECT table_name, num_rows FROM user_tables ORDER BY num_rows DESC;
SELECT trigger_name, trigger_type, triggering_event FROM user_triggers;
SELECT object_name FROM user_objects WHERE object_type = 'PACKAGE BODY';
```

---

## สิ่งที่ตัดสินใจแล้ว
- UI component library: **DevExtreme React 25.2.7** (Community license)
- Authentication: **JWT** (ยังไม่มี refresh token)
- Database naming: **คงชื่อ Oracle เดิม** (sc_mem_m_..., sc_dep_t_... ฯลฯ)
- EF Core snake_case: **manual loop** ใน OnModelCreating (EFCore.NamingConventions ไม่รองรับ EF Core 10)
- Backend: **Dapper** สำหรับ complex query, **EF Core** สำหรับ CRUD ทั่วไป

## สิ่งที่ยังไม่ตัดสินใจ
- [ ] เริ่ม migrate Module ไหนก่อน
- [ ] โครงสร้าง folder ของ .NET Core API (per-module หรือ per-layer)
- [ ] Refresh Token
- [ ] Module-level permission (ผู้ใช้ไหนเข้าได้ module ไหน)

## สถานะ Stack ใหม่ (2026-05-25)
- Backend: build clean, JWT auth endpoint ทำงานได้, admin user seeded
- Frontend: build clean, scCenter + 31 module placeholders, DevExtreme integrated
- ⚠️ EF migration `InitAuth` ต้อง recreate (ถูกลบระหว่าง refactor)
