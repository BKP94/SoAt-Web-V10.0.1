-- ============================================================================
-- step 6 function-first sweep — batch 5 (ปิดท้าย pka_com_function)
-- port (MISSING ใน PG):
--   fp_get_coopname               [src 1404]  ชื่อสหกรณ์
--   fp_get_loan_loantype(text)    [src 1599]  ประเภทเงินกู้ของสัญญา
--   fp_form_conno(text)           [src 688]   format เลขสัญญา
--   fp_get_loan_balance(text)     [src 1476]  ยอดกู้คงเหลือต่อสัญญา
--   fp_get_member_sharemonthly    [src 1427]  หุ้นรายเดือน (งดส่ง->0)
--   fp_get_member_id_card(text)   [NO LEGACY]  เลขบัตร ปชช. ตามทะเบียน  ** ดู deviation **
--
-- deviation (Legacy Fidelity):
--  - spa_dberror(...) (logger side-effect) -> ตัดทิ้ง คืน null/0 ตาม path เดิม
--  - return number -> numeric (เงิน), char/varchar2 -> text
--  - fp_get_member_id_card: **ไม่มีใน Oracle source เลย** — report rcTeller/loanCon/
--      r_mwa_book_loan_norm.xml เรียก `pka_com_function.fp_get_member_id_card(...)`
--      แต่ PKA_COM_FUNCTION (และทุก package) ไม่มี def. inferred จากชื่อ+การใช้
--      (coll_id_card) = คืน id_card ตาม membership_no จาก sc_mem_m_membership_registered
--      -> ใส่ minimal เพื่อให้รายงานรันได้ (flag ผู้ใช้ยืนยัน intent)
-- ============================================================================

-- ---- fp_get_coopname : ชื่อสหกรณ์ [src 1404] ------------------------------
CREATE OR REPLACE FUNCTION pka_com_function.fp_get_coopname()
RETURNS text LANGUAGE plpgsql STABLE AS $$
DECLARE ls_coop_name text;
BEGIN
  SELECT coop_name INTO STRICT ls_coop_name FROM sc_cnt_m_coop;
  RETURN trim(ls_coop_name);
EXCEPTION WHEN others THEN RETURN NULL;
END;
$$;

-- ---- fp_get_loan_loantype : ประเภทเงินกู้ของสัญญา [src 1599] --------------
CREATE OR REPLACE FUNCTION pka_com_function.fp_get_loan_loantype(as_conno text)
RETURNS text LANGUAGE plpgsql STABLE AS $$
DECLARE ls_loan_type text;
BEGIN
  SELECT loan_type INTO STRICT ls_loan_type
    FROM sc_lon_m_contract WHERE loan_contract_no = as_conno;
  RETURN trim(ls_loan_type);
EXCEPTION
  WHEN no_data_found THEN RETURN NULL;
  WHEN others THEN RETURN NULL;
END;
$$;

-- ---- fp_form_conno : format เลขสัญญา [src 688] ----------------------------
-- Oracle: เลือก contract_no_format ก่อน ถ้า null ใช้ contract_format
CREATE OR REPLACE FUNCTION pka_com_function.fp_form_conno(as_conno text)
RETURNS text LANGUAGE plpgsql STABLE AS $$
DECLARE
  ls_contract_no_format text;
  ls_contract_format    text;
  ls_format             text;
BEGIN
  BEGIN
    SELECT contract_no_format, contract_format
      INTO ls_contract_no_format, ls_contract_format FROM sc_lon_m_constant;
  EXCEPTION WHEN others THEN NULL; END;
  IF trim(ls_contract_no_format) IS NOT NULL THEN ls_format := ls_contract_no_format;
  ELSE                                            ls_format := ls_contract_format;  END IF;
  RETURN trim(pka_com_function.fp_form(as_conno, ls_format));
EXCEPTION WHEN others THEN RETURN NULL;
END;
$$;

-- ---- fp_get_loan_balance : ยอดกู้คงเหลือต่อสัญญา [src 1476] ----------------
CREATE OR REPLACE FUNCTION pka_com_function.fp_get_loan_balance(as_conno text)
RETURNS numeric LANGUAGE plpgsql STABLE AS $$
DECLARE ldc_loanbal numeric;
BEGIN
  SELECT principal_balance INTO STRICT ldc_loanbal
    FROM sc_lon_m_loan_card WHERE loan_contract_no = as_conno;
  RETURN coalesce(ldc_loanbal, 0);
EXCEPTION
  WHEN no_data_found THEN RETURN 0;
  WHEN others THEN RETURN NULL;
END;
$$;

-- ---- fp_get_member_sharemonthly : หุ้นรายเดือน [src 1427] -----------------
-- งดส่ง (drop_status='1') -> 0
CREATE OR REPLACE FUNCTION pka_com_function.fp_get_member_sharemonthly(as_memno text)
RETURNS numeric LANGUAGE plpgsql STABLE AS $$
DECLARE
  ldc_share_amount numeric;
  ls_drop_status   text;
BEGIN
  SELECT share_amount, drop_status INTO STRICT ldc_share_amount, ls_drop_status
    FROM sc_mem_m_share_mem WHERE membership_no = as_memno;
  IF ls_drop_status = '1' THEN RETURN 0;
  ELSE                         RETURN coalesce(ldc_share_amount, 0); END IF;
EXCEPTION
  WHEN no_data_found THEN RETURN 0;
  WHEN others THEN RETURN NULL;
END;
$$;

-- ---- fp_get_member_id_card : เลขบัตร ปชช. ตามทะเบียน [NO LEGACY] ----------
-- ดู deviation header — ไม่มี def ใน Oracle, inferred จาก usage (coll_id_card)
CREATE OR REPLACE FUNCTION pka_com_function.fp_get_member_id_card(as_memno text)
RETURNS text LANGUAGE plpgsql STABLE AS $$
DECLARE ls_id_card text;
BEGIN
  SELECT id_card INTO STRICT ls_id_card
    FROM sc_mem_m_membership_registered WHERE membership_no = as_memno;
  RETURN trim(ls_id_card);
EXCEPTION WHEN others THEN RETURN NULL;
END;
$$;
