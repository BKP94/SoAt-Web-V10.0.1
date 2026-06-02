-- STUB functions สำหรับ Oracle package PKA_ESTATE (Step 6: ให้ ViewDeployer ผ่าน)
-- คืน NULL — PL team จะ implement logic จริงภายหลัง
-- type map: NUMBER->double precision, DATE->timestamp (ตรงกับ ora2pg view columns)
CREATE SCHEMA IF NOT EXISTS pka_estate;

CREATE OR REPLACE FUNCTION pka_estate.fp_get_doc_address(text, double precision)
RETURNS text LANGUAGE sql IMMUTABLE AS $$ SELECT NULL::text $$;

CREATE OR REPLACE FUNCTION pka_estate.fp_get_doc_address(text)
RETURNS text LANGUAGE sql IMMUTABLE AS $$ SELECT NULL::text $$;

CREATE OR REPLACE FUNCTION pka_estate.fp_get_doc_detail(text, double precision)
RETURNS text LANGUAGE sql IMMUTABLE AS $$ SELECT NULL::text $$;

CREATE OR REPLACE FUNCTION pka_estate.fp_get_doc_detail(text)
RETURNS text LANGUAGE sql IMMUTABLE AS $$ SELECT NULL::text $$;
