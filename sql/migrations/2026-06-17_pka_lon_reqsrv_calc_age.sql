-- ============================================================================
-- step 6 (report SQL migration) — rcTeller.memDetail.r_amnat_mem_detail
-- migrate PL/SQL ที่รายงานนี้เรียกแต่ยังไม่มีใน PG: ตระกูลคำนวณ "อายุ" 2 สาย
--   age_life_text = pka_lon_reqsrv.fp_calc_agetext_m_live(memno)
--   age_mem_text  = pka_lon_reqsrv.fp_calc_agetext( fp_calc_install_m_age(memno) )
-- source: C:\SoAt_PEAN\Admin\Export\PACKAGE_BODY\PKA_LON_REQSRV.sql
--
-- มีใน PG อยู่แล้ว (ไม่สร้างซ้ำ): fp_calc_agetext(integer / integer,text,text,text /
--   timestamp,timestamp), fp_calc_install_m_live(timestamp) 1-arg,
--   pka_srv_datetime.fp_monthsafter/fp_firstdayofmonth/fp_lastdayofmonth,
--   pka.iscoop, public.nvn, pka_com_valid.var_date
--
-- มาตรฐานแปล (เทียบ blockB_tier1 / pka_com_function_form_address):
--   Oracle date->timestamp, char/varchar2->text, pls_integer->integer,
--   nvl->coalesce, ตัด spa_dberror (เก็บ control-flow เดิม: handler ที่ไม่มี return ->
--   `NULL` no-op continue; handler ที่ return null -> RETURN NULL),
--   raise_application_error -> RAISE EXCEPTION, qualify cross-schema call, idempotent.
--
-- DEFERRED (บันทึก): fp_calc_install_m_age(text,timestamp) คงสาขา legacy
--   `if pka.isCoop('TGE')='1' and li_member_term<48 then fp_get_member_ownmemage(...)`
--   ไว้เป๊ะ. coop ปัจจุบัน iscoop('TGE')='0' -> สาขานี้ไม่เคยรัน -> fp_get_member_ownmemage
--   ยังไม่ migrate (plpgsql late-binding: สร้าง function ได้แม้ callee ยังไม่มี). ถ้าย้ายไป
--   ใช้บน coop TGE ต้อง migrate fp_get_member_ownmemage เพิ่ม.
-- ============================================================================

-- ─── สาย m_live (อายุการมีชีวิต = นับจากวันเกิด) ──────────────────────────────

-- fp_calc_install_m_live(birth, req) [src 5765] : จำนวนเดือนระหว่างวันเกิดกับวันคำนวณ
CREATE OR REPLACE FUNCTION pka_lon_reqsrv.fp_calc_install_m_live(adt_birth timestamp, adt_req timestamp)
RETURNS integer LANGUAGE plpgsql AS $$
BEGIN
  RETURN pka_srv_datetime.fp_monthsafter(adt_birth, adt_req);
EXCEPTION WHEN OTHERS THEN RETURN NULL;
END;
$$;

-- fp_calc_install_m_live(memno, req) [src 5746] : ดึงวันเกิดจากทะเบียนแล้วนับเดือน
CREATE OR REPLACE FUNCTION pka_lon_reqsrv.fp_calc_install_m_live(as_memno text, adt_req timestamp)
RETURNS integer LANGUAGE plpgsql AS $$
DECLARE
  ldt_date_of_birth timestamp;
BEGIN
  BEGIN -- ข้อมูลสมาชิก
    SELECT date_of_birth INTO ldt_date_of_birth
    FROM sc_mem_m_membership_registered
    WHERE membership_no = as_memno;
  EXCEPTION WHEN OTHERS THEN NULL; -- legacy: spa_dberror (continue, ldt_date_of_birth=NULL)
  END;
  IF pka_com_valid.var_date(ldt_date_of_birth::date) = '0' THEN
    RETURN 0; -- ไม่พบวันเกิด
  END IF;
  RETURN pka_lon_reqsrv.fp_calc_install_m_live(ldt_date_of_birth, adt_req);
EXCEPTION WHEN OTHERS THEN RETURN NULL;
END;
$$;

-- fp_calc_agetext_m_live(memno, req) [src 5830] : ข้อความอายุ (ปี/เดือน) จากวันเกิด
CREATE OR REPLACE FUNCTION pka_lon_reqsrv.fp_calc_agetext_m_live(as_memno text, adt_req timestamp DEFAULT NULL)
RETURNS text LANGUAGE plpgsql AS $$
DECLARE
  ldt_req timestamp := COALESCE(adt_req, CURRENT_DATE::timestamp);
BEGIN
  RETURN pka_lon_reqsrv.fp_calc_agetext(
           pka_lon_reqsrv.fp_calc_install_m_live(as_memno, ldt_req) );
EXCEPTION WHEN OTHERS THEN RETURN NULL;
END;
$$;

-- ─── สาย m_age (อายุการเป็นสมาชิก) ───────────────────────────────────────────

-- fp_calc_install_m_age(approve, req, method, memno) [src 6054] : core คำนวณตามวิธีนับ
CREATE OR REPLACE FUNCTION pka_lon_reqsrv.fp_calc_install_m_age(
  adt_approve timestamp, adt_req timestamp, as_method text, as_memno text)
RETURNS integer LANGUAGE plpgsql AS $$
DECLARE
  ldt_datefrom  timestamp;
  ldt_dateto    timestamp;
  li_term       integer := 0;
  li_countshare integer := 0;
BEGIN
  IF adt_approve IS NULL THEN RETURN NULL; END IF; -- legacy: spa_dberror('NULL adt_approve')
  IF adt_req     IS NULL THEN RETURN NULL; END IF; -- legacy: spa_dberror('NULL adt_req')

  ldt_datefrom := pka_srv_datetime.fp_firstdayofmonth(adt_approve::date);
  ldt_dateto   := pka_srv_datetime.fp_lastdayofmonth(adt_req::date);
  li_term      := pka_srv_datetime.fp_monthsafter(ldt_datefrom, ldt_dateto);
  IF li_term > 0 THEN
    CASE as_method
      WHEN '3' THEN -- วันที่อนุมัติรวมเดือนสิ้นสุด
        ldt_datefrom := adt_approve;
        ldt_dateto   := adt_req;
        li_term      := pka_srv_datetime.fp_monthsafter(ldt_datefrom, ldt_dateto);
      WHEN '4' THEN -- ก่อนผ่านรายการนับแบบ0 หลังผ่านรายการนับ3
        IF as_memno IS NULL THEN
          RAISE EXCEPTION 'fp_calc_install_m_age>NULL as_memno';
        END IF;
        ldt_datefrom := pka_srv_datetime.fp_firstdayofmonth(adt_req::date);
        ldt_dateto   := pka_srv_datetime.fp_lastdayofmonth(adt_req::date);
        SELECT count(membership_no) INTO li_countshare
        FROM sc_mem_m_share_holding_detail
        WHERE (membership_no = as_memno)
          AND (operate_date BETWEEN ldt_datefrom AND ldt_dateto)
          AND (item_type = 'MS');
        IF li_countshare > 0 THEN li_term := li_term + 1; END IF;
      WHEN '5' THEN -- วันที่มีหุ้นวันแรก
        SELECT COALESCE(min(operate_date), ldt_datefrom) INTO ldt_datefrom
        FROM sc_mem_m_share_holding_detail
        WHERE membership_no = as_memno AND share_stock > 0;
        ldt_dateto := adt_req;
        li_term    := pka_srv_datetime.fp_monthsafter(ldt_datefrom, ldt_dateto);
      ELSE          -- 0:วันที่อนุมัติไม่รวมเดือนสิ้นสุด (นับวันชนวัน)
        ldt_datefrom := adt_approve;
        ldt_dateto   := adt_req;
        li_term      := pka_srv_datetime.fp_monthsafter(ldt_datefrom, ldt_dateto);
    END CASE;
  END IF;
  RETURN li_term;
EXCEPTION WHEN OTHERS THEN RETURN NULL;
END;
$$;

-- fp_calc_install_m_age(approve, req, method) [src 6048] : shim เติม memno=NULL
CREATE OR REPLACE FUNCTION pka_lon_reqsrv.fp_calc_install_m_age(
  adt_approve timestamp, adt_req timestamp, as_method text)
RETURNS integer LANGUAGE plpgsql AS $$
BEGIN
  RETURN pka_lon_reqsrv.fp_calc_install_m_age(adt_approve, adt_req, as_method, NULL::text);
EXCEPTION WHEN OTHERS THEN RETURN NULL;
END;
$$;

-- fp_calc_install_m_age(memno, req) [src 5962] : เลือกวิธีนับจาก sc_lon_m_constant
CREATE OR REPLACE FUNCTION pka_lon_reqsrv.fp_calc_install_m_age(as_memno text, adt_req timestamp)
RETURNS integer LANGUAGE plpgsql AS $$
DECLARE
  ls_method_count_age sc_lon_m_constant.method_count_age%type;
  li_period_recrieve  integer;
  li_member_term      integer;
  ldt_approve_date    timestamp;
  li_ownmemage        integer;
BEGIN
  IF as_memno IS NULL OR as_memno = ' ' THEN RETURN 0; END IF;
  BEGIN
    SELECT method_count_age INTO ls_method_count_age FROM sc_lon_m_constant;
  EXCEPTION WHEN OTHERS THEN NULL; -- legacy: spa_dberror('E3909...') (continue)
  END;
  IF ls_method_count_age = '1' OR ls_method_count_age = '2' THEN
    -- 1 จำนวนงวดหุ้นลบหนึ่ง / 2 จำนวนงวดหุ้นปัจจุบัน
    BEGIN
      SELECT period_recrieve INTO li_period_recrieve
      FROM sc_mem_m_share_mem WHERE (membership_no = as_memno);
    EXCEPTION WHEN OTHERS THEN RETURN 0; -- ไม่พบทะเบียนหุ้น
    END;
    IF li_period_recrieve > 0 THEN
      IF ls_method_count_age = '1' THEN
        li_member_term := li_period_recrieve - 1;
      ELSE
        li_member_term := li_period_recrieve;
      END IF;
    END IF;
  ELSE
    BEGIN
      SELECT approve_date INTO ldt_approve_date
      FROM sc_mem_m_membership_registered WHERE (membership_no = as_memno);
    EXCEPTION WHEN OTHERS THEN NULL; -- legacy: spa_dberror (continue)
    END;
    IF ldt_approve_date IS NULL THEN
      RETURN NULL; -- legacy: spa_dberror('ไม่พบวันที่อนุมัติ...'); return null
    END IF;
    li_member_term := pka_lon_reqsrv.fp_calc_install_m_age(
                        ldt_approve_date, adt_req, ls_method_count_age, as_memno);
  END IF;

  -- TGE: รวมอายุสมาชิกที่โอนมา ถ้า < 48 เดือน (coop อื่น li_ownmemage=0)
  IF pka.iscoop('TGE') = '1' AND li_member_term < 48 THEN
    li_ownmemage := pka_lon_reqsrv.fp_get_member_ownmemage(as_memno); -- DEFERRED (ดูหัวไฟล์)
  ELSE
    li_ownmemage := 0;
  END IF;

  li_member_term := COALESCE(li_member_term + nvn(li_ownmemage), 0);
  RETURN li_member_term;
EXCEPTION WHEN OTHERS THEN RETURN NULL;
END;
$$;

-- fp_calc_install_m_age(memno) [src 5956] : entry รายงาน — วันคำนวณ = วันนี้
CREATE OR REPLACE FUNCTION pka_lon_reqsrv.fp_calc_install_m_age(as_memno text)
RETURNS integer LANGUAGE plpgsql AS $$
BEGIN
  RETURN pka_lon_reqsrv.fp_calc_install_m_age(as_memno, CURRENT_DATE::timestamp);
EXCEPTION WHEN OTHERS THEN RETURN NULL;
END;
$$;
