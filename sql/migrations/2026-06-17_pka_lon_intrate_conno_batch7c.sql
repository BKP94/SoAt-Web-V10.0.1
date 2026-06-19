-- ============================================================================
-- step 6 function-first sweep — batch 7c (อัตราดอกเบี้ยตามเลขที่สัญญา — intrate per-contract)
-- port (ทั้งหมด MISSING ใน PG):
--   pka_lon_intsrv.fp_inttable_conno(text)                       [INTSRV 188]  มีตารางรายสัญญาไหม
--   pka_lon_intsrv.fp_intrate_table_conno(text,ts,numeric)       [INTSRV 1308] core ตารางรายสัญญา
--   pka_lon_intsrv.fp_intrate_conno(text,ts,numeric)             [INTSRV 657]  dispatcher
--   pka_lon_intsrv.fp_intrate_conno(text)                        [INTSRV 645]  entry (report เรียกตัวนี้ [1])
--
-- deps (มี body ใน PG แล้ว — batch7a): pka_lon_intsrv.fp_intrate_table_loantype(text,ts,numeric)
--
-- engine เดิม = package-array pattern เดียวกับ batch7a:
--   fp_inttable_conno BULK COLLECT sc_lon_m_int_step_rate_conno (กรอง loan_contract_no)
--     เข้า collection ผ่าน sp_inttable → fp_intrate_table_conno เรียก fp_intrate_table
--     iterate collection เดิม (max eff<=req, min step>=req, rate ณ จุดนั้น).
-- deviation (Legacy Fidelity): collapse package-array → single SQL (idiom batch7a เป๊ะ)
--   ผลลัพธ์เท่ากัน — collection ของ conno = ทุกแถวของสัญญานั้น (loan_type ถูก set NULL
--   ตอน BULK COLLECT → ไม่มี predicate loan_type ในการ iterate) ดังนั้น SQL กรองแค่
--   loan_contract_no = as_conno พอ:
--   - effective_date = max(effective_date) ที่ <= req
--   - loan_step     = min(loan_step) ที่ >= req_step
--   - rate          = loan_interest_rate ณ (eff,step) นั้น; ไม่พบ → coalesce 0
--   - fp_inttable_conno: เดิมคืน collection.count → collapse เป็น count(*) (ใช้แค่ check >0)
--   - spa_dberror(...) (logger) → ตัดทิ้ง คืน 0/null ตาม path เดิม
--   - select into ใน Oracle มี inner handler (swallow) → INTO STRICT + EXCEPTION WHEN others NULL
--       (no row → ค่าคงเป็น NULL ไหลต่อ เหมือน Oracle)
--   - number → numeric ; char/varchar2 → text ; date → timestamp ; to_date(sysdate) → CURRENT_DATE
-- ============================================================================

-- ---- fp_inttable_conno : มีตารางดอกเบี้ยรายสัญญาไหม (คืนจำนวนแถว) [INTSRV 188] -
CREATE OR REPLACE FUNCTION pka_lon_intsrv.fp_inttable_conno(as_conno text)
RETURNS int LANGUAGE plpgsql STABLE AS $$
DECLARE li_count int;
BEGIN
  SELECT count(*) INTO li_count
    FROM sc_lon_m_int_step_rate_conno
   WHERE loan_contract_no = as_conno;
  RETURN li_count;
EXCEPTION WHEN others THEN RETURN NULL;  -- spa_dberror('fp_inttable_conno')
END;
$$;

-- ---- fp_intrate_table_conno : อัตราตามตารางรายสัญญา (core 3-arg) [INTSRV 1308] -
CREATE OR REPLACE FUNCTION pka_lon_intsrv.fp_intrate_table_conno(
  as_conno text, adt_effective_date timestamp without time zone, adc_loan_step numeric)
RETURNS numeric LANGUAGE plpgsql STABLE AS $$
DECLARE
  ldt_eff  timestamp;
  ldc_step numeric;
  ldc_rate numeric;
BEGIN
  -- วันที่ประกาศใช้อัตราล่าสุด ก่อน/ถึง วันที่ req (เฉพาะตารางของสัญญานี้)
  SELECT max(effective_date) INTO ldt_eff
    FROM sc_lon_m_int_step_rate_conno
   WHERE loan_contract_no = as_conno
     AND effective_date <= adt_effective_date;
  IF ldt_eff IS NULL THEN RETURN 0; END IF;

  -- ช่วงเงิน: loan_step ต่ำสุดที่ >= req_step
  SELECT min(loan_step) INTO ldc_step
    FROM sc_lon_m_int_step_rate_conno
   WHERE loan_contract_no = as_conno
     AND effective_date = ldt_eff
     AND loan_step >= adc_loan_step;
  IF ldc_step IS NULL THEN RETURN 0; END IF;

  SELECT loan_interest_rate INTO ldc_rate
    FROM sc_lon_m_int_step_rate_conno
   WHERE loan_contract_no = as_conno
     AND effective_date = ldt_eff
     AND loan_step = ldc_step
   LIMIT 1;

  RETURN coalesce(ldc_rate, 0);
EXCEPTION WHEN others THEN RETURN NULL;  -- spa_dberror('fp_intrate_table_conno')
END;
$$;

-- ---- fp_intrate_conno (3-arg) : dispatcher ดอกเบี้ยรายสัญญา [INTSRV 657] ------
-- คงที่ตามสัญญา (fixed_interest_rate>0) > ตารางรายสัญญา (ถ้ามี) > ตารางตามประเภทกู้
CREATE OR REPLACE FUNCTION pka_lon_intsrv.fp_intrate_conno(
  as_conno text, adt_date timestamp without time zone, adc_principal numeric)
RETURNS numeric LANGUAGE plpgsql STABLE AS $$
DECLARE
  ldc_intrate   numeric;
  ldc_fixedrate numeric;
  ls_loantype   text;
BEGIN
  BEGIN
    SELECT coalesce(fixed_interest_rate, 0), trim(loan_type)
      INTO STRICT ldc_fixedrate, ls_loantype
      FROM sc_lon_m_loan_card
     WHERE loan_contract_no = as_conno;
  EXCEPTION WHEN others THEN NULL;  -- spa_dberror E253 (logger, swallow)
  END;

  IF ldc_fixedrate > 0 THEN
    ldc_intrate := ldc_fixedrate;  -- อัตราคงที่ตามสัญญา
  ELSE
    IF pka_lon_intsrv.fp_inttable_conno(as_conno) > 0 THEN
      ldc_intrate := pka_lon_intsrv.fp_intrate_table_conno(as_conno, adt_date, adc_principal);
    ELSE
      ldc_intrate := pka_lon_intsrv.fp_intrate_table_loantype(ls_loantype, adt_date, adc_principal);
    END IF;
  END IF;

  RETURN coalesce(ldc_intrate, 0);
EXCEPTION WHEN others THEN RETURN NULL;  -- spa_dberror('fp_intrate_conno')
END;
$$;

-- ---- fp_intrate_conno (1-arg) : entry — ใช้ยอดคงเหลอ + วันนี้ [INTSRV 645] ----
CREATE OR REPLACE FUNCTION pka_lon_intsrv.fp_intrate_conno(as_conno text)
RETURNS numeric LANGUAGE plpgsql STABLE AS $$
DECLARE ldc_balance numeric;
BEGIN
  BEGIN
    SELECT principal_balance INTO STRICT ldc_balance
      FROM sc_lon_m_loan_card
     WHERE loan_contract_no = as_conno;
  EXCEPTION WHEN others THEN NULL;  -- spa_dberror E237 (logger, swallow)
  END;

  RETURN pka_lon_intsrv.fp_intrate_conno(as_conno, CURRENT_DATE::timestamp, ldc_balance);
EXCEPTION WHEN others THEN RETURN NULL;  -- spa_dberror('fp_intrate_conno')
END;
$$;
