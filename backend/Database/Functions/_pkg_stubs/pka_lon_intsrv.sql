-- STUB functions สำหรับ Oracle package PKA_LON_INTSRV (Step 6: ให้ ViewDeployer ผ่าน)
-- คืน NULL — PL team จะ implement logic จริงภายหลัง
-- type map: NUMBER->double precision, DATE->timestamp (ตรงกับ ora2pg view columns)
CREATE SCHEMA IF NOT EXISTS pka_lon_intsrv;

CREATE OR REPLACE FUNCTION pka_lon_intsrv.fp_calint(text, timestamp, double precision, timestamp, text)
RETURNS double precision LANGUAGE sql IMMUTABLE AS $$ SELECT NULL::double precision $$;

CREATE OR REPLACE FUNCTION pka_lon_intsrv.fp_calint(text, text, double precision, timestamp, timestamp, double precision, text, text, boolean)
RETURNS double precision LANGUAGE sql IMMUTABLE AS $$ SELECT NULL::double precision $$;

CREATE OR REPLACE FUNCTION pka_lon_intsrv.fp_calint(text, timestamp)
RETURNS double precision LANGUAGE sql IMMUTABLE AS $$ SELECT NULL::double precision $$;
