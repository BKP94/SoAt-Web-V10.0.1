-- ============================================================
-- Oracle: pka_fin_daily.fp_finance_date
-- ============================================================
-- fp_finance_date()              → throw ถ้า finance_date เป็น null
-- fp_finance_date(ignore=>true)  → คืน null ถ้าไม่พบ (ไม่ throw)
-- ============================================================
CREATE OR REPLACE FUNCTION fp_finance_date(p_ignore BOOLEAN DEFAULT FALSE)
RETURNS DATE
LANGUAGE plpgsql
AS $$
DECLARE
  ldt_finance_date DATE;
BEGIN
  SELECT finance_date
  INTO   ldt_finance_date
  FROM   sc_fin_m_constant
  LIMIT  1;

  IF NOT p_ignore AND ldt_finance_date IS NULL THEN
    RAISE EXCEPTION 'E1640:pka_fin_daily ไม่พบวันที่ระบบการเงิน';
  END IF;

  RETURN ldt_finance_date;

EXCEPTION
  WHEN NO_DATA_FOUND THEN
    IF p_ignore THEN RETURN NULL; END IF;
    RAISE EXCEPTION 'E1644:pka_fin_daily ไม่พบข้อมูล sc_fin_m_constant';
  WHEN OTHERS THEN
    IF p_ignore THEN RETURN NULL; END IF;
    RAISE;
END;
$$;
