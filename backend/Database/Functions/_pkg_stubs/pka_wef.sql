-- STUB functions สำหรับ Oracle package PKA_WEF (Step 6: ให้ ViewDeployer ผ่าน)
-- คืน NULL — PL team จะ implement logic จริงภายหลัง
-- type map: NUMBER->double precision, DATE->timestamp (ตรงกับ ora2pg view columns)
CREATE SCHEMA IF NOT EXISTS pka_wef;

CREATE OR REPLACE FUNCTION pka_wef.fp_wef_paid_desc(text, text)
RETURNS text LANGUAGE sql IMMUTABLE AS $$ SELECT NULL::text $$;

CREATE OR REPLACE FUNCTION pka_wef.fp_wef_paid_money(text, text)
RETURNS text LANGUAGE sql IMMUTABLE AS $$ SELECT NULL::text $$;
