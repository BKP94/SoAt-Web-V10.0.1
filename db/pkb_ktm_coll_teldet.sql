-- ════════════════════════════════════════════════════════════════════════════
--  pkb_ktm — 3 ฟังก์ชันค้ำประกัน ใช้โดย scteldet › หลักประกัน (u_tabpg_mem_detail_coll_detail)
--
--   1) fp_get_count_coll(conno)        — นับคนค้ำของสัญญา (collateral_type_code='01', status<>'1')
--   2) fp_get_count_collin_req(reqno)  — นับคนค้ำของคำขอกู้ (เพดาน 12 ตาม winapp)
--   3) fp_get_msg_collused_teldet(memno)— ข้อความสรุปสิทธิค้ำใต้ grid (เฉพาะ สอ. KTM)
--
--  source: C:\SoAt_PEAN\Admin\Export\PACKAGE_BODY\PKB_KTM.sql
--  faithful: NVL→COALESCE, decode→CASE, %TYPE→ชนิดจริง
--    ตัด spa_dberror (logging) ออกจาก exception — คืนค่า fallback เดิม (1/0/'') เหมือน Oracle
--  หมายเหตุ KTM-only: fp_get_msg_collused_teldet ห่อด้วย pka.iscoop('KTM').
--    สอ. ปัจจุบัน sys_name = 'PEAN' → branch ไม่ทำงาน → คืนค่าว่างเสมอ (เหมือน legacy)
--    branch ในนั้นเรียก pkb_ktm.fp_get_collused_amount_refno (ยังไม่ migrate — KTM-only,
--    dead path สำหรับ PEAN) + pkb_ktm.fp_get_maxpermit_ktm (มีใน PG แล้ว). plpgsql resolve
--    ฟังก์ชันตอน runtime → CREATE ผ่านแม้ refno ยังไม่มี; ถ้าเปลี่ยน สอ. เป็น KTM ค่อย migrate refno
--  รันที่ pgAdmin โดย PL team (schema เป็น pgAdmin-managed)
-- ════════════════════════════════════════════════════════════════════════════

CREATE SCHEMA IF NOT EXISTS pkb_ktm;

-- ── 1) นับคนค้ำของสัญญานี้ ───────────────────────────────────────────────────
CREATE OR REPLACE FUNCTION pkb_ktm.fp_get_count_coll(as_conno varchar)
RETURNS numeric
LANGUAGE plpgsql
AS $$
DECLARE
    li_count_coll integer;
BEGIN
    SELECT count(*)
      INTO li_count_coll
      FROM sc_lon_m_contract_coll
     WHERE loan_contract_no    = as_conno
       AND collateral_type_code = '01'
       AND status <> '1';

    IF li_count_coll IS NULL THEN
        li_count_coll := 1;
    END IF;

    RETURN li_count_coll;
EXCEPTION WHEN OTHERS THEN
    RETURN 1;
END;
$$;

-- ── 2) นับคนค้ำของคำขอกู้ (loan_requestment_no) ──────────────────────────────
CREATE OR REPLACE FUNCTION pkb_ktm.fp_get_count_collin_req(as_reqno varchar)
RETURNS numeric
LANGUAGE plpgsql
AS $$
DECLARE
    li_count_coll integer;
BEGIN
    SELECT count(sc_lon_m_req_coll.loan_requestment_no)
      INTO li_count_coll
      FROM sc_lon_m_loan_request,
           sc_lon_m_req_coll
     WHERE sc_lon_m_loan_request.loan_requestment_no = sc_lon_m_req_coll.loan_requestment_no
       AND sc_lon_m_req_coll.collateral_type_code    = '01'
       AND sc_lon_m_loan_request.loan_requestment_no  = as_reqno;

    IF li_count_coll IS NULL THEN
        li_count_coll := 0;
    END IF;

    IF li_count_coll > 12 THEN  -- ตาม winapp ไม่มีทางมากกว่า 12
        li_count_coll := 0;
    END IF;

    RETURN li_count_coll;
EXCEPTION WHEN OTHERS THEN
    RETURN 1;
END;
$$;

-- ── 3) ข้อความสรุปสิทธิค้ำใต้ grid (KTM-only) ────────────────────────────────
CREATE OR REPLACE FUNCTION pkb_ktm.fp_get_msg_collused_teldet(as_memno varchar)
RETURNS varchar
LANGUAGE plpgsql
AS $$
DECLARE
    ls_msg_str        varchar(1000);
    ldc_used_amount   numeric;
    ldc_used_coll_bal numeric;
    ldc_maxpermit     numeric;
BEGIN
    IF pka.iscoop('KTM') = '1' THEN
        ldc_used_amount   := pkb_ktm.fp_get_collused_amount_refno(as_memno);  -- สิทธิค้ำประกันไปแล้ว
        ldc_maxpermit     := pkb_ktm.fp_get_maxpermit_ktm(as_memno);          -- สิทธิการกู้
        ldc_used_coll_bal := ldc_maxpermit - ldc_used_amount;

        IF ldc_used_coll_bal < 0 THEN
            ldc_used_coll_bal := 0;
        END IF;

        ls_msg_str := '--> สิทธิการกู้ = ' || to_snumber(ldc_maxpermit)
                   || '   ใช้สิทธิค้ำประกันไปแล้ว = ' || to_snumber(ldc_used_amount)
                   || '   เหลือสิทธิค้ำ = ' || to_snumber(ldc_used_coll_bal) || ' บาท';
    END IF;

    RETURN trim(COALESCE(ls_msg_str, ''));
EXCEPTION WHEN OTHERS THEN
    RETURN '';
END;
$$;
