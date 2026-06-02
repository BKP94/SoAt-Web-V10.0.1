-- STUB functions สำหรับ Oracle package PKA_REP_ESTATE (Step 6: ให้ ViewDeployer ผ่าน)
-- คืน NULL — PL team จะ implement logic จริงภายหลัง
-- type map: NUMBER->double precision, DATE->timestamp (ตรงกับ ora2pg view columns)
CREATE SCHEMA IF NOT EXISTS pka_rep_estate;

CREATE OR REPLACE FUNCTION pka_rep_estate.fp_get_deed_no(text, text)
RETURNS text LANGUAGE sql IMMUTABLE AS $$ SELECT NULL::text $$;

CREATE OR REPLACE FUNCTION pka_rep_estate.fp_get_home_info(text, text)
RETURNS text LANGUAGE sql IMMUTABLE AS $$ SELECT NULL::text $$;

CREATE OR REPLACE FUNCTION pka_rep_estate.fp_get_law_house(text, text)
RETURNS text LANGUAGE sql IMMUTABLE AS $$ SELECT NULL::text $$;

CREATE OR REPLACE FUNCTION pka_rep_estate.fp_get_law_house(text, double precision)
RETURNS text LANGUAGE sql IMMUTABLE AS $$ SELECT NULL::text $$;
