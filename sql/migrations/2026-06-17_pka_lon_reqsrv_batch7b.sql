-- ============================================================================
-- step 6 function-first sweep — batch 7b (งวด day-to-day + ค่าธรรมเนียมจ่ายจริง)
-- port (ทั้งหมด MISSING ใน PG):
--   pka_lon_reqsrv.fp_calc_install_d2d(date,date)        [REQSRV 3154]  จำนวนงวด
--   pka_lon_reqsrv.fp_get_fee_add_realrec(text,text)     [REQSRV 10297] ค่าธรรมเนียมจ่ายจริง
--
-- deps (มีใน PG แล้ว ไม่ต้อง port): pka.iscoop, pka_srv_datetime.fp_firstdayofmonth /
--   fp_lastdayofmonth / fp_relativemonth (batch6) / fp_monthsafter
--
-- deferred (Batch 7 ที่เหลือ แยกไป batch อื่น):
--   fp_calint(...)                  -> full interest engine (calh/cald, day-count) = batch เฉพาะ
--   fp_intrate_conno(...)           -> per-contract rate subtree (fp_inttable_conno/_table_conno)
--   fp_rule_loanpermit_levelcustom  -> ขึ้นกับ sp_rule_loanpermit_levelcustom (collection driver) = batch9
--
-- deviation (Legacy Fidelity):
--  - spa_dberror(...) (logger) -> ตัดทิ้ง คืน null ตาม path เดิม
--  - pls_integer -> int ; number -> numeric ; char/varchar2 -> text ; date -> date
--  - fp_calc_install_d2d: coop ปัจจุบัน sys_name='PEAN' -> iscoop('SKL')/('POT')='0'
--      ไหลเข้า else = +1 (รวมงวดแรก). คง branch SKL(+2)/POT(+0) ไว้ครบตามเดิม
--  - cast ชนิดเวลา: fp_relativemonth/fp_monthsafter รับ timestamp -> ส่ง ::timestamp,
--      ผลลัพธ์ ::date กลับเข้าตัวแปร date (ค่าเท่าเดิม เพราะเป็นวันที่ 1 ของเดือนเสมอ)
-- ============================================================================

-- ---- fp_calc_install_d2d : จำนวนงวดจากช่วงวันที่ [REQSRV 3154] -------------
CREATE OR REPLACE FUNCTION pka_lon_reqsrv.fp_calc_install_d2d(adt_start date, adt_end date)
RETURNS int LANGUAGE plpgsql STABLE AS $$
DECLARE
  ldt_start  date;
  ldt_end    date;
  li_install int;
BEGIN
  ldt_start := pka_srv_datetime.fp_firstdayofmonth(adt_start);
  ldt_end   := pka_srv_datetime.fp_firstdayofmonth(adt_end);
  -- ถ้า adt_end ไม่ใช่วันสิ้นเดือน -> ถอยกลับ 1 เดือน (ไม่นับเดือนที่ยังไม่ครบ)
  IF adt_end <> pka_srv_datetime.fp_lastdayofmonth(adt_end) THEN
    ldt_end := pka_srv_datetime.fp_relativemonth(ldt_end::timestamp, -1)::date;
  END IF;

  li_install := pka_srv_datetime.fp_monthsafter(ldt_start::timestamp, ldt_end::timestamp);

  IF    pka.iscoop('SKL') = '1' THEN li_install := li_install + 2;  -- สงขลา +2 งวด
  ELSIF pka.iscoop('POT') = '1' THEN NULL;                          -- ท่าเรือ ไม่รวมงวดแรก
  ELSE                               li_install := li_install + 1;  -- ทั่วไป รวมงวดแรก
  END IF;

  RETURN li_install;
EXCEPTION WHEN others THEN RETURN NULL;  -- spa_dberror('fp_calc_install_d2d')
END;
$$;

-- ---- fp_get_fee_add_realrec : ค่าธรรมเนียมที่จ่ายจริง [REQSRV 10297] -------
-- as_req_no ขึ้นต้น 'พ'/'ก' = เลขใบเสร็จ -> รวมจาก receipt_item (group_item='ISR')
-- ไม่ใช่ -> add_status='1' ดูจาก addloan_detail, ไม่งั้นดูจาก req_fee
CREATE OR REPLACE FUNCTION pka_lon_reqsrv.fp_get_fee_add_realrec(as_req_no text, add_status text)
RETURNS numeric LANGUAGE plpgsql STABLE AS $$
DECLARE ldc_amount numeric;
BEGIN
  IF as_req_no LIKE 'พ%' OR as_req_no LIKE 'ก%' THEN  -- ยอดชำระเพิ่มจากใบเสร็จ
    SELECT coalesce(sum(ri.item_amount), 0) INTO ldc_amount
      FROM sc_com_m_receipt_item ri, sc_com_m_ucf_receipt_item_type t
     WHERE t.item_type_id = ri.item_type_id
       AND t.group_item = 'ISR'
       AND ri.receipt_no = as_req_no;
  ELSE
    IF add_status = '1' THEN
      SELECT sum(item_amount) INTO ldc_amount
        FROM sc_lon_m_loan_addloan_detail
       WHERE loan_contract_no = as_req_no
         AND item_type IN ('TBK','LOA','LRV','FFO','BSH');
    ELSE
      SELECT sum(amount) INTO ldc_amount
        FROM sc_lon_m_req_fee
       WHERE loan_requestment_no = as_req_no
         AND fee_type IN ('TBK','LOA','LRV','FFO','BSH');
    END IF;
  END IF;

  RETURN coalesce(ldc_amount, 0);
EXCEPTION WHEN others THEN RETURN NULL;  -- spa_dberror('fp_get_fee_add_realrec')
END;
$$;
