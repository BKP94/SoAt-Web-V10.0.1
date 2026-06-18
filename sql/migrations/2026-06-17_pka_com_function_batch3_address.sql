-- ============================================================================
-- step 6 function-first sweep — batch 3 (pka_com_function: ที่อยู่ + ยอดคงเหลือ)
-- port: fp_get_member_address(MISSING), fp_get_member_address_line(MISSING),
--       fp_get_member_address_perm(STUB), fp_get_member_address_pres(STUB),
--       fp_get_loan_balance_by_mem(STUB), fp_form_depno(STUB)
-- source: PKA_COM_FUNCTION.sql @25,361,9,17,1786,658
--
-- deviation (Legacy Fidelity):
--  - BULK COLLECT + .Count (return null ถ้า count<>1) -> count(*) ก่อน แล้ว fetch 1 row
--  - spa_dberror(...) -> RETURN NULL / NULL (ตัว logger side-effect)
--  - fp_form_depno: ตัด cache package var is_depMask (perf-only) -> select ทุกครั้ง
-- หมายเหตุ: fp_shr_get_balance_atdate เลื่อน (รอ pka_rep_tel.share_balance_atdate)
-- ============================================================================

-- ---- fp_get_member_address(memno, addtype) : ที่อยู่เต็มบรรทัดเดียว [src 25] -
CREATE OR REPLACE FUNCTION pka_com_function.fp_get_member_address(as_memno text, as_addtype text)
RETURNS text LANGUAGE plpgsql STABLE AS $$
DECLARE
  r record;
  cnt int;
  ls_address text;
  ls_district_name text;
  ls_province_name text;
  ls_tambol text;
BEGIN
  SELECT count(*) INTO cnt FROM sc_mem_m_member_address
   WHERE membership_no = as_memno AND address_type = as_addtype;
  IF cnt = 0 OR cnt > 1 THEN RETURN NULL; END IF;

  SELECT address_no, mooban, moo, road, soi, tambol,
         district_code, province_code, postcode, telephone
    INTO r FROM sc_mem_m_member_address
   WHERE membership_no = as_memno AND address_type = as_addtype;

  ls_address := r.address_no;
  IF length(trim(r.mooban)) > 0 THEN ls_address := ls_address || ' หมู่บ้าน' || trim(r.mooban); END IF;
  IF length(trim(r.moo))    > 0 THEN ls_address := ls_address || ' หมู่ที่ ' || trim(r.moo);   END IF;
  IF length(trim(r.road))   > 0 THEN ls_address := ls_address || ' ถนน'      || trim(r.road);  END IF;
  IF length(trim(r.soi))    > 0 THEN ls_address := ls_address || ' ซอย'      || trim(r.soi);   END IF;
  IF length(trim(r.tambol)) > 0 THEN
    ls_tambol := pka_com_function.fp_get_sub_district_name(r.tambol);
    IF r.province_code = '010' THEN ls_address := ls_address || ' แขวง' || trim(ls_tambol);
    ELSE                            ls_address := ls_address || ' ต.'   || trim(ls_tambol); END IF;
  END IF;
  IF length(trim(r.district_code)) > 0 AND length(trim(r.province_code)) > 0 THEN
    BEGIN
      SELECT district_name INTO STRICT ls_district_name FROM sc_mem_m_ucf_district
       WHERE province_code = r.province_code AND district_code = r.district_code;
    EXCEPTION WHEN others THEN ls_district_name := NULL; END;
    IF length(trim(ls_district_name)) > 0 THEN
      IF r.province_code = '010' THEN ls_address := ls_address || ' เขต' || trim(ls_district_name);
      ELSE                            ls_address := ls_address || ' อ.'  || trim(ls_district_name); END IF;
    END IF;
  END IF;
  IF length(trim(r.province_code)) > 0 THEN
    BEGIN
      SELECT province_name INTO STRICT ls_province_name FROM sc_mem_m_ucf_province
       WHERE province_code = r.province_code;
    EXCEPTION WHEN others THEN ls_province_name := NULL; END;
    IF length(trim(ls_province_name)) > 0 THEN
      IF r.province_code = '010' THEN ls_address := ls_address || ' '    || trim(ls_province_name);
      ELSE                            ls_address := ls_address || ' จ.'  || trim(ls_province_name); END IF;
    END IF;
    IF length(trim(r.postcode)) > 0 THEN ls_address := ls_address || ' ' || trim(r.postcode); END IF;
  END IF;
  IF length(trim(r.telephone)) > 0 THEN ls_address := ls_address || ' โทรศัพท์ ' || trim(r.telephone); END IF;
  RETURN trim(ls_address);
EXCEPTION WHEN others THEN RETURN NULL;
END;
$$;

-- ---- fp_get_member_address_line(memno, addtype) : เหมือน address แต่ trim addr_no, ไม่มีโทร [src 361]
CREATE OR REPLACE FUNCTION pka_com_function.fp_get_member_address_line(as_memno text, as_addtype text)
RETURNS text LANGUAGE plpgsql STABLE AS $$
DECLARE
  r record;
  cnt int;
  ls_address text;
  ls_district_name text;
  ls_province_name text;
  ls_tambol text;
BEGIN
  SELECT count(*) INTO cnt FROM sc_mem_m_member_address
   WHERE membership_no = as_memno AND address_type = as_addtype;
  IF cnt = 0 OR cnt > 1 THEN RETURN NULL; END IF;

  SELECT address_no, mooban, moo, road, soi, tambol,
         district_code, province_code, postcode
    INTO r FROM sc_mem_m_member_address
   WHERE membership_no = as_memno AND address_type = as_addtype;

  ls_address := trim(r.address_no);
  IF length(trim(r.mooban)) > 0 THEN ls_address := ls_address || ' หมู่บ้าน' || trim(r.mooban); END IF;
  IF length(trim(r.moo))    > 0 THEN ls_address := ls_address || ' หมู่ที่ ' || trim(r.moo);   END IF;
  IF length(trim(r.road))   > 0 THEN ls_address := ls_address || ' ถนน'      || trim(r.road);  END IF;
  IF length(trim(r.soi))    > 0 THEN ls_address := ls_address || ' ซอย'      || trim(r.soi);   END IF;
  IF length(trim(r.tambol)) > 0 THEN
    ls_tambol := pka_com_function.fp_get_sub_district_name(r.tambol);
    IF r.province_code = '010' THEN ls_address := ls_address || ' แขวง' || trim(ls_tambol);
    ELSE                            ls_address := ls_address || ' ต.'   || trim(ls_tambol); END IF;
  END IF;
  IF length(trim(r.district_code)) > 0 AND length(trim(r.province_code)) > 0 THEN
    BEGIN
      SELECT district_name INTO STRICT ls_district_name FROM sc_mem_m_ucf_district
       WHERE province_code = r.province_code AND district_code = r.district_code;
    EXCEPTION WHEN others THEN ls_district_name := NULL; END;
    IF length(trim(ls_district_name)) > 0 THEN
      IF r.province_code = '010' THEN ls_address := ls_address || ' เขต' || trim(ls_district_name);
      ELSE                            ls_address := ls_address || ' อ.'  || trim(ls_district_name); END IF;
    END IF;
  END IF;
  IF length(trim(r.province_code)) > 0 THEN
    BEGIN
      SELECT province_name INTO STRICT ls_province_name FROM sc_mem_m_ucf_province
       WHERE province_code = r.province_code;
    EXCEPTION WHEN others THEN ls_province_name := NULL; END;
    IF length(trim(ls_province_name)) > 0 THEN
      IF r.province_code = '010' THEN ls_address := ls_address || ' '    || trim(ls_province_name);
      ELSE                            ls_address := ls_address || ' จ.'  || trim(ls_province_name); END IF;
    END IF;
    IF length(trim(r.postcode)) > 0 THEN ls_address := ls_address || ' ' || trim(r.postcode); END IF;
  END IF;
  RETURN trim(ls_address);
EXCEPTION WHEN others THEN RETURN NULL;
END;
$$;

-- ---- perm/pres : delegate [src 9,17] --------------------------------------
CREATE OR REPLACE FUNCTION pka_com_function.fp_get_member_address_perm(as_memno text)
RETURNS text LANGUAGE plpgsql STABLE AS $$
BEGIN RETURN pka_com_function.fp_get_member_address(as_memno, '1');
EXCEPTION WHEN others THEN RETURN NULL; END;
$$;

CREATE OR REPLACE FUNCTION pka_com_function.fp_get_member_address_pres(as_memno text)
RETURNS text LANGUAGE plpgsql STABLE AS $$
BEGIN RETURN pka_com_function.fp_get_member_address(as_memno, '0');
EXCEPTION WHEN others THEN RETURN NULL; END;
$$;

-- ---- fp_get_loan_balance_by_mem : ยอดเงินกู้คงเหลือ [src 1786] --------------
-- deviation: Oracle return NUMBER แต่คง double precision (stub เดิม) เพราะ view
--   vr_tel_insu_info ผูก signature นี้อยู่ — เลื่อนเปลี่ยนเป็น numeric (ต้อง recreate view)
CREATE OR REPLACE FUNCTION pka_com_function.fp_get_loan_balance_by_mem(as_memno text)
RETURNS double precision LANGUAGE plpgsql STABLE AS $$
DECLARE ldc_sumbal numeric;
BEGIN
  BEGIN
    SELECT sum(principal_balance) INTO ldc_sumbal FROM sc_lon_m_loan_card
     WHERE membership_no = as_memno AND principal_balance > 0;
  EXCEPTION WHEN others THEN NULL; END;
  RETURN coalesce(ldc_sumbal, 0);
EXCEPTION WHEN others THEN RETURN NULL;
END;
$$;

-- ---- fp_form_depno : format เลขบัญชีเงินฝาก [src 658] ----------------------
CREATE OR REPLACE FUNCTION pka_com_function.fp_form_depno(as_depno text)
RETURNS text LANGUAGE plpgsql STABLE AS $$
DECLARE
  ls_format sc_dep_m_constant.edit_mask%type;
  ls_form   text;
BEGIN
  BEGIN SELECT edit_mask INTO ls_format FROM sc_dep_m_constant;
  EXCEPTION WHEN others THEN NULL; END;
  ls_form := pka_com_function.fp_form(as_depno, ls_format);
  RETURN trim(ls_form);
EXCEPTION WHEN others THEN RETURN NULL;
END;
$$;
