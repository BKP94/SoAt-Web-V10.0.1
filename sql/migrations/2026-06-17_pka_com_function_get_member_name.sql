-- ============================================================================
-- step 6 (report SQL migration) — rcTeller.memDetail.r_amnat_mem_detail
-- port ของจริงให้ pka_com_function.fp_get_member_name (เดิมเป็น stub SELECT NULL
-- จาก 46 package stub ตอน migrate schema). รายงานนี้เรียกที่ main SQL + subreport
-- coll_nest. source: C:\SoAt_PEAN\Admin\Export\PACKAGE_BODY\PKA_COM_FUNCTION.sql @1345
--
-- มาตรฐานแปล: char/varchar2->text, Oracle `||` (ข้าม null) -> concat(),
--   in('0','0','000') -> in('0','000') (ตัดค่าซ้ำ), %type คงไว้, EXCEPTION เดิมเป๊ะ.
-- ============================================================================

-- fp_get_member_name(memno) [src 1345] : delegate split_prename='0' (ไม่แยกคำนำหน้า)
CREATE OR REPLACE FUNCTION pka_com_function.fp_get_member_name(a_membership_no text)
RETURNS text LANGUAGE plpgsql AS $$
BEGIN
  RETURN pka_com_function.fp_get_member_name(a_membership_no, '0');
END;
$$;

-- fp_get_member_name(memno, split_prename) [src 1348] : prename + ชื่อ + นามสกุล
CREATE OR REPLACE FUNCTION pka_com_function.fp_get_member_name(a_membership_no text, as_split_prename text)
RETURNS text LANGUAGE plpgsql AS $$
DECLARE
  l_member_name    sc_mem_m_membership_registered.member_name%type;
  l_member_surname sc_mem_m_membership_registered.member_surname%type;
  ls_prename_code  sc_mem_m_membership_registered.prename_code%type;
  l_prename        sc_mem_m_ucf_prename.prename%type;
BEGIN
  -- Validate argument
  IF a_membership_no IS NULL OR a_membership_no = ' ' THEN
    RETURN NULL;
  END IF;

  -- Process
  BEGIN -- ทะเบียน
    SELECT member_name, member_surname, prename_code
      INTO l_member_name, l_member_surname, ls_prename_code
    FROM sc_mem_m_membership_registered
    WHERE membership_no = a_membership_no;
  EXCEPTION WHEN OTHERS THEN RETURN NULL;
  END;

  IF ls_prename_code IN ('0','000') OR ls_prename_code IS NULL THEN
    l_prename := NULL; -- <ไม่ระบุ>
  ELSE
    BEGIN
      SELECT prename INTO l_prename
      FROM sc_mem_m_ucf_prename
      WHERE (prename_code = ls_prename_code);
    EXCEPTION WHEN OTHERS THEN l_prename := NULL;
    END;
  END IF;

  IF as_split_prename = '1' THEN
    -- แยกคำนำหน้าชื่อ
    RETURN concat(l_prename, ' ', l_member_name, '  ', l_member_surname);
  ELSE
    -- ไม่แยกคำนำหน้าชื่อ
    RETURN concat(l_prename, l_member_name, '  ', l_member_surname);
  END IF;
EXCEPTION WHEN OTHERS THEN RETURN NULL;
END;
$$;
