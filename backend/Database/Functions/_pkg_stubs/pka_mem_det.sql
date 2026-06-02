-- STUB functions สำหรับ Oracle package PKA_MEM_DET (Step 6: ให้ ViewDeployer ผ่าน)
-- คืน NULL — PL team จะ implement logic จริงภายหลัง
-- type map: NUMBER->double precision, DATE->timestamp (ตรงกับ ora2pg view columns)
CREATE SCHEMA IF NOT EXISTS pka_mem_det;

CREATE OR REPLACE FUNCTION pka_mem_det.fp_atm_balance(text)
RETURNS text LANGUAGE sql IMMUTABLE AS $$ SELECT NULL::text $$;

CREATE OR REPLACE FUNCTION pka_mem_det.fp_atm_status_desc_conno(text)
RETURNS text LANGUAGE sql IMMUTABLE AS $$ SELECT NULL::text $$;

CREATE OR REPLACE FUNCTION pka_mem_det.fp_loan_det(text)
RETURNS text LANGUAGE sql IMMUTABLE AS $$ SELECT NULL::text $$;
