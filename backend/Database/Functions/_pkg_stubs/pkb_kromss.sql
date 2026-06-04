-- Package PKB_KROMSS — implemented from Oracle source (legacy_ora_src/PKB_KROMSS.sql)
CREATE SCHEMA IF NOT EXISTS pkb_kromss;

-- fp_get_address_letter: ประกอบที่อยู่สมาชิกเป็น 3 บรรทัด คืนบรรทัดตาม ai_row (0=รวม,1,2,3)
--   as_docplace: 01=ที่ทำงาน 02=ที่อยู่ปัจจุบัน 03=ตามทะเบียนบ้าน 04=หน่วยงาน
CREATE OR REPLACE FUNCTION pkb_kromss.fp_get_address_letter(as_memno text, as_docplace text, ai_row int)
RETURNS varchar LANGUAGE plpgsql STABLE AS $$
DECLARE
  ls_line1 text; ls_line2 text; ls_line3 text;
  ls_address_type text;
  ls_address text; ls_moo text; ls_road text; ls_soi text;
  ls_tambol text; ls_post text; ls_mooban text;
  ls_disname text; ls_provname text; ls_provcode text;
  ls_docplace text; ls_groupnanme text;
BEGIN
  ls_groupnanme := '';
  CASE as_docplace
    WHEN '01' THEN   -- ที่ทำงาน
      ls_address_type := '2';
      SELECT member_group_name INTO STRICT ls_groupnanme
        FROM sc_mem_m_ucf_member_group, sc_mem_m_membership_registered
       WHERE sc_mem_m_membership_registered.member_group_no = sc_mem_m_ucf_member_group.member_group_no
         AND sc_mem_m_membership_registered.membership_no = as_memno;
    WHEN '02' THEN ls_address_type := '0';   -- ที่อยู่ปัจจุบัน
    WHEN '03' THEN ls_address_type := '1';   -- ตามทะเบียนบ้าน
    WHEN '04' THEN ls_address_type := '0';   -- หน่วยงาน (ใช้ที่อยู่ปัจจุบัน)
    ELSE
      RETURN 'ไม่ระบุ';
  END CASE;

  SELECT coalesce(sc_mem_m_member_address.address_no, ' '),
         coalesce(sc_mem_m_member_address.moo, ' '),
         coalesce(sc_mem_m_member_address.road, ' '),
         coalesce(sc_mem_m_member_address.soi, ' '),
         coalesce(sc_mem_m_member_address.tambol, ' '),
         coalesce(sc_mem_m_member_address.postcode, ' '),
         coalesce(sc_mem_m_member_address.mooban, ' '),
         coalesce(sc_mem_m_ucf_district.district_name, ' '),
         coalesce(sc_mem_m_ucf_province.province_name, ' '),
         coalesce(sc_mem_m_member_address.province_code, ' '),
         sc_mem_m_membership_registered.doc_place_status
    INTO STRICT ls_address, ls_moo, ls_road, ls_soi, ls_tambol, ls_post,
         ls_mooban, ls_disname, ls_provname, ls_provcode, ls_docplace
    FROM sc_mem_m_member_address, sc_mem_m_ucf_district,
         sc_mem_m_ucf_province, sc_mem_m_membership_registered
   WHERE sc_mem_m_ucf_district.province_code = sc_mem_m_member_address.province_code
     AND sc_mem_m_ucf_district.district_code = sc_mem_m_member_address.district_code
     AND sc_mem_m_ucf_province.province_code = sc_mem_m_ucf_district.province_code
     AND sc_mem_m_member_address.membership_no = sc_mem_m_membership_registered.membership_no
     AND sc_mem_m_member_address.membership_no = as_memno
     AND sc_mem_m_member_address.address_type = ls_address_type;

  ls_address  := trim(coalesce(ls_address, ' '));
  ls_moo      := trim(coalesce(ls_moo, ' '));
  ls_road     := trim(coalesce(ls_road, ' '));
  ls_soi      := trim(coalesce(ls_soi, ' '));
  ls_tambol   := trim(coalesce(ls_tambol, ' '));
  ls_post     := trim(coalesce(ls_post, ' '));
  ls_mooban   := trim(coalesce(ls_mooban, ' '));
  ls_disname  := trim(coalesce(ls_disname, ' '));
  ls_provname := trim(coalesce(ls_provname, ' '));
  ls_provcode := trim(coalesce(ls_provcode, ' '));
  ls_docplace := trim(coalesce(ls_docplace, ' '));

  IF length(trim(ls_moo))    <> 0 AND trim(ls_moo)    <> '-' THEN ls_moo    := 'หมู่ '||trim(ls_moo);       ELSE ls_moo    := ''; END IF;
  IF length(trim(ls_road))   <> 0 AND trim(ls_road)   <> '-' THEN ls_road   := 'ถนน'||trim(ls_road);        ELSE ls_road   := ''; END IF;
  IF length(trim(ls_soi))    <> 0 AND trim(ls_soi)    <> '-' THEN ls_soi    := 'ซอย'||trim(ls_soi);         ELSE ls_soi    := ''; END IF;
  IF length(trim(ls_mooban)) <> 0 AND trim(ls_mooban) <> '-' THEN ls_mooban := 'หมู่บ้าน'||trim(ls_mooban); ELSE ls_mooban := ''; END IF;

  IF ls_provcode = '10' THEN   -- กรุงเทพฯ → แขวง/เขต
    IF length(trim(ls_tambol)) <> 0 THEN ls_tambol := 'แขวง'||trim(ls_tambol); END IF;
    ls_disname := 'เขต'||ls_disname;
  ELSE                         -- ต่างจังหวัด → ตำบล/อำเภอ/จังหวัด
    IF length(trim(ls_tambol)) <> 0 THEN ls_tambol := 'ตำบล'||trim(ls_tambol); END IF;
    ls_disname  := 'อำเภอ'||trim(ls_disname);
    ls_provname := 'จังหวัด'||trim(ls_provname);
  END IF;

  ls_line1 := trim(coalesce(ls_groupnanme, ''))||'  '||trim(ls_address)||'  '||trim(ls_moo)||'  '||trim(ls_mooban)||'  '||trim(ls_soi);
  ls_line2 := trim(ls_road)||'  '||trim(ls_tambol)||'  '||trim(ls_disname);
  ls_line3 := trim(ls_provname)||'  '||trim(ls_post);

  CASE ai_row
    WHEN 0 THEN RETURN trim(trim(ls_line1)||'  '||trim(ls_line2)||'  '||trim(ls_line3));  -- รวมบรรทัดเดียว
    WHEN 1 THEN RETURN trim(ls_line1);
    WHEN 2 THEN RETURN trim(ls_line2);
    WHEN 3 THEN RETURN trim(ls_line3);
    ELSE RETURN ' ';
  END CASE;

EXCEPTION WHEN OTHERS THEN RETURN 'ไม่สามารถระบุได้';
END;
$$;
