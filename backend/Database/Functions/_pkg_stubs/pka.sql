-- Package PKA — implemented from Oracle source (legacy_ora_src/PKA.sql)
CREATE SCHEMA IF NOT EXISTS pka;

-- isCoop: ตรวจว่า sys_name ของสหกรณ์ (sc_cnt_m_coop, single-row config) ตรงกับชื่อที่ส่งมาไหม → '1'/'0'
CREATE OR REPLACE FUNCTION pka.iscoop(as_sys_name text)
RETURNS char LANGUAGE plpgsql STABLE AS $$
DECLARE
  ls_sys_name text;
BEGIN
  SELECT sys_name INTO ls_sys_name FROM sc_cnt_m_coop;
  IF lower(trim(ls_sys_name)) = lower(trim(as_sys_name)) THEN
    RETURN '1';   -- ใช่ สอ ที่ต้องการ
  END IF;
  RETURN '0';     -- ไม่ใช่ สอ ที่ต้องการ
END;
$$;
