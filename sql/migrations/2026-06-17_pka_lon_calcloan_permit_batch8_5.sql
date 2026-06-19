-- ============================================================================
-- step 6 function-first sweep — batch 8.5 (ยอดประกัน/สวัสดิการ + คืนหุ้น TGE)
-- port (ทั้งหมด MISSING ใน PG):
--   pka_lon_calcloan_permit.fp_get_welf_amount(text,date)      [1] สวัสดิการเสียชีวิต
--   pka_lon_calcloan_permit.fp_get_insur_skk(text,date)        [1] ประกัน สสก. (flag 200k)
--   pka_lon_calcloan_permit.fp_get_insur_skk_amount(text,date) [1] ยอดเงิน สสก.จริง
--   pka_lon_calcloan_permit.fp_get_insur_chomrom(text,date)    [1] ประกันชมรม จนท. (300k)
--   pka_lon_reqfee.fp_tge_calc_replace_share_return(text,text) [1] คืนหุ้นค้ำ (TGE)
--
-- deps (มี body ใน PG แล้ว): pka_lon_reqsrv.fp_calc_install_m_age(text,timestamp),
--   pka_lon_intsrv.fp_round_decimal(numeric,numeric,char)
--
-- deviation (Legacy Fidelity):
--  - spa_dberror(...) (logger) -> ตัดทิ้ง คืน NULL ตาม path เดิม (handler outer มี return->null)
--  - number -> numeric ; int/pls_integer -> int ; char/varchar2 -> text ; date -> date
--  - nvl/nvn(...) -> coalesce(...,0)
--  - fp_calc_install_m_age รับ timestamp -> ส่ง adt_req_date::timestamp
--  - fp_round_decimal arg3: Oracle ส่ง numeric 0 แต่ PG param เป็น char -> ส่ง '0' (เทียบเท่า)
--  - fp_get_insur_chomrom: select group_control ไม่มี handler ภายใน Oracle -> INTO STRICT
--      (raise NO_DATA_FOUND เมื่อไม่พบ -> outer handler -> RETURN NULL ตรงพฤติกรรม Oracle)
--  - fp_tge_calc_replace_share_return: **body จริงใน legacy = `return 0;`** ที่เหลือ comment
--      ทิ้งทั้งหมด -> port เป็น RETURN 0 (TGE coop เท่านั้น, PEAN ไม่ใช้)
-- ============================================================================

CREATE SCHEMA IF NOT EXISTS pka_lon_calcloan_permit;

-- ---- fp_get_welf_amount : สวัสดิการสมาชิกเสียชีวิต [@2319] -----------------
-- อายุสมาชิก >= 6 เดือน -> ปีละ 10,000 (cap 200,000)
CREATE OR REPLACE FUNCTION pka_lon_calcloan_permit.fp_get_welf_amount(as_memno text, adt_req_date date)
RETURNS numeric LANGUAGE plpgsql STABLE AS $$
DECLARE
  ldc_insur_amount numeric := 0;
  li_mem_age_month int;
  li_mem_age       int;
  ldc_fund_amount  numeric := 0;
BEGIN
  li_mem_age_month := pka_lon_reqsrv.fp_calc_install_m_age(as_memno, adt_req_date::timestamp);
  li_mem_age := pka_lon_intsrv.fp_round_decimal(li_mem_age_month::numeric / 12, 1, '0');

  IF li_mem_age_month >= 6 THEN
    ldc_fund_amount := li_mem_age * 10000;
    IF ldc_fund_amount > 200000 THEN ldc_fund_amount := 200000; END IF;
  END IF;

  ldc_insur_amount := coalesce(ldc_insur_amount, 0) + coalesce(ldc_fund_amount, 0);
  RETURN coalesce(ldc_insur_amount, 0);
EXCEPTION WHEN others THEN RETURN NULL;  -- spa_dberror
END;
$$;

-- ---- fp_get_insur_skk : เงินสงเคราะห์เสียชีวิต สสก. (flag 200k) [@2371] ----
CREATE OR REPLACE FUNCTION pka_lon_calcloan_permit.fp_get_insur_skk(as_memno text, adt_req_date date)
RETURNS numeric LANGUAGE plpgsql STABLE AS $$
DECLARE
  ldc_crm_amount numeric := 0;
  li_count_crem  int;
  li_year  int;
  li_month int;
BEGIN
  li_year  := extract(year  from adt_req_date);
  li_month := extract(month from adt_req_date);

  SELECT count(*) INTO li_count_crem
    FROM sc_kep_t_monthly_receive_det
   WHERE membership_no = as_memno
     AND keeping_type_code LIKE 'CM%'
     AND receive_year  = li_year
     AND receive_month = li_month;

  IF li_count_crem > 0 THEN ldc_crm_amount := 200000; END IF;

  RETURN coalesce(0 + coalesce(ldc_crm_amount, 0), 0);
EXCEPTION WHEN others THEN RETURN NULL;  -- spa_dberror
END;
$$;

-- ---- fp_get_insur_skk_amount : ยอดเงิน สสก. จริง [@2415] ------------------
CREATE OR REPLACE FUNCTION pka_lon_calcloan_permit.fp_get_insur_skk_amount(as_memno text, adt_req_date date)
RETURNS numeric LANGUAGE plpgsql STABLE AS $$
DECLARE
  ldc_insur_amount numeric := 0;
  li_year  int;
  li_month int;
BEGIN
  li_year  := extract(year  from adt_req_date);
  li_month := extract(month from adt_req_date);

  SELECT sum(money_amount) INTO ldc_insur_amount
    FROM sc_kep_t_monthly_receive_det
   WHERE membership_no = as_memno
     AND keeping_type_code IN ('CM', 'CM01')  -- BEER 04/2568 เป็น CM ก่อนหน้า CM01
     AND receive_year  = li_year
     AND receive_month = li_month;

  RETURN coalesce(ldc_insur_amount, 0);
EXCEPTION WHEN others THEN RETURN NULL;  -- spa_dberror
END;
$$;

-- ---- fp_get_insur_chomrom : ประกันชมรม จนท. (group_control '009' -> 300k) [@2451]
CREATE OR REPLACE FUNCTION pka_lon_calcloan_permit.fp_get_insur_chomrom(as_memno text, adt_req_date date)
RETURNS numeric LANGUAGE plpgsql STABLE AS $$
DECLARE
  ls_grp_control text;
  ldc_chomrom    numeric := 0;
BEGIN
  SELECT grp.member_group_control INTO STRICT ls_grp_control
    FROM sc_mem_m_membership_registered regis, sc_mem_m_ucf_member_group grp
   WHERE regis.member_group_no = grp.member_group_no
     AND regis.membership_no = as_memno;

  IF ls_grp_control = '009' THEN ldc_chomrom := 300000; END IF;

  RETURN coalesce(0 + coalesce(ldc_chomrom, 0), 0);
EXCEPTION WHEN others THEN RETURN NULL;  -- spa_dberror
END;
$$;

-- ---- fp_tge_calc_replace_share_return : คืนหุ้นค้ำ (TGE) [@805] ------------
-- legacy: body ทั้งหมดถูก comment ทิ้ง เหลือ `return 0;` เท่านั้น (PEAN ไม่ใช้)
CREATE OR REPLACE FUNCTION pka_lon_reqfee.fp_tge_calc_replace_share_return(as_memno text, as_loan_type text)
RETURNS numeric LANGUAGE plpgsql IMMUTABLE AS $$
BEGIN
  RETURN 0;
END;
$$;
