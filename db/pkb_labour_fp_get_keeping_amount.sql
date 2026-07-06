-- ════════════════════════════════════════════════════════════════════════════
--  pkb_labour.fp_get_keeping_amount — migrate Oracle → PostgreSQL
--  ใช้โดย scteldet › เรียกเก็บรายเดือน (u_tabpg_mem_detail_month_detail) header :
--    "เงินเก็บรับ (NET)" — เรียกด้วย as_kep_group='NET'
--    (migrate ทั้ง function ครบทุกกลุ่ม เพื่อ faithful + reuse — NET คือเคสที่ frontend ใช้)
--    NET: KTM เงินรอจ่ายคืนเป็นยอดติดลบอยู่แล้ว → sum(money_amount) ตรงทั้งหมด
--
--  source: C:\SoAt_PEAN\Admin\Export\PACKAGE_BODY\PKB_LABOUR.sql (fp_get_keeping_amount)
--  faithful: CASE simple statement; recursion (FILE_SHR/FILE_LON) qualify schema;
--    nvn(x) [=NVL(x,0)] → COALESCE(x,0); nvl→COALESCE; ตัด exception spa_dberror ทิ้ง
--  หมายเหตุ param char (Oracle unconstrained) → varchar ใน PG กันตัด (เช่น 'FILE_SHR')
--    param Oracle int (ปี/เดือน/seq) → double precision ให้ตรงชนิดคอลัมน์จริงใน PG
--    (sc_kep_t_monthly_receive[_det].receive_year/receive_month/seq_no = double precision)
--  รันที่ pgAdmin โดย PL team (schema เป็น pgAdmin-managed)
-- ════════════════════════════════════════════════════════════════════════════

CREATE SCHEMA IF NOT EXISTS pkb_labour;

CREATE OR REPLACE FUNCTION pkb_labour.fp_get_keeping_amount(
    as_memno     varchar,
    ai_year      double precision,
    ai_month     double precision,
    ai_seqno     double precision,
    as_kep_group varchar
)
RETURNS numeric
LANGUAGE plpgsql
AS $$
DECLARE
    ldc_keepin_amount numeric;
    ldc_money_return  numeric;
BEGIN
    CASE as_kep_group

        -- UNKEEP_TGE: ยอดที่เก็บไม่ได้ ไม่รวม ฌาปนกิจ (MR%/CM)
        WHEN 'UNKEEP_TGE' THEN
            SELECT sum(unkeep_money_amount) INTO ldc_keepin_amount
              FROM sc_kep_t_monthly_receive_det
             WHERE membership_no = as_memno
               AND receive_year  = ai_year
               AND receive_month = ai_month
               AND keeping_type_code NOT LIKE 'MR%'
               AND keeping_type_code NOT IN ('CM')
               AND seq_no = ai_seqno;

        -- FILE_TGE: ไฟล์ส่งโรงพิมพ์ ไม่รวม ฌาปนกิจ (กลุ่ม CMT)
        WHEN 'FILE_TGE' THEN
            SELECT COALESCE(sum(money_amount_not), 0) INTO ldc_keepin_amount
              FROM sc_kep_t_monthly_receive_det, sc_kep_m_ucf_keeping_item_type
             WHERE sc_kep_t_monthly_receive_det.keeping_type_code = sc_kep_m_ucf_keeping_item_type.keeping_type_code
               AND sc_kep_t_monthly_receive_det.membership_no = as_memno
               AND sc_kep_t_monthly_receive_det.receive_year  = ai_year
               AND sc_kep_t_monthly_receive_det.receive_month = ai_month
               AND sc_kep_t_monthly_receive_det.seq_no        = ai_seqno
               AND keeping_type_group NOT IN ('CMT');

        -- FILE_OTH: ค่าธรรมเนียม/ประกัน/อื่นๆ (ไม่ใช่ หุ้น/หนี้/เงินฝาก)
        WHEN 'FILE_OTH' THEN
            SELECT sum(money_amount) INTO ldc_keepin_amount
              FROM sc_kep_t_monthly_receive_det, sc_kep_m_ucf_keeping_item_type
             WHERE sc_kep_t_monthly_receive_det.keeping_type_code = sc_kep_m_ucf_keeping_item_type.keeping_type_code
               AND sc_kep_t_monthly_receive_det.membership_no = as_memno
               AND sc_kep_t_monthly_receive_det.receive_year  = ai_year
               AND sc_kep_t_monthly_receive_det.receive_month = ai_month
               AND sc_kep_t_monthly_receive_det.seq_no        = ai_seqno
               AND keeping_type_group NOT IN ('SHR','LON','MRT','DEP');

        -- FILE_SHR: ยอดหุ้น ถ้ามีเงินคืนติดลบเอามาลดในหุ้น
        WHEN 'FILE_SHR' THEN
            ldc_keepin_amount := pkb_labour.fp_get_keeping_amount(as_memno, ai_year, ai_month, ai_seqno, 'SHR');
            ldc_money_return  := pkb_labour.fp_get_keeping_amount(as_memno, ai_year, ai_month, ai_seqno, 'LON')
                               - pkb_labour.fp_get_keeping_amount(as_memno, ai_year, ai_month, ai_seqno, 'MRT');
            IF ldc_money_return < 0 THEN
                ldc_keepin_amount := ldc_keepin_amount + ldc_money_return;
            END IF;

        -- FILE_LON: ยอดหนี้ ลบรอจ่ายคืน ห้ามติดลบ
        WHEN 'FILE_LON' THEN
            ldc_keepin_amount := pkb_labour.fp_get_keeping_amount(as_memno, ai_year, ai_month, ai_seqno, 'LON')
                               - pkb_labour.fp_get_keeping_amount(as_memno, ai_year, ai_month, ai_seqno, 'MRT');
            IF ldc_keepin_amount < 0 THEN
                ldc_keepin_amount := 0;
            END IF;

        -- UNKEEP: ยอดที่เก็บไม่ได้
        WHEN 'UNKEEP' THEN
            SELECT sum(unkeep_money_amount) INTO ldc_keepin_amount
              FROM sc_kep_t_monthly_receive_det
             WHERE membership_no = as_memno
               AND receive_year  = ai_year
               AND receive_month = ai_month
               AND keeping_type_code NOT LIKE 'MR%'
               AND seq_no = ai_seqno;

        -- NOT: ยอดที่เก็บได้
        WHEN 'NOT' THEN
            SELECT sum(money_amount_not) INTO ldc_keepin_amount
              FROM sc_kep_t_monthly_receive_det
             WHERE membership_no = as_memno
               AND receive_year  = ai_year
               AND receive_month = ai_month
               AND keeping_type_code NOT LIKE 'MR%'
               AND seq_no = ai_seqno;

        -- KEP: ยอดที่เรียกเก็บไป (ยังไม่ลดเงินจ่ายคืน)
        WHEN 'KEP' THEN
            SELECT sum(money_amount) INTO ldc_keepin_amount
              FROM sc_kep_t_monthly_receive_det
             WHERE membership_no = as_memno
               AND receive_year  = ai_year
               AND receive_month = ai_month
               AND keeping_type_code NOT LIKE 'MR%'
               AND seq_no = ai_seqno;

        -- NET: KTM เงินรอจ่ายคืนเป็นยอดติดลบ → sum ตรงทั้งหมด (รวมทุก keeping_type_code)
        WHEN 'NET' THEN
            SELECT sum(money_amount) INTO ldc_keepin_amount
              FROM sc_kep_t_monthly_receive_det
             WHERE membership_no = as_memno
               AND receive_year  = ai_year
               AND receive_month = ai_month
               AND seq_no = ai_seqno;

        -- else: เลือกตามกลุ่มเรียกเก็บ (as_kep_group = keeping_type_group)
        ELSE
            SELECT sum(money_amount) INTO ldc_keepin_amount
              FROM sc_kep_t_monthly_receive_det, sc_kep_m_ucf_keeping_item_type
             WHERE sc_kep_t_monthly_receive_det.keeping_type_code = sc_kep_m_ucf_keeping_item_type.keeping_type_code
               AND sc_kep_t_monthly_receive_det.membership_no = as_memno
               AND sc_kep_t_monthly_receive_det.receive_year  = ai_year
               AND sc_kep_t_monthly_receive_det.receive_month = ai_month
               AND sc_kep_t_monthly_receive_det.seq_no        = ai_seqno
               AND sc_kep_m_ucf_keeping_item_type.keeping_type_group = as_kep_group;

    END CASE;

    RETURN COALESCE(ldc_keepin_amount, 0);
END;
$$;
