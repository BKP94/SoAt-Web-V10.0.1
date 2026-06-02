-- ============================================================
-- Oracle: pka_fin_daily.fp_counter_opened
-- ============================================================
-- ตรวจสอบว่าเคาน์เตอร์ของ user ที่ login อยู่เปิดแล้วหรือยัง
--
-- Dependencies:
--   fp_finance_date(true)          ← วันที่การเงิน
--   current_setting('app.login_id') ← แทน current_setting('app.login_id', true)
--   current_setting('app.login_br') ← แทน current_setting('app.login_br', true)
--   sc_fin_journal_head
--
-- Returns: '1' = เปิดแล้ว, '0' = ยังไม่เปิด
-- ============================================================
CREATE OR REPLACE FUNCTION fp_counter_opened()
RETURNS CHAR(1)
LANGUAGE plpgsql
AS $$
DECLARE
  li_count      INT;
  ldt_fin_date  DATE;
  ls_entry_fin  TEXT;
  ls_branch_fin TEXT;
BEGIN
  -- วันที่การเงิน (ignore=true → คืน null ถ้ายังไม่เปิดวัน)
  ldt_fin_date := fp_finance_date(true);

  -- รหัส user และสาขา (แทน pka_com_login package)
  ls_entry_fin  := TRIM(current_setting('app.login_id', true));
  ls_branch_fin := TRIM(current_setting('app.login_br', true));

  IF ldt_fin_date IS NOT NULL
     AND ls_entry_fin  <> ''
     AND ls_branch_fin <> ''
  THEN
    SELECT COUNT(*)
    INTO   li_count
    FROM   sc_fin_journal_head
    WHERE  branch_fin   = ls_branch_fin
      AND  journal_date = ldt_fin_date
      AND  entry_fin    = ls_entry_fin
      AND  fin_book     = '0'
      AND  close_day    = '0';

    IF li_count > 0 THEN
      RETURN '1';
    END IF;
  END IF;

  RETURN '0';

EXCEPTION WHEN OTHERS THEN
  RAISE EXCEPTION 'E441:pka_fin_daily.fp_counter_opened: %', SQLERRM;
END;
$$;
