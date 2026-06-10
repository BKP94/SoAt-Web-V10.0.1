-- ============================================================================
-- 2026-06-10_pka_valuechange_sctelnewbma.sql
-- migrate Oracle package function ที่ ValueChanged ของ sctelnewbma เรียก แต่ยังไม่มีใน PG
--   source: C:\SoAt_PEAN\Admin\Export\PACKAGE_BODY\ (PKA_ELECTION / PKA_MEM_CTL /
--           PKA_LON_REQSRV / PKA_LON_INTSRV / PKA_SHR / PKA_MEM_MSGALERT)
--
-- ฟังก์ชันที่ migrate (เรียงตาม dependency):
--   pka_lon_reqsrv.fp_calc_install_m_live(timestamp)  → เดือนที่มีชีวิต (วันเกิด→อายุ, Group B)
--   pka_election.fp_help_election(varchar)            → กลุ่มช่วยเลือกตั้ง (Group B)
--   pka_shr.fp_unitprice()                            → มูลค่าหุ้นต่อหน่วย (default 10)
--   pka_lon_intsrv.fp_round_decimal(num,num,char)     → ปัดเศษ (+ ขึ้น / - ลง / อื่น = ปัดใกล้)
--   pka_mem_ctl.fp_get_shrsendpermonth_percent/_step/_appdate
--   pka_mem_ctl.fp_get_share_sendpermonth_min/_max (char,num) + overload (num)
--   pka_mem_ctl.fp_get_share_sendpermonth(num)        → คำนวณหุ้นจากเงินเดือน (Group D)
--   pka_mem_msgalert.fp_msg(char)                     → STUB '' (ดูหมายเหตุท้ายไฟล์)
--
-- การแปลง Oracle→PG: spa_dberror→RAISE/return, nvl→coalesce, sysdate→current_date,
--   rownum=1 order by→ORDER BY ... LIMIT 1, no_data_found→IF NOT FOUND
-- idempotent: CREATE SCHEMA IF NOT EXISTS + CREATE OR REPLACE FUNCTION (รันซ้ำได้)
-- ============================================================================

CREATE SCHEMA IF NOT EXISTS pka_election;
CREATE SCHEMA IF NOT EXISTS pka_shr;
CREATE SCHEMA IF NOT EXISTS pka_mem_ctl;
CREATE SCHEMA IF NOT EXISTS pka_mem_msgalert;
CREATE SCHEMA IF NOT EXISTS pka_lon_intsrv;
CREATE SCHEMA IF NOT EXISTS pka_lon_reqsrv;

-- ── pka_lon_reqsrv.fp_calc_install_m_live — เดือนที่มีชีวิต (จากวันเกิด ถึงวันนี้) ────────
-- legacy: return pka_srv_datetime.fp_monthsafter(birth, sysdate)
-- ใช้คู่กับ fp_calc_agetext(integer) ที่มีอยู่แล้ว → ข้อความอายุ
CREATE OR REPLACE FUNCTION pka_lon_reqsrv.fp_calc_install_m_live(adt_birth timestamp without time zone)
RETURNS integer LANGUAGE plpgsql AS $$
BEGIN
  IF adt_birth IS NULL THEN RETURN 0; END IF;
  RETURN pka_srv_datetime.fp_monthsafter(adt_birth, CURRENT_DATE::timestamp);
EXCEPTION WHEN OTHERS THEN RETURN NULL;
END;
$$;

-- ── pka_srv_datetime.fp_monthsafter — จำนวนเดือนระหว่าง 2 วัน (เดิมใน PG เป็น stub SELECT NULL) ──
-- legacy: TRUNC(MONTHS_BETWEEN(end, begin), 0) = เดือนเต็มที่ผ่านไป → ใช้ age() ของ PG ให้ผลตรงกัน
CREATE OR REPLACE FUNCTION pka_srv_datetime.fp_monthsafter(
    adt_begin timestamp without time zone, adt_end timestamp without time zone)
RETURNS integer LANGUAGE plpgsql AS $$
DECLARE iv interval;
BEGIN
  IF adt_begin IS NULL OR adt_end IS NULL THEN RETURN NULL; END IF;
  iv := age(adt_end, adt_begin);
  RETURN (date_part('year', iv) * 12 + date_part('month', iv))::int;
EXCEPTION WHEN OTHERS THEN RETURN NULL;
END;
$$;

-- ── pka_lon_reqsrv.fp_calc_agetext — จำนวนเดือน → "X ปี Y เดือน" (เดิมใน PG เป็น stub) ──────
-- overload 4-arg = logic จริง, overload 1-arg = เรียก 4-arg ด้วย format ปี/เดือนเริ่มต้น
CREATE OR REPLACE FUNCTION pka_lon_reqsrv.fp_calc_agetext(
    ai_monthterm integer, as_fyear text, as_mformat text, as_round_month text)
RETURNS text LANGUAGE plpgsql AS $$
DECLARE
  li_year    int;
  li_month   int;
  ls_agetext varchar := '';
BEGIN
  li_year  := trunc(ai_monthterm / 12.0);
  li_month := mod(ai_monthterm, 12);

  IF as_round_month = '1' THEN          -- ปัดเศษเดือน(>=6) เป็นปี
    IF li_month >= 6 THEN li_year := li_year + 1; END IF;
  END IF;

  IF li_year  <> 0 THEN ls_agetext := ls_agetext || replace(as_fyear,  'Y', li_year::text);  END IF;
  IF li_month <> 0 THEN ls_agetext := ls_agetext || replace(as_mformat, 'M', li_month::text); END IF;

  IF ls_agetext IS NULL OR length(trim(ls_agetext)) = 0 THEN ls_agetext := '<>'; END IF;
  RETURN ls_agetext;
EXCEPTION WHEN OTHERS THEN RETURN NULL;
END;
$$;

CREATE OR REPLACE FUNCTION pka_lon_reqsrv.fp_calc_agetext(ai_monthterm integer)
RETURNS text LANGUAGE plpgsql AS $$
BEGIN
  RETURN pka_lon_reqsrv.fp_calc_agetext(ai_monthterm, 'Y ปี', ' M เดือน', '0');
EXCEPTION WHEN OTHERS THEN RETURN NULL;
END;
$$;

-- ── pka_election.fp_help_election — หากลุ่มช่วยเลือกตั้งที่สมาชิกน้อยสุด ───────────────────
CREATE OR REPLACE FUNCTION pka_election.fp_help_election(as_groupno varchar)
RETURNS varchar LANGUAGE plpgsql AS $$
DECLARE
  ls_help varchar;
  r record;
BEGIN
  BEGIN
    SELECT election_help INTO ls_help
    FROM sc_mem_m_ucf_member_group
    WHERE member_group_no = as_groupno;
  EXCEPTION WHEN OTHERS THEN ls_help := '00';
  END;
  IF ls_help IS NULL THEN ls_help := '00'; END IF;

  -- ไม่กำหนด / ไม่มีสิทธิ → คืนตรงๆ
  IF ls_help = '090000' THEN RETURN '090000'; END IF;
  IF ls_help = '999999' THEN RETURN '999999'; END IF;

  -- หากลุ่มที่จำนวนสมาชิก (มสามัญ) น้อยที่สุด
  FOR r IN
    SELECT eg.election_group AS election_group
    FROM sc_mem_m_membership_registered mr, sc_mem_m_ucf_election_group eg
    WHERE mr.election_group = eg.election_group
      AND mr.mem_type = '01'
      AND eg.election_help = ls_help
    GROUP BY eg.election_group
    ORDER BY count(mr.membership_no), eg.election_group
  LOOP
    RETURN r.election_group;
  END LOOP;

  RETURN ls_help;
END;
$$;

-- ── pka_shr.fp_unitprice — มูลค่าหุ้นต่อหน่วย (default 10) ────────────────────────────────
CREATE OR REPLACE FUNCTION pka_shr.fp_unitprice()
RETURNS numeric LANGUAGE plpgsql AS $$
DECLARE ldc numeric;
BEGIN
  SELECT share_value_perunit INTO ldc FROM sc_share_m_constant;
  IF ldc IS NULL OR ldc = 0 THEN ldc := 10; END IF;
  RETURN ldc;
EXCEPTION WHEN OTHERS THEN RETURN 10;
END;
$$;

-- ── pka_lon_intsrv.fp_round_decimal — ปัดเศษตามสถานะ (+ ขึ้น / - ลง / อื่น = ปัดเข้าใกล้) ──
CREATE OR REPLACE FUNCTION pka_lon_intsrv.fp_round_decimal(adc_dec numeric, adc_round numeric, as_status char)
RETURNS numeric LANGUAGE plpgsql AS $$
DECLARE
  ldc_return  numeric;
  ldc_decfull numeric;
  ldc_decover numeric;
BEGIN
  IF adc_dec   IS NULL OR adc_dec   <= 0 THEN RETURN adc_dec; END IF;
  IF adc_round IS NULL OR adc_round <= 0 THEN RETURN adc_dec; END IF;

  ldc_decover := mod(adc_dec, adc_round);
  IF ldc_decover > 0 THEN
    ldc_decfull := adc_dec - ldc_decover;
    CASE as_status
      WHEN '+' THEN ldc_return := ldc_decfull + adc_round;
      WHEN '-' THEN ldc_return := ldc_decfull;
      ELSE
        IF ldc_decover >= (adc_round / 2) THEN ldc_return := ldc_decfull + adc_round;
        ELSE ldc_return := ldc_decfull; END IF;
    END CASE;
  ELSE
    ldc_return := adc_dec;
  END IF;

  RETURN COALESCE(ldc_return, 0);
EXCEPTION WHEN OTHERS THEN RETURN NULL;
END;
$$;

-- ── pka_mem_ctl: ช่วงการส่งหุ้น (เปอร์เซ็น / จำนวนหุ้น / ตามวันที่อนุมัติ) ─────────────────
CREATE OR REPLACE FUNCTION pka_mem_ctl.fp_get_shrsendpermonth_percent(adc_salary numeric)
RETURNS numeric LANGUAGE plpgsql AS $$
DECLARE ldc numeric;
BEGIN
  SELECT (adc_salary * (percent_share_rate / 100)) INTO ldc
  FROM sc_mem_m_share_send_month
  WHERE salary_before <= adc_salary AND salary_until >= adc_salary;
  IF NOT FOUND THEN ldc := 0; END IF;
  RETURN COALESCE(ldc, 0);
END;
$$;

CREATE OR REPLACE FUNCTION pka_mem_ctl.fp_get_shrsendpermonth_step(adc_salary numeric)
RETURNS numeric LANGUAGE plpgsql AS $$
DECLARE ldc numeric; ldc_unit numeric;
BEGIN
  ldc_unit := pka_shr.fp_unitprice();
  SELECT (monthly_share_amount * ldc_unit) INTO ldc
  FROM sc_mem_m_share_send_month
  WHERE salary_before <= adc_salary AND salary_until >= adc_salary;
  IF NOT FOUND THEN ldc := 0; END IF;
  RETURN COALESCE(ldc, 0);
END;
$$;

CREATE OR REPLACE FUNCTION pka_mem_ctl.fp_get_shrsendpermonth_appdate(adt_approve date, adc_salary numeric)
RETURNS numeric LANGUAGE plpgsql AS $$
DECLARE ldc numeric;
BEGIN
  SELECT (adc_salary * (percent_share_rate / 100)) INTO ldc
  FROM sc_mem_m_share_send_month
  WHERE approve_date <= adt_approve
  ORDER BY approve_date DESC
  LIMIT 1;
  IF NOT FOUND THEN RETURN 0; END IF;
  RETURN ldc;
END;
$$;

-- ส่งหุ้นอย่างต่ำ — ตาม sc_cnt_m_coop.send_share_status (0=ตามตารางจำนวนหุ้น / 1=% เงินเดือน /
--   2=% ตามตาราง / 3=หลายลักษณะ / 4=ตามวันอนุมัติ / 9=เท่าเงินเดือน)
CREATE OR REPLACE FUNCTION pka_mem_ctl.fp_get_share_sendpermonth_min(as_memno char, adc_salary numeric)
RETURNS numeric LANGUAGE plpgsql AS $$
DECLARE
  ldc_monthly_share numeric;
  ls_round_monthly  char;
  ls_send_status    char;
  ldc_percent_share numeric;
  ldc_share_percent numeric;
  ldc_share_step    numeric;
  ls_cal_permit     char;
  ldt_approve       date;
BEGIN
  SELECT send_share_status, percent_share INTO ls_send_status, ldc_percent_share FROM sc_cnt_m_coop;

  CASE ls_send_status
    WHEN '1' THEN
      IF ldc_percent_share > 0 THEN ldc_monthly_share := adc_salary * ldc_percent_share; END IF;
    WHEN '9' THEN
      ldc_monthly_share := adc_salary;
    WHEN '2' THEN
      ldc_monthly_share := pka_mem_ctl.fp_get_shrsendpermonth_percent(adc_salary);
    WHEN '3' THEN
      SELECT cal_permit_style INTO ls_cal_permit
      FROM sc_mem_m_share_send_month
      WHERE salary_before <= adc_salary AND salary_until >= adc_salary;
      IF NOT FOUND THEN RETURN 0; END IF;
      ldc_share_step    := pka_mem_ctl.fp_get_shrsendpermonth_step(adc_salary);
      ldc_share_percent := pka_mem_ctl.fp_get_shrsendpermonth_percent(adc_salary);
      CASE ls_cal_permit
        WHEN '1' THEN   -- เลือกค่าที่น้อย
          IF ldc_share_step < ldc_share_percent THEN ldc_monthly_share := ldc_share_step;
          ELSE ldc_monthly_share := ldc_share_percent; END IF;
        WHEN '2' THEN   -- เลือกค่าที่มาก
          IF ldc_share_step > ldc_share_percent THEN ldc_monthly_share := ldc_share_step;
          ELSE ldc_monthly_share := ldc_share_percent; END IF;
        ELSE            -- '0' รวมกัน
          ldc_monthly_share := ldc_share_step + ldc_share_percent;
      END CASE;
    WHEN '4' THEN
      SELECT approve_date INTO ldt_approve FROM sc_mem_m_membership_registered WHERE membership_no = as_memno;
      ldc_monthly_share := pka_mem_ctl.fp_get_shrsendpermonth_appdate(ldt_approve, adc_salary);
    ELSE              -- '0' ตามตารางจำนวนหุ้น
      ldc_monthly_share := pka_mem_ctl.fp_get_shrsendpermonth_step(adc_salary);
  END CASE;

  -- ปัดเศษค่าหุ้น (round_monthly: + ขึ้น / - ลง / 0 ปัดใกล้)
  SELECT round_monthly INTO ls_round_monthly FROM sc_share_m_constant;
  ldc_monthly_share := pka_lon_intsrv.fp_round_decimal(ldc_monthly_share, 10, ls_round_monthly);

  RETURN ldc_monthly_share;
END;
$$;

CREATE OR REPLACE FUNCTION pka_mem_ctl.fp_get_share_sendpermonth_min(adc_salary numeric)
RETURNS numeric LANGUAGE plpgsql AS $$
BEGIN RETURN pka_mem_ctl.fp_get_share_sendpermonth_min(NULL::char, adc_salary); END;
$$;

-- ส่งหุ้นสูงสุด — ไม่เกิน % เงินเดือน, ไม่เกิน over_share_gain, (ตามอายุสมาชิก = เฉพาะ memno)
CREATE OR REPLACE FUNCTION pka_mem_ctl.fp_get_share_sendpermonth_max(as_memno char, adc_salary numeric)
RETURNS numeric LANGUAGE plpgsql AS $$
DECLARE
  ldc_monthly_share          numeric;
  ldc_over_share_gain        numeric;
  ldc_max_monthly_per_salary numeric;
  ldc_max_share_salalry      numeric;
  li_mem_age                 int;
BEGIN
  SELECT max_monthly_per_salary INTO ldc_max_monthly_per_salary FROM sc_share_m_constant;
  IF ldc_max_monthly_per_salary > 0 THEN
    ldc_monthly_share := ldc_max_monthly_per_salary * adc_salary;
  END IF;

  SELECT over_share_gain INTO ldc_over_share_gain FROM sc_cnt_m_coop;
  IF ldc_monthly_share > ldc_over_share_gain AND ldc_over_share_gain > 0 THEN
    ldc_monthly_share := ldc_over_share_gain;
  END IF;

  -- ตารางอายุการเป็นสมาชิก: ต้องใช้ pka_lon_reqsrv.fp_calc_install_m_age (ยังไม่ migrate)
  -- caller จาก sctelnewbma ส่ง memno = NULL เสมอ → branch นี้เป็น dead path (ไม่ถูกเรียก)
  IF trim(as_memno) IS NOT NULL THEN
    li_mem_age := pka_lon_reqsrv.fp_calc_install_m_age(as_memno);
    IF li_mem_age > 0 THEN
      BEGIN
        SELECT max_share_salalry INTO ldc_max_share_salalry
        FROM sc_mem_m_share_send_memage th
        WHERE mem_age = (SELECT max(mem_age) FROM sc_mem_m_share_send_memage td WHERE td.mem_age <= li_mem_age);
      EXCEPTION WHEN OTHERS THEN ldc_max_share_salalry := 0;
      END;
      IF ldc_max_share_salalry > 0 AND ldc_monthly_share > ldc_max_share_salalry * adc_salary THEN
        ldc_monthly_share := ldc_max_share_salalry * adc_salary;
      END IF;
    END IF;
  END IF;

  -- ปัดเข้าหามูลค่าหุ้น (ปัดขึ้น)
  ldc_monthly_share := pka_lon_intsrv.fp_round_decimal(ldc_monthly_share, pka_shr.fp_unitprice(), '+');
  RETURN COALESCE(ldc_monthly_share, 0);
END;
$$;

CREATE OR REPLACE FUNCTION pka_mem_ctl.fp_get_share_sendpermonth_max(adc_salary numeric)
RETURNS numeric LANGUAGE plpgsql AS $$
BEGIN RETURN pka_mem_ctl.fp_get_share_sendpermonth_max(NULL::char, adc_salary); END;
$$;

-- ── pka_mem_ctl.fp_get_share_sendpermonth — หุ้นที่ควรส่ง (min, แต่ไม่เกิน max) ────────────
CREATE OR REPLACE FUNCTION pka_mem_ctl.fp_get_share_sendpermonth(adc_salary numeric)
RETURNS numeric LANGUAGE plpgsql AS $$
DECLARE
  ldc_monthshare     numeric := 0;
  ldc_monthshare_max numeric := 0;
BEGIN
  IF adc_salary IS NULL OR adc_salary <= 0 THEN RETURN 0; END IF;
  ldc_monthshare     := pka_mem_ctl.fp_get_share_sendpermonth_min(NULL::char, adc_salary);
  ldc_monthshare_max := pka_mem_ctl.fp_get_share_sendpermonth_max(NULL::char, adc_salary);
  IF ldc_monthshare_max > 0 AND ldc_monthshare > ldc_monthshare_max THEN
    ldc_monthshare := ldc_monthshare_max;
  END IF;
  RETURN COALESCE(ldc_monthshare, 0);
END;
$$;

-- ── pka_mem_msgalert.fp_msg — STUB ───────────────────────────────────────────────────────
-- ฟังก์ชันเต็มรวม sub-function ~25 ตัว (fp_msg_member_own/_loan_*/_aml/...) + อ้างอีกหลาย
-- package/table → เป็นการ migrate ทั้ง package PKA_MEM_MSGALERT (out of scope งานนี้)
-- ผู้เรียกในหน้า sctelnewbma คือ sc.scCoop.ofFormat (ผ่าน ofParse) ซึ่ง "ทิ้ง" ค่าที่คืน
-- (ofParse ใช้แค่ pad zero + validate ว่ามีทะเบียน) → คืน '' จึงปลอดภัยและปลดบล็อก Group E
-- TODO(PL): แทนที่ด้วย logic เต็มจาก C:\SoAt_PEAN\Admin\Export\PACKAGE_BODY\PKA_MEM_MSGALERT.sql
CREATE OR REPLACE FUNCTION pka_mem_msgalert.fp_msg(as_memno char)
RETURNS varchar LANGUAGE plpgsql AS $$
BEGIN RETURN ''; END;
$$;
