-- ============================================================================
-- step 6 function-first sweep — batch 10 : pkb_amnat (report helpers, Oracle→PG)
-- source: C:\SoAt_PEAN\Admin\Export\PACKAGE_BODY\PKB_AMNAT.sql
-- schema = pkb_amnat (call site: pkb_amnat.fp_...)
--
-- PORT (2 ตัว):
--   fp_grade_count_by_groupcon(date, grade, groupcon) — นับสมาชิกตามเกรด+กลุ่มควบคุม ณ วันที่
--   fp_get_memcoll_str(memno)                         — รายชื่อสมาชิกที่ใช้ memno เป็นผู้ค้ำ (join ',')
--     dependency: pka_com_function.fp_get_member_name — ✅ มีใน PG แล้ว
-- ============================================================================

CREATE SCHEMA IF NOT EXISTS pkb_amnat;

-- ---- fp_grade_count_by_groupcon : นับสมาชิก (เกรด other_code + กลุ่มควบคุม) ณ balance_date ----
--   legacy: nvl(count(1),0) จาก sc_rep_mem_share_loan_bal; ไม่มี exception handler
CREATE OR REPLACE FUNCTION pkb_amnat.fp_grade_count_by_groupcon(adtm_date date, as_grade text, as_groupcon text)
RETURNS integer LANGUAGE plpgsql STABLE AS $$
DECLARE li_count integer;
BEGIN
  SELECT coalesce(count(1), 0)
    INTO li_count
    FROM sc_rep_mem_share_loan_bal
   WHERE share_balance > 0
     AND mem_type      = '01'
     AND other_code    = as_grade
     AND balance_date  = adtm_date
     AND member_group_no IN (
           SELECT member_group_no
             FROM sc_mem_m_ucf_member_group
            WHERE member_group_control = as_groupcon);
  RETURN li_count;
END;
$$;

-- ---- fp_get_memcoll_str : รายชื่อสมาชิกที่นำหุ้น memno ไปค้ำสัญญา (distinct ชื่อ, join ',') ----
--   legacy: cursor distinct (membership_no, fp_get_member_name) → bulk collect → loop ||',' → trim
--           exception others → spa_dberror (คืน null โดยปริยาย)
--   PG: string_agg แทน loop. share_stock*percent_shareperloan_drop < principal_balance
CREATE OR REPLACE FUNCTION pkb_amnat.fp_get_memcoll_str(as_memno text)
RETURNS text LANGUAGE plpgsql STABLE AS $$
DECLARE ls_collateral text;
BEGIN
  SELECT string_agg(contract_mem, ',')
    INTO ls_collateral
    FROM (
      SELECT DISTINCT c.membership_no,
             trim(pka_com_function.fp_get_member_name(c.membership_no)) AS contract_mem
        FROM sc_lon_m_contract              c,
             sc_lon_m_contract_coll         cc,
             sc_lon_m_loan_card             lc,
             sc_mem_m_membership_registered mr,
             sc_mem_m_share_mem             sm,
             sc_lon_m_coll_rule             cr
       WHERE c.loan_contract_no = cc.loan_contract_no
         AND c.loan_contract_no = lc.loan_contract_no
         AND c.membership_no     = mr.membership_no
         AND mr.membership_no    = sm.membership_no
         AND c.loan_type         = cr.loan_type
         AND (cc.status = '0' OR cc.status IS NULL)
         AND cc.collateral_type_code = '01'
         AND c.loan_type <> 'ฉ'
         AND lc.principal_balance > 0
         AND coalesce(sm.share_stock, 0) * coalesce(cr.percent_shareperloan_drop, 0) < lc.principal_balance
         AND cc.ref_own_no = as_memno
    ) d;
  RETURN trim(ls_collateral);
EXCEPTION
  WHEN others THEN RETURN NULL;   -- mirror spa_dberror swallow
END;
$$;
