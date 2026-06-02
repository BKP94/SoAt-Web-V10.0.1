-- STUB functions สำหรับ Oracle package PKA_HR_OFF_MEMBER (Step 6: ให้ ViewDeployer ผ่าน)
-- คืน NULL — PL team จะ implement logic จริงภายหลัง
-- type map: NUMBER->double precision, DATE->timestamp (ตรงกับ ora2pg view columns)
CREATE SCHEMA IF NOT EXISTS pka_hr_off_member;

CREATE OR REPLACE FUNCTION pka_hr_off_member.fp_get_off_name(text)
RETURNS text LANGUAGE sql IMMUTABLE AS $$ SELECT NULL::text $$;
