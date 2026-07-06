-- ════════════════════════════════════════════════════════════════════════════
--  pka_lon_addloan.get_loan_special_paid — migrate Oracle → PostgreSQL
--  ใช้โดย scteldet › รายละเอียดเงินกู้ (u_tabpg_mem_detail_loan_detail) :
--    เช็คเงินกู้พิเศษกลุ่ม '03' รับเป็นงวด (pay_loan_period='1') ว่าจ่ายเงินครบหรือยัง
--    → ถ้า loan_approve_amount > get_loan_special_paid(conno) ระบายเซลล์แดง
--
--  source: C:\SoAt_PEAN\Admin\Export\PACKAGE_BODY\PKA_LON_ADDLOAN.sql
--  faithful: NVL→COALESCE, %TYPE คงไว้, no_data_found→คืน null (เหมือน Oracle)
--    ตัด exception when others/spa_dberror ทิ้ง (raise error ปกติ — viewer ไม่ต้องดัก)
--  รันที่ pgAdmin โดย PL team (schema เป็น pgAdmin-managed)
-- ════════════════════════════════════════════════════════════════════════════

CREATE SCHEMA IF NOT EXISTS pka_lon_addloan;

CREATE OR REPLACE FUNCTION pka_lon_addloan.get_loan_special_paid(as_conno varchar)
RETURNS numeric
LANGUAGE plpgsql
AS $$
DECLARE
    ldc_loan_approve_amount numeric;
    ldc_paid_first_amount   numeric;
    ldc_loan_amount         numeric;
    ls_close_status         sc_lon_m_loan_card.close_status%type;
BEGIN
    BEGIN
        SELECT sc_lon_m_contract.loan_approve_amount,
               sc_lon_m_contract.paid_first_amount,
               sc_lon_m_loan_card.close_status
          INTO STRICT ldc_loan_approve_amount, ldc_paid_first_amount, ls_close_status
          FROM sc_lon_m_contract, sc_lon_m_rule, sc_lon_m_loan_card
         WHERE sc_lon_m_contract.loan_type        = sc_lon_m_rule.loan_type
           AND sc_lon_m_contract.loan_contract_no = sc_lon_m_loan_card.loan_contract_no
           AND sc_lon_m_rule.pay_loan_period      = '1'
           AND sc_lon_m_contract.loan_contract_no = as_conno;
    EXCEPTION
        WHEN no_data_found THEN
            RETURN ldc_loan_approve_amount;   -- null (faithful กับ Oracle: คืนตัวแปรที่ยังว่าง)
    END;

    IF ldc_paid_first_amount = 0 THEN
        ldc_paid_first_amount := ldc_loan_approve_amount;
    END IF;
    IF ls_close_status = '1' THEN
        ldc_paid_first_amount := ldc_loan_approve_amount;
    END IF;

    SELECT sum(addloan_amount)
      INTO ldc_loan_amount
      FROM sc_lon_m_loan_addloan
     WHERE loan_contract_no = as_conno
       AND COALESCE(cancel_status,'0') = '0';

    RETURN ldc_paid_first_amount + COALESCE(ldc_loan_amount, 0);
END;
$$;
