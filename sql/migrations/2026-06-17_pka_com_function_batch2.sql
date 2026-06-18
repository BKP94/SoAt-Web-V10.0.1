-- ============================================================================
-- step 6 function-first sweep — batch 2 (pka_com_function)
-- port: fp_get_numberthai(MISSING), fp_get_moneythai(STUB), fp_get_group_name(STUB),
--       fp_get_group_name_mem(STUB), fp_get_sub_district_name(STUB)
-- source: C:\SoAt_PEAN\Admin\Export\PACKAGE_BODY\PKA_COM_FUNCTION.sql @487,592,808,813,859
--
-- deviation ที่บันทึก (ตาม Legacy Fidelity):
--  - spa_dberror(...) (error logger, side-effect) -> RETURN NULL ตาม convention เดิม
--  - Oracle implicit SELECT (raise NO_DATA_FOUND/TOO_MANY_ROWS) -> INTO STRICT
--  - numberthai: Oracle GOTO end_loop (ข้าม append หลักที่เป็น 0) -> CONTINUE
--  - numberthai: array index ติดลบ (-3..9) -> inline CASE; ตำแหน่ง 0..6 -> pos[idx+1]
--  - moneythai: param เป็น double precision (จาก stub เดิม; Oracle เป็น NUMBER) ->
--      cast ::numeric + trim_scale() เพื่อจำลอง Oracle to_char(NUMBER) ที่ตัด 0 ท้าย
-- ============================================================================

-- ---- fp_get_numberthai(text) : เลข -> คำอ่านไทย [src 487] -------------------
CREATE OR REPLACE FUNCTION pka_com_function.fp_get_numberthai(as_number text)
RETURNS text LANGUAGE plpgsql IMMUTABLE AS $$
DECLARE
  pos text[] := ARRAY['','สิบ','ร้อย','พัน','หมื่น','แสน','ล้าน']; -- หน่วย idx0..6 -> pos[idx+1]
  ls_number      text;
  ls_fraction    text;
  ls_numberword  text := '';
  li_count_pos   int;
  li_count_million int;
  li_index       int;
  li_number      int;
  li_length_number int;
  li_pos_dot     int;
  ltab_number    text[] := ARRAY[]::text[];
  grp            text;
BEGIN
  IF as_number IS NULL THEN RETURN NULL; END IF;
  ls_number  := replace(rtrim(as_number), ',', '');
  li_pos_dot := strpos(ls_number, '.');
  IF li_pos_dot > 0 THEN
    ls_fraction := substr(ls_number, li_pos_dot + 1, length(ls_number) - li_pos_dot);
    ls_number   := substr(ls_number, 1, li_pos_dot - 1);
  END IF;
  IF ls_number IS NULL OR ls_number = '' THEN ls_number := '0'; END IF;

  -- จำนวนเต็ม : แบ่งกลุ่มละ 6 หลัก (หลักล้าน)
  li_length_number := length(ls_number);
  li_count_million := li_length_number / 6;            -- integer division
  IF li_count_million > 0 THEN
    IF (li_length_number % 6) > 0 THEN li_count_million := li_count_million + 1; END IF;
    ls_number := lpad(ls_number, li_count_million * 6, '0');
    FOR i IN 1..li_count_million LOOP
      ltab_number[i] := substr(ls_number, ((i - 1) * 6) + 1, 6);
    END LOOP;
  ELSE
    ltab_number[1]   := ls_number;
    li_count_million := 1;
  END IF;

  FOR j IN 1..li_count_million LOOP
    IF j > 1 AND length(ls_numberword) > 0 THEN
      ls_numberword := ls_numberword || pos[7];        -- ล้าน
    END IF;
    grp          := ltab_number[j];
    li_count_pos := length(grp);
    li_index     := 0;
    FOR i IN 1..li_count_pos LOOP
      li_index  := li_index + 1;
      li_number := substr(grp, li_index, 1)::int;
      IF li_number = 0 AND li_count_pos > 1 THEN CONTINUE; END IF;          -- ข้ามหลักที่เป็น 0
      IF li_number = 2 AND i = li_count_pos - 1 THEN li_number := -2; END IF;  -- ยี่สิบ
      IF li_number = 1 AND i = li_count_pos - 1 THEN li_number := -3; END IF;  -- สิบ
      IF li_number = 1 AND i = li_count_pos AND li_count_pos > 1 THEN          -- เอ็ด
        IF grp::int > 1 THEN li_number := -1; END IF;
      END IF;
      ls_numberword := ls_numberword
        || CASE li_number
             WHEN -3 THEN '' WHEN -2 THEN 'ยี่' WHEN -1 THEN 'เอ็ด'
             WHEN 0 THEN 'ศูนย์' WHEN 1 THEN 'หนึ่ง' WHEN 2 THEN 'สอง'
             WHEN 3 THEN 'สาม' WHEN 4 THEN 'สี่' WHEN 5 THEN 'ห้า'
             WHEN 6 THEN 'หก' WHEN 7 THEN 'เจ็ด' WHEN 8 THEN 'แปด' WHEN 9 THEN 'เก้า'
           END
        || pos[(li_count_pos - i) + 1];
    END LOOP;
  END LOOP;

  -- ทศนิยม
  li_count_pos := length(coalesce(ls_fraction, ''));
  IF li_count_pos > 0 THEN
    ls_numberword := ls_numberword || 'จุด';
    li_index := 0;
    FOR i IN 1..li_count_pos LOOP
      li_index  := li_index + 1;
      li_number := substr(ls_fraction, li_index, 1)::int;
      ls_numberword := ls_numberword
        || CASE li_number
             WHEN 0 THEN 'ศูนย์' WHEN 1 THEN 'หนึ่ง' WHEN 2 THEN 'สอง'
             WHEN 3 THEN 'สาม' WHEN 4 THEN 'สี่' WHEN 5 THEN 'ห้า'
             WHEN 6 THEN 'หก' WHEN 7 THEN 'เจ็ด' WHEN 8 THEN 'แปด' WHEN 9 THEN 'เก้า'
           END;
    END LOOP;
  END IF;

  RETURN trim(ls_numberword);
EXCEPTION WHEN OTHERS THEN RETURN NULL;
END;
$$;

-- ---- fp_get_moneythai(double precision) : เงิน -> คำอ่านไทย [src 592] -------
CREATE OR REPLACE FUNCTION pka_com_function.fp_get_moneythai(adc_number double precision)
RETURNS text LANGUAGE plpgsql IMMUTABLE AS $$
DECLARE
  ls_numberword text := '';
  ls_number     text;
  ls_fraction   text;
  li_pos_dot    int;
BEGIN
  IF NOT (coalesce(adc_number, 0) > 0) THEN RETURN 'ศูนย์บาทถ้วน'; END IF;  -- var_number=0
  ls_number  := trim_scale(adc_number::numeric)::text;                       -- จำลอง to_char(NUMBER)
  li_pos_dot := strpos(ls_number, '.');
  IF li_pos_dot > 0 THEN
    ls_fraction := substr(ls_number, li_pos_dot + 1, length(ls_number) - li_pos_dot);
    IF length(ls_fraction) > 2 THEN
      NULL;  -- Oracle: spa_dberror('ไม่รองรับเศษสตางค์มากกว่าสองตำแหน่ง')
    ELSE
      ls_fraction := substr(ls_fraction || '0', 1, 2);
    END IF;
    ls_number := substr(ls_number, 1, li_pos_dot - 1);
    IF ls_number IS NULL OR ls_number = '' THEN ls_number := '0'; END IF;
  END IF;

  IF length(ls_number) > 0 THEN
    ls_numberword := pka_com_function.fp_get_numberthai(ls_number);
    IF length(coalesce(ls_fraction, '')) > 0 THEN
      ls_numberword := ls_numberword || 'บาท';
      ls_numberword := ls_numberword || pka_com_function.fp_get_numberthai(ls_fraction) || 'สตางค์';
    ELSE
      ls_numberword := ls_numberword || 'บาทถ้วน';
    END IF;
  END IF;
  RETURN trim(ls_numberword);
EXCEPTION WHEN OTHERS THEN RETURN NULL;
END;
$$;

-- ---- fp_get_group_name(text) : ชื่อหน่วย [src 813] -------------------------
CREATE OR REPLACE FUNCTION pka_com_function.fp_get_group_name(as_group_no text)
RETURNS text LANGUAGE plpgsql STABLE AS $$
DECLARE ls_member_group_name sc_mem_m_ucf_member_group.member_group_name%type;
BEGIN
  SELECT member_group_name INTO STRICT ls_member_group_name
  FROM sc_mem_m_ucf_member_group WHERE member_group_no = as_group_no;
  RETURN trim(ls_member_group_name);
EXCEPTION
  WHEN no_data_found THEN RETURN NULL;
  WHEN others THEN RETURN NULL;
END;
$$;

-- ---- fp_get_group_name_mem(text) : ชื่อหน่วยจากเลขสมาชิก [src 808] ----------
CREATE OR REPLACE FUNCTION pka_com_function.fp_get_group_name_mem(as_memno text)
RETURNS text LANGUAGE plpgsql STABLE AS $$
BEGIN
  RETURN pka_com_function.fp_get_group_name(pka_com_function.fp_get_member_group(as_memno));
END;
$$;

-- ---- fp_get_sub_district_name(text) : ชื่อตำบล [src 859] -------------------
CREATE OR REPLACE FUNCTION pka_com_function.fp_get_sub_district_name(as_subdis text)
RETURNS text LANGUAGE plpgsql STABLE AS $$
DECLARE ls_subdistrict_name sc_mem_m_ucf_subdistrict.subdistrict_name%type;
BEGIN
  BEGIN
    SELECT subdistrict_name INTO STRICT ls_subdistrict_name
    FROM sc_mem_m_ucf_subdistrict WHERE subdistrict_code = as_subdis;
  EXCEPTION
    WHEN no_data_found THEN RETURN as_subdis;   -- ไม่พบ -> คืนรหัสเดิม
    WHEN others THEN NULL;                        -- spa_dberror
  END;
  RETURN trim(ls_subdistrict_name);
EXCEPTION WHEN others THEN RETURN NULL;
END;
$$;
