-- ============================================================================
-- step 6 function-first sweep — batch 10 : pkb_repyear (report helpers, Oracle→PG)
-- source: C:\SoAt_PEAN\Admin\Export\PACKAGE_BODY\PKB_REPYEAR.sql
-- schema = pkb_repyear (call site: pkb_repyear.fp_...)
--
-- PORT (1 ตัว):
--   fp_loan_sum_int(conno, bdate, edate) — รวมดอกเบี้ยจ่ายของสัญญาในช่วงวันที่ (×(-1)×sign_status)
-- ============================================================================

CREATE SCHEMA IF NOT EXISTS pkb_repyear;

-- ---- fp_loan_sum_int : รวมดอกเบี้ยของสัญญา conno ระหว่าง bdate..edate ----
--   legacy: sum((-1)*nvl(interest_amout,0)*nvl(sign_status,0)); ถ้า >0 คืนค่า ไม่งั้นคืน 0
--           exception others → spa_dberror (คืน null โดยปริยาย)
CREATE OR REPLACE FUNCTION pkb_repyear.fp_loan_sum_int(as_conno text, adtm_bdate date, adtm_edate date)
RETURNS numeric LANGUAGE plpgsql STABLE AS $$
DECLARE ldc_amount numeric;
BEGIN
  SELECT sum((-1) * coalesce(d.interest_amout, 0) * coalesce(i.sign_status, 0))
    INTO ldc_amount
    FROM sc_mem_m_membership_registered mr,
         sc_lon_m_loan_card             lc,
         sc_lon_m_loan_card_detail      d,
         sc_lon_m_ucf_loan_card_item    i,
         sc_lon_m_rule                  r
   WHERE lc.membership_no  = mr.membership_no
     AND lc.loan_type      = r.loan_type
     AND d.loan_contract_no = lc.loan_contract_no
     AND d.item_type_code   = i.item_type_code
     AND d.loan_payment_date BETWEEN adtm_bdate AND adtm_edate
     AND lc.loan_contract_no = as_conno
     AND d.status = '0';
  IF ldc_amount > 0 THEN
    RETURN ldc_amount;
  END IF;
  RETURN 0;
EXCEPTION
  WHEN others THEN RETURN NULL;   -- mirror spa_dberror swallow
END;
$$;
