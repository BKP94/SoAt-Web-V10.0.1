-- ============================================================================
-- 2026-06-06_pka_trigger_infra.sql
-- เติม "Oracle package layer" ที่ trigger (TBIU) ต้องใช้ — migration gap จาก Oracle→PG
--
-- ปัญหา: trigger functions ที่ migrate มาอ้าง object ของ Oracle package ที่ไม่เคยถูก
--        สร้างใน PG → insert/update ระเบิด (เช่น 42P01 "missing FROM-clause entry for
--        table pka" ที่ if pka.auto_entry)
--
-- สิ่งที่ทำ:
--   1) login getters (PKA_COM_FUNCTION.fp_login_*)  → อ่าน session GUC ที่ sc.db เซ็ต
--      (sc.db ทำ SET LOCAL app.login_id / app.login_br / app.login_pc ต่อ request)
--   2) error raisers (spa_dberror / spa_dberrcol)     → RAISE EXCEPTION (Oracle raise_app_error)
--   3) getdefault (PKA_SRV_DBATTRIB)                  → stub คืน NULL (PL team ใส่ logic จริงภายหลัง)
--   4) rewrite package-VARIABLE (เรียกแบบไม่มีวงเล็บ → PG parse เป็น table.column ไม่ได้)
--      ในทุก trigger function: pka.auto_entry/auto_seqno/iscoop→true, pka.today→current_date,
--      pka_com_login.login_*→current_setting(...)
--
-- หมายเหตุ: idempotent (CREATE OR REPLACE). ปลอดภัยรันซ้ำได้
-- ============================================================================

-- 1) ── login getters ───────────────────────────────────────────────────────
CREATE SCHEMA IF NOT EXISTS pka_com_function;

CREATE OR REPLACE FUNCTION pka_com_function.fp_login_id() RETURNS varchar
LANGUAGE sql STABLE AS $$ SELECT current_setting('app.login_id', true) $$;

CREATE OR REPLACE FUNCTION pka_com_function.fp_login_br() RETURNS varchar
LANGUAGE sql STABLE AS $$ SELECT current_setting('app.login_br', true) $$;

CREATE OR REPLACE FUNCTION pka_com_function.fp_login_pc() RETURNS varchar
LANGUAGE sql STABLE AS $$ SELECT current_setting('app.login_pc', true) $$;

-- 2) ── error raisers (เรียกผ่าน CALL ใน trigger) ────────────────────────────
CREATE OR REPLACE PROCEDURE spa_dberror(p_msg text)
LANGUAGE plpgsql AS $$
BEGIN
  RAISE EXCEPTION '%', p_msg USING ERRCODE = 'P0001';
END $$;

-- spa_dberrcol(table, column, value) — overload ตามชนิด value ที่ trigger ส่งมา
-- (varchar→text, numeric/int→numeric, real/float→double, timestamp, date)
CREATE OR REPLACE PROCEDURE spa_dberrcol(p_table text, p_col text, p_val text)
LANGUAGE plpgsql AS $$
BEGIN
  RAISE EXCEPTION 'ข้อมูลไม่ถูกต้อง/ต้องระบุ: %.% = [%]', p_table, p_col, coalesce(p_val, '<null>')
    USING ERRCODE = 'P0001';
END $$;

CREATE OR REPLACE PROCEDURE spa_dberrcol(p_table text, p_col text, p_val numeric)
LANGUAGE plpgsql AS $$ BEGIN CALL spa_dberrcol(p_table, p_col, p_val::text); END $$;

CREATE OR REPLACE PROCEDURE spa_dberrcol(p_table text, p_col text, p_val double precision)
LANGUAGE plpgsql AS $$ BEGIN CALL spa_dberrcol(p_table, p_col, p_val::text); END $$;

CREATE OR REPLACE PROCEDURE spa_dberrcol(p_table text, p_col text, p_val timestamp without time zone)
LANGUAGE plpgsql AS $$ BEGIN CALL spa_dberrcol(p_table, p_col, p_val::text); END $$;

CREATE OR REPLACE PROCEDURE spa_dberrcol(p_table text, p_col text, p_val date)
LANGUAGE plpgsql AS $$ BEGIN CALL spa_dberrcol(p_table, p_col, p_val::text); END $$;

-- 3) ── getdefault stub (อ่าน default ของ column จาก metadata — Oracle dbattrib) ─
CREATE SCHEMA IF NOT EXISTS pka_srv_dbattrib;
CREATE OR REPLACE FUNCTION pka_srv_dbattrib.getdefault(p_table text, p_col text) RETURNS text
LANGUAGE sql IMMUTABLE AS $$ SELECT NULL::text $$;

-- 4) ── rewrite package-variable refs (no-paren) ในทุก trigger function ───────
SET check_function_bodies = off;   -- กัน CREATE ล้ม ถ้า body มีปัญหาอื่นค้างอยู่ (ไม่ทำให้แย่ลง)
DO $do$
DECLARE
  r record;
  s text;
  n int := 0;
BEGIN
  FOR r IN
    SELECT p.oid, pg_get_functiondef(p.oid) AS def
    FROM pg_proc p
    WHERE p.prorettype = 'pg_catalog.trigger'::regtype
      AND (p.prosrc ~ 'pka\.(auto_entry|auto_seqno|iscoop|today)\y'
        OR p.prosrc ~ 'pka_com_login\.(login_pc|login_app|login_curdir|login_id|login_br)\y')
  LOOP
    s := r.def;
    s := regexp_replace(s, 'pka\.auto_entry\y',           'true',          'g');
    s := regexp_replace(s, 'pka\.auto_seqno\y',           'true',          'g');
    s := regexp_replace(s, 'pka\.iscoop\y',               'true',          'g');
    s := regexp_replace(s, 'pka\.today\y',                'current_date',  'g');
    s := regexp_replace(s, 'pka_com_login\.login_pc\y',     'current_setting(''app.login_pc'', true)',     'g');
    s := regexp_replace(s, 'pka_com_login\.login_app\y',    'current_setting(''app.login_app'', true)',    'g');
    s := regexp_replace(s, 'pka_com_login\.login_curdir\y', 'current_setting(''app.login_curdir'', true)', 'g');
    s := regexp_replace(s, 'pka_com_login\.login_id\y',     'current_setting(''app.login_id'', true)',     'g');
    s := regexp_replace(s, 'pka_com_login\.login_br\y',     'current_setting(''app.login_br'', true)',     'g');
    EXECUTE s;
    n := n + 1;
  END LOOP;
  RAISE NOTICE 'rewrote % trigger function(s)', n;
END $do$;
