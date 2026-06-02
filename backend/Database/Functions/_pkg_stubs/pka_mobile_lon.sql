-- STUB functions สำหรับ Oracle package PKA_MOBILE_LON (Step 6: ให้ ViewDeployer ผ่าน)
-- คืน NULL — PL team จะ implement logic จริงภายหลัง
-- type map: NUMBER->double precision, DATE->timestamp (ตรงกับ ora2pg view columns)
CREATE SCHEMA IF NOT EXISTS pka_mobile_lon;

CREATE OR REPLACE FUNCTION pka_mobile_lon.fp_cal_int(text, timestamp)
RETURNS double precision LANGUAGE sql IMMUTABLE AS $$ SELECT NULL::double precision $$;
