-- ============================================================================
-- step 6 function-first sweep — batch 9c (report-DRIVER stored procedures)
-- ----------------------------------------------------------------------------
-- repQuery <root procedure="pkg.sp_xxx(args)"> = runtime ต้อง EXECUTE proc ตัวนี้
-- ก่อน (มันเติม staging table SC_REP_*) แล้วค่อยรัน <sql> ที่ select จาก staging.
-- ไฟล์นี้ = port ตัว proc; การ wire runtime ให้เรียก proc ทำที่ sc/report.cs + repView.
--
-- port (5 proc ที่มี Oracle source + deps ครบใน PG):
--   pka_rep_mis.sp_paid_loan_by_month(int)                 [REPMIS 6]    สรุปจ่ายเงินกู้รายเดือน
--   pka_rep_mis.sp_paid_loan_by_day_in_month(int,int)      [REPMIS 136]  สรุปจ่ายเงินกู้รายวันในเดือน
--   pka_rep_kep.sp_process_kep_return(date,int,int)         [REPKEP 1348] คงค้างคืนใบเสร็จรายเดือน (BOK)
--   pka_rep_kep.sp_process_kep_return_rep(int,int)          [REPKEP 1506] คงค้างคืนใบเสร็จ (REP, ผิดนัด≤2งวด)
--   pka_rep_tel.sp_rep_2label_mem_retire(int,text,text)     [REPTEL 2857] label 2 คอลัมน์ สมาชิกเกษียณ
--
-- DEFER (มี source แต่ติด blocker / ไม่มี source — ไม่ port ในไฟล์นี้):
--   pka_rep_mis.sp_business_volume(date,date)  [REPMIS 498]
--       → เรียก pka_acc_moneysheet.sp_report('BUSINESS',...) ซึ่งยังไม่ migrate (finance-tier)
--   pka_rep_loan.sp_rep_lon_return(date,int)              → ไม่มีใน Oracle export (spec+body)
--   pka_shr.sp_build_book_item(memno,line,date) [3-arg]   → ไม่มีใน Oracle export
--       (pka_dep_bookslip.sp_build_book_item เป็น 7-arg คนละตัว — report อ้าง sig ที่ไม่มีจริง)
--   pka_test.sp_mis_report_share() / _share_month() / _dep()
--       → ไม่มีใน Oracle export เลย (package ชื่อ "TEST"; body มีแค่ sp_process_kep_estimate_rep)
--       → 3 ตัวนี้เป็น MIS-grid report (ต้อง band-grid UI ใน arg popup) ด้วย — defer 2 ชั้น
--   ⇒ 6 report ที่อ้าง 5 proc ไม่มี source = dead/broken แม้บน legacy (ORA-06550) → บันทึกเป็น deviation
--
-- deviation (Legacy Fidelity):
--   - PROCEDURE (Oracle) → PG PROCEDURE (เรียกผ่าน CALL ที่ sc.db.pkProcedure) — เหมือนเดิม
--   - PL/SQL collection-of-%ROWTYPE + FORALL insert → %ROWTYPE record + `INSERT ... SELECT (rec).*`
--       ต่อแถว (idiom collapse เดียวกับ batch7a) — delete ก่อน/insert ราย-แถว = ผลลัพธ์เท่ากัน
--       (staging ถูก rebuild ทั้งตารางทุกครั้งอยู่แล้ว)
--   - `pka.to_date('d/m/yyyy')` / bare `to_date(...)` → `to_date(str,'DD/MM/YYYY')` (pg_catalog 2-arg)
--       *ไม่* ใช้ public.to_date(text) เพราะตัวนั้นเป็น stub (คืน 1/1/2007 ตายตัว)
--   - `last_day(d)` → pka_srv_datetime.fp_lastdayofmonth(d) (มีใน PG)
--   - GOTO SKIP_LOOP (ข้าม loan_type 61/62/63) → CONTINUE (label อยู่ท้าย loop = continue)
--   - nvl→coalesce ; sysdate→CURRENT_DATE ; number→numeric ; varchar2/char→text ; date→date
--   - Oracle `date + 1` (วันถัดไป) → PG `+ interval '1 day'` (timestamp + int ใช้ไม่ได้)
--   - spa_dberror(...) (logger) ที่ swallow → ตัด/แทนด้วย RAISE WARNING (ไม่ abort, ช่วย debug)
--   - outer `exception when others` (Oracle: prior DML คงอยู่) → PG: BEGIN/EXCEPTION = subtxn
--       ⇒ error กลางทาง roll back staging ทั้งก้อน (ต่างจาก Oracle ที่เหลือ partial) — ยอมรับได้
--       (staging ที่ build ครึ่งเดียวไม่มีประโยชน์อยู่แล้ว) + RAISE WARNING ให้เห็น error
-- ============================================================================

CREATE SCHEMA IF NOT EXISTS pka_rep_mis;
CREATE SCHEMA IF NOT EXISTS pka_rep_kep;
CREATE SCHEMA IF NOT EXISTS pka_rep_tel;

-- ════════════════════════════════════════════════════════════════════════════
-- 1) pka_rep_mis.sp_paid_loan_by_month — สรุปการจ่ายเงินกู้ รายเดือน [REPMIS 6]
-- ════════════════════════════════════════════════════════════════════════════
CREATE OR REPLACE PROCEDURE pka_rep_mis.sp_paid_loan_by_month(ai_year int)
LANGUAGE plpgsql AS $$
DECLARE
  dr        record;
  lrec      sc_rep_mis_paid_loan_by_month%ROWTYPE;
  ldt_begin date;
  ldt_bdate date;
  ldt_edate date;
  li_count  int;
  ldc_app   numeric;
  li_year   int;
BEGIN
  li_year := ai_year - 543;

  BEGIN
    SELECT beginning_of_account INTO ldt_begin
      FROM sc_acc_m_account_year
     WHERE account_year = li_year;
  EXCEPTION WHEN OTHERS THEN
    RAISE WARNING 'E16:pka_rep_mis.sp_paid_loan_by_month %', SQLERRM;  -- spa_dberror (swallow)
  END;

  -- รื้อ staging ก่อน (Oracle ลบท้าย; rebuild ทั้งตาราง = ผลเท่ากัน)
  DELETE FROM sc_rep_mis_paid_loan_by_month;

  FOR dr IN (
      SELECT loan_type, atm_status, withdraw_flag
        FROM sc_lon_m_rule
       WHERE user_current = '1'
       ORDER BY loan_type
  ) LOOP
      lrec := NULL;
      lrec.loan_type := dr.loan_type;

      ldt_bdate := ldt_begin;

      FOR i IN 1..12 LOOP
          ldt_edate := pka_srv_datetime.fp_lastdayofmonth(ldt_bdate);

          IF dr.atm_status = '0' THEN
              SELECT coalesce(count(1),0), coalesce(sum(loan_approve_amount),0)
                INTO li_count, ldc_app
                FROM sc_lon_m_contract
               WHERE begining_of_contract BETWEEN ldt_bdate AND ldt_edate
                 AND loan_type = dr.loan_type;
          ELSE
              IF dr.withdraw_flag = 'N' THEN
                  -- atm
                  SELECT coalesce(count(1),0), coalesce(sum(trans_amount),0)
                    INTO li_count, ldc_app
                    FROM sc_atm_recv_msg, sc_lon_m_contract
                   WHERE sc_atm_recv_msg.ref_contract = sc_lon_m_contract.loan_contract_no
                     AND response_code = '0000'
                     AND effect_date BETWEEN ldt_bdate AND ldt_edate
                     AND sc_lon_m_contract.loan_type = dr.loan_type;
              ELSE
                  -- mobile
                  SELECT coalesce(count(1),0), coalesce(sum(trans_amount),0)
                    INTO li_count, ldc_app
                    FROM sc_mobile_recv_msg, sc_lon_m_contract
                   WHERE sc_mobile_recv_msg.from_coop = sc_lon_m_contract.loan_contract_no
                     AND method_uri = 'ADDLOAN'
                     AND response_code = 'SUCCESS'
                     AND confirm_status = '1'
                     AND effect_date BETWEEN ldt_bdate AND ldt_edate
                     AND sc_lon_m_contract.loan_type = dr.loan_type;
              END IF;
          END IF;

          CASE i
            WHEN 1  THEN lrec.count_01 := li_count; lrec.amout_01 := ldc_app;
            WHEN 2  THEN lrec.count_02 := li_count; lrec.amout_02 := ldc_app;
            WHEN 3  THEN lrec.count_03 := li_count; lrec.amout_03 := ldc_app;
            WHEN 4  THEN lrec.count_04 := li_count; lrec.amout_04 := ldc_app;
            WHEN 5  THEN lrec.count_05 := li_count; lrec.amout_05 := ldc_app;
            WHEN 6  THEN lrec.count_06 := li_count; lrec.amout_06 := ldc_app;
            WHEN 7  THEN lrec.count_07 := li_count; lrec.amout_07 := ldc_app;
            WHEN 8  THEN lrec.count_08 := li_count; lrec.amout_08 := ldc_app;
            WHEN 9  THEN lrec.count_09 := li_count; lrec.amout_09 := ldc_app;
            WHEN 10 THEN lrec.count_10 := li_count; lrec.amout_10 := ldc_app;
            WHEN 11 THEN lrec.count_11 := li_count; lrec.amout_11 := ldc_app;
            WHEN 12 THEN lrec.count_12 := li_count; lrec.amout_12 := ldc_app;
          END CASE;

          ldt_bdate := ldt_edate + 1;
      END LOOP;

      INSERT INTO sc_rep_mis_paid_loan_by_month SELECT (lrec).*;
  END LOOP;

EXCEPTION WHEN OTHERS THEN
  RAISE WARNING 'E130:pka_rep_mis.sp_paid_loan_by_month %', SQLERRM;  -- spa_dberror (swallow)
END;
$$;

-- ════════════════════════════════════════════════════════════════════════════
-- 2) pka_rep_mis.sp_paid_loan_by_day_in_month — สรุปจ่ายเงินกู้รายวัน [REPMIS 136]
-- ════════════════════════════════════════════════════════════════════════════
CREATE OR REPLACE PROCEDURE pka_rep_mis.sp_paid_loan_by_day_in_month(ai_year int, ai_month int)
LANGUAGE plpgsql AS $$
DECLARE
  dr                           record;
  lrec                         sc_rep_total_loan_by_day%ROWTYPE;
  li_count                     numeric;
  ldc_app                      numeric;
  li_year                      int;
  ldc_app_total                numeric := 0;
  li_loan_approve_amount_total numeric := 0;
  li_real_recieve_total        numeric := 0;
  ldt_date_to                  date;
  li_last_day                  int;
  li_real_recieve              numeric;
  li_loan_approve_amount       numeric;
  ls_loan_type                 text;
BEGIN
  li_year := ai_year - 543;
  ldt_date_to := pka_srv_datetime.fp_lastdayofmonth(to_date('1/'||ai_month||'/'||li_year,'DD/MM/YYYY'));
  li_last_day := extract(day FROM ldt_date_to)::int;

  DELETE FROM sc_rep_total_loan_by_day;

  FOR dr IN (
      SELECT loan_type, atm_status, withdraw_flag
        FROM sc_lon_m_rule
       WHERE user_current = '1'
       ORDER BY loan_type
  ) LOOP
      ls_loan_type := dr.loan_type;
      IF ls_loan_type IN ('61','62','63') THEN
          CONTINUE;  -- เดิม GOTO SKIP_LOOP (label ท้าย loop)
      END IF;

      lrec := NULL;
      lrec.loan_type := dr.loan_type;
      ldc_app_total := 0;
      li_loan_approve_amount_total := 0;
      li_real_recieve_total := 0;

      FOR i IN 1..li_last_day LOOP
          IF dr.atm_status = '0' THEN
              IF ls_loan_type = '60' THEN
                  SELECT coalesce(count(1),0), coalesce(sum(sc_lon_m_contract.loan_approve_amount),0)
                    INTO li_count, ldc_app
                    FROM sc_lon_m_contract, sc_lon_m_loan_request
                   WHERE sc_lon_m_contract.loan_requestment_no = sc_lon_m_loan_request.loan_requestment_no
                     AND sc_lon_m_loan_request.approve_status = '1'
                     AND sc_lon_m_contract.begining_of_contract = to_date(i||'/'||ai_month||'/'||li_year,'DD/MM/YYYY')
                     AND sc_lon_m_contract.loan_type IN ('60','61','62','63');

                  SELECT coalesce(sum(sc_lon_m_contract.real_recieve),0), coalesce(sum(sc_lon_m_contract.loan_approve_amount),0)
                    INTO li_real_recieve, li_loan_approve_amount
                    FROM sc_lon_m_contract, sc_lon_m_loan_request
                   WHERE sc_lon_m_contract.loan_requestment_no = sc_lon_m_loan_request.loan_requestment_no
                     AND sc_lon_m_loan_request.approve_status = '1'
                     AND sc_lon_m_contract.begining_of_contract = to_date(i||'/'||ai_month||'/'||li_year,'DD/MM/YYYY')
                     AND sc_lon_m_contract.loan_type IN ('60','61','62','63');
              ELSE
                  SELECT coalesce(count(1),0), coalesce(sum(sc_lon_m_contract.loan_approve_amount),0)
                    INTO li_count, ldc_app
                    FROM sc_lon_m_contract, sc_lon_m_loan_request
                   WHERE sc_lon_m_contract.loan_requestment_no = sc_lon_m_loan_request.loan_requestment_no
                     AND sc_lon_m_loan_request.approve_status = '1'
                     AND sc_lon_m_contract.begining_of_contract = to_date(i||'/'||ai_month||'/'||li_year,'DD/MM/YYYY')
                     AND sc_lon_m_contract.loan_type = dr.loan_type;

                  SELECT coalesce(sum(sc_lon_m_contract.real_recieve),0), coalesce(sum(sc_lon_m_contract.loan_approve_amount),0)
                    INTO li_real_recieve, li_loan_approve_amount
                    FROM sc_lon_m_contract, sc_lon_m_loan_request
                   WHERE sc_lon_m_contract.loan_requestment_no = sc_lon_m_loan_request.loan_requestment_no
                     AND sc_lon_m_loan_request.approve_status = '1'
                     AND sc_lon_m_contract.begining_of_contract = to_date(i||'/'||ai_month||'/'||li_year,'DD/MM/YYYY')
                     AND sc_lon_m_contract.loan_type = dr.loan_type;
              END IF;
          ELSE
              IF dr.withdraw_flag = 'N' THEN
                  -- atm
                  SELECT coalesce(count(1),0)
                    INTO li_count
                    FROM sc_lon_m_contract, sc_lon_m_loan_request_mpaid, sc_lon_m_loan_request
                   WHERE sc_lon_m_loan_request_mpaid.loan_requestment_no = sc_lon_m_contract.loan_requestment_no
                     AND sc_lon_m_contract.loan_requestment_no = sc_lon_m_loan_request.loan_requestment_no
                     AND sc_lon_m_loan_request_mpaid.other_loan_status = '0'
                     AND sc_lon_m_contract.begining_of_contract = to_date(i||'/'||ai_month||'/'||li_year,'DD/MM/YYYY')
                     AND sc_lon_m_loan_request.approve_status = '1'
                     AND sc_lon_m_loan_request_mpaid.type_pay_money = 'ATM'
                     AND sc_lon_m_contract.loan_type = dr.loan_type;

                  SELECT coalesce(sum(sc_lon_m_contract.loan_approve_amount),0)
                    INTO li_loan_approve_amount
                    FROM sc_lon_m_contract, sc_lon_m_loan_request_mpaid, sc_lon_m_loan_request
                   WHERE sc_lon_m_loan_request_mpaid.loan_requestment_no = sc_lon_m_contract.loan_requestment_no
                     AND sc_lon_m_contract.loan_requestment_no = sc_lon_m_loan_request.loan_requestment_no
                     AND sc_lon_m_loan_request_mpaid.other_loan_status = '0'
                     AND sc_lon_m_contract.begining_of_contract = to_date(i||'/'||ai_month||'/'||li_year,'DD/MM/YYYY')
                     AND sc_lon_m_loan_request.approve_status = '1'
                     AND sc_lon_m_loan_request_mpaid.type_pay_money = 'ATM'
                     AND sc_lon_m_contract.loan_type = dr.loan_type;

                  WITH req_fee_sum AS (
                      SELECT loan_requestment_no, coalesce(sum(amount),0) AS total_req_fee
                        FROM sc_lon_m_req_fee GROUP BY loan_requestment_no
                  ), fund_new_sum AS (
                      SELECT loan_requestment_no, coalesce(sum(fund_new),0) AS total_fund_new
                        FROM sc_lon_m_req_fund_new GROUP BY loan_requestment_no
                  ), fund_ret_sum AS (
                      SELECT loan_requestment_no, coalesce(sum(fund_real),0) AS total_fund_ret
                        FROM sc_lon_m_req_fund_ret WHERE fund_ret > 0 GROUP BY loan_requestment_no
                  )
                  SELECT coalesce(sum(lr.loan_request_amount - lr.total_old_loan - lr.total_oldint
                                      - coalesce(rf.total_req_fee,0) - coalesce(fn.total_fund_new,0)
                                      - lr.buy_share - coalesce(fr.total_fund_ret,0)),0)
                    INTO li_real_recieve
                    FROM sc_lon_m_loan_request_mpaid, sc_lon_m_loan_request lr
                    JOIN sc_lon_m_contract lc ON lr.loan_requestment_no = lc.loan_requestment_no
                    LEFT JOIN req_fee_sum  rf ON lr.loan_requestment_no = rf.loan_requestment_no
                    LEFT JOIN fund_new_sum fn ON lr.loan_requestment_no = fn.loan_requestment_no
                    LEFT JOIN fund_ret_sum fr ON lc.loan_requestment_no = fr.loan_requestment_no
                   WHERE sc_lon_m_loan_request_mpaid.other_loan_status = '0'
                     AND sc_lon_m_loan_request_mpaid.loan_requestment_no = lr.loan_requestment_no
                     AND lc.begining_of_contract = to_date(i||'/'||ai_month||'/'||li_year,'DD/MM/YYYY')
                     AND lr.approve_status = '1'
                     AND sc_lon_m_loan_request_mpaid.type_pay_money = 'ATM'
                     AND lc.loan_type = dr.loan_type;

                  SELECT coalesce(sum((SELECT coalesce(sum(sc_atm_recv_msg.trans_amount),0)
                                         FROM sc_atm_recv_msg
                                        WHERE sc_atm_recv_msg.ref_contract = sc_lon_m_contract.loan_contract_no
                                          AND response_code = '0000')),1)
                    INTO ldc_app
                    FROM sc_lon_m_loan_request, sc_lon_m_rule, sc_lon_m_contract,
                         sc_com_m_branch, sc_lon_m_ucf_loan_payment_type, sc_lon_m_loan_request_mpaid
                   WHERE sc_lon_m_contract.loan_requestment_no = sc_lon_m_loan_request.loan_requestment_no
                     AND sc_lon_m_contract.loan_type = sc_lon_m_rule.loan_type
                     AND sc_com_m_branch.branch_id = sc_lon_m_contract.branch_id
                     AND sc_lon_m_ucf_loan_payment_type.loan_payment_type_code = sc_lon_m_contract.loan_payment_type_code
                     AND sc_lon_m_loan_request_mpaid.loan_requestment_no = sc_lon_m_loan_request.loan_requestment_no
                     AND sc_lon_m_loan_request_mpaid.other_loan_status = '0'
                     AND sc_lon_m_contract.begining_of_contract = to_date(i||'/'||ai_month||'/'||li_year,'DD/MM/YYYY')
                     AND sc_lon_m_loan_request.approve_status = '1'
                     AND sc_lon_m_loan_request_mpaid.type_pay_money = 'ATM'
                     AND sc_lon_m_contract.loan_type = dr.loan_type;
              ELSE
                  -- mobile
                  SELECT coalesce(count(1),0)
                    INTO li_count
                    FROM sc_mobile_recv_msg, sc_lon_m_contract, sc_lon_m_loan_request
                   WHERE sc_mobile_recv_msg.from_coop = sc_lon_m_contract.loan_contract_no
                     AND sc_lon_m_contract.loan_requestment_no = sc_lon_m_loan_request.loan_requestment_no
                     AND method_uri = 'ADDLOAN'
                     AND response_code = 'SUCCESS'
                     AND confirm_status = '1'
                     AND sc_lon_m_loan_request.approve_status = '1'
                     AND effect_date = to_date(i||'/'||ai_month||'/'||li_year,'DD/MM/YYYY')
                     AND sc_lon_m_contract.loan_type = dr.loan_type;

                  SELECT coalesce(sum(sc_lon_m_contract.loan_approve_amount),0)
                    INTO li_loan_approve_amount
                    FROM sc_mobile_recv_msg, sc_lon_m_contract, sc_lon_m_loan_request
                   WHERE sc_mobile_recv_msg.from_coop = sc_lon_m_contract.loan_contract_no
                     AND sc_lon_m_contract.loan_requestment_no = sc_lon_m_loan_request.loan_requestment_no
                     AND method_uri = 'ADDLOAN'
                     AND response_code = 'SUCCESS'
                     AND confirm_status = '1'
                     AND sc_lon_m_loan_request.approve_status = '1'
                     AND effect_date = to_date(i||'/'||ai_month||'/'||li_year,'DD/MM/YYYY')
                     AND sc_lon_m_contract.loan_type = dr.loan_type;

                  WITH req_fee_sum AS (
                      SELECT loan_requestment_no, coalesce(sum(amount),0) AS total_req_fee
                        FROM sc_lon_m_req_fee GROUP BY loan_requestment_no
                  ), fund_new_sum AS (
                      SELECT loan_requestment_no, coalesce(sum(fund_new),0) AS total_fund_new
                        FROM sc_lon_m_req_fund_new GROUP BY loan_requestment_no
                  ), fund_ret_sum AS (
                      SELECT loan_requestment_no, coalesce(sum(fund_real),0) AS total_fund_ret
                        FROM sc_lon_m_req_fund_ret WHERE fund_ret > 0 GROUP BY loan_requestment_no
                  )
                  SELECT coalesce(sum(lr.loan_request_amount - lr.total_old_loan - lr.total_oldint
                                      - coalesce(rf.total_req_fee,0) - coalesce(fn.total_fund_new,0)
                                      - lr.buy_share - coalesce(fr.total_fund_ret,0)),0)
                    INTO li_real_recieve
                    FROM sc_lon_m_loan_request_mpaid, sc_lon_m_loan_request lr
                    JOIN sc_lon_m_contract lc ON lr.loan_requestment_no = lc.loan_requestment_no
                    LEFT JOIN req_fee_sum  rf ON lr.loan_requestment_no = rf.loan_requestment_no
                    LEFT JOIN fund_new_sum fn ON lr.loan_requestment_no = fn.loan_requestment_no
                    LEFT JOIN fund_ret_sum fr ON lc.loan_requestment_no = fr.loan_requestment_no
                   WHERE sc_lon_m_loan_request_mpaid.other_loan_status = '0'
                     AND sc_lon_m_loan_request_mpaid.loan_requestment_no = lr.loan_requestment_no
                     AND lc.begining_of_contract = to_date(i||'/'||ai_month||'/'||li_year,'DD/MM/YYYY')
                     AND lr.approve_status = '1'
                     AND sc_lon_m_loan_request_mpaid.type_pay_money = 'ATM'
                     AND lc.loan_type = dr.loan_type;

                  SELECT coalesce(sum((SELECT coalesce(sum(sc_atm_recv_msg.trans_amount),0)
                                         FROM sc_atm_recv_msg
                                        WHERE sc_atm_recv_msg.ref_contract = sc_lon_m_contract.loan_contract_no
                                          AND response_code = '0000')),0)
                    INTO ldc_app
                    FROM sc_lon_m_loan_request, sc_lon_m_rule, sc_lon_m_contract,
                         sc_com_m_branch, sc_lon_m_ucf_loan_payment_type, sc_lon_m_loan_request_mpaid
                   WHERE sc_lon_m_contract.loan_requestment_no = sc_lon_m_loan_request.loan_requestment_no
                     AND sc_lon_m_contract.loan_type = sc_lon_m_rule.loan_type
                     AND sc_com_m_branch.branch_id = sc_lon_m_contract.branch_id
                     AND sc_lon_m_ucf_loan_payment_type.loan_payment_type_code = sc_lon_m_contract.loan_payment_type_code
                     AND sc_lon_m_loan_request_mpaid.loan_requestment_no = sc_lon_m_loan_request.loan_requestment_no
                     AND sc_lon_m_loan_request_mpaid.other_loan_status = '0'
                     AND sc_lon_m_contract.begining_of_contract = to_date(i||'/'||ai_month||'/'||li_year,'DD/MM/YYYY')
                     AND sc_lon_m_loan_request.approve_status = '1'
                     AND sc_lon_m_loan_request_mpaid.type_pay_money = 'ATM'
                     AND sc_lon_m_contract.loan_type = dr.loan_type;
              END IF;
          END IF;

          CASE i
            WHEN 1 THEN lrec.day1 := li_count;   WHEN 2 THEN lrec.day2 := li_count;
            WHEN 3 THEN lrec.day3 := li_count;   WHEN 4 THEN lrec.day4 := li_count;
            WHEN 5 THEN lrec.day5 := li_count;   WHEN 6 THEN lrec.day6 := li_count;
            WHEN 7 THEN lrec.day7 := li_count;   WHEN 8 THEN lrec.day8 := li_count;
            WHEN 9 THEN lrec.day9 := li_count;   WHEN 10 THEN lrec.day10 := li_count;
            WHEN 11 THEN lrec.day11 := li_count; WHEN 12 THEN lrec.day12 := li_count;
            WHEN 13 THEN lrec.day13 := li_count; WHEN 14 THEN lrec.day14 := li_count;
            WHEN 15 THEN lrec.day15 := li_count; WHEN 16 THEN lrec.day16 := li_count;
            WHEN 17 THEN lrec.day17 := li_count; WHEN 18 THEN lrec.day18 := li_count;
            WHEN 19 THEN lrec.day19 := li_count; WHEN 20 THEN lrec.day20 := li_count;
            WHEN 21 THEN lrec.day21 := li_count; WHEN 22 THEN lrec.day22 := li_count;
            WHEN 23 THEN lrec.day23 := li_count; WHEN 24 THEN lrec.day24 := li_count;
            WHEN 25 THEN lrec.day25 := li_count; WHEN 26 THEN lrec.day26 := li_count;
            WHEN 27 THEN lrec.day27 := li_count; WHEN 28 THEN lrec.day28 := li_count;
            WHEN 29 THEN lrec.day29 := li_count; WHEN 30 THEN lrec.day30 := li_count;
            WHEN 31 THEN lrec.day31 := li_count;
            ELSE NULL;
          END CASE;

          ldc_app_total := ldc_app_total + ldc_app;
          li_loan_approve_amount_total := li_loan_approve_amount_total + li_loan_approve_amount;
          li_real_recieve_total := li_real_recieve_total + li_real_recieve;
      END LOOP;

      lrec.total_loan     := ldc_app_total;
      lrec.total_contract := li_loan_approve_amount_total;
      lrec.total_paid     := li_real_recieve_total;
      lrec.rep_month      := ai_month;
      lrec.rep_year       := ai_year;

      INSERT INTO sc_rep_total_loan_by_day SELECT (lrec).*;
  END LOOP;

EXCEPTION WHEN OTHERS THEN
  RAISE WARNING 'E130:pka_rep_mis.sp_paid_loan_by_day_in_month % % %', ls_loan_type, li_year, SQLERRM;
END;
$$;

-- ════════════════════════════════════════════════════════════════════════════
-- 3) pka_rep_kep.sp_process_kep_return — คงค้างคืนใบเสร็จรายเดือน (BOK) [REPKEP 1348]
-- ════════════════════════════════════════════════════════════════════════════
CREATE OR REPLACE PROCEDURE pka_rep_kep.sp_process_kep_return(adt_book_date date, ai_year int, ai_month int)
LANGUAGE plpgsql AS $$
DECLARE
  dr               record;
  li_year          int;
  ldtm_last_return date;
  ldc_share        numeric;
  ldc_loan         numeric;
  ldc_period_arr   numeric;
BEGIN
  li_year := ai_year - 543;

  -- 1. หาวันที่ใบเสร็จ ของเดือนล่าสุด
  BEGIN
    SELECT receipt_date INTO ldtm_last_return
      FROM sc_kep_m_monthly_process
     WHERE receive_year = li_year AND receive_month = ai_month;
  EXCEPTION WHEN OTHERS THEN
    RAISE WARNING 'E1272:ไม่พบวันที่ใบเสร็จ %', SQLERRM;  -- spa_dberror (swallow)
  END;

  -- 2. Delete (BOK) ลบก่อนเสมอ
  DELETE FROM sc_rep_kep_return_month WHERE rep_type = 'BOK';

  -- 3.1 insert ทุกคนที่คืนใบเสร็จในเดือนที่ประมวล → ผิดนัด 1 งวด
  INSERT INTO sc_rep_kep_return_month
        ( membership_no, count_month, last_month, last_year, book_date, rep_type, last_return, prin_arr )
  SELECT head_a.membership_no, 1, head_a.receive_month, head_a.receive_year,
         adt_book_date, 'BOK', head_a.receipt_date, head_a.kep_amount - head_a.kep_method_amount
    FROM sc_kep_t_monthly_receive head_a, sc_mem_m_membership_registered
   WHERE sc_mem_m_membership_registered.membership_no = head_a.membership_no
     AND head_a.receipt_status = '2'
     AND head_a.ppm_status = '0'
     AND head_a.receipt_date = ldtm_last_return
     AND head_a.membership_no IN (
            SELECT rec_det.membership_no
              FROM sc_kep_t_monthly_receive_det rec_det, sc_kep_m_ucf_keeping_item_type
             WHERE rec_det.keeping_type_code = sc_kep_m_ucf_keeping_item_type.keeping_type_code
               AND rec_det.unkeep_money_amount > 0
               AND rec_det.mrpay_newcontract_status = '0'
               AND rec_det.receive_year  = head_a.receive_year
               AND rec_det.receive_month = head_a.receive_month
               AND sc_kep_m_ucf_keeping_item_type.not_ask_staus = '0');

  -- 3.2 update คนที่ผิดนัดต่อเนื่อง (ไล่วันที่ใบเสร็จย้อนหลัง)
  FOR dr IN (
      SELECT return_date FROM (
          SELECT receipt_date AS return_date
            FROM sc_kep_m_monthly_process
           WHERE receipt_date < ldtm_last_return
           ORDER BY receipt_date DESC
      ) tb
  ) LOOP
      UPDATE sc_rep_kep_return_month
         SET count_month = count_month + 1, last_return = dr.return_date
       WHERE rep_type = 'BOK'
         AND last_return = ldtm_last_return
         AND membership_no IN (
                SELECT head_a.membership_no
                  FROM sc_kep_t_monthly_receive head_a
                 WHERE head_a.receipt_status = '2'
                   AND head_a.ppm_status = '0'
                   AND head_a.receipt_date = dr.return_date
                   AND head_a.membership_no IN (
                          SELECT rec_det.membership_no
                            FROM sc_kep_t_monthly_receive_det rec_det, sc_kep_m_ucf_keeping_item_type
                           WHERE rec_det.keeping_type_code = sc_kep_m_ucf_keeping_item_type.keeping_type_code
                             AND rec_det.unkeep_money_amount > 0
                             AND rec_det.mrpay_newcontract_status = '0'
                             AND rec_det.receive_year  = head_a.receive_year
                             AND rec_det.receive_month = head_a.receive_month
                             AND sc_kep_m_ucf_keeping_item_type.not_ask_staus = '0'));

      ldtm_last_return := dr.return_date;
  END LOOP;

  -- 3.3 คำนวณ period_arr จาก prin_arr (Niorn 2023-09-02)
  FOR dr IN (SELECT membership_no FROM sc_rep_kep_return_month) LOOP
      SELECT coalesce(sum(period_payment_amount),0) INTO ldc_loan
        FROM sc_lon_m_contract, sc_lon_m_loan_card, sc_lon_m_rule
       WHERE sc_lon_m_rule.loan_type = sc_lon_m_contract.loan_type
         AND sc_lon_m_contract.loan_contract_no = sc_lon_m_loan_card.loan_contract_no
         AND sc_lon_m_rule.drop_all = '0'
         AND sc_lon_m_loan_card.principal_balance > 0
         AND sc_lon_m_loan_card.membership_no = dr.membership_no;

      SELECT coalesce(sum(share_amount),0) INTO ldc_share
        FROM sc_mem_m_share_mem
       WHERE sc_mem_m_share_mem.drop_status = '0'
         AND sc_mem_m_share_mem.membership_no = dr.membership_no;

      IF ldc_loan + ldc_share = 0 THEN
          ldc_period_arr := 1;
      ELSE
          ldc_period_arr := ldc_loan + ldc_share;
      END IF;

      UPDATE sc_rep_kep_return_month
         SET period_arr = ceil(prin_arr / ldc_period_arr)
       WHERE rep_type = 'BOK'
         AND membership_no = dr.membership_no;
  END LOOP;

EXCEPTION WHEN OTHERS THEN
  RAISE WARNING 'pka_rep_kep.sp_process_kep_return %', SQLERRM;
END;
$$;

-- ════════════════════════════════════════════════════════════════════════════
-- 4) pka_rep_kep.sp_process_kep_return_rep — คงค้าง (REP, ผิดนัด≤2งวด) [REPKEP 1506]
-- ════════════════════════════════════════════════════════════════════════════
CREATE OR REPLACE PROCEDURE pka_rep_kep.sp_process_kep_return_rep(ai_year int, ai_month int)
LANGUAGE plpgsql AS $$
DECLARE
  dr            record;
  li_year       int;
  ldtm_before   date;
  ldtm_present  date;
  ls_mem_no     text := ' ';
BEGIN
  -- spa_dberror('E1441:...') เดิมเป็น logger (ไม่ abort) → drop
  li_year := ai_year - 543;

  -- 1. วันที่ใบเสร็จเดือนล่าสุด
  BEGIN
    SELECT receipt_date INTO ldtm_present
      FROM sc_kep_m_monthly_process
     WHERE receive_year = li_year AND receive_month = ai_month;
  EXCEPTION WHEN OTHERS THEN
    RAISE WARNING 'E1357:ไม่พบวันที่ใบเสร็จ %', SQLERRM;
  END;

  -- 2. วันที่ใบเสร็จเดือนก่อนหน้า (ย้อน 12 เดือน, ตรึงวันที่ 28)
  ldtm_before := pka_srv_datetime.fp_relativemonth(ldtm_present::timestamp, -12);
  ldtm_before := to_date('28/'||to_char(ldtm_before,'MM/YYYY'),'DD/MM/YYYY');

  -- 3.1 Delete (REP)
  DELETE FROM sc_rep_kep_return_month WHERE rep_type = 'REP';

  -- 3.2 ไล่คนที่คืนใบเสร็จย้อนกลับ (เรียงวันที่ใบเสร็จมากก่อน)
  FOR dr IN (
      SELECT head_a.membership_no, head_a.receive_month, head_a.receive_year, head_a.receipt_date
        FROM sc_kep_t_monthly_receive head_a
       WHERE head_a.receipt_status = '2'
         AND head_a.membership_no IN (
                SELECT rec_det.membership_no
                  FROM sc_kep_t_monthly_receive_det rec_det, sc_kep_m_ucf_keeping_item_type
                 WHERE rec_det.keeping_type_code = sc_kep_m_ucf_keeping_item_type.keeping_type_code
                   AND rec_det.mrpay_newcontract_status = '0'
                   AND rec_det.receive_year  = head_a.receive_year
                   AND rec_det.receive_month = head_a.receive_month
                   AND sc_kep_m_ucf_keeping_item_type.not_ask_staus = '0')
         AND head_a.receipt_date >= ldtm_before
       ORDER BY head_a.membership_no, head_a.receipt_date DESC
  ) LOOP
      -- 3.3 ทะเบียนใหม่ + ใบเสร็จ = เดือนล่าสุด → insert (ผิดนัด 1 งวด)
      IF dr.membership_no <> ls_mem_no AND ldtm_present = dr.receipt_date THEN
          INSERT INTO sc_rep_kep_return_month
                ( membership_no, count_month, last_month, last_year, book_date, rep_type )
          VALUES ( dr.membership_no, 1, dr.receive_month, dr.receive_year, CURRENT_DATE, 'REP');
          ls_mem_no := dr.membership_no;
      ELSE
          -- 3.4 ใบเสร็จ < เดือนล่าสุด → +1 งวด (ผิดนัดเดือนก่อนด้วย)
          IF dr.receipt_date < ldtm_present THEN
              UPDATE sc_rep_kep_return_month
                 SET count_month = count_month + 1,
                     last_month  = dr.receive_month,
                     last_year   = dr.receive_year
               WHERE membership_no = dr.membership_no
                 AND rep_type = 'REP';
          END IF;
      END IF;
  END LOOP;

EXCEPTION WHEN OTHERS THEN
  RAISE WARNING 'pka_rep_kep.sp_process_kep_return_rep %', SQLERRM;
END;
$$;

-- ════════════════════════════════════════════════════════════════════════════
-- 5) pka_rep_tel.sp_rep_2label_mem_retire — label 2 คอลัมน์ สมาชิกเกษียณ [REPTEL 2857]
-- ════════════════════════════════════════════════════════════════════════════
CREATE OR REPLACE PROCEDURE pka_rep_tel.sp_rep_2label_mem_retire(
  ai_year int, as_bmem text DEFAULT '000000', as_emem text DEFAULT '999999')
LANGUAGE plpgsql AS $$
DECLARE
  dr       record;
  ls_bmem  text;
  ls_emem  text;
  ll_row   int := 1;
  li_index int := 0;
  li_year  int;
BEGIN
  IF as_bmem IS NULL OR as_bmem = '!NL!' THEN ls_bmem := '000000'; ELSE ls_bmem := as_bmem; END IF;
  IF as_emem IS NULL THEN ls_emem := '999999'; ELSE ls_emem := as_emem; END IF;
  li_year := ai_year - 543;

  DELETE FROM sc_rep_2label_mem_retire;

  FOR dr IN (
      SELECT sc_mem_m_membership_registered.membership_no
        FROM sc_mem_m_member_address, sc_mem_m_membership_registered,
             sc_mem_m_ucf_province, sc_mem_m_ucf_district
       WHERE sc_mem_m_membership_registered.membership_no = sc_mem_m_member_address.membership_no
         AND sc_mem_m_member_address.province_code = sc_mem_m_ucf_province.province_code
         AND sc_mem_m_member_address.district_code = sc_mem_m_ucf_district.district_code
         AND sc_mem_m_ucf_district.province_code = sc_mem_m_member_address.province_code
         AND sc_mem_m_membership_registered.member_status_code = '0'
         AND pka_lon_reqsrv.fp_calc_member_retire(sc_mem_m_membership_registered.membership_no)
             = (SELECT end_date + interval '1 day' FROM sc_lon_m_close_year WHERE lon_year = li_year)
         AND sc_mem_m_member_address.address_type = '0'
         AND sc_mem_m_membership_registered.membership_no BETWEEN ls_bmem AND ls_emem
       ORDER BY sc_mem_m_membership_registered.membership_no
  ) LOOP
      li_index := li_index + 1;
      CASE li_index
        WHEN 1 THEN
          INSERT INTO sc_rep_2label_mem_retire (seq_no, memno_1)
          VALUES (ll_row, dr.membership_no);
        WHEN 2 THEN
          UPDATE sc_rep_2label_mem_retire SET memno_2 = dr.membership_no WHERE seq_no = ll_row;
          ll_row := ll_row + 1;
          li_index := 0;
      END CASE;
  END LOOP;

EXCEPTION WHEN OTHERS THEN
  RAISE WARNING 'sp_rep_2label_mem_retire(%,%) %', as_bmem, as_emem, SQLERRM;
END;
$$;
