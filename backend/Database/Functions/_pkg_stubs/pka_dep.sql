-- STUB functions สำหรับ Oracle package PKA_DEP (Step 6: ให้ ViewDeployer ผ่าน)
-- คืน NULL — PL team จะ implement logic จริงภายหลัง
-- type map: NUMBER->double precision, DATE->timestamp (ตรงกับ ora2pg view columns)
CREATE SCHEMA IF NOT EXISTS pka_dep;

CREATE OR REPLACE FUNCTION pka_dep.fp_get_print_code(text, text)
RETURNS text LANGUAGE sql IMMUTABLE AS $$ SELECT NULL::text $$;
