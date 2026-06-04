# SoAt WebApp — Project Context

## โปรเจคนี้คืออะไร
ระบบสหกรณ์ออมทรัพย์ (Savings Cooperative) — migrate จาก legacy ไปสู่ modern stack ด้วย **Strangler Fig Pattern** (สร้าง module ใหม่ทีละตัว, ระบบเดิมยังทำงานระหว่าง migrate)

| | Legacy (`C:\SoAt_PEAN`) | Target (โปรเจคนี้) |
|---|---|---|
| Frontend | ASP.NET Web Forms + DevExpress 17.1.6 | **Blazor Server + DevExpress** |
| Backend | C# .NET Framework 4.8 | .NET Core (services เรียกตรงผ่าน DI) |
| Database | Oracle 19c | PostgreSQL (Npgsql + EF Core migrations) |

> **ทิศ frontend (ตัดสินใจ 2026-06-04):** เปลี่ยนจาก React/TypeScript → **Blazor Server + DevExpress**
> เหตุผล: ทีมถนัด C#, ผู้ใช้ใน intranet (จุดอ่อน Blazor Server ไม่กระทบ), และ reuse legacy XtraReports ~2,900 ตัวได้
> React (`frontend/`) ถูกลบออกแล้ว (commit `da07ed6`) — โครง Blazor ยังไม่ scaffold (รอ DevExpress license)

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
- **EF Core ใช้เฉพาะ Migrations** (schema) — ไม่ inject `AppDbContext` ใน service
- **Auth: cookie-based** (Blazor Server) — service เรียกตรงผ่าน DI, ไม่ผ่าน HTTP/JWT

### Blazor Server + DevExpress (frontend)
> โครงยังไม่ scaffold — รอ DevExpress license. หลักการด้านล่างคือสิ่งที่ตัดสินใจแล้ว, รายละเอียด UI pattern (layout/component) จะนิยามตอน scaffold + ลง DevExpress
- Component = PascalCase `.razor`, module folder ตรง legacy เป๊ะ (case-sensitive)
- Navigation: scCenter เป็น public landing, login เมื่อเข้า module
- **Format/value ทุกตัวมาจาก `sc.*`** (อย่า hardcode ในหน้า) — ผูกกับ utility C# โดยตรง:
  - **วันที่** → `sc.value.toStringTH` — พ.ศ. display, ค.ศ. storage เสมอ
  - **เลขบัตร ปชช.** → `sc.mask.maskIdCard` (`9-9999-99999-99-9`)
  - **เงิน** → `sc.mask.maskDecimal` (`#,##0.00`) | **จำนวนเต็ม** → `#,##0` | **%** → `sc.mask.maskPercent2`
  - **Dropdown** → bind `sc.ComboItem` (Value=`code`, Text=`name`) จาก `sc.db.getComboAsync(sc.combo.*)`
- **DevExpress theme** — เปลี่ยน theme ที่จุดเดียว (config), ห้าม override สี/focus/shadow, แตะได้แค่ layout

---

## Claude Working Rules (สำคัญมาก — ทำทุกครั้ง)
1. **อ่าน `sc/` ก่อนเขียนโค้ดใหม่เสมอ** (`mask.cs`, `value.cs`, `combo.cs`, `css.cs`, `att.cs`, `scCoop.cs`, `util.cs`, `db.cs`) — เพื่อรู้ว่ามี utility/constant อะไรแล้ว
2. **ถ้าไม่แน่ใจ ถามก่อน** — ห้ามคิดเองแล้วเขียนทันที ต้องรอ confirm
3. **UI ต้องเชื่อม C# ชัดเจน** — format/value ทุกตัวเรียกจาก `sc.*` ตรง (mask, value, combo) ไม่ hardcode ในหน้า
4. **ใช้ `sc.combo.*` แทน SQL เขียนเอง** — ตรวจ combo.cs ก่อน, dropdown code+name → `getComboAsync(sc.combo.xxx)`

---

## Architecture Decisions (ตัดสินใจแล้ว)
- **.NET Core layers:** `SoAt.Application` (DTO+services) / `SoAt.Infrastructure` (sc.db, persistence, deployers) / `SoAt.Core` (sc/* library) / `SoAt.Domain`
  - `SoAt.API` (controllers) มีอยู่จากยุค React — Blazor Server เรียก service ตรงผ่าน DI, ไม่ต้องผ่าน controller (จะเก็บไว้/ตัด ตอน scaffold Blazor)
- Backend: **`sc.db`** สำหรับ query+CRUD ทั้งหมด, **EF Core** สำหรับ Migrations เท่านั้น
- Dropdown: **`sc.db.getComboAsync` + `sc.combo.*`** — ไม่เขียน SQL เอง
- DB naming: คงชื่อ Oracle เดิม | EF Core snake_case: **manual loop** ใน OnModelCreating (EFCore.NamingConventions ไม่รองรับ EF Core 10)
- **Frontend: Blazor Server + DevExpress** (เปลี่ยนจาก React 2026-06-04) | Auth: **cookie-based** (service ผ่าน DI)

### ยังไม่ตัดสินใจ
- [ ] Scaffold โครง Blazor Server (รอ DevExpress license — ติด user/pass ตอนติดตั้ง)
- [ ] เก็บหรือตัด `SoAt.API` controllers — [ ] เริ่ม migrate module ไหนก่อน — [ ] Module-level permission
- [ ] federation strategy ของ `view_tel_get_creamation` (dblink 3 Oracle DB)

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

## สถานะ Stack ใหม่ (2026-06-04)
- Backend: build clean, sc.db migration สมบูรณ์ — API ที่ `http://localhost:5139`
- **Frontend: ลบ React ออกแล้ว** (commit `da07ed6`) — รอ scaffold Blazor Server (รอ DevExpress license)
- **DB deploy:** Tables 1,460 / Functions 352 + 46 stub / Triggers 376 / **Views 171/171 ✅**
- **Step 6 เสร็จ** (commit `4f4a925`): 46 Oracle package functions implement เป็น PG stub ใน `Database/Functions/_pkg_stubs/` (16 schemas: pka, pka_com_function, pkb_kromss, pka_srv_datetime, pka_estate, pka_lon_*, pka_hr_*, pka_mem_det, pka_wef ...) จาก source จริง `legacy_ora_src/` (gitignored). เหลือ 1 view defer = `VIEW_TEL_GET_CREAMATION.sql.deferred` (federate 3 Oracle DB ผ่าน dblink)

### ถัดไป
1. Scaffold Blazor Server project (ทำได้เลย, ใส่ DevExpress ทีหลังเมื่อ license พร้อม)
2. เลือก module แรกที่จะ migrate ขึ้น Blazor
