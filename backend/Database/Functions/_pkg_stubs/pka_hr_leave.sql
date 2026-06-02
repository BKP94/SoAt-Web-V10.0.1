-- STUB functions สำหรับ Oracle package PKA_HR_LEAVE (Step 6: ให้ ViewDeployer ผ่าน)
-- คืน NULL — PL team จะ implement logic จริงภายหลัง
-- type map: NUMBER->double precision, DATE->timestamp (ตรงกับ ora2pg view columns)
CREATE SCHEMA IF NOT EXISTS pka_hr_leave;

CREATE OR REPLACE FUNCTION pka_hr_leave.fp_count_leave_by_type(text, text, integer)
RETURNS double precision LANGUAGE sql IMMUTABLE AS $$ SELECT NULL::double precision $$;

CREATE OR REPLACE FUNCTION pka_hr_leave.fp_count_time_by_type(text, text, integer)
RETURNS integer LANGUAGE sql IMMUTABLE AS $$ SELECT NULL::integer $$;
