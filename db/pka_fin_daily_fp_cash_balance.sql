-- ════════════════════════════════════════════════════════════════════════════
--  pka_fin_daily.fp_cash_balance — migrate Oracle → PostgreSQL
--  "จำนวนเงิน(เงินสด)คงเหลือในลิ้นชัก" ของ entry การเงิน (เจ้าหน้าที่/เคาน์เตอร์)
--    = balance_forward ของ sc_fin_journal_head แถวปัจจุบัน (สมุดหลัก fin_book='0', ยังไม่ปิดวัน close_day='0')
--    ของสาขาที่ล็อกอิน (login_br) + วันที่การเงิน (finance_date) + entry_fin ที่ระบุ
--
--  source: C:\SoAt_PEAN\Admin\Export\PACKAGE_BODY\PKA_FIN_DAILY.sql (fp_cash_balance, 2 overloads)
--  dependency: pka_fin_daily.fp_finance_date('1')  — migrate แล้ว (PL team / pgAdmin)
--  login vars : pka_com_login.login_id/login_br → current_setting('app.login_*', true)
--               (dbFactory.create(userId, branchId) → SET LOCAL app.login_id/app.login_br)
--
--  faithful:
--    • no-arg overload ส่ง login_id เป็น entry_fin (เหมือน legacy บรรทัด 1653)
--    • Oracle no_data_found → 0 : PG SELECT INTO (non-strict) ไม่พบแถว → ตัวแปรเป็น NULL
--      แล้ว COALESCE(...,0) คืน 0 เอง (ไม่ต้องมี exception handler)
--    • ตัด WHEN OTHERS → spa_dberror/return null : ให้ error จริงเด้งขึ้นแทนที่จะกลืนเป็น NULL
--      (แนวเดียวกับ pka_mem_det.fp_cal_loan_paidable)
--    • ตัดตัวแปร li_open_no (Oracle ประกาศไว้แต่ไม่ได้ใช้)
--  รันที่ pgAdmin โดย PL team (schema เป็น pgAdmin-managed)
-- ════════════════════════════════════════════════════════════════════════════

CREATE SCHEMA IF NOT EXISTS pka_fin_daily;

-- ── overload ไม่รับ argument : ใช้ login_id ปัจจุบันเป็น entry_fin ─────────────
CREATE OR REPLACE FUNCTION pka_fin_daily.fp_cash_balance()
RETURNS numeric
LANGUAGE plpgsql
AS $$
BEGIN
    RETURN pka_fin_daily.fp_cash_balance(current_setting('app.login_id', true));
END;
$$;

-- ── overload หลัก : ระบุ entry_fin ───────────────────────────────────────────
CREATE OR REPLACE FUNCTION pka_fin_daily.fp_cash_balance(as_entry_fin varchar)
RETURNS numeric
LANGUAGE plpgsql
AS $$
DECLARE
    ldc_cash_balance numeric;
    ldt_finance_date date;
BEGIN
    ldt_finance_date := pka_fin_daily.fp_finance_date('1');
    IF ldt_finance_date IS NULL THEN
        RETURN 0;
    END IF;

    SELECT balance_forward
      INTO ldc_cash_balance
      FROM sc_fin_journal_head
     WHERE branch_fin   = current_setting('app.login_br', true)
       AND journal_date = ldt_finance_date
       AND entry_fin    = as_entry_fin
       AND fin_book     = '0'
       AND close_day    = '0';

    RETURN COALESCE(ldc_cash_balance, 0);
END;
$$;
