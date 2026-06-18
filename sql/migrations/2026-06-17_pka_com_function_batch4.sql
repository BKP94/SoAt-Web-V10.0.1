-- ============================================================================
-- step 6 function-first sweep — batch 4 (pka_com_function: สมาชิก/ชื่อเดือน/user)
-- port (ทั้งหมด MISSING ใน PG):
--   fp_get_member_sharestock      [src 1447]  หุ้นสะสม
--   fp_get_member_salary          [src 1534]  เงินเดือน
--   fp_get_member_name_eng        [src 1572]  ชื่อ-สกุล อังกฤษ
--   fp_get_month_name(int)        [src 1613]  ชื่อเดือน (delegate LT)
--   fp_get_month_name(int,text)   [src 1641]  ชื่อเดือน (LT/LE/ST/SE)
--   fp_get_member_position_long   [src 1817]  ชื่อตำแหน่ง (ยาว)
--   fp_get_member_position_name   [src 1832]  ชื่อตำแหน่ง (จาก ucf_position)
--   fp_get_member_address_tel     [src 459]   เบอร์โทรจากที่อยู่
--   fp_get_user_name              [src 827]   ชื่อ user
--
-- deviation (Legacy Fidelity):
--  - spa_dberror(...) (logger side-effect) -> ตัดทิ้ง คืน null/0 ตาม path เดิม
--  - fp_get_member_name_eng: Oracle `a||' '||b` (NULL||x = x) -> ใช้ concat() ให้ NULL=ว่าง
--  - fp_get_month_name(int,char): Oracle EXECUTE IMMEDIATE เลือกคอลัมน์ตาม case
--      -> port เป็น CASE เลือกคอลัมน์ตรง (ผลลัพธ์เท่ากัน, ไม่ต้อง dynamic SQL)
--  - fp_get_user_name: Oracle คำนวณ ls_user_id (จาก as_entryid/fp_login_id) แต่
--      WHERE จริงใช้ as_entryid ตรงๆ (ls_user_id เป็น dead code) -> ตัด fp_login_id
--      branch ทิ้ง query as_entryid ตาม behavior จริง
--  - fp_get_member_address_tel: BULK COLLECT + .Count (return null ถ้า count<>1)
--      -> count(*) ก่อน แล้ว fetch
--  - return number -> numeric (เงิน/หุ้น), varchar2 -> text
-- ============================================================================

-- ---- fp_get_member_sharestock : หุ้นสะสม [src 1447] -----------------------
CREATE OR REPLACE FUNCTION pka_com_function.fp_get_member_sharestock(as_memno text)
RETURNS numeric LANGUAGE plpgsql STABLE AS $$
DECLARE ldc_share_stock numeric;
BEGIN
  SELECT share_stock INTO STRICT ldc_share_stock
    FROM sc_mem_m_share_mem WHERE membership_no = as_memno;
  RETURN coalesce(ldc_share_stock, 0);
EXCEPTION
  WHEN no_data_found THEN RETURN 0;
  WHEN others THEN RETURN NULL;
END;
$$;

-- ---- fp_get_member_salary : เงินเดือน [src 1534] --------------------------
CREATE OR REPLACE FUNCTION pka_com_function.fp_get_member_salary(as_memno text)
RETURNS numeric LANGUAGE plpgsql STABLE AS $$
DECLARE ldc_amount numeric;
BEGIN
  SELECT salary_amount INTO STRICT ldc_amount
    FROM sc_mem_m_member_work_info WHERE membership_no = as_memno;
  RETURN coalesce(ldc_amount, 0);
EXCEPTION
  WHEN no_data_found THEN RETURN 0;
  WHEN others THEN RETURN 0;
END;
$$;

-- ---- fp_get_member_name_eng : ชื่อ-สกุล อังกฤษ [src 1572] ------------------
-- concat() (ไม่ใช่ ||) เพราะ Oracle NULL||x = x
CREATE OR REPLACE FUNCTION pka_com_function.fp_get_member_name_eng(as_memno text)
RETURNS text LANGUAGE plpgsql STABLE AS $$
DECLARE ls_eng_name text;
BEGIN
  SELECT concat(prename_eng, ' ', name_eng, ' ', surname_eng) INTO STRICT ls_eng_name
    FROM sc_mem_m_membership_registered WHERE membership_no = as_memno;
  RETURN trim(ls_eng_name);
EXCEPTION WHEN others THEN RETURN NULL;
END;
$$;

-- ---- fp_get_month_name(int) : ชื่อเดือน (delegate LT) [src 1613] -----------
CREATE OR REPLACE FUNCTION pka_com_function.fp_get_month_name(ai_month int)
RETURNS text LANGUAGE plpgsql STABLE AS $$
BEGIN RETURN pka_com_function.fp_get_month_name(ai_month, 'LT');
EXCEPTION WHEN others THEN RETURN NULL; END;
$$;

-- ---- fp_get_month_name(int,text) : ชื่อเดือนตาม case [src 1641] ------------
CREATE OR REPLACE FUNCTION pka_com_function.fp_get_month_name(ai_month int, as_case text)
RETURNS text LANGUAGE plpgsql STABLE AS $$
DECLARE ls_name text;
BEGIN
  CASE as_case
    WHEN 'LT' THEN SELECT month_name_thai  INTO STRICT ls_name FROM sc_cnt_m_month WHERE month_no = ai_month;
    WHEN 'LE' THEN SELECT month_name_eng   INTO STRICT ls_name FROM sc_cnt_m_month WHERE month_no = ai_month;
    WHEN 'ST' THEN SELECT shot_month_thai  INTO STRICT ls_name FROM sc_cnt_m_month WHERE month_no = ai_month;
    WHEN 'SE' THEN SELECT shot_month_eng   INTO STRICT ls_name FROM sc_cnt_m_month WHERE month_no = ai_month;
    ELSE RETURN NULL;  -- case นอก (LT,LE,ST,SE): Oracle log error แล้ว fallthrough -> null
  END CASE;
  RETURN trim(ls_name);
EXCEPTION
  WHEN no_data_found THEN RETURN NULL;
  WHEN others THEN RETURN NULL;
END;
$$;

-- ---- fp_get_member_position_long : ชื่อตำแหน่งยาว [src 1817] ---------------
CREATE OR REPLACE FUNCTION pka_com_function.fp_get_member_position_long(as_memno text)
RETURNS text LANGUAGE plpgsql STABLE AS $$
DECLARE ls_position_long text;
BEGIN
  SELECT position_long INTO STRICT ls_position_long
    FROM sc_mem_m_member_work_info WHERE membership_no = as_memno;
  RETURN ls_position_long;
EXCEPTION
  WHEN no_data_found THEN RETURN NULL;
  WHEN others THEN RETURN NULL;
END;
$$;

-- ---- fp_get_member_position_name : ชื่อตำแหน่งจาก ucf_position [src 1832] --
CREATE OR REPLACE FUNCTION pka_com_function.fp_get_member_position_name(as_memno text)
RETURNS text LANGUAGE plpgsql STABLE AS $$
DECLARE ls_position_name text;
BEGIN
  SELECT p.position_name INTO STRICT ls_position_name
    FROM sc_mem_m_ucf_position p, sc_mem_m_member_work_info w
   WHERE p.position_code = w.position_code
     AND w.membership_no = as_memno;
  RETURN ls_position_name;
EXCEPTION
  WHEN no_data_found THEN RETURN NULL;
  WHEN others THEN RETURN NULL;
END;
$$;

-- ---- fp_get_member_address_tel : เบอร์โทรจากที่อยู่ [src 459] --------------
CREATE OR REPLACE FUNCTION pka_com_function.fp_get_member_address_tel(as_memno text, as_addtype text)
RETURNS text LANGUAGE plpgsql STABLE AS $$
DECLARE
  cnt int;
  ls_telephone text;
  ls_address text := '';
BEGIN
  SELECT count(*) INTO cnt FROM sc_mem_m_member_address
   WHERE membership_no = as_memno AND address_type = as_addtype;
  IF cnt = 0 OR cnt > 1 THEN RETURN NULL; END IF;

  SELECT telephone INTO ls_telephone FROM sc_mem_m_member_address
   WHERE membership_no = as_memno AND address_type = as_addtype;
  IF length(trim(ls_telephone)) > 0 THEN ls_address := ls_address || trim(ls_telephone); END IF;
  RETURN trim(ls_address);
EXCEPTION WHEN others THEN RETURN NULL;
END;
$$;

-- ---- fp_get_user_name : ชื่อ user [src 827] -------------------------------
-- deviation: ls_user_id เป็น dead code (WHERE ใช้ as_entryid) -> ตัด fp_login_id branch
CREATE OR REPLACE FUNCTION pka_com_function.fp_get_user_name(as_entryid text DEFAULT NULL)
RETURNS text LANGUAGE plpgsql STABLE AS $$
DECLARE ls_description text;
BEGIN
  SELECT user_name INTO STRICT ls_description
    FROM si_security_user WHERE user_id = as_entryid;
  RETURN trim(ls_description);
EXCEPTION WHEN others THEN RETURN NULL;
END;
$$;
