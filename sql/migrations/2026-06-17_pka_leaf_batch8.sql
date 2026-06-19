-- ============================================================================
-- step 6 function-first sweep — batch 8 (leaf ของ package กระจัดกระจาย)
-- port (ทั้งหมด MISSING ใน PG ยกเว้น fp_get_print_code = STUB):
--   pka_mem.fp_desc_prename(text)                  [PKA_MEM 258]  ดึงคำนำหน้า (dep ของ fp_member_name)
--   pka_mem.fp_desc_position(text)                 [PKA_MEM 279]  ตำแหน่ง
--   pka_mem.fp_desc_apptype(text)                  [PKA_MEM 300]  ประเภทการสมัคร
--   pka_mem.fp_desc_memtype(text)                  [PKA_MEM 321]  ประเภทสมาชิก
--   pka_mem.fp_desc_memgroup(text)                 [PKA_MEM 342]  หน่วย (เรียก fp_get_group_name)
--   pka_mem_newmem.fp_member_name(text)            [NEWMEM 636]   ชื่อ-สกุล จากใบสมัคร
--   pka_hr.fp_get_hr_name(text)                    [PKA_HR 321]   ชื่อ-สกุล เจ้าหน้าที่
--   pka_hr.fp_get_hr_position_by_offno(text,text)  [PKA_HR 353]   ตำแหน่ง(+แผนก) เจ้าหน้าที่
--   pka_dep.fp_get_deptype(text)                   [PKA_DEP]      ประเภทบัญชีเงินฝาก
--   pka_dep.fp_get_print_code(text,text)           [PKA_DEP 1907] STUB FIX — print_code สลิป
--   pka_insure_paysrv.fp_get_insure_approve(text)  [INSURE 397]   ทุนประกันอนุมัติ
--   pka_kep.fp_get_money_amount_unk(text,int,int,int)         [PKA_KEP 1026]   เงินค้างส่ง
--   pka_kep_magent.fp_get_agent_amount_seq(text,int,int,int)  [MAGENT 395]    ยอดตัวแทนต่อ seq
--
-- deps (มีใน PG แล้ว): public.is_number, pka_com_function.fp_get_group_name
--
-- deviation (Legacy Fidelity):
--  - spa_dberror(...) (logger) -> ตัดทิ้ง คืนค่าตาม path เดิม
--  - char/varchar2 -> text ; number -> numeric ; pls_integer/int -> int ; date -> date
--  - Oracle `||` (ข้าม NULL = empty) -> concat() (PG `||` คืน NULL ถ้ามี operand NULL)
--  - Oracle implicit SELECT INTO (ไม่มี handler) -> INTO STRICT เพื่อให้ raise NO_DATA_FOUND
--      เหมือน Oracle เป๊ะ (fp_get_hr_name / fp_get_hr_position_by_offno.department / fp_member_name internal)
--  - มี handler ที่ Oracle (spa_dberror ไม่ return) -> EXCEPTION WHEN others THEN RETURN NULL
--  - is_number/to_number guard: PG is_number(code)='1' -> code::numeric=0 -> null
--  - fp_get_money_amount_unk: Oracle ไม่ nvl -> คง RETURN sum (อาจ NULL เมื่อไม่มีแถว) ตามเดิม
--  - fp_get_agent_amount_seq: nvn(...) -> coalesce(...,0)
--  - fp_get_print_code: select print_code ไม่มี handler ที่ Oracle -> INTO STRICT (propagate)
-- ============================================================================

-- schema ตามแพ็กเกจ Oracle (1 package = 1 schema) — สร้างถ้ายังไม่มี
CREATE SCHEMA IF NOT EXISTS pka_mem;
CREATE SCHEMA IF NOT EXISTS pka_hr;
CREATE SCHEMA IF NOT EXISTS pka_kep;
CREATE SCHEMA IF NOT EXISTS pka_kep_magent;
CREATE SCHEMA IF NOT EXISTS pka_insure_paysrv;

-- ====================== PKA_MEM : fp_desc_* =================================
-- ---- fp_desc_prename : คำนำหน้า [PKA_MEM 258] -----------------------------
CREATE OR REPLACE FUNCTION pka_mem.fp_desc_prename(as_prename_code text)
RETURNS text LANGUAGE plpgsql STABLE AS $$
DECLARE ls_prename text;
BEGIN
  IF trim(as_prename_code) IS NULL THEN RETURN NULL; END IF;
  IF public.is_number(as_prename_code) = '1' AND as_prename_code::numeric = 0 THEN RETURN NULL; END IF;
  SELECT prename INTO STRICT ls_prename
    FROM sc_mem_m_ucf_prename WHERE prename_code = as_prename_code;
  RETURN trim(ls_prename);
EXCEPTION WHEN others THEN RETURN NULL;
END;
$$;

-- ---- fp_desc_position : ตำแหน่ง [PKA_MEM 279] ------------------------------
CREATE OR REPLACE FUNCTION pka_mem.fp_desc_position(as_position_code text)
RETURNS text LANGUAGE plpgsql STABLE AS $$
DECLARE ls_position_name text;
BEGIN
  IF trim(as_position_code) IS NULL THEN RETURN NULL; END IF;
  IF public.is_number(as_position_code) = '1' AND as_position_code::numeric = 0 THEN RETURN NULL; END IF;
  SELECT position_name INTO STRICT ls_position_name
    FROM sc_mem_m_ucf_position WHERE position_code = as_position_code;
  RETURN trim(ls_position_name);
EXCEPTION WHEN others THEN RETURN NULL;
END;
$$;

-- ---- fp_desc_apptype : ประเภทการสมัคร [PKA_MEM 300] -----------------------
CREATE OR REPLACE FUNCTION pka_mem.fp_desc_apptype(as_appl_type_code text)
RETURNS text LANGUAGE plpgsql STABLE AS $$
DECLARE ls_appl_type_name text;
BEGIN
  IF trim(as_appl_type_code) IS NULL THEN RETURN NULL; END IF;
  IF public.is_number(as_appl_type_code) = '1' AND as_appl_type_code::numeric = 0 THEN RETURN NULL; END IF;
  SELECT appl_type_name INTO STRICT ls_appl_type_name
    FROM sc_mem_m_ucf_application_type WHERE appl_type_code = as_appl_type_code;
  RETURN trim(ls_appl_type_name);
EXCEPTION WHEN others THEN RETURN NULL;
END;
$$;

-- ---- fp_desc_memtype : ประเภทสมาชิก [PKA_MEM 321] -------------------------
CREATE OR REPLACE FUNCTION pka_mem.fp_desc_memtype(as_mem_type_code text)
RETURNS text LANGUAGE plpgsql STABLE AS $$
DECLARE ls_mem_type_desc text;
BEGIN
  IF trim(as_mem_type_code) IS NULL THEN RETURN NULL; END IF;
  IF public.is_number(as_mem_type_code) = '1' AND as_mem_type_code::numeric = 0 THEN RETURN NULL; END IF;
  SELECT mem_type_desc INTO STRICT ls_mem_type_desc
    FROM sc_mem_m_ucf_member_type WHERE mem_type_code = as_mem_type_code;
  RETURN trim(ls_mem_type_desc);
EXCEPTION WHEN others THEN RETURN NULL;
END;
$$;

-- ---- fp_desc_memgroup : หน่วย [PKA_MEM 342] (ไม่เช็ค code=0 — บางสหกรณ์หน่วย 000000)
CREATE OR REPLACE FUNCTION pka_mem.fp_desc_memgroup(as_member_group_no text)
RETURNS text LANGUAGE plpgsql STABLE AS $$
BEGIN
  IF trim(as_member_group_no) IS NULL THEN RETURN NULL; END IF;
  RETURN pka_com_function.fp_get_group_name(as_member_group_no);
EXCEPTION WHEN others THEN RETURN NULL;
END;
$$;

-- ====================== PKA_MEM_NEWMEM ======================================
-- ---- fp_member_name : ชื่อ-สกุล จากใบสมัคร [NEWMEM 636] -------------------
-- Oracle: prename||trim(name)||'  '||trim(surname) (|| ข้าม NULL) -> concat()
CREATE OR REPLACE FUNCTION pka_mem_newmem.fp_member_name(as_appno text)
RETURNS text LANGUAGE plpgsql STABLE AS $$
DECLARE ls_rc text;
BEGIN
  SELECT concat(pka_mem.fp_desc_prename(prename_code), trim(member_name), '  ', trim(member_surname))
    INTO STRICT ls_rc
    FROM sc_mem_m_application_form WHERE application_form_no = as_appno;
  RETURN ls_rc;
EXCEPTION WHEN others THEN RETURN NULL;  -- spa_dberror('fp_member_name')
END;
$$;

-- ====================== PKA_HR ==============================================
-- ---- fp_get_hr_name : ชื่อ-สกุล เจ้าหน้าที่ [PKA_HR 321] ------------------
-- Oracle ไม่มี exception handler -> INTO STRICT (raise NO_DATA_FOUND เหมือนเดิม)
CREATE OR REPLACE FUNCTION pka_hr.fp_get_hr_name(as_offno text)
RETURNS text LANGUAGE plpgsql STABLE AS $$
DECLARE ls_hr_name text;
BEGIN
  SELECT concat(p.prename, m.member_name, '  ', m.member_surname)
    INTO STRICT ls_hr_name
    FROM sc_hr_off_member m, sc_mem_m_ucf_prename p
   WHERE m.prename_code = p.prename_code
     AND m.official_no = as_offno;
  RETURN ls_hr_name;
END;
$$;

-- ---- fp_get_hr_position_by_offno : ตำแหน่ง(+แผนก) [PKA_HR 353] ------------
-- query แรก = aggregate min -> coalesce(min,'') (ได้แถวเสมอ, plain INTO)
-- query แผนก (as_full='1') Oracle ไม่มี handler -> INTO STRICT (propagate)
CREATE OR REPLACE FUNCTION pka_hr.fp_get_hr_position_by_offno(as_offno text, as_full text DEFAULT '0')
RETURNS text LANGUAGE plpgsql STABLE AS $$
DECLARE
  ls_position_name   text;
  ls_department_desc text;
BEGIN
  SELECT coalesce(min(op.official_desc), '') INTO ls_position_name
    FROM sc_hr_ucf_official_position op, sc_hr_off_member m
   WHERE m.official_position = op.official_position
     AND m.official_no = as_offno;

  IF as_full = '1' THEN
    SELECT d.department_desc INTO STRICT ls_department_desc
      FROM sc_hr_off_member m, sc_hr_ucf_department d
     WHERE m.department_id = d.department_id
       AND m.official_no = as_offno;
    ls_position_name := concat(ls_position_name, ' ', ls_department_desc);
  END IF;

  RETURN ls_position_name;
END;
$$;

-- ====================== PKA_DEP =============================================
-- ---- fp_get_deptype : ประเภทบัญชีเงินฝาก ----------------------------------
-- Oracle handler (no_data/others -> spa_dberror, ไม่ return) -> RETURN NULL
CREATE OR REPLACE FUNCTION pka_dep.fp_get_deptype(as_depno text)
RETURNS text LANGUAGE plpgsql STABLE AS $$
DECLARE ls_deposit_type_code text;
BEGIN
  SELECT deposit_type_code INTO STRICT ls_deposit_type_code
    FROM sc_dep_m_creditor WHERE deposit_account_no = trim(as_depno);
  RETURN ls_deposit_type_code;
EXCEPTION WHEN others THEN RETURN NULL;
END;
$$;

-- ---- fp_get_print_code : print_code ของสลิป [PKA_DEP 1907] (STUB FIX) ------
CREATE OR REPLACE FUNCTION pka_dep.fp_get_print_code(as_slip_no text, as_item_type text)
RETURNS text LANGUAGE plpgsql STABLE AS $$
DECLARE
  ls_print_code    text;
  ls_money_type    text;
  ls_item_type     text;
  ls_cancel_status text;
BEGIN
  -- รายการมีสลิปหรือไม่
  BEGIN
    SELECT deposit_money_type_code, cancel_status
      INTO STRICT ls_money_type, ls_cancel_status
      FROM sc_dep_t_deposit_slip WHERE deposit_slip_no = as_slip_no;
  EXCEPTION WHEN no_data_found THEN ls_item_type := as_item_type;
            WHEN others        THEN ls_item_type := as_item_type;
  END;

  IF ls_money_type = '12' AND left(as_item_type, 1) <> 'I' THEN   -- 12 ปิดบัญชีเข้ารอจ่ายคืน
    RETURN 'CMR';
  ELSIF ls_cancel_status = '1' THEN                               -- รายการปรับปรุง
    RETURN as_item_type;
  ELSIF as_item_type = 'DTR' OR as_item_type = 'WTR' THEN         -- ครบกำหนด/ถอนก่อนกำหนด
    RETURN as_item_type;
  ELSIF as_item_type = 'IRW' OR as_item_type = 'INR' THEN         -- เรียกคืนดอกเบี้ย
    RETURN as_item_type;
  ELSIF ls_item_type = as_item_type OR ls_money_type <> '08' OR left(as_item_type, 1) = 'F' THEN
    SELECT print_code INTO STRICT ls_print_code
      FROM sc_dep_m_ucf_dep_item_type WHERE deposit_item_type = as_item_type;
    RETURN ls_print_code;
  ELSE
    -- แบ่งจ่ายหลายทาง ใช้ oth_item
    BEGIN
      SELECT oth_item INTO STRICT ls_item_type
        FROM sc_dep_t_deposit_slip_item
       WHERE deposit_slip_no = as_slip_no AND seq_no = 1;
    EXCEPTION WHEN no_data_found THEN ls_item_type := as_item_type;
              WHEN others        THEN ls_item_type := as_item_type;
    END;
    SELECT print_code INTO STRICT ls_print_code
      FROM sc_dep_m_ucf_dep_item_type WHERE deposit_item_type = ls_item_type;
    RETURN ls_print_code;
  END IF;
END;
$$;

-- ====================== PKA_INSURE_PAYSRV ===================================
-- ---- fp_get_insure_approve : ทุนประกันอนุมัติ [INSURE 397] ----------------
CREATE OR REPLACE FUNCTION pka_insure_paysrv.fp_get_insure_approve(as_memno text)
RETURNS numeric LANGUAGE plpgsql STABLE AS $$
DECLARE ldc_number numeric;
BEGIN
  SELECT coalesce(sum(i.insurance_approve), 0) INTO ldc_number
    FROM sc_mem_m_insure i, sc_mem_m_insure_rule r
   WHERE r.insurance_type = i.insurance_type
     AND r.insure_status = '1'
     AND r.insure_loan = '0'
     AND i.insurance_status = '1'
     AND i.membership_no = as_memno;
  RETURN ldc_number;
EXCEPTION WHEN others THEN RETURN NULL;  -- spa_dberror
END;
$$;

-- ====================== PKA_KEP =============================================
-- ---- fp_get_money_amount_unk : เงินค้างส่ง [PKA_KEP 1026] ------------------
-- Oracle ไม่ nvl -> คง RETURN sum (NULL เมื่อไม่มีแถว) ตามเดิม
CREATE OR REPLACE FUNCTION pka_kep.fp_get_money_amount_unk(as_memno text, ai_year int, ai_month int, ai_seq int)
RETURNS numeric LANGUAGE plpgsql STABLE AS $$
DECLARE ldc_amount numeric;
BEGIN
  SELECT sum(unkeep_money_amount) INTO ldc_amount
    FROM sc_kep_t_monthly_receive_det
   WHERE membership_no = as_memno
     AND receive_year  = ai_year
     AND receive_month = ai_month
     AND seq_no        = ai_seq;
  RETURN ldc_amount;
EXCEPTION WHEN others THEN RETURN NULL;  -- spa_dberror
END;
$$;

-- ====================== PKA_KEP_MAGENT ======================================
-- ---- fp_get_agent_amount_seq : ยอดตัวแทนต่อ seq [MAGENT 395] --------------
-- nvn(...) -> coalesce(...,0) ; magent_not='0' (1=ไม่ตั้ง)
CREATE OR REPLACE FUNCTION pka_kep_magent.fp_get_agent_amount_seq(as_memno text, ai_year int, ai_month int, ai_seqno int)
RETURNS numeric LANGUAGE plpgsql STABLE AS $$
DECLARE ldc_keeping_monthly numeric;
BEGIN
  SELECT sum(d.money_amount) INTO ldc_keeping_monthly
    FROM sc_kep_t_monthly_receive_det d, sc_kep_m_ucf_keeping_item_type k, sc_kep_m_ucf_process pr
   WHERE d.keeping_type_code = k.keeping_type_code
     AND d.membership_no = as_memno
     AND d.receive_year  = ai_year
     AND d.receive_month = ai_month
     AND d.seq_no        = ai_seqno
     AND k.keeping_type_group = pr.proc_code
     AND pr.magent_not = '0';
  RETURN coalesce(ldc_keeping_monthly, 0);
EXCEPTION WHEN others THEN RETURN NULL;  -- spa_dberror
END;
$$;
