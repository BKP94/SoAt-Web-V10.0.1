-- ============================================================================
-- 2026-06-11_pka_blockB_tier1.sql
-- Block B — Tier 1 (shared/common package functions) ที่ trigger/function ทั่วทุก
-- module เรียกแต่ยังไม่ถูกสร้างใน PG (migration gap จาก Oracle package layer)
--
-- ที่มา: landmine scan (C:\tmp\dbq\blockB_missing_pkg.txt) — 39 fn หาย กระทบ 56 caller.
--        Tier 1 = package กลุ่ม pka_com_* / pka_srv_* (module-agnostic, leverage สูงสุด)
--        Tier 2 (pka_fin/pka_lon/pka_dep/pka_mem/...) เลื่อนไปทำตอนสร้าง UI module นั้น
--
-- มาตรฐานแปล Oracle→PG (ตาม [[project-trigger-migration-gap]]):
--   - แปล body 1:1 ตาม legacy (fidelity); ตัด `EXCEPTION WHEN OTHERS THEN spa_dberror(...)`
--     ออก (PG ไม่ครอบ catch-all) — แต่ `WHEN NO_DATA_FOUND` ที่เป็น "logic" → `IF NOT FOUND`
--   - sysdate→CURRENT_TIMESTAMP, NVL→COALESCE, SELECT INTO no-row → IF NOT FOUND
--   - return char '1'/'0' ของ Oracle → varchar (ค่าเทียบ '0'/'1' เหมือนเดิม)
--   - idempotent (CREATE OR REPLACE) ปลอดภัยรันซ้ำ
--
-- *** Batch 1 (2026-06-11): pka_srv_datetime + pka_com_valid (8 fn) ***
-- ============================================================================

-- =====================================================================
-- 1) pka_srv_datetime — date helpers (เรียกโดย trigger/report หลาย module)
--    fp_LastDayOfMonth ← 10 caller | fp_FirstDayOfMonth ← 1
-- =====================================================================
CREATE SCHEMA IF NOT EXISTS pka_srv_datetime;

-- หาวันสุดท้ายของเดือน (Oracle: LAST_DAY) — NULL→NULL
CREATE OR REPLACE FUNCTION pka_srv_datetime.fp_lastdayofmonth(adt_date date)
RETURNS date LANGUAGE sql IMMUTABLE AS $$
  SELECT CASE
           WHEN adt_date IS NULL THEN NULL
           ELSE (date_trunc('month', adt_date::timestamp) + interval '1 month - 1 day')::date
         END
$$;

-- หาวันแรกของเดือน (วันที่ 1) — NULL→NULL
CREATE OR REPLACE FUNCTION pka_srv_datetime.fp_firstdayofmonth(adt_date date)
RETURNS date LANGUAGE sql IMMUTABLE AS $$
  SELECT CASE
           WHEN adt_date IS NULL THEN NULL
           ELSE date_trunc('month', adt_date::timestamp)::date
         END
$$;

-- =====================================================================
-- 2) pka_com_valid — validator (มี/ไม่มี → '1'/'0')
--    var_number ← 6 | account_id ← 2 | loan_contract_no ← 2
--    loan_objective_code ← 1 | money_type_id ← 1 | var_date ← 1
-- =====================================================================
CREATE SCHEMA IF NOT EXISTS pka_com_valid;

-- จำนวนเงินต้อง > 0 ถึง return '1' (null/≤0 → '0')
CREATE OR REPLACE FUNCTION pka_com_valid.var_number(adc_number numeric)
RETURNS varchar LANGUAGE sql IMMUTABLE AS $$
  SELECT CASE WHEN adc_number > 0 THEN '1' ELSE '0' END
$$;

-- วันที่มีอยู่จริง (ไม่ null และไม่ใช่ 01/01/1900) → '1'
CREATE OR REPLACE FUNCTION pka_com_valid.var_date(adt_value date)
RETURNS varchar LANGUAGE sql IMMUTABLE AS $$
  SELECT CASE
           WHEN adt_value IS NULL THEN '0'
           WHEN to_char(adt_value, 'DD/MM/YYYY') = '01/01/1900' THEN '0'
           ELSE '1'
         END
$$;

-- SC_ACC_M_ACCOUNT_MASTER.account_id (เฉพาะ account_type_id='3') มีอยู่จริง?
CREATE OR REPLACE FUNCTION pka_com_valid.account_id(as_code varchar)
RETURNS varchar LANGUAGE plpgsql STABLE AS $$
DECLARE li_count int;
BEGIN
  SELECT count(account_id) INTO li_count
  FROM sc_acc_m_account_master
  WHERE account_id = as_code
    AND account_type_id = '3';
  IF li_count > 0 THEN RETURN '1'; ELSE RETURN '0'; END IF;
END $$;

-- sc_lon_m_ucf_loan_obj (loan_type + loan_objective_code) มีอยู่จริง?
CREATE OR REPLACE FUNCTION pka_com_valid.loan_objective_code(as_loan_type varchar, as_code varchar)
RETURNS varchar LANGUAGE plpgsql STABLE AS $$
DECLARE li_count int;
BEGIN
  SELECT count(loan_type) INTO li_count
  FROM sc_lon_m_ucf_loan_obj
  WHERE loan_type = as_loan_type
    AND loan_objective_code = as_code;
  IF li_count > 0 THEN RETURN '1'; ELSE RETURN '0'; END IF;
END $$;

-- เลขที่สัญญาเงินกู้ sc_lon_m_contract.loan_contract_no มีอยู่จริง?
CREATE OR REPLACE FUNCTION pka_com_valid.loan_contract_no(as_value varchar)
RETURNS varchar LANGUAGE plpgsql STABLE AS $$
DECLARE ls_value varchar;
BEGIN
  IF as_value IS NULL OR as_value = ' ' THEN RETURN '0'; END IF;
  SELECT loan_contract_no INTO ls_value
  FROM sc_lon_m_contract
  WHERE loan_contract_no = as_value;
  IF NOT FOUND THEN RETURN '0'; END IF;   -- Oracle: WHEN NO_DATA_FOUND → '0'
  RETURN '1';
END $$;

-- รหัสประเภทเงิน sc_com_m_ucf_money_type ตาม type R=รับชำระ / P=จ่ายกู้ / Y=ปันผล
CREATE OR REPLACE FUNCTION pka_com_valid.money_type_id(as_value varchar, as_type varchar)
RETURNS varchar LANGUAGE plpgsql STABLE AS $$
DECLARE ls_value varchar;
BEGIN
  IF as_value IS NULL OR as_value = ' ' THEN RETURN '0'; END IF;
  IF as_type IS NULL OR as_type NOT IN ('R','P','Y') THEN RETURN '0'; END IF;

  IF as_type = 'R' THEN          -- รับชำระ
    SELECT money_type_id INTO ls_value FROM sc_com_m_ucf_money_type
    WHERE money_type_id = as_value AND receipt_status = '1';
    IF NOT FOUND THEN RETURN '0'; END IF;
  END IF;
  IF as_type = 'P' THEN          -- จ่ายเงินกู้
    SELECT money_type_id INTO ls_value FROM sc_com_m_ucf_money_type
    WHERE money_type_id = as_value AND payment_status = '1';
    IF NOT FOUND THEN RETURN '0'; END IF;
  END IF;
  IF as_type = 'Y' THEN          -- จ่ายเงินปันผล/เฉลี่ยคืน
    SELECT money_type_id INTO ls_value FROM sc_com_m_ucf_money_type
    WHERE money_type_id = as_value AND dividen_status = '1';
    IF NOT FOUND THEN RETURN '0'; END IF;
  END IF;

  RETURN '1';
END $$;

-- =====================================================================
-- *** Batch 2A (2026-06-11): pka_com_function (6 fn self-contained) ***
--   schema pka_com_function สร้างไว้แล้วใน 2026-06-06_pka_trigger_infra.sql
--   *** DEFER → Tier 2 (loan module): fp_lon_get_balance_atdate ***
--     เหตุผล: overload 2-arg delegate ไป pka_rep_tel.loan_balance_atdate
--     (teller/report package ยังไม่ migrate) → ถ้าแปลตอนนี้ runtime ยังพังอยู่ดี.
--     กฎ: classify by self-containment ไม่ใช่ชื่อ package — ตัวที่ body เรียก
--     package Tier-2 ที่ยังไม่มี ให้เลื่อนไปทำพร้อม module นั้น
-- =====================================================================
CREATE SCHEMA IF NOT EXISTS pka_com_function;

-- กลุ่มสมาชิก (member_group_no) จากทะเบียนสมาชิก
CREATE OR REPLACE FUNCTION pka_com_function.fp_get_member_group(a_membership_no varchar)
RETURNS varchar LANGUAGE plpgsql STABLE AS $$
DECLARE ls_member_group_no varchar;
BEGIN
  SELECT member_group_no INTO ls_member_group_no
  FROM sc_mem_m_membership_registered
  WHERE membership_no = a_membership_no;
  IF NOT FOUND THEN RETURN NULL; END IF;   -- Oracle: WHEN NO_DATA_FOUND → null
  RETURN trim(ls_member_group_no);
END $$;

-- ชื่อจังหวัด
CREATE OR REPLACE FUNCTION pka_com_function.fp_get_province_name(as_province_code varchar)
RETURNS varchar LANGUAGE plpgsql STABLE AS $$
DECLARE ls_province_name varchar;
BEGIN
  SELECT province_name INTO ls_province_name
  FROM sc_mem_m_ucf_province WHERE province_code = as_province_code;
  IF NOT FOUND THEN RETURN NULL; END IF;
  RETURN trim(ls_province_name);
END $$;

-- ชื่ออำเภอ (join province+district บน province_code)
CREATE OR REPLACE FUNCTION pka_com_function.fp_get_district_name(as_province_code varchar, as_district_code varchar)
RETURNS varchar LANGUAGE plpgsql STABLE AS $$
DECLARE ls_district_name varchar;
BEGIN
  SELECT d.district_name INTO ls_district_name
  FROM sc_mem_m_ucf_province p, sc_mem_m_ucf_district d
  WHERE p.province_code = d.province_code
    AND p.province_code = as_province_code
    AND d.district_code = as_district_code;
  IF NOT FOUND THEN RETURN NULL; END IF;
  RETURN trim(ls_district_name);
END $$;

-- ยอดเงินฝากคงเหลือ (เจ้าหนี้เงินฝาก) — ไม่พบ → 0
CREATE OR REPLACE FUNCTION pka_com_function.fp_get_deposit_balance(as_depno varchar)
RETURNS numeric LANGUAGE plpgsql STABLE AS $$
DECLARE ldc_deposit_balance numeric;
BEGIN
  SELECT deposit_balance INTO ldc_deposit_balance
  FROM sc_dep_m_creditor WHERE deposit_account_no = as_depno;
  IF NOT FOUND THEN RETURN 0; END IF;   -- Oracle: WHEN NO_DATA_FOUND → 0
  RETURN COALESCE(ldc_deposit_balance, 0);
END $$;

-- เลขสมาชิกของสัญญาเงินกู้
CREATE OR REPLACE FUNCTION pka_com_function.fp_get_loan_memno(as_conno varchar)
RETURNS varchar LANGUAGE plpgsql STABLE AS $$
DECLARE ls_memno varchar;
BEGIN
  SELECT membership_no INTO ls_memno
  FROM sc_lon_m_contract WHERE loan_contract_no = as_conno;
  IF NOT FOUND THEN RETURN NULL; END IF;
  RETURN trim(ls_memno);
END $$;

-- ชื่อคู่สมรส (คำนำหน้า+ชื่อ+นามสกุล); prename_code 0/00/000 = ไม่ระบุ
--   หมายเหตุ fidelity: Oracle `||` มอง NULL เป็น '' → PG ต้อง COALESCE ทุกชิ้น
--   ไม่งั้นทั้ง expression กลายเป็น NULL
CREATE OR REPLACE FUNCTION pka_com_function.fp_get_member_spname(a_membership_no varchar)
RETURNS varchar LANGUAGE plpgsql STABLE AS $$
DECLARE
  l_member_name    varchar;
  l_member_surname varchar;
  ls_prename_code  varchar;
  l_prename        varchar;
BEGIN
  IF a_membership_no IS NULL OR a_membership_no = ' ' THEN RETURN NULL; END IF;

  SELECT spouse_name, spouse_surname, prename_code
    INTO l_member_name, l_member_surname, ls_prename_code
  FROM sc_mem_m_member_spouse_info WHERE membership_no = a_membership_no;
  IF NOT FOUND THEN RETURN NULL; END IF;   -- Oracle: inner begin/exception → return null

  IF ls_prename_code IN ('0','00','000') OR trim(ls_prename_code) IS NULL THEN
    l_prename := NULL;                       -- <ไม่ระบุ>
  ELSE
    SELECT prename INTO l_prename
    FROM sc_mem_m_ucf_prename WHERE prename_code = ls_prename_code;
    IF NOT FOUND THEN l_prename := NULL; END IF;
  END IF;

  RETURN trim(trim(COALESCE(l_prename,'')) || ' ' || trim(COALESCE(l_member_name,''))
              || '  ' || trim(COALESCE(l_member_surname,'')));
END $$;

-- =====================================================================
-- *** Batch 3 (2026-06-11): pka_srv_string (key=value parser, self-contained) ***
--   callers: public.getkeyvalue / public.vget (fp_getkeyvalue), public.vset (fp_setkeyvalue)
--   pure string manipulation — ไม่แตะ table/package อื่น
--   หมายเหตุ deviation (บันทึก):
--     1) package-state `ib_KeyValid` (boolean) ตัดทิ้ง — caller อ่านแค่ค่า return,
--        ตัวที่อ่าน ib_KeyValid คือ fp_isKeyValid ซึ่งไม่มี caller ใน scan
--     2) Oracle INSTR(str,sub,start) 3-arg ไม่มีใน PG → ทำ helper fp_instr (1-based, 0=ไม่พบ)
--     3) fp_right = helper ของ Oracle (ไม่ใช่ built-in) ต้องสร้างคู่กัน
-- =====================================================================
CREATE SCHEMA IF NOT EXISTS pka_srv_string;

-- helper: ตัดอักษรขวา N ตัว (เทียบ Oracle pka_srv_string.fp_right)
CREATE OR REPLACE FUNCTION pka_srv_string.fp_right(as_string varchar, ai_len integer)
RETURNS varchar LANGUAGE sql IMMUTABLE AS $$
  SELECT CASE WHEN length(as_string) > ai_len
              THEN substr(as_string, length(as_string) - ai_len + 1, ai_len)
              ELSE as_string END
$$;

-- helper: เทียบ Oracle INSTR(str,sub[,start]) — 1-based, คืน 0 เมื่อไม่พบ
CREATE OR REPLACE FUNCTION pka_srv_string.fp_instr(as_str varchar, as_sub varchar, ai_start integer DEFAULT 1)
RETURNS integer LANGUAGE sql IMMUTABLE AS $$
  SELECT CASE
    WHEN as_str IS NULL OR as_sub IS NULL THEN 0
    WHEN strpos(substr(as_str, GREATEST(ai_start,1)), as_sub) = 0 THEN 0
    ELSE GREATEST(ai_start,1) - 1 + strpos(substr(as_str, GREATEST(ai_start,1)), as_sub)
  END
$$;

-- อ่านค่าคีย์จาก source "key1=val1&key2=val2" (3-arg main)
CREATE OR REPLACE FUNCTION pka_srv_string.fp_getkeyvalue(as_source varchar, as_keyword varchar, as_separator varchar)
RETURNS varchar LANGUAGE plpgsql IMMUTABLE AS $$
DECLARE
  li_keyword   integer := 0;
  li_separator integer := 0;
  li_equal     integer := 0;
  ls_keyvalue  varchar;
BEGIN
  IF trim(as_source) IS NULL OR trim(as_keyword) IS NULL OR trim(as_separator) IS NULL THEN
    RETURN NULL;
  END IF;

  IF substr(as_source, 1, length(as_keyword||'=')) = as_keyword||'=' THEN
    -- key แรกคือ key ที่ต้องการ
    li_equal     := pka_srv_string.fp_instr(as_source, '=');
    li_separator := pka_srv_string.fp_instr(as_source, as_separator);
    IF li_separator > 0 THEN
      ls_keyvalue := substr(as_source, li_equal + 1, li_separator - li_equal - 1);
    ELSE
      ls_keyvalue := substr(as_source, li_equal + 1);
    END IF;
  ELSE
    li_keyword := pka_srv_string.fp_instr(as_source, as_separator||as_keyword||'=');
    IF li_keyword > 0 THEN
      li_equal     := pka_srv_string.fp_instr(as_source, '=', li_keyword + 1);
      li_separator := pka_srv_string.fp_instr(as_source, as_separator, li_keyword + 1);
      IF li_separator > 0 THEN
        ls_keyvalue := substr(as_source, li_equal + 1, li_separator - li_equal - 1);
      ELSE
        ls_keyvalue := substr(as_source, li_equal + 1);
      END IF;
    END IF;   -- ไม่พบ key → ls_keyvalue คง NULL
  END IF;

  IF ls_keyvalue IS NOT NULL THEN
    ls_keyvalue := replace(ls_keyvalue, '!SPR!', as_separator);
  END IF;
  RETURN ls_keyvalue;
END $$;

-- overload 2-arg (separator '&')
CREATE OR REPLACE FUNCTION pka_srv_string.fp_getkeyvalue(as_source varchar, as_keyword varchar)
RETURNS varchar LANGUAGE sql IMMUTABLE AS $$
  SELECT pka_srv_string.fp_getkeyvalue(as_source, as_keyword, '&')
$$;

-- กำหนดค่าคีย์ (มีอยู่→แทนค่า, ไม่มี→เพิ่ม) (4-arg main)
--   หมายเหตุ fidelity: Oracle `||` มอง NULL เป็น '' → COALESCE ls_keyvalue ในจุดต่อสตริง
CREATE OR REPLACE FUNCTION pka_srv_string.fp_setkeyvalue(as_source varchar, as_keyword varchar, as_keyvalue varchar, as_separator varchar)
RETURNS varchar LANGUAGE plpgsql IMMUTABLE AS $$
DECLARE
  li_keyword   integer := 0;
  li_separator integer := 0;
  li_equal     integer := 0;
  ls_temp      varchar;
  ls_source    varchar;
  ls_keyvalue  varchar;
BEGIN
  ls_source := as_source;

  IF as_separator IS NOT NULL THEN
    ls_keyvalue := replace(as_keyvalue, as_separator, '!SPR!');
  END IF;

  -- ค่า keyvalue เป็น null ได้ (ตาม legacy) — เช็คแค่ keyword/separator
  IF trim(as_keyword) IS NULL OR trim(as_separator) IS NULL THEN
    RETURN ls_source;
  END IF;

  IF substr(ls_source, 1, length(as_keyword||'=')) = as_keyword||'=' THEN
    li_keyword := 1;
  ELSE
    li_keyword := pka_srv_string.fp_instr(lower(ls_source), lower(as_separator||as_keyword||'='), 1);
    IF li_keyword > 0 THEN
      li_keyword := li_keyword + 1;
    END IF;
  END IF;

  IF li_keyword > 0 THEN
    -- พบคีย์ : เปลี่ยนแปลงค่า
    ls_temp := ltrim(pka_srv_string.fp_right(ls_source, length(ls_source) - (li_keyword + length(as_keyword) - 1)));
    IF substr(ls_temp, 1, 1) = '=' THEN
      li_equal     := pka_srv_string.fp_instr(ls_source, '=', li_keyword + 1);
      li_separator := pka_srv_string.fp_instr(ls_source, as_separator, li_equal + 1);
      IF li_separator > 0 THEN
        ls_source := substr(ls_source, 1, li_equal) || COALESCE(ls_keyvalue,'') || as_separator
                     || pka_srv_string.fp_right(ls_source, length(ls_source) - li_separator);
      ELSE
        ls_source := substr(ls_source, 1, li_equal) || COALESCE(ls_keyvalue,'');
      END IF;
    END IF;
  ELSE
    -- ไม่พบคีย์ : เพิ่มให้
    IF length(ls_source) > 0 THEN
      ls_source := ls_source || as_separator || as_keyword || '=' || COALESCE(ls_keyvalue,'');
    ELSE
      ls_source := as_keyword || '=' || COALESCE(ls_keyvalue,'');
    END IF;
  END IF;

  RETURN ls_source;
END $$;

-- overload 3-arg (separator '&')
CREATE OR REPLACE FUNCTION pka_srv_string.fp_setkeyvalue(as_source varchar, as_keyword varchar, as_keyvalue varchar)
RETURNS varchar LANGUAGE sql IMMUTABLE AS $$
  SELECT pka_srv_string.fp_setkeyvalue(as_source, as_keyword, as_keyvalue, '&')
$$;

-- =====================================================================
-- *** Tier-1 DEFERRED (2026-06-11): ตัวที่ "ไม่ self-contained" — รอ 2nd-layer infra ***
--   เหตุผลร่วม: ปัจจุบัน PG ยังไม่มี pka_attrib.getdata / pka_com_login.* (session
--   bridge: login_app/window_active) / getcoltype·getcomment (data-dictionary) /
--   fp_timetext. แปลตอนนี้ = function ยัง explode runtime อยู่ดี → เลื่อนไปทำพร้อม
--   "ชั้น infra ที่สอง" (หรือพร้อม module ที่ใช้). กฎ: classify by self-containment.
--
--   1) pka_com.getattrib_app        (caller: trigger_fct_tbiu_sc_fin_vourcher_head)
--        ต้องมี pka_attrib.getdata (dynamic-SQL engine) + pka_com_login.login_app/login_br
--   2) pka_srv_dbattrib.getmeaning  (caller: public.to_meaing)
--        ต้องมี getcomment→sp_load_tabcolattrib (อ่าน column-comment dict) → rewrite เป็น
--        pg_description/col_description; meta, leverage ต่ำ (1 caller)
--   3) pka_com_datalog.sp_addlog + sp_set_edittime (caller: trigger_fct_tbiu_sc_mem_m_capital_pay)
--        ต้องมี getcoltype + pka_com_login.window_active + package-state ii_edit_time
--        (audit log → sc_lon_edit_data) → ทำพร้อม module mem
--   4) pka_com_process.fp_timebegin + fp_timeend (caller: public.time_begin/time_end)
--        dev profiling — package-state associative array + fp_timetext; leverage ต่ำ
-- =====================================================================
