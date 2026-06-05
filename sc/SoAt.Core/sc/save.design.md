# `sc.save` — Central Save Engine (Design Doc)

> สถานะ: **DESIGN — รอ review (ยังไม่ implement)** · 2026-06-05
> แทนที่: save logic เขียนมือต่อหน้า (เช่น `SctelnewbmaService.CreateApplicationAsync` ~350 บรรทัด)
> เทียบ legacy: `sc.save.ofSave()` (Web Forms — สแกน control `class="save / save-table / table-xxx"`)
> แนวทางที่เลือก: **Attribute บน DTO** (ไม่ใช่ marker ใน Razor / ไม่สแกน DOM)

---

## 1. หลักการ

Legacy `sc.save.ofSave()` ทำงานบน Web Forms ที่ server มี **control tree** จริง → ติด CSS class บอก table/column แล้ว engine ประกอบ SQL ให้. **Blazor Server ไม่มี control tree ฝั่ง server** — ข้อมูลอยู่ใน **C# model ที่ strongly-typed** (`ApplicationFormDto`) อยู่แล้ว.

ดังนั้น "ตัวเทียบ" ของ CSS marker คือ **attribute บน DTO** — ย้าย marker จาก markup ที่กระจาย → ไว้ที่ model ที่เดียว. Engine reflect อ่าน attribute → ยิงผ่าน `sc.db` reflection writer ที่**มีอยู่แล้ว** (`dbInsertAsync<T>` / `dbUpdateAsync<T>`, [db.cs:547](db.cs)) ครบในทรานแซกชันเดียว.

**เป้าหมาย dev experience:** เขียนหน้าใหม่ = annotate DTO + เรียก `save.ofSaveAsync(model)` 1 บรรทัด — **ไม่เขียน SQL save เลย**.

หลักออกแบบ:
- **DTO เป็น single source of truth ของ mapping** (ที่เดียว ไม่กระจายใน markup)
- **reuse ของเดิม** — `dbInsertAsync<T>`/`dbUpdateAsync<T>`/`getColumnAllAsync` + transaction ของ `sc.db` (1 instance = 1 transaction)
- **ไม่แตะ Page Architecture contract** — `PanOperate` ยัง raise `OnSave` → Page เหมือนเดิม
- **convention over config** — default แมพ PascalCase → snake_case, audit เติมเอง; ใส่ attribute เฉพาะที่ต่างจาก default

---

## 2. Attribute Spec

ทั้งหมดอยู่ใน `sc/SoAt.Core/sc/save.cs` (Core → DTO ใน `SoAt.Application` annotate ได้ เพราะ Application ref Core อยู่แล้ว)

| Attribute | ใช้กับ | ความหมาย | legacy เทียบ |
|---|---|---|---|
| `[SaveTable(table, ParentKey=, SeqColumn=, ChildMode=)]` | class **หรือ** property | object/list นี้ → table นี้ (1 row ต่อ object, N row ต่อ list) | `class="save table-xxx"` / `save-table` |
| `[SaveKey(Generator=)]` | property | PK. ว่าง → INSERT (+gen ถ้ามี Generator); มีค่า → UPDATE | key column |
| `[SaveColumn("name")]` | property | override ชื่อ column (ปกติ auto snake_case) | `col-name` |
| `[SaveIgnore]` | property | ข้าม (lookups / computed / UI-only) | ไม่ติด class |
| `[SaveRequired("msg")]` | property | validate ก่อนเซฟ | `ofValidateRequired` |
| `[SaveDefault(value, InsertOnly=true)]` | property | ค่า default ตอน insert (เช่น `ApproveStatus="2"`) | hidden default |

### กฎ default (ไม่ต้องใส่ attribute)
- ชื่อ column = `ToSnakeCase(PropName)` — ตรงกับ `dbUpdateAsync<T>` เดิม
- prop ที่เป็น `List<>`/object ซึ่งติด `[SaveTable]` → ถือเป็น **child node** (ไม่ใช่ column ของ parent)
- prop ที่ไม่มีใน table จริง → ข้ามอัตโนมัติ (เพราะ engine เทียบกับ `getColumnAllAsync`)
- `null` → ไม่ insert (skipNulls=true เหมือนเดิม) — ยกเว้นมี `[SaveDefault]`
- **audit columns** (`created_at`,`created_by`,`updated_at`,`updated_by`) — ถ้า table มี column นี้ engine เติมเอง: insert เติมทั้ง 4, update เติมแค่ `updated_*`. ไม่ต้องประกาศใน DTO

### ChildMode (กลยุทธ์ child ตอน UPDATE) — ดู §6 + open question Q1
- `Replace` (default): `DELETE FROM child WHERE parent_key=@k` แล้ว INSERT ใหม่ทั้งหมด — ตรงพฤติกรรม grid legacy
- `Upsert`: match ด้วย key → update/insert ทีละ row (เก็บ identity/audit)

---

## 3. ตัวอย่างจริง — sctelnewbma (before → after)

### DTO หลัง annotate (`SctelnewbmaDto.cs`)
```csharp
[SaveTable("sc_mem_m_application_form")]
public class ApplicationFormDto
{
    [SaveKey(Generator = "GenApplicationFormNo")]
    public string? ApplicationFormNo { get; set; }

    [SaveRequired("กรุณากรอกชื่อ")]    public string? MemberName    { get; set; } // → member_name
    [SaveRequired("กรุณากรอกนามสกุล")] public string? MemberSurname { get; set; }
    [SaveRequired("กรุณาเลือกประเภทสมาชิก")] public string? MemType  { get; set; }

    [SaveColumn("hum_id")] public string? HumId { get; set; }

    [SaveDefault("2")] public string? ApproveStatus { get; set; } // insert-only default
    [SaveDefault("0")] public string? CancelStatus  { get; set; }

    // 1:1 child → FK = application_form_no (engine เติมจาก key ของ parent)
    [SaveTable("sc_mem_m_app_work_info", ParentKey = "application_form_no")]
    public AppWorkInfoDto? WorkInfo { get; set; }

    // 1:N child (grid) → ใส่ seq_no 1..N ให้เอง
    [SaveTable("sc_mem_m_app_address",        ParentKey = "application_form_no", SeqColumn = "seq_no")]
    public List<AppAddressDto>      Addresses     { get; set; } = [];
    [SaveTable("sc_mem_m_app_member_refer",   ParentKey = "application_form_no", SeqColumn = "seq_no")]
    public List<AppMemberReferDto>  MemberRefers  { get; set; } = [];
    [SaveTable("sc_mem_m_app_recrieve_gain",  ParentKey = "application_form_no", SeqColumn = "seq_no")]
    public List<AppRecrieveGainDto> RecrieveGains { get; set; } = [];
    [SaveTable("sc_mem_m_app_bank_accno",     ParentKey = "application_form_no", SeqColumn = "seq_no")]
    public List<AppBankAccountDto>  BankAccounts  { get; set; } = [];

    // 1:1 tabs
    [SaveTable("sc_mem_m_app_spouse_info", ParentKey = "application_form_no")]
    public AppSpouseInfoDto? SpouseInfo { get; set; }
    [SaveTable("sc_mem_m_app_own_info",    ParentKey = "application_form_no")]
    public AppOwnInfoDto? OwnInfo { get; set; }

    [SaveIgnore] public string? PictureBase64   { get; set; } // ← จัดด้วย hook (decode byte[])
    [SaveIgnore] public string? SignatureBase64 { get; set; }
}
```
> หมายเหตุ: `AppAddressDto` มี 3 ตัว (ปัจจุบัน/ทะเบียนบ้าน/ที่ทำงาน) เก็บใน `List` เดียว ติด `AddressType` ต่อ row — เข้าโมเดล 1:N ได้พอดี (legacy เดิมแยก insert 3 ครั้ง)

### Page.Save() (`Page.razor`) — จาก ~30 บรรทัด → เหลือ
```csharp
private async Task Save()
{
    _status = null; _saving = true;
    try
    {
        var r = await Save.ofSaveAsync(_form, new SaveContext(_userId, _branchId)
        {
            Generators = { ["GenApplicationFormNo"] = db => GenApplicationFormNoAsync(db) },
            Hooks = { BeforeChild_sc_mem_m_app_picture = ... } // decode base64 (option, ดู §8)
        });
        _ok = true; _status = $"{r.Message} (เลขที่ {r.Key})";
        if (r.IsInsert) Nav.NavigateTo($"/sctelnewbma/{r.Key}");
    }
    catch (SaveValidationException ve) { _ok = false; _status = ve.FirstMessage; }
    catch (Exception ex)              { _ok = false; _status = $"เกิดข้อผิดพลาด: {ex.Message}"; }
    finally { _saving = false; }
}
```
> `CreateApplicationAsync` + `UpdateApplicationAsync` + helper insert ทั้งหมด (~350 บรรทัด) → **ลบทิ้ง**. service เหลือเฉพาะ `GetLookupsAsync` / `GetApplicationAsync` / `GenApplicationFormNoAsync` + business hook จริง.

---

## 4. Engine API

```csharp
namespace sc;

public sealed class save(dbFactory dbFactory)        // DI: scoped/singleton เหมือน dbFactory
{
    public async Task<SaveResult> ofSaveAsync(object root, SaveContext ctx);
}

public sealed class SaveContext(string userId, string branchId)
{
    public string UserId { get; } = userId;
    public string BranchId { get; } = branchId;
    public Dictionary<string, Func<sc.db, Task<string>>> Generators { get; } = new();
    // hooks (option) — ดู §8
}

public sealed record SaveResult(string Key, string Message, bool IsInsert);

public sealed class SaveValidationException(IReadOnlyList<string> errors) : Exception
{
    public IReadOnlyList<string> Errors { get; } = errors;
    public string FirstMessage => Errors[0];
}
```

`SavePlan`/`SaveNode` (reflection metadata) **cache ต่อ Type** (`ConcurrentDictionary<Type, SavePlan>`) — reflect ครั้งเดียวต่อ DTO.

---

## 5. Engine Flow (ลำดับการทำงาน)

```
ofSaveAsync(root, ctx):
 1. plan = GetOrBuildPlan(root.GetType())         // reflect + cache
 2. errors = ValidateRequired(root, plan)          // เดิน graph เก็บ [SaveRequired] ที่ว่าง
    if errors.Any → throw SaveValidationException   // ยังไม่เปิด connection
 3. db = dbFactory.create(ctx.UserId, ctx.BranchId) // 1 instance = 1 transaction
    try:
 4.   result = await SaveNode(db, root, plan.Root, parentKey: null, ctx)
 5.   await db.ofConnectionCloseAsync("save")        // _dbState=Execute → COMMIT
      return result
    catch:
 6.   await db.ofConnectionCloseAsync("save", onError:true) // → ROLLBACK
      throw
```

```
SaveNode(db, obj, node, parentKey, ctx):
 a. ถ้า node มี ParentKey → set column[ParentKey] = parentKey
 b. resolve key:
      - root: ถ้า [SaveKey] ว่าง → isInsert=true; ถ้ามี Generator → key = await gen(db); set กลับ obj
              ถ้า [SaveKey] มีค่า → isInsert=false
      - child: key = parentKey (+SeqColumn ถ้าเป็น list element)
 c. build columns:
      - reflect props (ข้าม [SaveIgnore], ข้าม props ที่เป็น child [SaveTable], ข้าม null)
      - + [SaveDefault] (insert เท่านั้น) + audit (เทียบ getColumnAllAsync)
 d. execute:
      - isInsert → dbInsertAsync(table, cols)
      - update   → dbUpdateAsync(table, cols, keyCols)
 e. recurse children (props ที่ติด [SaveTable]):
      - object (1:1): SaveNode(child, parentKey=key)
      - list (1:N):
          ChildMode.Replace → dbDeleteAsync("DELETE FROM {t} WHERE {ParentKey}=@k", key)
          for i, item in list: set SeqColumn=i+1; SaveNode(item, parentKey=key, forceInsert=true)
 f. return { key, isInsert }
```

**Transaction:** ทุก execute ใช้ `db` instance เดียว → `_trans` เดียว. error ที่ไหนก็ rollback ทั้งหมด (ตรงกับ try/catch + `ofConnectionCloseAsync(onError:true)` ใน service เดิม).

---

## 6. Child handling รายละเอียด

| เคส | DTO | กลยุทธ์ |
|---|---|---|
| 1:1 (work_info, spouse, own) | `AppXxxDto?` (nullable) | null → skip; ไม่ null → upsert 1 row (PK = parent key) |
| 1:N grid (address, bank, refer, gain) | `List<AppXxxDto>` | Replace (default): delete-by-parent + reinsert, seq 1..N |
| nested | child ที่มี child อีก | recurse (รองรับ แต่ sctelnewbma ไม่ลึกขนาดนั้น) |

> **PK ของ child:** ส่วนใหญ่เป็น composite (`application_form_no` + `seq_no`). Replace mode ใช้แค่ INSERT จึงไม่ต้องรู้ PK ตอน save (ลบยกแผงก่อน). ถ้าเลือก Upsert ต้องระบุ key columns ของ child → ดู Q1.

---

## 7. Validation (`ofValidateRequired` เทียบ)

- เดิน graph ก่อนเปิด connection → เก็บทุก `[SaveRequired]` ที่ค่าว่าง/null เป็น list ข้อความ
- มี error → `throw SaveValidationException(errors)` (ไม่แตะ DB)
- Page catch → โชว์ `_status` (เหมือน `Validate()` เดิมใน [Page.razor:145](../../../scTeller/Components/Pages/sctelnewbma/Page.razor))
- business rule ที่ไม่ใช่ "required เฉยๆ" (เช่น "สัดส่วนผู้รับผลประโยชน์รวม 100%") → **ไม่ย้ายเข้า engine** ปล่อยให้ Page validate เองก่อนเรียก (engine ทำแค่ required แบบ declarative)

---

## 8. Business hook (logic ที่ไม่ generic)

บางหน้ามี logic เฉพาะที่ attribute ครอบไม่ได้ (เช่น sctelnewbma: decode `PictureBase64` → `byte[]` ลง `sc_mem_m_app_picture`). 3 ทางเลือก:

- **(แนะนำ) ปล่อยให้ service จัดส่วนพิเศษ เรียก engine สำหรับ 90% ที่เหลือ** — Page เรียก `Svc.SaveAsync` ที่ภายในเรียก `save.ofSaveAsync(form)` แล้วตามด้วย insert รูป/ลายเซ็นเองในทรานแซกชันเดียวกัน (ส่ง `db` instance เข้า engine ได้ overload `ofSaveAsync(root, db, ctx)`)
- attribute พิเศษ `[SaveConvert(typeof(Base64ToBytes))]` — generic ขึ้น แต่ over-engineer สำหรับตอนนี้
- `SaveContext.Hooks` callback ต่อ table — ยืดหยุ่นแต่ผูก string

→ **ข้อเสนอ:** overload `ofSaveAsync(object root, sc.db db, SaveContext ctx)` (ไม่เปิด/ปิด connection เอง) เพื่อให้ service เอา engine ไปประกอบกับ logic พิเศษในทรานแซกชันเดียวได้. ส่วน overload `ofSaveAsync(root, ctx)` (เปิด/ปิดเอง) ไว้ใช้หน้าง่ายๆ ที่ไม่มี hook.

---

## 9. ไฟล์ + DI

| ไฟล์ | เนื้อหา |
|---|---|
| `sc/SoAt.Core/sc/save.cs` | attributes + `save` engine + `SaveContext`/`SaveResult`/`SaveValidationException` + `SavePlan` cache |
| DI (`Program.cs` ของ scCenter/module หรือ Infrastructure DependencyInjection) | `services.AddScoped<sc.save>()` (หรือ singleton เหมือน dbFactory) |

ไม่เพิ่ม dependency ใหม่ — ใช้ `dbFactory`/`sc.db`/reflection ที่มีอยู่.

---

## 10. ผลที่ได้ / ขอบเขตที่ครอบ

✅ ครอบ: หน้า master/transaction ที่ save = insert/update หลาย table แบบ parent→children FK + seq (เคสส่วนใหญ่ของระบบ)
✅ reuse: `dbInsertAsync<T>`/`dbUpdateAsync<T>`/transaction เดิม — ไม่รื้อ `sc.db`
✅ dev เขียนหน้าใหม่: annotate DTO + 1 call, ไม่เขียน SQL save
❌ ไม่ครอบ (ใช้ hook/เขียนเอง): logic แปลง (base64→byte), business validation ข้าม field, call PL function, federation

---

## 11. Open Questions (ต้องตอบก่อน implement)

| # | คำถาม | ข้อเสนอ default |
|---|---|---|
| Q1 | child UPDATE: **Replace (delete+reinsert)** หรือ **Upsert (diff)**? Replace ง่าย+ตรง legacy แต่เสีย audit/identity ของ row ที่ไม่เปลี่ยน; Upsert ต้องรู้ PK ของทุก child table | **Replace** เป็น default, เปิด `[SaveTable(ChildMode=Upsert)]` รายตัวเมื่อจำเป็น |
| Q2 | default-on-insert (`ApproveStatus="2"`): ใช้ `[SaveDefault]` หรือ hook? | `[SaveDefault]` (declarative, อ่านง่าย) |
| Q3 | key generator register ที่ไหน — DI registry, หรือ `SaveContext.Generators` (ต่อ call)? | `SaveContext.Generators` ก่อน (เริ่มง่าย), ยก DI ทีหลังถ้าซ้ำเยอะ |
| Q4 | soft-delete: บาง table ใช้ `cancel_status` แทนลบจริง — Replace mode ควร hard DELETE ไหม? | hard DELETE สำหรับ app_* child (เป็น draft); ตารางจริงค่อยพิจารณาตอน migrate module นั้น |
| Q5 | composite key DTO (parent+seq) ที่ต้อง UPDATE ตรง row — รองรับ `[SaveKey]` หลายตัวไหม? | รองรับ multi `[SaveKey]` (Q1=Upsert ค่อยใช้) |
| Q6 | audit เติมจาก convention (เช็คชื่อ column) พอ หรือบาง table ชื่อ audit ต่าง? | convention 4 ชื่อมาตรฐานตาม CLAUDE.md; table ที่ต่างค่อย override |

---

## 12. แผน implement (เมื่อ approve)

1. `save.cs`: attributes + `SaveContext`/`SaveResult`/exception + `SavePlan` reflection cache
2. engine core: `SaveNode` (insert/update + audit + default), validation pass
3. child cascade (Replace mode) + seq
4. overload `ofSaveAsync(root, db, ctx)` สำหรับ hook
5. DI registration
6. **Prototype:** annotate `SctelnewbmaDto` + refactor `Page.Save()` + ตัด save code ใน service → ทดสอบ create/update เทียบผลกับเดิม (ตาราง + row + audit ตรงกัน)
7. ปรับ CLAUDE.md (Page Architecture) เพิ่มกฎ "save ผ่าน sc.save + annotate DTO"

> หลัง prototype ผ่าน → กลายเป็น template ให้ทุก module ใหม่ใช้ (เหมือน copy โครง sctelnewbma)
