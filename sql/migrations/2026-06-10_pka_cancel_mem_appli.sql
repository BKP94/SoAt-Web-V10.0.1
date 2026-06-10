-- ============================================================================
-- 2026-06-10_pka_cancel_mem_appli.sql
-- migrate การยกเลิก (void) ใบสมัครสมาชิก จาก Oracle → PG
--   legacy: pka_mem_newmem.sp_docno_cancel(as_appno, as_reason)
--   (ดู C:\SoAt_PEAN\Admin\Export\PACKAGE_BODY\PKA_MEM_NEWMEM.sql)
--
-- กลไก legacy: validate approve_status (0/1=ยกเลิกไม่ได้, 2=รออนุมัติ→ยกเลิกได้)
--   แล้ว set cancel_status='1' + cancel_id/branch/date/reason. ยกเลิกซ้ำไม่ได้ (cancel_status ต้อง '0')
--
-- การ migrate (เทียบ docno 2026-06-08 / trigger infra 2026-06-06):
--   * pka_com_login.login_id/login_br → current_setting('app.login_id'/'app.login_br', true)
--     (sc.db ทำ SET LOCAL ต่อ request ผ่าน dbFactory.create(userId, branchId))
--   * sysdate → CURRENT_TIMESTAMP (cancel_date เป็น timestamp)
--   * spa_dberror('Exx:...') → RAISE EXCEPTION ... USING ERRCODE='P0001'
--     (คง E-number เดิมจาก Oracle ไว้ trace กลับ source; ข้อความไทยลอก legacy 1:1)
--   * ไม่ใส่ EXCEPTION WHEN OTHERS wrapper (จะ mask ข้อความ Exx เฉพาะ) — ให้ error เด้งตรง
--   * SQL%ROWCOUNT → GET DIAGNOSTICS ... ROW_COUNT ; NO_DATA_FOUND → IF NOT FOUND
--
-- C# เรียกบรรทัดเดียว: scDb.pkProcedureAsync("pka_mem_newmem.sp_docno_cancel", appno, reason)
-- หมายเหตุ: idempotent (CREATE OR REPLACE). รันซ้ำได้
-- ============================================================================

CREATE SCHEMA IF NOT EXISTS pka_mem_newmem;

CREATE OR REPLACE PROCEDURE pka_mem_newmem.sp_docno_cancel(
    as_appno  text,
    as_reason text)
LANGUAGE plpgsql AS $$
DECLARE
    ls_approve_status char(1);
    ls_cancel_status  char(1);
    v_rows            int;
BEGIN
    -- อ่านสถานะอนุมัติ/ยกเลิก (ไม่พบแถว → E28 เลียน Oracle NO_DATA_FOUND ใน inner block)
    SELECT approve_status, cancel_status
      INTO ls_approve_status, ls_cancel_status
    FROM sc_mem_m_application_form
    WHERE application_form_no = as_appno;
    IF NOT FOUND THEN
        RAISE EXCEPTION 'E28:select สถานะอนุมัติ' USING ERRCODE = 'P0001';
    END IF;

    CASE ls_approve_status
    WHEN '0' THEN
        RAISE EXCEPTION 'E32:ไม่สามารถ ยกเลิกใบคำขอสมัคสมาชิกได้เพราะสถานะเป็น  : ไม่อนุมัติ' USING ERRCODE = 'P0001';
    WHEN '1' THEN
        RAISE EXCEPTION 'E34:ไม่สามารถ ยกเลิกใบคำขอสมัคสมาชิกได้เพราะสถานะเป็น  : อนุมัติ' USING ERRCODE = 'P0001';
    WHEN '2' THEN
        IF ls_cancel_status = '1' THEN
            RAISE EXCEPTION 'E41:ใบสมัครเลขที่ % ถูกยกเลิกแล้ว ไม่สามารถยกเลิกซ้ำได้', trim(as_appno)
                USING ERRCODE = 'P0001';
        END IF;

        UPDATE sc_mem_m_application_form
           SET cancel_status = '1',
               cancel_id     = current_setting('app.login_id', true),
               cancel_branch = current_setting('app.login_br', true),
               cancel_date   = CURRENT_TIMESTAMP,
               cancel_reason = as_reason
         WHERE application_form_no = as_appno
           AND cancel_status = '0';

        GET DIAGNOSTICS v_rows = ROW_COUNT;
        IF v_rows <> 1 THEN
            RAISE EXCEPTION 'E45:การยกเลขที่คำขอไม่สมบูรณ์ (row_count <> 1)' USING ERRCODE = 'P0001';
        END IF;
    ELSE
        RAISE EXCEPTION 'E48:not case support สถานะอนมัติ' USING ERRCODE = 'P0001';
    END CASE;
END $$;
