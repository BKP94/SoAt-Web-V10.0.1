-- ============================================================================
-- step 6 (report SQL migration) — function-first sweep #1
-- port pka_com_function.fp_get_thaidate (เดิม STUB SELECT NULL) — ฟังก์ชันที่
-- rcTeller เรียกมากสุด 962 ครั้ง (วันที่ พ.ศ. แบบ token-format)
-- source: C:\SoAt_PEAN\Admin\Export\PACKAGE_BODY\PKA_COM_FUNCTION.sql @949,952
--
-- มาตรฐานแปล / deviation ที่บันทึก:
--  - varchar2/char -> text, date -> timestamp (คง signature เดิมใน PG)
--  - to_char(d,'D') 1=อาทิตย์..7=เสาร์ : PG 'D' = Sunday(1)..Saturday(7) ตรงกัน
--  - var_string(x)='0' (null/blank) -> inline length(trim(coalesce(x,'')))=0
--  - spa_dberror('...') (error logger, side-effect) -> ตัดออก ใช้ RETURN NULL
--    ตาม convention ที่ใช้กับ fp_get_member_name (ไฟล์ port ก่อนหน้า)
--  - **PG vs Oracle replace():** Oracle replace(str,NULL,x)=str เดิม แต่ PG=NULL
--    จึง guard `if token is not null` ก่อน replace ทุกจุด + coalesce ค่าแทนเป็น ''
--    (Oracle replace(str,tok,NULL) = ลบ tok ทิ้ง) เพื่อให้ผลลัพธ์ตรง legacy เป๊ะ
-- ============================================================================

-- overload 1: (timestamp) -> delegate default 'DD/MM/YYYY' [src 949]
CREATE OR REPLACE FUNCTION pka_com_function.fp_get_thaidate(adt_date timestamp)
RETURNS text LANGUAGE plpgsql IMMUTABLE AS $$
BEGIN
  RETURN pka_com_function.fp_get_thaidate(adt_date, 'DD/MM/YYYY');
END;
$$;

-- overload 2: (timestamp, format) [src 952]
CREATE OR REPLACE FUNCTION pka_com_function.fp_get_thaidate(adt_date timestamp, as_format text)
RETURNS text LANGUAGE plpgsql IMMUTABLE AS $$
DECLARE
  ltab_DayText   text[] := ARRAY['อาทิตย์','จันทร์','อังคาร','พุธ','พฤหัสบดี','ศุกร์','เสาร์'];
  ltab_Day_Abbr  text[] := ARRAY['อา','จ','อ','พ','พฤ','ศ','ส'];
  ltab_MonthText text[] := ARRAY['มกราคม','กุมภาพันธ์','มีนาคม','เมษายน','พฤษภาคม','มิถุนายน',
                                 'กรกฎาคม','สิงหาคม','กันยายน','ตุลาคม','พฤศจิกายน','ธันวาคม'];
  ltab_Month_Abbr text[] := ARRAY['ม.ค.','ก.พ.','มี.ค.','เม.ย.','พ.ค.','มิ.ย.',
                                  'ก.ค.','ส.ค.','ก.ย.','ต.ค.','พ.ย.','ธ.ค.'];
  ls_thaidate text;
  ls_day_name text;
  ls_day      text;
  ls_month    text;
  ls_year     text;
  ls_hour     text;
  ls_minute   text;
  ls_socond   text;
  ls_format_dn text;
  ls_format_d  text;
  ls_format_m  text;
  ls_format_y  text;
  ls_format_h  text;
  ls_format_mi text;
  ls_format_s  text;
  lu text := upper(as_format);
BEGIN
  IF adt_date IS NULL THEN RETURN NULL; END IF;

  -- ชื่อวัน ------------------------------------
  IF    strpos(lu,'DAY') > 0 THEN
    ls_format_dn := 'DAY'; ls_day_name := ltab_DayText[to_char(adt_date,'D')::int];
  ELSIF strpos(lu,'DY') > 0 THEN
    ls_format_dn := 'DY';  ls_day_name := ltab_Day_Abbr[to_char(adt_date,'D')::int];
  END IF;

  -- วัน ------------------------------------
  IF    strpos(lu,'DDD') > 0 THEN
    ls_format_d := 'DDD'; ls_day := to_char(adt_date,'DDD');
  ELSIF strpos(lu,'DD') > 0 THEN
    ls_format_d := 'DD';  ls_day := to_char(adt_date,'DD');
  ELSIF strpos(lu,'SD') > 0 THEN
    ls_format_d := 'SD';  ls_day := to_char(adt_date,'DD')::int::text; -- ไม่เอา 0 นำหน้า
  END IF;

  -- เดือน ------------------------------------
  IF    strpos(lu,'MONTH') > 0 THEN
    ls_format_m := 'MONTH'; ls_month := ltab_MonthText[to_char(adt_date,'MM')::int];
  ELSIF strpos(lu,'MON') > 0 THEN
    ls_format_m := 'MON';   ls_month := ltab_Month_Abbr[to_char(adt_date,'MM')::int];
  ELSIF strpos(lu,'MM') > 0 THEN
    ls_format_m := 'MM';    ls_month := to_char(adt_date,'MM');
  END IF;

  -- ปี ---------------------------------------
  ls_year := (extract(year from adt_date)::int + 543)::text;
  IF    strpos(lu,'YYYY') > 0 THEN
    ls_format_y := 'YYYY'; -- ls_year คงเดิม 4 หลัก
  ELSIF strpos(lu,'YYY') > 0 THEN
    ls_format_y := 'YYY';  ls_year := substr(ls_year,2,3);
  ELSIF strpos(lu,'YY') > 0 THEN
    ls_format_y := 'YY';   ls_year := substr(ls_year,3,2);
  END IF;

  -- ชั่วโมง -----------------------------------
  IF    strpos(lu,'HH24') > 0 THEN ls_format_h := 'HH24';
  ELSIF strpos(lu,'HH12') > 0 THEN ls_format_h := 'HH12';
  ELSIF strpos(lu,'HH')   > 0 THEN ls_format_h := 'HH';
  END IF;
  IF length(trim(coalesce(ls_format_h,''))) > 0 THEN ls_hour := to_char(adt_date,ls_format_h); END IF;

  -- นาที -------------------------------------
  IF strpos(lu,'MI') > 0 THEN
    ls_format_mi := 'MI'; ls_minute := to_char(adt_date,'MI');
  END IF;

  -- วินาที ------------------------------------
  IF    strpos(lu,'SSSSS') > 0 THEN ls_format_s := 'SSSSS';
  ELSIF strpos(lu,'SSSS')  > 0 THEN NULL;
  ELSIF strpos(lu,'SSS')   > 0 THEN NULL;
  ELSIF strpos(lu,'SS')    > 0 THEN ls_format_s := 'SS';
  END IF;
  IF length(trim(coalesce(ls_format_s,''))) > 0 THEN ls_socond := to_char(adt_date,ls_format_s); END IF;

  -- รวม --------------------------- (guard null token: PG replace(NULL)=NULL ต่างจาก Oracle)
  ls_thaidate := upper(as_format);
  IF ls_format_dn IS NOT NULL THEN ls_thaidate := replace(ls_thaidate, ls_format_dn, coalesce(ls_day_name,'')); END IF;
  IF ls_format_d  IS NOT NULL THEN ls_thaidate := replace(ls_thaidate, ls_format_d,  coalesce(ls_day,''));      END IF;
  IF ls_format_m  IS NOT NULL THEN ls_thaidate := replace(ls_thaidate, ls_format_m,  coalesce(ls_month,''));    END IF;
  IF ls_format_y  IS NOT NULL THEN ls_thaidate := replace(ls_thaidate, ls_format_y,  coalesce(ls_year,''));     END IF;
  IF ls_format_h  IS NOT NULL THEN ls_thaidate := replace(ls_thaidate, ls_format_h,  coalesce(ls_hour,''));     END IF;
  IF ls_format_mi IS NOT NULL THEN ls_thaidate := replace(ls_thaidate, ls_format_mi, coalesce(ls_minute,''));   END IF;
  IF ls_format_s  IS NOT NULL THEN ls_thaidate := replace(ls_thaidate, ls_format_s,  coalesce(ls_socond,''));   END IF;
  RETURN trim(ls_thaidate);
EXCEPTION WHEN OTHERS THEN RETURN NULL;
END;
$$;
