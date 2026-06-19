-- ============================================================================
-- step 6 function-first sweep — batch 6 (pka_lon_reqsrv: อายุ/เกษียณ)
-- port (MISSING/STUB ใน PG):
--   pka.isactive(text)                          [PKA src 73]   MISSING — สถานะ active flag
--   pka_srv_datetime.fp_relativemonth(ts,int)   [DATETIME 143] STUB  — ADD_MONTHS (เกษียณ dep)
--   pka_lon_reqsrv.fp_rule_retireage(text)      [REQSRV 5666]  MISSING — อายุเกษียณ(ปี)
--   pka_lon_reqsrv.fp_calc_member_retire(text)  [REQSRV 4928]  MISSING — วันที่เกษียณ (1-arg)
--   pka_lon_reqsrv.fp_calc_member_retire(text,ts,int) [4965]   MISSING — วันที่เกษียณ (3-arg)
--   pka_lon_reqsrv.fp_calc_agetext_m_age(text,ts) [REQSRV 5806] MISSING — ข้อความอายุการเป็นสมาชิก
--
-- deviation (Legacy Fidelity):
--  - spa_dberror(...) (logger side-effect) -> ตัดทิ้ง คืน null/continue ตาม path เดิม
--  - return number/pls_integer -> int/numeric; varchar2/char -> text; date -> timestamp
--  - fp_relativemonth: Oracle ADD_MONTHS — ถ้า input เป็นวันสุดท้ายของเดือน ผลลัพธ์
--      = วันสุดท้ายของเดือนปลายทาง (PG `+ interval 'n month'` clamp วันเกินให้อยู่แล้ว
--      เหลือเคสวันสุดท้ายเดือนที่ต้อง snap) — keep signature (ts,int)->ts เดิม (มี dep)
--  - var_date(date) รับ date -> cast timestamp::date เวลาเรียก
--  - pka.to_date(to_char(sysdate,'dd/mm/yyyy')) (วันนี้ ตัดเวลา) -> CURRENT_DATE::timestamp
--  - SELECT INTO (no STRICT) ครอบ EXCEPTION WHEN others -> กลืน error คงค่า null เหมือนเดิม
-- หมายเหตุ: fp_calc_member_retire(date) / (date,group,position,sex) overload ยังไม่ port
--   (repQuery เรียกแค่ 1-arg + 3-arg(memno,birth,retireage)) — เพิ่มภายหลังถ้าต้องใช้
-- ============================================================================

-- ---- pka.isactive : สถานะ active flag [PKA src 73] -----------------------
CREATE OR REPLACE FUNCTION pka.isactive(as_code text)
RETURNS text LANGUAGE plpgsql STABLE AS $$
DECLARE ls_active_status text;
BEGIN
  BEGIN
    SELECT active_status INTO STRICT ls_active_status
      FROM sc_cnt_m_status_active WHERE status_code = as_code;
  EXCEPTION WHEN no_data_found THEN ls_active_status := NULL;
  END;
  RETURN coalesce(ls_active_status, '0');
EXCEPTION WHEN others THEN RETURN NULL;  -- Oracle spa_dberror('isActive')
END;
$$;

-- ---- pka_srv_datetime.fp_relativemonth : ADD_MONTHS [DATETIME 143] --------
-- เก็บ positional ($1,$2) เพื่อเลี่ยง "cannot change name of input parameter"
CREATE OR REPLACE FUNCTION pka_srv_datetime.fp_relativemonth(timestamp without time zone, integer)
RETURNS timestamp without time zone LANGUAGE plpgsql IMMUTABLE AS $$
DECLARE d date;
BEGIN
  IF $1 IS NULL OR $2 IS NULL THEN RETURN NULL; END IF;
  d := $1::date;
  -- input เป็นวันสุดท้ายของเดือน -> ผลลัพธ์เป็นวันสุดท้ายของเดือนปลายทาง (ADD_MONTHS)
  IF d = (date_trunc('month', d::timestamp) + interval '1 month - 1 day')::date THEN
    RETURN ((date_trunc('month', d::timestamp) + make_interval(months => $2))
            + interval '1 month - 1 day')::timestamp;
  END IF;
  -- เคสปกติ: PG interval clamp วันที่เกินจำนวนวันของเดือนปลายทางให้อยู่แล้ว
  RETURN (d + make_interval(months => $2))::timestamp;
EXCEPTION WHEN others THEN RETURN NULL;  -- Oracle spa_dberror('fp_RelativeMonth')
END;
$$;

-- ---- fp_rule_retireage : อายุเกษียณ(ปี) [REQSRV src 5666] ------------------
CREATE OR REPLACE FUNCTION pka_lon_reqsrv.fp_rule_retireage(as_memno text)
RETURNS int LANGUAGE plpgsql STABLE AS $$
DECLARE
  ls_retiretype     text;
  li_retireage      int;
  ls_sex            text;
  ls_group_position text;
BEGIN
  -- วิธีการมองอายุเกษียณ
  BEGIN SELECT retire_age_type INTO STRICT ls_retiretype FROM sc_cnt_m_coop;
  EXCEPTION WHEN others THEN NULL; END;  -- spa_dberror('E3380')

  CASE ls_retiretype
    WHEN '1' THEN  -- มองตามหน่วยงาน
      IF length(trim(as_memno)) > 0 THEN NULL; ELSE ls_retiretype := '0'; END IF;
    WHEN '2' THEN  -- มองตามกลุ่มตำแหน่ง
      IF length(trim(as_memno)) > 0 THEN NULL; ELSE ls_retiretype := '0'; END IF;
    ELSE NULL;     -- '0' ปกติ (เท่ากันทุกคน)
  END CASE;

  CASE ls_retiretype
    WHEN '1' THEN  -- มองตามหน่วยงาน
      BEGIN
        SELECT g.retire_age INTO STRICT li_retireage
          FROM sc_mem_m_ucf_member_group g, sc_mem_m_membership_registered m
         WHERE g.member_group_no = m.member_group_no
           AND m.membership_no = as_memno;
      EXCEPTION WHEN others THEN NULL; END;  -- spa_dberror(...)
    WHEN '2' THEN  -- มองตามกลุ่มตำแหน่ง
      BEGIN
        SELECT m.sex, w.group_position INTO STRICT ls_sex, ls_group_position
          FROM sc_mem_m_membership_registered m, sc_mem_m_member_work_info w
         WHERE m.membership_no = w.membership_no
           AND m.membership_no = as_memno;
      EXCEPTION WHEN others THEN NULL; END;  -- spa_dberror(...)
      IF ls_sex = 'F' THEN
        BEGIN
          SELECT retire_age_female INTO STRICT li_retireage
            FROM sc_mem_m_ucf_group_position WHERE group_position = ls_group_position;
        EXCEPTION WHEN others THEN RETURN 0; END;  -- spa_dberror(...); return 0
      ELSE
        BEGIN
          SELECT retire_age_male INTO STRICT li_retireage
            FROM sc_mem_m_ucf_group_position WHERE group_position = ls_group_position;
        EXCEPTION WHEN others THEN RETURN 0; END;  -- spa_dberror(...); return 0
      END IF;
    ELSE  -- '0' ปกติ (เท่ากันทุกคน)
      BEGIN SELECT retire_age INTO STRICT li_retireage FROM sc_cnt_m_coop;
      EXCEPTION WHEN others THEN NULL; END;  -- spa_dberror('E3434')
  END CASE;

  li_retireage := coalesce(li_retireage, 60);
  RETURN li_retireage;
EXCEPTION WHEN others THEN RETURN NULL;  -- spa_dberror('fp_rule_retireage')
END;
$$;

-- ---- fp_calc_member_retire (3-arg) : วันที่เกษียณ [REQSRV src 4965] --------
CREATE OR REPLACE FUNCTION pka_lon_reqsrv.fp_calc_member_retire(
  as_memno text, adt_birth timestamp without time zone, ai_retireage int DEFAULT 0)
RETURNS timestamp without time zone LANGUAGE plpgsql STABLE AS $$
DECLARE
  li_retireage             int;
  ls_cal_retire_method     text;
  ls_retire_bymonth_status text;
  li_retire_month          int;
  ldt_retiredate           timestamp;
  li_year                  int;
  li_count_mem             int := 0;
BEGIN
  IF adt_birth IS NULL THEN RETURN NULL; END IF;

  -- สมาชิกไม่ได้ระบุอายุเกษียณ ให้คำนวณหา
  IF ai_retireage > 0 THEN
    li_retireage := ai_retireage;
  ELSE
    li_retireage := pka_lon_reqsrv.fp_rule_retireage(as_memno);  -- อายุเกษียณ(ปี)
  END IF;

  IF li_retireage > 0 THEN
    BEGIN
      SELECT retire_bymonth_status, retire_month, cal_retire_method
        INTO STRICT ls_retire_bymonth_status, li_retire_month, ls_cal_retire_method
        FROM sc_cnt_m_coop;
    EXCEPTION WHEN others THEN NULL; END;  -- spa_dberror('E3103')

    IF ls_retire_bymonth_status = '1' THEN
      BEGIN
        SELECT count(*) INTO li_count_mem
          FROM sc_mem_m_membership_registered
         WHERE member_group_no = '1999499' AND membership_no = as_memno;
      EXCEPTION WHEN no_data_found THEN NULL; END;
      IF li_count_mem > 0 THEN li_retire_month := 12; END IF;
    END IF;

    IF ls_retire_bymonth_status = '1' AND li_retire_month > 0 THEN
      -- เกษียณตามเดือน retire_month
      li_year := extract(year FROM adt_birth);
      IF extract(month FROM adt_birth) > li_retire_month THEN
        -- กษ กันยา: ถ้าเกิด 1 ตค กษ เลย ไม่ต่อ
        IF li_retire_month = 9
           AND extract(month FROM adt_birth) = li_retire_month + 1
           AND extract(day FROM adt_birth) = 1 THEN
          ldt_retiredate := pka_srv_datetime.fp_lastdayofmonth(
                              make_date(li_year + li_retireage, li_retire_month, 1));
        ELSE
          -- เกิดหลังเดือน retire_month -> สิ้นเดือน retire_month ปีหน้า
          ldt_retiredate := pka_srv_datetime.fp_lastdayofmonth(
                              make_date(li_year + li_retireage + 1, li_retire_month, 1));
        END IF;
      ELSE
        ldt_retiredate := pka_srv_datetime.fp_lastdayofmonth(
                            make_date(li_year + li_retireage, li_retire_month, 1));
      END IF;
      IF pka.isactive('MemRetireDateUseEndMonth') = '1' THEN
        NULL;  -- วันที่เกษียณแสดง 30 ก.ย.
      ELSE
        ldt_retiredate := ldt_retiredate + interval '1 day';  -- 1 ต.ค.
      END IF;
    ELSE
      -- เกษียณตามเงื่อนไข cal_retire_method
      CASE ls_cal_retire_method
        WHEN '1' THEN  -- วันสิ้นเดือน, เดือนเกิด, ปีเกษียณ
          ldt_retiredate := pka_srv_datetime.fp_relativemonth(adt_birth, li_retireage*12);
          ldt_retiredate := pka_srv_datetime.fp_lastdayofmonth(ldt_retiredate::date);
        WHEN '2' THEN  -- วันที่หนึ่ง, เดือนเกิด, ปีเกษียณ
          ldt_retiredate := pka_srv_datetime.fp_relativemonth(adt_birth, li_retireage*12);
          ldt_retiredate := pka_srv_datetime.fp_firstdayofmonth(ldt_retiredate::date);
        WHEN '3' THEN  -- วันเกิด, เดือนเกิด, ปีเกษียณ
          ldt_retiredate := pka_srv_datetime.fp_relativemonth(adt_birth, li_retireage*12);
        ELSE  -- วันที่หนึ่ง, เดือนเกิด+1, ปีเกษียณ
          ldt_retiredate := pka_srv_datetime.fp_relativemonth(adt_birth, li_retireage*12);
          ldt_retiredate := pka_srv_datetime.fp_firstdayofmonth(ldt_retiredate::date);
          ldt_retiredate := pka_srv_datetime.fp_relativemonth(ldt_retiredate, 1);
      END CASE;
    END IF;
  END IF;

  RETURN ldt_retiredate;
EXCEPTION WHEN others THEN RETURN NULL;  -- spa_dberror('fp_calc_member_retire')
END;
$$;

-- ---- fp_calc_member_retire (1-arg) : วันที่เกษียณ [REQSRV src 4928] --------
CREATE OR REPLACE FUNCTION pka_lon_reqsrv.fp_calc_member_retire(as_memno text)
RETURNS timestamp without time zone LANGUAGE plpgsql STABLE AS $$
DECLARE
  ldt_date_of_birth   timestamp;
  ldt_retire_date     timestamp;
  ls_ignor_retiredage text;
BEGIN
  IF as_memno IS NULL OR length(trim(as_memno)) = 0 THEN
    ldt_date_of_birth := NULL;  -- เรียกจากหน้าจอประมาณการ ไม่มีเลขทะเบียน
  ELSE
    BEGIN
      SELECT w.retire_date, m.date_of_birth, g.ignor_retire_date
        INTO ldt_retire_date, ldt_date_of_birth, ls_ignor_retiredage
        FROM sc_mem_m_membership_registered m,
             sc_mem_m_member_work_info w,
             sc_mem_m_ucf_member_group g
       WHERE m.membership_no = w.membership_no
         AND m.membership_no = as_memno
         AND g.member_group_no = m.member_group_no;
    EXCEPTION WHEN others THEN NULL; END;  -- spa_dberror('E3051')

    IF ls_ignor_retiredage = '1' THEN
      RETURN NULL;  -- หน่วยงานไม่มองอายุเกษียณ (บำนาญ/กู้หุ้น)
    END IF;
    IF pka_com_valid.var_date(ldt_retire_date::date) = '1' THEN
      RETURN ldt_retire_date;  -- เจ้าหน้าที่ระบุวันเกษียณ
    END IF;
    -- var_date(date_of_birth)='0' -> Oracle spa_dberror เฉยๆ (drop), ไหลต่อ
  END IF;

  RETURN pka_lon_reqsrv.fp_calc_member_retire(as_memno, ldt_date_of_birth);
EXCEPTION WHEN others THEN RETURN NULL;  -- spa_dberror('fp_calc_member_retire')
END;
$$;

-- ---- fp_calc_agetext_m_age : ข้อความอายุการเป็นสมาชิก [REQSRV src 5806] ----
CREATE OR REPLACE FUNCTION pka_lon_reqsrv.fp_calc_agetext_m_age(
  as_memno text, adt_req timestamp without time zone DEFAULT NULL)
RETURNS text LANGUAGE plpgsql STABLE AS $$
DECLARE ldt_req timestamp;
BEGIN
  IF adt_req IS NULL THEN
    BEGIN
      -- ลาออก(status='3') ใช้วันอนุมัติลาออก ไม่งั้น null
      SELECT CASE WHEN member_status_code = '3' THEN resignation_approve_date ELSE NULL END
        INTO STRICT ldt_req
        FROM sc_mem_m_membership_registered WHERE membership_no = as_memno;
    EXCEPTION WHEN others THEN RETURN NULL; END;
    IF ldt_req IS NULL THEN ldt_req := CURRENT_DATE::timestamp; END IF;
  ELSE
    ldt_req := adt_req;
  END IF;

  RETURN pka_lon_reqsrv.fp_calc_agetext(
           pka_lon_reqsrv.fp_calc_install_m_age(as_memno, ldt_req));
EXCEPTION WHEN others THEN RETURN NULL;
END;
$$;
