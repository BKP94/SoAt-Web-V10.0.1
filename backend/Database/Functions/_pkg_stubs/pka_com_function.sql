-- STUB functions สำหรับ Oracle package PKA_COM_FUNCTION (Step 6: ให้ ViewDeployer ผ่าน)
-- คืน NULL — PL team จะ implement logic จริงภายหลัง
-- type map: NUMBER->double precision, DATE->timestamp (ตรงกับ ora2pg view columns)
CREATE SCHEMA IF NOT EXISTS pka_com_function;

CREATE OR REPLACE FUNCTION pka_com_function.fp_get_member_address_pres(text)
RETURNS text LANGUAGE sql IMMUTABLE AS $$ SELECT NULL::text $$;

CREATE OR REPLACE FUNCTION pka_com_function.fp_get_sub_district_name(text)
RETURNS text LANGUAGE sql IMMUTABLE AS $$ SELECT NULL::text $$;

CREATE OR REPLACE FUNCTION pka_com_function.fp_form_depno(text)
RETURNS text LANGUAGE sql IMMUTABLE AS $$ SELECT NULL::text $$;

CREATE OR REPLACE FUNCTION pka_com_function.fp_get_group_name(text)
RETURNS text LANGUAGE sql IMMUTABLE AS $$ SELECT NULL::text $$;

CREATE OR REPLACE FUNCTION pka_com_function.fp_get_group_name_mem(text)
RETURNS text LANGUAGE sql IMMUTABLE AS $$ SELECT NULL::text $$;

CREATE OR REPLACE FUNCTION pka_com_function.fp_get_loan_balance_by_mem(text)
RETURNS double precision LANGUAGE sql IMMUTABLE AS $$ SELECT NULL::double precision $$;

CREATE OR REPLACE FUNCTION pka_com_function.fp_get_member_address_perm(text)
RETURNS text LANGUAGE sql IMMUTABLE AS $$ SELECT NULL::text $$;

CREATE OR REPLACE FUNCTION pka_com_function.fp_get_member_name(text)
RETURNS text LANGUAGE sql IMMUTABLE AS $$ SELECT NULL::text $$;

CREATE OR REPLACE FUNCTION pka_com_function.fp_get_member_name(text, text)
RETURNS text LANGUAGE sql IMMUTABLE AS $$ SELECT NULL::text $$;

CREATE OR REPLACE FUNCTION pka_com_function.fp_get_moneythai(double precision)
RETURNS text LANGUAGE sql IMMUTABLE AS $$ SELECT NULL::text $$;

CREATE OR REPLACE FUNCTION pka_com_function.fp_get_thaidate(timestamp)
RETURNS text LANGUAGE sql IMMUTABLE AS $$ SELECT NULL::text $$;

CREATE OR REPLACE FUNCTION pka_com_function.fp_get_thaidate(timestamp, text)
RETURNS text LANGUAGE sql IMMUTABLE AS $$ SELECT NULL::text $$;

CREATE OR REPLACE FUNCTION pka_com_function.fp_shr_get_balance_atdate(text, timestamp)
RETURNS double precision LANGUAGE sql IMMUTABLE AS $$ SELECT NULL::double precision $$;
