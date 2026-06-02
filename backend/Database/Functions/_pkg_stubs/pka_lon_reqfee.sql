-- STUB functions สำหรับ Oracle package PKA_LON_REQFEE (Step 6: ให้ ViewDeployer ผ่าน)
-- คืน NULL — PL team จะ implement logic จริงภายหลัง
-- type map: NUMBER->double precision, DATE->timestamp (ตรงกับ ora2pg view columns)
CREATE SCHEMA IF NOT EXISTS pka_lon_reqfee;

CREATE OR REPLACE FUNCTION pka_lon_reqfee.fp_port_calc_insure_duty(double precision)
RETURNS double precision LANGUAGE sql IMMUTABLE AS $$ SELECT NULL::double precision $$;

CREATE OR REPLACE FUNCTION pka_lon_reqfee.fp_port_calc_insure_full(double precision)
RETURNS double precision LANGUAGE sql IMMUTABLE AS $$ SELECT NULL::double precision $$;

CREATE OR REPLACE FUNCTION pka_lon_reqfee.fp_port_calc_insure_tax(double precision, double precision)
RETURNS double precision LANGUAGE sql IMMUTABLE AS $$ SELECT NULL::double precision $$;
