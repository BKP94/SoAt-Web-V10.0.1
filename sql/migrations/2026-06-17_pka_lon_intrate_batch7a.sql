-- ============================================================================
-- step 6 function-first sweep — batch 7a (ดอกเบี้ยตามตาราง — intrate table)
-- port (ทั้งหมด MISSING ใน PG):
--   pka_lon_intsrv.fp_intrate_table_loantype(text)              [INTSRV 1228]
--   pka_lon_intsrv.fp_intrate_table_loantype(text,ts)           [INTSRV 1231]
--   pka_lon_intsrv.fp_intrate_table_loantype(text,ts,numeric)   [INTSRV 1234] core
--   pka_lon_reqsrv.fp_calc_intrate(text)                        [REQSRV 3692]
-- รวม 58 calls (intrate_table_loantype 21 + calc_intrate 37) ใน repQuery rcTeller
--
-- engine เดิม = package-array pattern: fp_inttable_loantype BULK COLLECT ตาราง
--   sc_lon_m_int_step_rate เข้า collection itabrow_inttable (กรอง loan_type =
--   as_loantype หรือ loan_type IS NULL) → fp_intrate_table iterate collection 3 รอบ
--   (หา effective_date ล่าสุด<=req, หา loan_step ต่ำสุด>=req, หยิบ rate).
-- deviation (Legacy Fidelity): collapse package-array → single SQL (idiom
--   "package cache var → select ทุกครั้ง") ผลลัพธ์เท่ากันเป๊ะ:
--   - effective_date = max(effective_date) ที่ <= req  (loop เลือกตัวสุดท้าย=ล่าสุด)
--   - loan_step     = min(loan_step) ที่ >= req_step   (loop ascending + EXIT ตัวแรก)
--   - rate          = loan_interest_rate ณ (eff,step) นั้น; ไม่พบ → nvl(,0)=0
--   - spa_dberror(...) (logger) → ตัดทิ้ง คืน 0/null ตาม path เดิม
--   - i_approx_interest (package var ตั้งจากหน้าจอขอกู้) → report ไม่เคยตั้ง = 0
--       → ตัดสาขา `if i_approx_interest>0 return` ทิ้ง (ไม่มี package state ใน PG)
--   - number → numeric; char → text; date → timestamp; to_date(sysdate) → CURRENT_DATE
-- ============================================================================

-- ---- core 3-arg: อัตราดอกเบี้ยตามตาราง [INTSRV 1234 -> fp_intrate_table 1243] -
CREATE OR REPLACE FUNCTION pka_lon_intsrv.fp_intrate_table_loantype(
  as_loan_type text, adt_effective_date timestamp without time zone, adc_loan_step numeric)
RETURNS numeric LANGUAGE plpgsql STABLE AS $$
DECLARE
  ldt_eff  timestamp;
  ldc_step numeric;
  ldc_rate numeric;
BEGIN
  -- วันที่ประกาศใช้อัตราล่าสุด ก่อน/ถึง วันที่ req (loan_type ตรง หรือ NULL = ทุกประเภท)
  SELECT max(effective_date) INTO ldt_eff
    FROM sc_lon_m_int_step_rate
   WHERE (loan_type IS NULL OR loan_type = as_loan_type)
     AND effective_date <= adt_effective_date;
  IF ldt_eff IS NULL THEN RETURN 0; END IF;  -- E836 (logger) -> ไหลต่อจน rate=null->0

  -- ช่วงเงิน: loan_step ต่ำสุดที่ >= req_step (loop ascending + EXIT ตัวแรก)
  SELECT min(loan_step) INTO ldc_step
    FROM sc_lon_m_int_step_rate
   WHERE (loan_type IS NULL OR loan_type = as_loan_type)
     AND effective_date = ldt_eff
     AND loan_step >= adc_loan_step;
  IF ldc_step IS NULL THEN RETURN 0; END IF;  -- E851 (logger) -> rate=null->0

  -- อัตราดอกเบี้ย ณ (effective_date, loan_step)
  SELECT loan_interest_rate INTO ldc_rate
    FROM sc_lon_m_int_step_rate
   WHERE (loan_type IS NULL OR loan_type = as_loan_type)
     AND effective_date = ldt_eff
     AND loan_step = ldc_step
   LIMIT 1;

  RETURN coalesce(ldc_rate, 0);
EXCEPTION WHEN others THEN RETURN NULL;  -- spa_dberror('fp_intrate_table')
END;
$$;

-- ---- 2-arg: default loan_step = 0.01 [INTSRV 1231] ------------------------
CREATE OR REPLACE FUNCTION pka_lon_intsrv.fp_intrate_table_loantype(
  as_loan_type text, adt_effective_date timestamp without time zone)
RETURNS numeric LANGUAGE plpgsql STABLE AS $$
BEGIN
  RETURN pka_lon_intsrv.fp_intrate_table_loantype(as_loan_type, adt_effective_date, 0.01);
EXCEPTION WHEN others THEN RETURN NULL;
END;
$$;

-- ---- 1-arg: default effective_date = วันนี้ [INTSRV 1228] -----------------
CREATE OR REPLACE FUNCTION pka_lon_intsrv.fp_intrate_table_loantype(as_loan_type text)
RETURNS numeric LANGUAGE plpgsql STABLE AS $$
BEGIN
  RETURN pka_lon_intsrv.fp_intrate_table_loantype(as_loan_type, CURRENT_DATE::timestamp, 0.01);
EXCEPTION WHEN others THEN RETURN NULL;
END;
$$;

-- ---- fp_calc_intrate : ดอกเบี้ยตาราง + ดอกเบี้ยเพิ่มตอนขอกู้ [REQSRV 3692] --
CREATE OR REPLACE FUNCTION pka_lon_reqsrv.fp_calc_intrate(as_loantype text)
RETURNS numeric LANGUAGE plpgsql STABLE AS $$
DECLARE
  ldc_intrate numeric;
  ldc_intreq  numeric;
BEGIN
  -- (i_approx_interest package var ตัดทิ้ง — report ไม่เคยตั้ง ดู header)
  ldc_intrate := pka_lon_intsrv.fp_intrate_table_loantype(as_loantype);  -- ตารางดอกเบี้ย

  BEGIN
    SELECT increment_interest_rate INTO STRICT ldc_intreq
      FROM sc_lon_m_rule WHERE loan_type = as_loantype;
  EXCEPTION WHEN others THEN NULL; END;  -- E2639 (logger)

  RETURN ldc_intrate + coalesce(ldc_intreq, 0);  -- ดอกเบี้ยเพิ่มเมื่อขอกู้
EXCEPTION WHEN others THEN RETURN NULL;  -- spa_dberror('fp_calc_intrate')
END;
$$;
