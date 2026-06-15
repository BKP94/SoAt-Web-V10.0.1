-- ============================================================================
-- 2026-06-12_pka_com_function_form_address.sql
-- Report migration Step 6 — pka_com_function: fn ที่รายงาน rcTeller.memDetail
-- (r_amnat_member_list_by_group_format) เรียกแต่ยังไม่ถูกสร้างใน PG
--
-- ที่มา: /pilot-test รายงานนำร่อง fail ที่ 42883 function ไม่มี — ขาด 4 fn:
--        fp_form_idcard → fp_form → fp_form_char2value (chain format),
--        fp_get_member_address_letter (dependency fp_get_sub_district_name มีแล้ว)
-- source Oracle: C:\SoAt_PEAN\Admin\Export\PACKAGE_BODY\PKA_COM_FUNCTION.sql
--
-- มาตรฐานแปล Oracle→PG (ตาม [[project-trigger-migration-gap]] / blockB_tier1):
--   - แปล body 1:1 (fidelity); ตัด `EXCEPTION WHEN OTHERS THEN spa_dberror(...)` ออก
--   - return char '1'/'0' ของ Oracle → varchar (ค่าเทียบเหมือนเดิม)
--   - Oracle `||` ทน NULL (NULL||x = x) → ใช้ `concat()` ของ PG (ละ NULL เป็น '')
--     เพื่อคง semantics เดิมเป๊ะ ใน accumulator ที่อาจเริ่มจาก NULL
--   - cross-fn call qualify schema เสมอ (pka_com_function.*), ตาราง unqualified
--   - idempotent (CREATE OR REPLACE) ปลอดภัยรันซ้ำ
-- ============================================================================

CREATE SCHEMA IF NOT EXISTS pka_com_function;

-- =====================================================================
-- 1) fp_form_char2value — format char ตัวนี้เป็น "ช่องรับค่า" (1) หรือ "อักขระคงที่" (0)
--    leaf fn (ไม่พึ่งใคร) — legacy PKA_COM_FUNCTION.sql:755
-- =====================================================================
CREATE OR REPLACE FUNCTION pka_com_function.fp_form_char2value(as_char varchar)
RETURNS varchar LANGUAGE sql IMMUTABLE AS $$
  SELECT CASE
           WHEN as_char IS NULL OR as_char = ' ' THEN '0'
           WHEN as_char IN ('x','X','@','T','Y','M','D','B','#') THEN '1'  -- ช่องรับค่า
           ELSE '0'                                                         -- อักขระคงที่ของ format
         END
$$;

-- =====================================================================
-- 2) fp_form — เติมค่า as_value ลงในรูปแบบ as_format (เช่น 'X-XXXX-XXXXX-XX-X')
--    legacy PKA_COM_FUNCTION.sql:777 — replace ทีละ key (X ที่เพิ่งต่อท้าย) เป็นเลขจริง
-- =====================================================================
CREATE OR REPLACE FUNCTION pka_com_function.fp_form(as_value varchar, as_format varchar)
RETURNS varchar LANGUAGE plpgsql IMMUTABLE AS $$
DECLARE
  ls_form         varchar := '';
  ls_key          varchar;
  ls_val          varchar;
  li_count_format int := 0;
  li_count_value  int := 0;
  li_length_value int;
BEGIN
  li_count_format := length(trim(as_format));
  FOR i IN 1..li_count_format LOOP
    ls_key  := upper(substr(as_format, i, 1));
    ls_form := ls_form || upper(ls_key);
    IF pka_com_function.fp_form_char2value(ls_key) = '1' THEN
      li_count_value := li_count_value + 1;
      ls_val := substr(as_value, li_count_value, 1);   -- ไม่ trim (legacy)
      IF ls_val IS NULL OR ls_val = '' THEN            -- Oracle substr เกินขอบ = NULL
        ls_val := ' ';
      END IF;
      ls_form := replace(ls_form, ls_key, ls_val);
    END IF;
  END LOOP;
  li_length_value := length(trim(as_value));
  IF li_count_value < li_length_value THEN
    ls_form := ls_form || substr(as_value, li_count_value + 1, li_length_value - li_count_value);
  END IF;
  RETURN ls_form;
END $$;

-- =====================================================================
-- 3) fp_form_idcard — format เลขบัตร ปชช. 'X-XXXX-XXXXX-XX-X'
--    legacy PKA_COM_FUNCTION.sql:678 (declare %type แต่ hardcode mask → คง hardcode)
-- =====================================================================
CREATE OR REPLACE FUNCTION pka_com_function.fp_form_idcard(as_idcard varchar)
RETURNS varchar LANGUAGE plpgsql IMMUTABLE AS $$
DECLARE
  ls_mask varchar := 'X-XXXX-XXXXX-XX-X';
BEGIN
  RETURN pka_com_function.fp_form(trim(as_idcard), trim(ls_mask));
END $$;

-- =====================================================================
-- 4) fp_get_member_address_letter — ที่อยู่สมาชิกราย "บรรทัด" (li_line 1-15)
--    legacy PKA_COM_FUNCTION.sql:130 — BULK COLLECT → count แล้ว select เดี่ยว
--    เงื่อนไข: ต้องเจอ "พอดี 1 แถว" เท่านั้น (0 หรือ >1 → NULL)
--    dependency: pka_com_function.fp_get_sub_district_name (มีแล้วใน PG)
--    NOTE: รายงานนำร่องใช้แค่ line 1-4 แต่ port ครบ 1-15 ตาม fidelity
--    DEVIATION (เล็ก): li_line นอก 1-15 → Oracle เข้า CASE_NOT_FOUND แล้ว
--      exception handler คืน null (dead code `return ' '`). PG ใช้ ELSE RETURN NULL
--      ให้ผลเท่ากัน (รายงานไม่เคยเรียกนอกช่วงนี้)
-- =====================================================================
CREATE OR REPLACE FUNCTION pka_com_function.fp_get_member_address_letter(
  as_memno varchar, as_addtype varchar, li_line int)
RETURNS varchar LANGUAGE plpgsql STABLE AS $$
DECLARE
  r                   record;
  li_count            int;
  ls_district_name    varchar;
  ls_province_name    varchar;
  ls_tambol           varchar;
  ls_subdistrict_name varchar;
  ls_address1  varchar;  ls_address2  varchar;  ls_address3  varchar;
  ls_address4  varchar;  ls_address5  varchar;  ls_address6  varchar;
  ls_address7  varchar;  ls_address8  varchar;  ls_address9  varchar;
  ls_address10 varchar;  ls_address11 varchar;  ls_address12 varchar;
  ls_address13 varchar;  ls_address14 varchar;  ls_address15 varchar;
BEGIN
  SELECT count(*) INTO li_count
  FROM sc_mem_m_member_address
  WHERE membership_no = as_memno
    AND address_type = as_addtype;

  IF li_count = 0 OR li_count > 1 THEN
    RETURN NULL;
  END IF;

  SELECT address_no, mooban, moo, road, soi, tambol,
         district_code, province_code, postcode, telephone
  INTO r
  FROM sc_mem_m_member_address
  WHERE membership_no = as_memno
    AND address_type = as_addtype;

  CASE li_line
  WHEN 1 THEN
    ls_address1 := trim(r.address_no);
    IF length(trim(r.mooban)) > 0 THEN
      ls_address1 := concat(ls_address1, ' หมู่บ้าน', trim(r.mooban));
    END IF;
    IF length(trim(r.moo)) > 0 THEN
      ls_address1 := concat(ls_address1, ' หมู่ที่ ', trim(r.moo));
    END IF;
    RETURN ls_address1;

  WHEN 2 THEN
    IF length(trim(r.road)) > 0 THEN
      ls_address2 := concat(ls_address2, ' ถนน', trim(r.road));
    END IF;
    IF length(trim(r.soi)) > 0 THEN
      ls_address2 := concat(ls_address2, ' ซอย', trim(r.soi));
    END IF;
    IF length(trim(r.tambol)) > 0 THEN
      ls_tambol := pka_com_function.fp_get_sub_district_name(r.tambol);
      IF r.province_code = '010' THEN
        ls_address2 := concat(ls_address2, ' แขวง', trim(ls_tambol));
      ELSE
        ls_address2 := concat(ls_address2, ' ต.', trim(ls_tambol));
      END IF;
    END IF;
    RETURN ls_address2;

  WHEN 3 THEN
    IF length(trim(r.district_code)) > 0 THEN
      IF length(trim(r.province_code)) > 0 THEN
        BEGIN
          SELECT district_name INTO ls_district_name
          FROM sc_mem_m_ucf_district
          WHERE province_code = r.province_code
            AND district_code = r.district_code;
        EXCEPTION WHEN OTHERS THEN ls_district_name := NULL;
        END;
        IF length(trim(ls_district_name)) > 0 THEN
          IF r.province_code = '010' THEN
            ls_address3 := concat(ls_address3, ' เขต', trim(ls_district_name));
          ELSE
            ls_address3 := concat(ls_address3, ' อ.', trim(ls_district_name));
          END IF;
        END IF;
      END IF;
    END IF;
    RETURN ls_address3;

  WHEN 4 THEN
    IF length(trim(r.province_code)) > 0 THEN
      BEGIN
        SELECT province_name INTO ls_province_name
        FROM sc_mem_m_ucf_province
        WHERE province_code = r.province_code;
      EXCEPTION WHEN OTHERS THEN ls_province_name := NULL;
      END;
      IF length(trim(ls_province_name)) > 0 THEN
        IF r.province_code = '010' THEN
          ls_address4 := concat(ls_address4, ' ', trim(ls_province_name));
        ELSE
          ls_address4 := concat(ls_address4, ' จ.', trim(ls_province_name));
        END IF;
      END IF;
      IF length(trim(r.postcode)) > 0 THEN
        ls_address4 := concat(ls_address4, ' ', trim(r.postcode));
      END IF;
    END IF;
    RETURN ls_address4;

  WHEN 5 THEN
    IF length(trim(r.telephone)) > 0 THEN
      ls_address5 := concat(ls_address5, ' โทรศัพท์ ', trim(r.telephone));
    END IF;
    RETURN ls_address5;

  WHEN 6 THEN
    ls_address6 := trim(r.address_no);
    RETURN ls_address6;

  WHEN 7 THEN
    IF length(trim(r.mooban)) > 0 THEN ls_address7 := trim(r.mooban); ELSE ls_address7 := '-'; END IF;
    RETURN ls_address7;

  WHEN 8 THEN
    IF length(trim(r.moo)) > 0 THEN ls_address8 := trim(r.moo); ELSE ls_address8 := '-'; END IF;
    RETURN ls_address8;

  WHEN 9 THEN
    IF length(trim(r.road)) > 0 THEN ls_address9 := trim(r.road); ELSE ls_address9 := '-'; END IF;
    RETURN ls_address9;

  WHEN 10 THEN
    IF length(trim(r.soi)) > 0 THEN ls_address10 := trim(r.soi); ELSE ls_address10 := '-'; END IF;
    RETURN ls_address10;

  WHEN 11 THEN
    IF length(trim(r.tambol)) > 0 THEN
      BEGIN
        SELECT subdistrict_name INTO ls_subdistrict_name
        FROM sc_mem_m_ucf_subdistrict
        WHERE subdistrict_code = r.tambol;
      EXCEPTION WHEN OTHERS THEN ls_subdistrict_name := NULL;
      END;
      IF length(trim(ls_subdistrict_name)) > 0 THEN
        ls_address11 := trim(ls_subdistrict_name);
      END IF;
    ELSE
      ls_address11 := '-';
    END IF;
    RETURN ls_address11;

  WHEN 12 THEN
    IF length(trim(r.district_code)) > 0 THEN
      IF length(trim(r.province_code)) > 0 THEN
        BEGIN
          SELECT district_name INTO ls_district_name
          FROM sc_mem_m_ucf_district
          WHERE province_code = r.province_code
            AND district_code = r.district_code;
        EXCEPTION WHEN OTHERS THEN ls_district_name := NULL;
        END;
        IF length(trim(ls_district_name)) > 0 THEN
          ls_address12 := trim(ls_district_name);
        END IF;
      END IF;
    ELSE
      ls_address12 := '-';
    END IF;
    RETURN ls_address12;

  WHEN 13 THEN
    IF length(trim(r.province_code)) > 0 THEN
      BEGIN
        SELECT province_name INTO ls_province_name
        FROM sc_mem_m_ucf_province
        WHERE province_code = r.province_code;
      EXCEPTION WHEN OTHERS THEN ls_province_name := NULL;
      END;
      IF length(trim(ls_province_name)) > 0 THEN
        ls_address13 := trim(ls_province_name);
      END IF;
    ELSE
      ls_address13 := '-';
    END IF;
    RETURN ls_address13;

  WHEN 14 THEN
    IF length(trim(r.province_code)) > 0 THEN
      -- Oracle select province_name แต่ไม่ใช้ (คง logic เดิม: คืน postcode)
      BEGIN
        SELECT province_name INTO ls_province_name
        FROM sc_mem_m_ucf_province
        WHERE province_code = r.province_code;
      EXCEPTION WHEN OTHERS THEN ls_province_name := NULL;
      END;
      IF length(trim(r.postcode)) > 0 THEN
        ls_address14 := trim(r.postcode);
      END IF;
    ELSE
      ls_address14 := '-';
    END IF;
    RETURN ls_address14;

  WHEN 15 THEN
    IF length(trim(r.telephone)) > 0 THEN ls_address15 := trim(r.telephone); ELSE ls_address15 := '-'; END IF;
    RETURN ls_address15;

  ELSE
    RETURN NULL;   -- li_line นอก 1-15 (ดู DEVIATION ด้านบน)
  END CASE;
END $$;
