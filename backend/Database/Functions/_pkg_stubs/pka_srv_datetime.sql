-- STUB functions สำหรับ Oracle package PKA_SRV_DATETIME (Step 6: ให้ ViewDeployer ผ่าน)
-- คืน NULL — PL team จะ implement logic จริงภายหลัง
-- type map: NUMBER->double precision, DATE->timestamp (ตรงกับ ora2pg view columns)
CREATE SCHEMA IF NOT EXISTS pka_srv_datetime;

CREATE OR REPLACE FUNCTION pka_srv_datetime.fp_monthsafter(timestamp, timestamp)
RETURNS integer LANGUAGE sql IMMUTABLE AS $$ SELECT NULL::integer $$;

CREATE OR REPLACE FUNCTION pka_srv_datetime.fp_relativemonth(timestamp, integer)
RETURNS timestamp LANGUAGE sql IMMUTABLE AS $$ SELECT NULL::timestamp $$;
