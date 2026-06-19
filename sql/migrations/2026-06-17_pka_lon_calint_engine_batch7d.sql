-- ============================================================================
-- step 6 function-first sweep — batch 7d (เครื่องคำนวณดอกเบี้ย fp_calint — engine หนักสุด)
-- port (เดิมเป็น STUB `SELECT NULL` ใน PG — แทนที่ด้วยของจริง):
--   pka_lon_intsrv.fp_calint(text, ts)                                  [wrapper 2-arg] [INTSRV 357]
--   pka_lon_intsrv.fp_calint(text, ts, float8, ts, text)               [wrapper 5-arg] [INTSRV 357]
--   pka_lon_intsrv.fp_calint(text,text,float8,ts,ts,float8,text,text,bool) [engine 9-arg] [INTSRV 391]
-- new (deps ที่ต้อง port ร่วม):
--   pka_lon_intsrv.fp_round_loan(text, numeric, text)                  [INTSRV 688] ปัดเศษดอกเบี้ยตาม rule
--   pka_lon_intsrv._fp_calint_core(...)                                [collapse fp_calint_calculate+fp_calculate+fp_calint_nexteffect]
--
-- deps (มี body ใน PG แล้ว): fp_intrate_table_loantype / fp_intrate_table_conno (batch7a/7c),
--   fp_inttable_conno (batch7c), fp_round_decimal, pka_srv_datetime.fp_monthsafter
--
-- ── การ collapse (Legacy Fidelity — package-collection → stateless SQL) ──────
-- Oracle: fp_calint(9-arg) เลือกตารางดอกเบี้ย โหลดเข้า package-collection itabrow_inttable
--   (ผ่าน fp_inttable_fixRate/_conno/_loantype) แล้ว fp_calint_calculate → fp_calculate
--   วน segment โดย fp_calint_nexteffect หา boundary วันที่อัตราเปลี่ยน, fp_intrate_table
--   อ่าน rate จาก collection. ทั้งหมดยุบเป็น _fp_calint_core: ไม่มี collection — query
--   ตารางต้นทาง (sc_lon_m_int_step_rate / _conno) ตรง ผ่าน fp_intrate_table_* ที่ port แล้ว.
--
-- ค่าจริง PEAN ที่ทำให้ collapse ถูกต้อง + ตัด subtree ได้ (ตรวจ DB 2026-06-17):
--   • sc_lon_m_constant.day_in_year = 365 (>0, ล็อก) → fp_calculate/fp_nexteffect เข้า branch
--     "ai_daysinyear>0 → return ทันที" = ไม่มี logic ปีอธิกมาส/ข้ามปี → **ตัด leaf อธิกมาสทิ้งทั้งหมด**
--     (faithful: ถ้าวันไหน day_in_year=0 ค่อย port fp_daysinyear/fp_lastdayofyear เพิ่ม — ปัจจุบันไม่ใช้)
--   • day_count_method = '2' (งวดแรกนับหน้าหลัง ต่อไปนับหลัง) — port ครบทั้ง '2'/'1'/else
--   • interest_cal_method_code = '01' ทุก rule → 'D' (รายวัน). port 'M' (รายเดือน) ไว้ครบเช่นกัน
--   • calint_from_other = '0' ทุก rule → AOT 2-สเตป (Niorn 2024-08-18) **ไม่ถูกเรียก** แต่ port ไว้
--   • ไม่มีตาราง sc_lon_m_int_time_loan ใน PG → ข้าม fp_inttable_intTimeLoan (โปรโมชั่นคงที่ 3 ปี)
--     ไหลลง loantype-table ตรง = พฤติกรรมจริง PEAN (ไม่มีโปรโมชั่น). deviation: บันทึกไว้
--   • POT step-up (as_intstep_active='1', sp_intrate_steprate) — POT เท่านั้น, PEAN ไม่ใช้ → ตัด
--
-- idiom เดิมทุก batch:
--   • spa_dberror(...) = log อย่างเดียว ไม่ raise (design `exc when others then spa_dberror()` = swallow)
--     → ตัดทิ้ง: inner select-into handler = swallow (ค่าคง null ไหลต่อ) ; outer = RETURN NULL
--   • nvl/nvn → coalesce ; To_char(x,'…99.99') ปัด 2 ตำแหน่ง → round(x,2) ; number→numeric
--   • report เรียกผ่าน double precision (ตาม stub) → signature คง float8, คำนวณภายในเป็น numeric
--   • li_guard = กันลูปค้าง (เชิงป้องกัน — ไม่เกิดกับข้อมูลปกติ เพราะ boundary ก้าวหน้าเสมอ)
-- ============================================================================

-- ลบ stub เดิม (SELECT NULL) เฉพาะ 5-arg/9-arg (ไม่มี view ผูก) ก่อนสร้างของจริง
--   2-arg ห้าม DROP (view_deppaidloan / vr_deppaidloan ผูกอยู่) → ใช้ CREATE OR REPLACE
--   ด้านล่าง (stub ไม่มีชื่อ param → REPLACE ต้องไม่ใส่ชื่อ ใช้ $1/$2 ใน body)
DROP FUNCTION IF EXISTS pka_lon_intsrv.fp_calint(text, timestamp without time zone, double precision, timestamp without time zone, text);
DROP FUNCTION IF EXISTS pka_lon_intsrv.fp_calint(text, text, double precision, timestamp without time zone, timestamp without time zone, double precision, text, text, boolean);

-- ---- fp_round_loan : ปัดเศษดอกเบี้ยตามกฎประเภทเงินกู้ [INTSRV 688] ----------
CREATE OR REPLACE FUNCTION pka_lon_intsrv.fp_round_loan(
  as_loantype text, adc_intcal numeric, as_paytype text DEFAULT NULL)
RETURNS numeric LANGUAGE plpgsql STABLE AS $$
DECLARE
  lb_default boolean := false;
  ldc_round  numeric;
  ls_typeround text;
  ls_round_status text;
  ls_intreturn_round_status text; ldc_intreturn_round_method numeric; ls_intreturn_type_round_method text;
  ls_intmonth_round_status  text; ldc_intmonth_round_method  numeric; ls_intmonth_type_round_method  text;
  ls_decimal_type text;
  ldc_interest numeric;
BEGIN
  BEGIN
    SELECT intreturn_round_status, intreturn_round_method, intreturn_type_round_method,
           intmonth_round_status,  intmonth_round_method,  intmonth_type_round_method,
           decimal_type
      INTO STRICT ls_intreturn_round_status, ldc_intreturn_round_method, ls_intreturn_type_round_method,
           ls_intmonth_round_status, ldc_intmonth_round_method, ls_intmonth_type_round_method,
           ls_decimal_type
      FROM sc_lon_m_rule
     WHERE loan_type = as_loantype;
  EXCEPTION WHEN others THEN NULL;  -- spa_dberror E632 (logger, swallow)
  END;

  IF as_paytype = 'RI' THEN          -- ดอกเบี้ยคืน
    ls_round_status := ls_intreturn_round_status;
    ldc_round := ldc_intreturn_round_method;
    ls_typeround := ls_intreturn_type_round_method;
    IF ls_round_status = '1' THEN NULL; ELSE lb_default := true; END IF;
  ELSIF as_paytype = 'RM' THEN       -- ประมวลผล (รายเดือน)
    ls_round_status := ls_intmonth_round_status;
    ldc_round := ldc_intmonth_round_method;
    ls_typeround := ls_intmonth_type_round_method;
    IF ls_round_status = '1' THEN NULL; ELSE lb_default := true; END IF;
  ELSE
    lb_default := true;
  END IF;

  IF lb_default THEN
    IF length(trim(ls_decimal_type)) = 4 THEN
      ldc_round := to_number(substr(ls_decimal_type, 1, 3), '999') / 100;
      ls_typeround := substr(ls_decimal_type, 4, 1);
    ELSE
      ldc_round := 0;
      ls_typeround := '0';
    END IF;
  END IF;

  IF ldc_round > 0 THEN NULL; ELSE ldc_round := 0.01; END IF;

  ldc_interest := pka_lon_intsrv.fp_round_decimal(adc_intcal, ldc_round, ls_typeround);
  RETURN coalesce(ldc_interest, 0);
EXCEPTION WHEN others THEN RETURN NULL;  -- spa_dberror('fp_round_loan')
END;
$$;

-- ---- _fp_calint_core : แกนคำนวณ (collapse calculate+nexteffect, ไร้ collection) -
-- p_rate_src: 'FIX'=คงที่ p_fixedrate | 'CONNO'=ตารางรายสัญญา | 'LOANTYPE'=ตารางประเภทกู้
CREATE OR REPLACE FUNCTION pka_lon_intsrv._fp_calint_core(
  p_conno text, p_loantype text, p_principal numeric,
  p_bg date, p_en date, p_calinttype text,
  p_daysinyear int, p_fixedrate numeric, p_rate_src text)
RETURNS numeric LANGUAGE plpgsql STABLE AS $$
DECLARE
  ldt_cur  date;
  ldt_next date;
  ldc_rate numeric;
  ldc_daycount numeric;
  ldc_interest numeric := 0;
  li_diy   numeric;
  li_guard int := 0;
BEGIN
  IF p_principal IS NULL OR p_bg IS NULL OR p_en IS NULL THEN RETURN NULL; END IF;
  IF p_bg > p_en THEN RETURN 0; END IF;

  -- ───── รายเดือน (M) : segment เดียว, daysinyear=12 ─────
  IF p_calinttype = 'M' THEN
    ldc_rate := CASE p_rate_src
                  WHEN 'FIX'   THEN coalesce(p_fixedrate, 0)
                  WHEN 'CONNO' THEN pka_lon_intsrv.fp_intrate_table_conno(p_conno, p_bg::timestamp, p_principal)
                  ELSE              pka_lon_intsrv.fp_intrate_table_loantype(p_loantype, p_bg::timestamp, p_principal)
                END;
    ldc_daycount := pka_srv_datetime.fp_monthsafter(p_bg::timestamp, p_en::timestamp);
    IF ldc_daycount > 0 THEN
      ldc_interest := ldc_interest + round((p_principal * ldc_rate * ldc_daycount) / 12, 2);
    END IF;
    RETURN coalesce(ldc_interest, 0);
  END IF;

  -- ───── รายวัน (D) : วน segment ตาม boundary วันที่อัตราเปลี่ยน ─────
  ldt_cur := p_bg;
  LOOP
    li_guard := li_guard + 1;
    IF li_guard > 100000 THEN EXIT; END IF;  -- กันลูปค้าง (เชิงป้องกัน ไม่เกิดกับข้อมูลปกติ)

    -- หา boundary ถัดไป (fp_calint_nexteffect, ai_daysinyear>0 → ไม่มี logic ปีอธิกมาส)
    IF p_rate_src = 'FIX' THEN
      ldt_next := p_en;                      -- อัตราคงที่ ไม่มี boundary
    ELSIF p_rate_src = 'CONNO' THEN
      SELECT (min(effective_date))::date INTO ldt_next
        FROM (SELECT effective_date
                FROM sc_lon_m_int_step_rate_conno
               WHERE loan_contract_no = p_conno
                 AND effective_date >  ldt_cur::timestamp
                 AND effective_date <= p_en::timestamp
               GROUP BY effective_date
              HAVING max(loan_step) >= p_principal) q;
      IF ldt_next IS NULL THEN ldt_next := p_en; ELSE ldt_next := ldt_next - 1; END IF;
    ELSE  -- LOANTYPE
      SELECT (min(effective_date))::date INTO ldt_next
        FROM (SELECT effective_date
                FROM sc_lon_m_int_step_rate
               WHERE (loan_type = p_loantype OR loan_type IS NULL)
                 AND effective_date >  ldt_cur::timestamp
                 AND effective_date <= p_en::timestamp
               GROUP BY effective_date
              HAVING max(loan_step) >= p_principal) q;
      IF ldt_next IS NULL THEN ldt_next := p_en; ELSE ldt_next := ldt_next - 1; END IF;
    END IF;

    -- อัตรา ณ วันต้น segment
    ldc_rate := CASE p_rate_src
                  WHEN 'FIX'   THEN coalesce(p_fixedrate, 0)
                  WHEN 'CONNO' THEN pka_lon_intsrv.fp_intrate_table_conno(p_conno, ldt_cur::timestamp, p_principal)
                  ELSE              pka_lon_intsrv.fp_intrate_table_loantype(p_loantype, ldt_cur::timestamp, p_principal)
                END;

    li_diy := CASE WHEN p_daysinyear > 0 THEN p_daysinyear ELSE 365 END;  -- day_in_year ล็อก 365
    ldc_daycount := (ldt_next - ldt_cur) + 1;  -- นับวันสิ้นสุดด้วย
    IF ldc_daycount > 0 THEN
      ldc_interest := ldc_interest + round((p_principal * ldc_rate * ldc_daycount) / li_diy, 2);
    END IF;

    ldt_cur := ldt_next + 1;
    EXIT WHEN ldt_next >= p_en;
  END LOOP;

  RETURN coalesce(ldc_interest, 0);
EXCEPTION WHEN others THEN RETURN NULL;  -- spa_dberror('fp_calint_calculate'/'fp_calculate')
END;
$$;

-- ---- fp_calint (9-arg engine) [INTSRV 391] ---------------------------------
CREATE OR REPLACE FUNCTION pka_lon_intsrv.fp_calint(
  as_conno text, as_loan_type text, adc_principal double precision,
  adt_date_from timestamp without time zone, adt_date_to timestamp without time zone,
  adc_fixedrate double precision, as_paytype text,
  as_roundbath text DEFAULT '1', ab_firstpay boolean DEFAULT NULL)
RETURNS double precision LANGUAGE plpgsql STABLE AS $$
DECLARE
  ldt_begin date; ldt_end date;
  ldc_fixedrate numeric := 0;
  ls_loan_type  text;
  ls_int_method text;
  li_day_in_year int;
  ls_day_count_method text;
  ldtm_begin date;
  ldc_interest numeric := 0;
  ls_cfo text; ls_cflt text;          -- calint_from_other / calint_from_loan_type (AOT)
  ldc_shr numeric; adc_prin_step_2 numeric; ldc_int1 numeric; ldc_int2 numeric;
  v_src text; v_fixedrate numeric := 0;
  v_prin numeric;
BEGIN
  -- Validate (Oracle: spa_dberror=log; principal null ไหลต่อ; principal<=0 → 0)
  IF adc_principal IS NULL OR adt_date_from IS NULL OR adt_date_to IS NULL THEN
    NULL;  -- E86 (logger) — ไหลต่อ
  END IF;
  IF adc_principal <= 0 THEN RETURN 0; END IF;
  v_prin := adc_principal::numeric;

  -- ประเภทเงินกู้ (ถ้าไม่ส่งมา → จากสัญญา)
  IF trim(coalesce(as_loan_type, '')) = '' THEN
    BEGIN
      SELECT loan_type INTO STRICT ls_loan_type
        FROM sc_lon_m_contract WHERE loan_contract_no = as_conno;
    EXCEPTION WHEN others THEN NULL;  -- E98 logger
    END;
  ELSE
    ls_loan_type := as_loan_type;
  END IF;

  -- การนับวัน
  BEGIN
    SELECT day_count_method, day_in_year INTO STRICT ls_day_count_method, li_day_in_year
      FROM sc_lon_m_constant;
  EXCEPTION WHEN others THEN NULL;  -- E483 logger
  END;

  IF ls_day_count_method = '2' THEN          -- งวดแรกนับหน้าหลัง ต่อไปนับหลัง
    BEGIN
      SELECT begining_of_contract::date INTO STRICT ldtm_begin
        FROM sc_lon_m_contract WHERE loan_contract_no = as_conno;
    EXCEPTION
      WHEN no_data_found THEN ldtm_begin := adt_date_from::date;  -- KTM 2020-04-17
      WHEN others THEN NULL;                                       -- E469 logger
    END;
    IF ldtm_begin = adt_date_from::date THEN
      ldt_begin := adt_date_from::date;        -- งวดแรก: นับหน้าหลัง
    ELSE
      ldt_begin := adt_date_from::date + 1;     -- ต่อไป: นับหลัง
    END IF;
    ldt_end := adt_date_to::date;
  ELSIF ls_day_count_method = '1' THEN          -- นับหลัง
    ldt_begin := adt_date_from::date + 1;
    ldt_end   := adt_date_to::date;
  ELSE                                          -- นับหน้า
    ldt_begin := adt_date_from::date;
    ldt_end   := adt_date_to::date - 1;
  END IF;

  -- เลือกแหล่งอัตราดอกเบี้ย (fixRate > conno-table > loantype-table)
  IF adc_fixedrate > 0 THEN
    v_src := 'FIX'; v_fixedrate := adc_fixedrate::numeric;
  ELSE
    IF trim(coalesce(as_conno, '')) <> '' THEN
      BEGIN
        SELECT coalesce(fixed_interest_rate, 0) INTO STRICT ldc_fixedrate
          FROM sc_lon_m_loan_card WHERE loan_contract_no = as_conno;
      EXCEPTION WHEN others THEN NULL;  -- E176 logger
      END;
      IF ldc_fixedrate > 0 THEN
        v_src := 'FIX'; v_fixedrate := ldc_fixedrate;
      ELSIF pka_lon_intsrv.fp_inttable_conno(as_conno) > 0 THEN
        v_src := 'CONNO';
      ELSE
        v_src := 'LOANTYPE';   -- ข้าม intTimeLoan (ไม่มีตาราง promo ใน PG) → loantype ตรง
      END IF;
    ELSE
      IF trim(coalesce(ls_loan_type, '')) <> '' THEN
        v_src := 'LOANTYPE';
      ELSE
        v_src := 'FIX'; v_fixedrate := 0;   -- fp_inttable_fixRate(0)
      END IF;
    END IF;
  END IF;

  -- วิธีคำนวณ (รายวัน/รายเดือน) + AOT flag
  BEGIN
    SELECT interest_cal_method_code, calint_from_other, calint_from_loan_type
      INTO STRICT ls_int_method, ls_cfo, ls_cflt
      FROM sc_lon_m_rule WHERE loan_type = ls_loan_type;
  EXCEPTION WHEN others THEN NULL;  -- E593 logger
  END;
  IF ls_int_method = '01' THEN ls_int_method := 'D'; ELSE ls_int_method := 'M'; END IF;
  ldc_fixedrate := coalesce(ldc_fixedrate, 0);

  -- คำนวณ
  IF ls_cfo = '1' THEN
    -- AOT 2-สเตป (Niorn 2024-08-18) — แบ่งมูลค่าหุ้นค้ำ (อ้างอิงประเภทอื่น) + หนี้คงเหลือ (ประเภทจริง)
    -- หมายเหตุ: PEAN ทุก rule calint_from_other='0' → branch นี้ยังไม่ถูกใช้จริง (port ไว้เผื่อ)
    BEGIN
      SELECT used_amount INTO STRICT ldc_shr
        FROM sc_lon_m_contract_coll
       WHERE collateral_type_code = '02' AND status = '0' AND loan_contract_no = as_conno;
    EXCEPTION WHEN others THEN NULL;  -- E242 logger
    END;
    IF ldc_shr > v_prin THEN ldc_shr := v_prin; END IF;
    adc_prin_step_2 := v_prin - ldc_shr;
    -- step1: อัตราตามประเภทอ้างอิง (mode '0' = loantype-table หรือ fix ถ้า ldc_fixedrate>0)
    ldc_int1 := pka_lon_intsrv._fp_calint_core(as_conno, ls_cflt, ldc_shr,
                  ldt_begin, ldt_end, ls_int_method, li_day_in_year, ldc_fixedrate,
                  CASE WHEN ldc_fixedrate > 0 THEN 'FIX' ELSE 'LOANTYPE' END);
    -- step2: อัตราตามประเภทจริง
    ldc_int2 := pka_lon_intsrv._fp_calint_core(as_conno, ls_loan_type, adc_prin_step_2,
                  ldt_begin, ldt_end, ls_int_method, li_day_in_year, ldc_fixedrate,
                  CASE WHEN ldc_fixedrate > 0 THEN 'FIX' ELSE 'LOANTYPE' END);
    ldc_interest := coalesce(ldc_int1, 0) + coalesce(ldc_int2, 0);
  ELSE
    ldc_interest := pka_lon_intsrv._fp_calint_core(as_conno, ls_loan_type, v_prin,
                      ldt_begin, ldt_end, ls_int_method, li_day_in_year, v_fixedrate, v_src);
  END IF;

  -- ปัดเศษ
  IF ldc_interest > 0 THEN
    IF as_roundbath IS NULL OR as_roundbath <> '0' THEN
      ldc_interest := pka_lon_intsrv.fp_round_loan(ls_loan_type, ldc_interest, as_paytype);
    END IF;
  END IF;

  RETURN coalesce(ldc_interest, 0)::double precision;
EXCEPTION WHEN others THEN RETURN NULL;  -- spa_dberror outer
END;
$$;

-- ---- fp_calint (wrapper 3/4/5-arg) [INTSRV 357] ---------------------------
-- report เรียก 4-arg (conno,date,prin,from) / 5-arg (+paytype) ; 2-arg แยกด้านล่าง
-- ⚠ adc_principal ไม่ใส่ DEFAULT — กันชนกับ overload 2-arg (เรียก 2 อาร์กิวเมนต์ →
--   match แค่ตัว 2-arg). adt_date_from/paytype มี DEFAULT (ครอบ 3/4-arg)
-- ดึง loan_type/balance/last_calcint_date/fixed_rate จากสัญญา
CREATE OR REPLACE FUNCTION pka_lon_intsrv.fp_calint(
  as_conno text, adt_date_to timestamp without time zone,
  adc_principal double precision,
  adt_date_from timestamp without time zone DEFAULT NULL,
  as_paytype text DEFAULT 'PL')
RETURNS double precision LANGUAGE plpgsql STABLE AS $$
DECLARE
  ls_loan_type text;
  ldc_balance  numeric;
  ldt_from     timestamp;
  ldc_fixed    numeric;
BEGIN
  BEGIN
    SELECT loan_type, principal_balance, last_calcint_date, fixed_interest_rate
      INTO STRICT ls_loan_type, ldc_balance, ldt_from, ldc_fixed
      FROM sc_lon_m_loan_card WHERE loan_contract_no = as_conno;
  EXCEPTION WHEN others THEN NULL;  -- E368 logger
  END;

  IF adc_principal >= 0 THEN ldc_balance := adc_principal::numeric; END IF;  -- เงินต้นหักกลบ
  IF adt_date_from IS NOT NULL THEN ldt_from := adt_date_from; END IF;       -- คิดจากวันที่ระบุ

  RETURN pka_lon_intsrv.fp_calint(
    as_conno, ls_loan_type, ldc_balance::double precision, ldt_from, adt_date_to,
    coalesce(ldc_fixed, 0)::double precision, as_paytype, '1', NULL);
EXCEPTION WHEN others THEN RETURN NULL;  -- spa_dberror outer
END;
$$;

-- ---- fp_calint (entry 2-arg) [INTSRV 357] ---------------------------------
-- report เรียก fp_calint(conno, date) ; view_deppaidloan / vr_deppaidloan ผูกอยู่
-- → CREATE OR REPLACE (ห้าม DROP). stub เดิมไม่มีชื่อ param → ใช้ $1/$2 (conno,date_to)
-- delegate ไป wrapper ด้วย principal=-1 (ใช้ยอดคงเหลือจากการ์ด), from=null, paytype='PL'
CREATE OR REPLACE FUNCTION pka_lon_intsrv.fp_calint(text, timestamp without time zone)
RETURNS double precision LANGUAGE plpgsql STABLE AS $$
BEGIN
  RETURN pka_lon_intsrv.fp_calint($1, $2, (-1)::double precision, NULL::timestamp, 'PL');
END;
$$;
