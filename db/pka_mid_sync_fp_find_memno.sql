-- ════════════════════════════════════════════════════════════════════════════
--  pka_mid_sync.fp_find_memno — migrate Oracle → PostgreSQL
--  ใช้โดย scteldet › อ่านบัตรประชาชน (ScanCard) : id_card → membership_no
--    ปกติ 1 id = 1 ทะเบียน; กรณี "ลาออกสมัครใหม่" (มีทะเบียนซ้ำ id เดียว >1)
--    → เลือกเฉพาะทะเบียนสถานะปกติ member_status_code='0'
--
--  source: C:\SoAt_PEAN\Admin\Export\PACKAGE_BODY\PKA_MID_SYNC.sql (fp_find_memno)
--  faithful: %TYPE คงไว้; max()/count() เป็น aggregate → ไม่เกิด no_data_found เลย
--    (Oracle handler E279/E441 เป็น dead code) จึงคืน NULL เมื่อไม่พบ ตรงพฤติกรรมจริง
--    ตัด exception when others/spa_dberror ทิ้ง (viewer ไม่ต้องดัก — raise ปกติ)
--  รันที่ pgAdmin โดย PL team (schema เป็น pgAdmin-managed)
-- ════════════════════════════════════════════════════════════════════════════

CREATE SCHEMA IF NOT EXISTS pka_mid_sync;

CREATE OR REPLACE FUNCTION pka_mid_sync.fp_find_memno(as_id varchar)
RETURNS varchar
LANGUAGE plpgsql
AS $$
DECLARE
    ls_memno sc_mem_m_membership_registered.membership_no%type;
    li_rc    int;
BEGIN
    SELECT max(membership_no), count(1)
      INTO ls_memno, li_rc
      FROM sc_mem_m_membership_registered
     WHERE id_card = as_id;

    -- ลาออกสมัครใหม่: id เดียวมีหลายทะเบียน → เลือกเฉพาะสถานะปกติ ('0')
    IF li_rc > 1 THEN
        SELECT max(membership_no)
          INTO ls_memno
          FROM sc_mem_m_membership_registered
         WHERE id_card = as_id
           AND member_status_code = '0';
    END IF;

    RETURN ls_memno;
END;
$$;
