-- STUB functions สำหรับ Oracle package PKA_LON_REQSRV (Step 6: ให้ ViewDeployer ผ่าน)
-- คืน NULL — PL team จะ implement logic จริงภายหลัง
-- type map: NUMBER->double precision, DATE->timestamp (ตรงกับ ora2pg view columns)
CREATE SCHEMA IF NOT EXISTS pka_lon_reqsrv;

CREATE OR REPLACE FUNCTION pka_lon_reqsrv.fp_calc_agetext(integer)
RETURNS text LANGUAGE sql IMMUTABLE AS $$ SELECT NULL::text $$;

CREATE OR REPLACE FUNCTION pka_lon_reqsrv.fp_calc_agetext(timestamp, timestamp)
RETURNS text LANGUAGE sql IMMUTABLE AS $$ SELECT NULL::text $$;

CREATE OR REPLACE FUNCTION pka_lon_reqsrv.fp_calc_agetext(integer, text, text, text)
RETURNS text LANGUAGE sql IMMUTABLE AS $$ SELECT NULL::text $$;

CREATE OR REPLACE FUNCTION pka_lon_reqsrv.fp_isvalid_memloan_collfree(text)
RETURNS text LANGUAGE sql IMMUTABLE AS $$ SELECT NULL::text $$;
