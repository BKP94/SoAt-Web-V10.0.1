-- ════════════════════════════════════════════════════════════════════════════
--  pka_mem_det.fp_cal_loan_paidable — migrate Oracle → PostgreSQL
--  ใช้โดย scteldet › รายละเอียดเงินกู้ (u_tabpg_loan_detail_loan_detail_main) :
--    "คงเหลือรับเงินงวด" (paid_able) — ยอดที่ยังรับเพิ่มได้ของสัญญา
--    เฉพาะเงินกู้ ATM / looping / เงินกู้พิเศษกลุ่ม '03' (รับเป็นงวด) เท่านั้น
--    เงินกู้พิเศษ: ถ้า loan_approve_amount > get_loan_special_paid(conno) → คืนส่วนต่าง, else 0
--
--  source: C:\SoAt_PEAN\Admin\Export\PACKAGE_BODY\PKA_MEM_DET.sql (fp_cal_loan_paidable)
--  dependency: pka_lon_addloan.get_loan_special_paid (migrate แล้ว)
--  faithful: DECODE/if คงตรรกะ; SELECT INTO (non-strict) → ไม่พบแถวคืน NULL แล้วตกไป RETURN 0
--    (ตัด exception spa_dberror('E993') — viewer อ้าง conno ที่มีอยู่จริงเสมอ)
--  รันที่ pgAdmin โดย PL team (schema เป็น pgAdmin-managed)
-- ════════════════════════════════════════════════════════════════════════════

CREATE SCHEMA IF NOT EXISTS pka_mem_det;

CREATE OR REPLACE FUNCTION pka_mem_det.fp_cal_loan_paidable(as_conno varchar)
RETURNS numeric
LANGUAGE plpgsql
AS $$
DECLARE
    ls_atm_status      char;
    ls_loan_looping    char;
    ls_loan_group_code char(2);
    ldc_approve        numeric;
    ldc_balance        numeric;
    ldc_paid           numeric;
BEGIN
    SELECT sc_lon_m_rule.atm_status,
           sc_lon_m_rule.loan_looping,
           sc_lon_m_rule.loan_group_code,
           sc_lon_m_contract.loan_approve_amount,
           sc_lon_m_loan_card.principal_balance
      INTO ls_atm_status, ls_loan_looping, ls_loan_group_code,
           ldc_approve, ldc_balance
      FROM sc_lon_m_contract, sc_lon_m_loan_card, sc_lon_m_rule
     WHERE sc_lon_m_loan_card.loan_type        = sc_lon_m_rule.loan_type
       AND sc_lon_m_loan_card.loan_contract_no = sc_lon_m_contract.loan_contract_no
       AND sc_lon_m_loan_card.loan_contract_no = as_conno;

    -- เฉพาะเงินกู้ atm/looping และเงินกู้พิเศษรับเป็นงวด เท่านั้น ที่จะมียอดรับเพิ่มได้
    IF (ls_atm_status = '1' OR ls_loan_looping = '1') THEN
        NULL;
    ELSIF ls_loan_group_code = '03' THEN
        -- เงินกู้พิเศษ — ยอดที่จ่ายไปแล้ว
        ldc_paid := pka_lon_addloan.get_loan_special_paid(as_conno);
        IF ldc_approve > ldc_paid THEN
            RETURN ldc_approve - ldc_paid;
        END IF;
    END IF;

    RETURN 0;
END;
$$;
