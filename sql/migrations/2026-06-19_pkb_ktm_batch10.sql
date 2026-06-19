-- ============================================================================
-- step 6 function-first sweep — batch 10 : pkb_ktm (report helpers, Oracle→PG)
-- source: C:\SoAt_PEAN\Admin\Export\PACKAGE_BODY\PKB_KTM.sql
-- schema = pkb_ktm (call site: pkb_ktm.fp_...)
--
-- PORT (2 ตัว — ไม่มี dependency ภายนอก):
--   fp_get_loan_period_payment(memno, lontype)  — รวมยอดผ่อนต่องวด/สัญญายังมีหนี้
--   fp_get_loan_balance_type(memno, lontype)    — ยอดเงินต้นคงเหลือแยกตามชนิดสัญญา
--
-- ⚠️ DEFER (ไม่ port ใน batch นี้):
--   fp_get_collpermit_balance / fp_get_maxpermit_ktm — chain เรียก
--     pka_lon_reqsrv.fp_calc_loanpermit_levelcustom + .fp_collused_calc_totalamount
--     ซึ่ง **ยังไม่มีใน PG** (ตระกูล levelcustom — straggler เดียวกับ fp_rule_loanpermit_levelcustom).
--     ต้อง migrate levelcustom family ก่อนถึงจะ port ได้ faithful.
--
-- ⚠️ NO SOURCE (defer / infer ภายหลัง):
--   fp_get_count_age_memno (16 calls) — ไม่มีใน PACKAGE_BODY/SPEC ทั้ง export
--     → ต้องทำ infer-minimal (เหมือน batch9c-2) หรือ defer; ยังไม่ทำใน batch นี้
-- ============================================================================

CREATE SCHEMA IF NOT EXISTS pkb_ktm;

-- ---- fp_get_loan_period_payment : รวมยอดผ่อนต่องวดของสัญญาที่ยังมีหนี้ ----
--   legacy: nvl(sum(period_payment_amount),0); no_data→0, others→0
CREATE OR REPLACE FUNCTION pkb_ktm.fp_get_loan_period_payment(as_memno text, as_lontype text)
RETURNS numeric LANGUAGE plpgsql STABLE AS $$
DECLARE ldc_amount numeric;
BEGIN
  SELECT coalesce(sum(c.period_payment_amount), 0)
    INTO ldc_amount
    FROM sc_lon_m_contract  c,
         sc_lon_m_loan_card lc
   WHERE c.loan_contract_no = lc.loan_contract_no
     AND c.membership_no    = as_memno
     AND c.loan_type        = as_lontype
     AND lc.principal_balance > 0;
  RETURN coalesce(ldc_amount, 0);
EXCEPTION
  WHEN others THEN RETURN 0;   -- legacy: no_data_found→0, others→0
END;
$$;

-- ---- fp_get_loan_balance_type : ยอดเงินต้นคงเหลือ แยกตามชนิดสัญญา ----
--   legacy: sum(principal_balance); no_data→0 (coalesce ครอบ), others→null
CREATE OR REPLACE FUNCTION pkb_ktm.fp_get_loan_balance_type(as_memno text, as_lontype text)
RETURNS numeric LANGUAGE plpgsql STABLE AS $$
DECLARE ldc_loanbal numeric;
BEGIN
  SELECT sum(principal_balance)
    INTO ldc_loanbal
    FROM sc_lon_m_loan_card
   WHERE membership_no = as_memno
     AND loan_type     = as_lontype
     AND principal_balance > 0;
  RETURN coalesce(ldc_loanbal, 0);  -- no-row → null → 0 (เลียน no_data_found→0)
EXCEPTION
  WHEN others THEN RETURN NULL;      -- legacy: others→null
END;
$$;
