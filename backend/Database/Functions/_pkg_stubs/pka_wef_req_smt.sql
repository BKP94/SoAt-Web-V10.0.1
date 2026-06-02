-- STUB functions สำหรับ Oracle package PKA_WEF_REQ_SMT (Step 6: ให้ ViewDeployer ผ่าน)
-- คืน NULL — PL team จะ implement logic จริงภายหลัง
-- type map: NUMBER->double precision, DATE->timestamp (ตรงกับ ora2pg view columns)
CREATE SCHEMA IF NOT EXISTS pka_wef_req_smt;

CREATE OR REPLACE FUNCTION pka_wef_req_smt.fp_cals_paid_rate(double precision)
RETURNS double precision LANGUAGE sql IMMUTABLE AS $$ SELECT NULL::double precision $$;
