-- ============================================================================
-- 2026-06-08_pka_docno_mem_appli.sql
-- migrate กลไกสร้างเลขที่เอกสาร (docno) จาก Oracle → PG เฉพาะที่ sctelnewbma ใช้
--   legacy: pka_mem_newmem.sp_gen_application_form_no → pka_com_docno.sp_generate('MEM_APPLI_NO')
--   (ดู C:\SoAt_PEAN\Admin\Export\PACKAGE_BODY\PKA_COM_DOCNO.sql / PKA_MEM_NEWMEM.sql)
--
-- กลไก legacy:
--   ตาราง sc_cnt_m_document_no_control เก็บ running-number ต่อ document_code
--     last_document_no = เลขรันปัจจุบัน (เช่น '00001'), document_year = ปี พ.ศ.
--   sp_generate: lock แถว → +1 ที่ส่วนตัวเลขท้าย (คง prefix ตัวอักษร + ความกว้างเดิม) → update
--   sp_gen_application_form_no: เอา last_document_no (ต้อง 5 หลัก) มาต่อท้าย 2 หลักท้ายของปี พ.ศ.
--     เช่น พ.ศ. 2569 → '69' || '00001' = '6900001'
--
-- การ migrate (เทียบ trigger infra 2026-06-06):
--   * package variable (is_application_form_no) → session GUC app.application_form_no
--     (sp_ เซ็ตด้วย set_config, fp_ อ่านด้วย current_setting — C# เรียก sp แล้ว fp บน connection เดียว)
--   * concurrency: ใช้ SELECT ... FOR UPDATE lock แถว (แทน retry-loop ของ Oracle)
--   * spa_dberror (E492) → RAISE EXCEPTION
--
-- หมายเหตุ: idempotent (CREATE OR REPLACE + seed แบบ NOT EXISTS). รันซ้ำได้
-- ============================================================================

CREATE SCHEMA IF NOT EXISTS pka_com_docno;
CREATE SCHEMA IF NOT EXISTS pka_mem_newmem;

-- ── 1) core generator — +1 เลขรันของ document_code (เทียบ pka_com_docno.sp_generate) ──
-- คืน last_document_no ใหม่ + ปี พ.ศ. ของแถว (lock แถวกัน race ด้วย FOR UPDATE)
CREATE OR REPLACE FUNCTION pka_com_docno.sp_generate(
    p_code      text,
    OUT o_lastdocno text,
    OUT o_year      text)
LANGUAGE plpgsql AS $$
DECLARE
    v_last   text;
    v_year   text;
    v_num    text := '';
    v_prefix text := '';
    v_ch     char;
    i        int;
BEGIN
    -- ยังไม่มี config → สร้างให้ (default 6 หลักตาม Oracle sp_autocode; code ที่ต้องการ
    -- ความกว้างอื่น เช่น MEM_APPLI_NO 5 หลัก ให้ seed แถวไว้ล่วงหน้า — ดูส่วนท้ายไฟล์)
    INSERT INTO sc_cnt_m_document_no_control(document_code, document_name, last_document_no, document_year)
    SELECT p_code, p_code, '000000', (extract(year from current_date) + 543)::text
    WHERE NOT EXISTS (SELECT 1 FROM sc_cnt_m_document_no_control WHERE document_code = p_code);

    SELECT trim(last_document_no), trim(document_year)
      INTO v_last, v_year
    FROM sc_cnt_m_document_no_control
    WHERE document_code = p_code
    FOR UPDATE;

    IF v_last IS NULL OR v_last = '' THEN v_last := '000000'; END IF;
    IF v_year IS NULL OR v_year = '' THEN v_year := (extract(year from current_date) + 543)::text; END IF;

    -- แยกตัวเลขท้าย (v_num) ออกจาก prefix ตัวอักษร (v_prefix) — วนจากขวา
    FOR i IN REVERSE length(v_last)..1 LOOP
        v_ch := substr(v_last, i, 1);
        IF v_ch BETWEEN '0' AND '9' THEN
            v_num := v_ch || v_num;
        ELSE
            v_prefix := substr(v_last, 1, i);
            EXIT;
        END IF;
    END LOOP;
    IF v_num = '' THEN v_num := '0'; END IF;

    -- +1 แล้ว pad 0 กลับให้กว้างเท่าเดิม
    v_num  := lpad((v_num::bigint + 1)::text, length(v_num), '0');
    v_last := v_prefix || v_num;

    UPDATE sc_cnt_m_document_no_control
       SET last_document_no = v_last
     WHERE document_code = p_code;

    o_lastdocno := v_last;
    o_year      := v_year;
END $$;

-- ── 2) เลขที่ใบสมัครสมาชิก (เทียบ pka_mem_newmem.sp_gen_application_form_no / fp_*) ──
-- sp_ เก็บผลใน session GUC, fp_ อ่านกลับ — เลียน package variable is_application_form_no
CREATE OR REPLACE PROCEDURE pka_mem_newmem.sp_gen_application_form_no()
LANGUAGE plpgsql AS $$
DECLARE
    v_no   text;
    v_year text;
BEGIN
    SELECT o_lastdocno, o_year INTO v_no, v_year
    FROM pka_com_docno.sp_generate('MEM_APPLI_NO');

    -- มีผลต่อการบันทึกรูป — เลขรันต้องเป็น 5 หลักพอดี
    IF length(trim(v_no)) <> 5 THEN
        RAISE EXCEPTION 'E492:เลขที่ใบสมัคร(MEM_APPLI_NO) ได้(%) กรุณากำหนดค่าให้เท่ากับ 5 หลัก ,กรุณากำหนดที่ผู้ดูแลระบบ', trim(v_no)
            USING ERRCODE = 'P0001';
    END IF;

    v_no := substr(v_year, 3, 2) || trim(v_no);   -- 2 หลักท้ายปี พ.ศ. + เลขรัน 5 หลัก
    PERFORM set_config('app.application_form_no', v_no, false);
END $$;

CREATE OR REPLACE FUNCTION pka_mem_newmem.fp_gen_application_form_no()
RETURNS text
LANGUAGE sql AS $$ SELECT current_setting('app.application_form_no', true) $$;

-- ── 3) seed config แถว MEM_APPLI_NO (5 หลัก, ปี พ.ศ. ปัจจุบัน) ถ้ายังไม่มี ──
INSERT INTO sc_cnt_m_document_no_control(document_code, document_name, last_document_no, document_year)
SELECT 'MEM_APPLI_NO', 'เลขที่ใบสมัครสมาชิก', '00000', (extract(year from current_date) + 543)::text
WHERE NOT EXISTS (SELECT 1 FROM sc_cnt_m_document_no_control WHERE document_code = 'MEM_APPLI_NO');
