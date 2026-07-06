-- ════════════════════════════════════════════════════════════════════════════
--  pka_srv_dbattrib_getcoltext.sql
--  migrate Oracle PKA_SRV_DBATTRIB.GETCOLTEXT → PostgreSQL
--  รันที่ pgAdmin โดย PL team (schema เป็น pgAdmin-managed — Claude ไม่รันเอง)
--
--  legacy (PKA_SRV_DBATTRIB.sql):
--    getcoltext(as_tab, as_col) → อ่าน column comment (getcomment → user_col_comments)
--    → คืน "ข้อความที่อยู่ระหว่าง !N ... N!" (trim) ; ถ้าไม่มี marker → null
--    (คู่แฝด getmeaning ใช้ marker !M ... M! ต่างหาก — ไม่ได้ migrate ในไฟล์นี้)
--
--  PG idiom:
--    user_col_comments.comments  → col_description(table_oid, attnum)  (pg_description)
--    Oracle instr/substr (1-based) → PG position/substr (1-based) — semantics ตรงกัน
--
--  ผู้ใช้จริง: scteldet G7 tab "เปลี่ยนสถานะ/บันทึกช่วยจำ"
--    (u_tabpg_mem_detail_chg_memo_status) — SELECT ... getcoltext(
--       'sc_mem_m_membership_registered', trim(permit_name)) as permit_desc
--    ⚠ ต้องมี COMMENT ON COLUMN sc_mem_m_membership_registered.<permit> ที่มี !N...N!
--      ครบทุกคอลัมน์สิทธิ์ (ปัจจุบัน dev มี comment ไม่ครบ — PL reconcile กับ Oracle)
-- ════════════════════════════════════════════════════════════════════════════

CREATE SCHEMA IF NOT EXISTS pka_srv_dbattrib;

CREATE OR REPLACE FUNCTION pka_srv_dbattrib.getcoltext(as_tab text, as_col text)
RETURNS text
LANGUAGE plpgsql
STABLE
AS $$
DECLARE
  ls_comment text;
  li_begin   int;
  li_end     int;
BEGIN
  -- getcomment: อ่าน comment ของคอลัมน์ (เทียบ user_col_comments ของ Oracle)
  SELECT col_description(c.oid, a.attnum)
    INTO ls_comment
    FROM pg_class c
    JOIN pg_namespace n ON n.oid = c.relnamespace
    JOIN pg_attribute a ON a.attrelid = c.oid
   WHERE c.relname = lower(trim(as_tab))
     AND a.attname = lower(trim(as_col))
     AND a.attnum  > 0
     AND NOT a.attisdropped
   LIMIT 1;

  ls_comment := trim(ls_comment);
  li_begin := position('!N' IN ls_comment);
  li_end   := position('N!' IN ls_comment);
  IF li_begin > 0 AND li_end > 0 THEN
    RETURN trim(substr(ls_comment, li_begin + 2, li_end - li_begin - 2));
  END IF;
  RETURN NULL;
EXCEPTION WHEN OTHERS THEN
  RETURN NULL;
END;
$$;
