-- ============================================================================
-- step 6 function-first sweep — batch 9a (ยอดคงเหลือ ณ วันที่ — balance-at-date family)
-- port (รายงาน rcTeller เรียกผ่าน pka_com_function):
--   pka_com_valid.status_active(text)                              [VALID 1217]  lookup config flag
--   pka_kep_yproc.fp_share_effect(date,text,text)                  [YPROC 1744]  วันที่มีผลของหุ้น (3-arg)
--   pka_kep_yproc.fp_share_effect(text,int)                        [YPROC 1772]  เรียกผ่าน seq_no (2-arg)
--   pka_rep_tel.loan_balance_atdate(text,ts,int)                   [REPTEL 1981] core หนี้คงเหลือ ณ วันที่
--   pka_rep_tel.share_balance_atdate(text,ts,int)                  [REPTEL 2044] core หุ้นคงเหลือ ณ วันที่
--   pka_com_function.fp_lon_get_balance_atdate(text,ts)            [FUNC 1232]   delegate → loan_balance_atdate  [14]
--   pka_com_function.fp_lon_get_balance_atdate(text,text,ts)       [FUNC 1208]   รวมทุกสัญญาของ memno+loantype
--   pka_com_function.fp_lon_get_balance_atnow(text)               [FUNC 1802]   sum principal_balance ปัจจุบัน  [3]
--   pka_com_function.fp_shr_get_balance_atdate(text,ts)           [FUNC 1125]   delegate → share_balance_atdate [34]
--   pka_com_function.fp_get_intarr_card_atdate(ts,text)           [FUNC 1979]   ดบ.ค้างฉุกเฉิน ณ วันที่ [1]
--
-- โครงจริง: fp_shr_/fp_lon_get_balance_atdate ใน pka_com_function เป็น thin delegate
--   → core logic อยู่ pka_rep_tel.{loan,share}_balance_atdate (ยอดปัจจุบัน − เงินต้น/เงินหุ้นที่เกิดหลัง atdate)
--
-- PEAN simplification (ตรวจ live): sc_cnt_m_status_active ไม่มี row 'ShareDividenDateEffectedByCalintDate'
--   → status_active คืน '0' → fp_share_effect เข้า else เสมอ (คืน operate_date). พอร์ต faithful ไม่ hardcode
--   (config เปลี่ยนได้ → คง path 'พ'/'ก' lookup sc_com_m_receipt.calcint_date ไว้ครบ)
--
-- deviation (Legacy Fidelity):
--   - spa_dberror(...) (logger) → ตัดทิ้ง; outer handler เดิม fall-through ไม่ return → mirror เป็น RETURN NULL
--     (callers coalesce/เทียบ '1' → NULL = inactive เทียบเท่า '0'/0 เดิม)
--   - 3-arg fp_lon_get_balance_atdate: BULK COLLECT loop+sum → SQL sum(loan_balance_atdate(conno,atdate)) ตรง
--   - CASE …loan_payment_date ELSE loan_payment_date END (2 branch เหมือนกัน) → loan_payment_date เฉยๆ
--   - number→numeric (core) ; pka_com_function entries คืน double precision ให้ตรง stub family เดิม
--   - char/varchar2→text ; date→timestamp ; seq_no (double precision ใน PG) → ::int ตอนส่งเข้า fp_share_effect
--   - fp_shr_get_balance_atdate มี view dep (view_tge_dep_coll_head) + ไม่มี param name →
--       CREATE OR REPLACE ใช้ $1/$2 (gotcha เดียวกับ batch7d)
-- ============================================================================

CREATE SCHEMA IF NOT EXISTS pka_rep_tel;
CREATE SCHEMA IF NOT EXISTS pka_kep_yproc;
CREATE SCHEMA IF NOT EXISTS pka_com_valid;

-- ---- status_active : อ่านสถานะเปิด/ปิด config flag จาก sc_cnt_m_status_active [VALID 1217] ----
CREATE OR REPLACE FUNCTION pka_com_valid.status_active(as_status_code text)
RETURNS text LANGUAGE plpgsql STABLE AS $$
DECLARE ls_valid text;
BEGIN
  SELECT active_status INTO STRICT ls_valid
    FROM sc_cnt_m_status_active
   WHERE trim(status_code) = trim(as_status_code);
  RETURN coalesce(nullif(trim(ls_valid),''),'0');
EXCEPTION
  WHEN no_data_found THEN RETURN '0';
  WHEN others THEN RETURN NULL;  -- spa_dberror('status_active')
END;
$$;

-- ---- fp_share_effect (3-arg) : วันที่มีผลของรายการหุ้น [YPROC 1744] ----
-- ถ้า flag ShareDividenDateEffectedByCalintDate='1' และเอกสารขึ้นต้น 'พ'/'ก' (หุ้นพิเศษ/หุ้นจากการกู้)
-- → ใช้วันที่คิดดบ.จากใบเสร็จ ; มิฉะนั้น → วันที่ทำรายการ
CREATE OR REPLACE FUNCTION pka_kep_yproc.fp_share_effect(adt_operate timestamp, as_docno text, as_item_type text)
RETURNS timestamp LANGUAGE plpgsql STABLE AS $$
DECLARE ldt_calint_date timestamp;
BEGIN
  IF pka_com_valid.status_active('ShareDividenDateEffectedByCalintDate') = '1' THEN
    IF substr(as_docno,1,1) IN ('พ','ก') THEN
      BEGIN
        SELECT calcint_date INTO STRICT ldt_calint_date
          FROM sc_com_m_receipt
         WHERE receipt_no = as_docno;
      EXCEPTION WHEN others THEN ldt_calint_date := NULL;
      END;
    END IF;
    IF ldt_calint_date IS NULL THEN
      RETURN adt_operate;
    ELSE
      RETURN ldt_calint_date;
    END IF;
  ELSE
    RETURN adt_operate;
  END IF;
EXCEPTION WHEN others THEN RETURN NULL;  -- spa_dberror('fp_share_effect')
END;
$$;

-- ---- fp_share_effect (2-arg) : หา operate/doc/item ของ (memno,seq) แล้วเรียก 3-arg [YPROC 1772] ----
CREATE OR REPLACE FUNCTION pka_kep_yproc.fp_share_effect(as_memno text, ai_seqno int)
RETURNS timestamp LANGUAGE plpgsql STABLE AS $$
DECLARE dr record;
BEGIN
  FOR dr IN
    SELECT operate_date, doc_no, item_type
      FROM sc_mem_m_share_holding_detail
     WHERE membership_no = as_memno
       AND seq_no = ai_seqno
  LOOP
    RETURN pka_kep_yproc.fp_share_effect(dr.operate_date, dr.doc_no, dr.item_type);
  END LOOP;
  RETURN NULL;
EXCEPTION WHEN others THEN RETURN NULL;  -- spa_dberror('fp_share_effect')
END;
$$;

-- ---- loan_balance_atdate : หนี้คงเหลือของสัญญา ณ วันที่ [REPTEL 1981] ----
-- ยอดปัจจุบัน − เงินต้นที่ชำระหลัง atdate (item ที่ sign_status=±1, ยกเว้น 'BF')
-- ai_seqno>0 : หักรายการวันเดียวกันที่ seq เกิดทีหลังด้วย
CREATE OR REPLACE FUNCTION pka_rep_tel.loan_balance_atdate(as_conno text, adt_atdate timestamp DEFAULT NULL, ai_seqno int DEFAULT NULL)
RETURNS numeric LANGUAGE plpgsql STABLE AS $$
DECLARE
  ldc_balance numeric;
  ldc_payment numeric;
  ldc_sameday numeric;
BEGIN
  SELECT sum(principal_balance) INTO ldc_balance
    FROM sc_lon_m_loan_card
   WHERE loan_contract_no = as_conno;
  ldc_balance := coalesce(ldc_balance,0);

  IF adt_atdate IS NULL THEN
    RETURN ldc_balance;
  END IF;

  SELECT sum(d.payment_amount * i.sign_status::numeric) INTO ldc_payment
    FROM sc_lon_m_loan_card_detail d
    JOIN sc_lon_m_loan_card c ON c.loan_contract_no = d.loan_contract_no
    JOIN sc_lon_m_ucf_loan_card_item i ON i.item_type_code = d.item_type_code
   WHERE i.sign_status IN (1,-1)
     AND i.item_type_code <> 'BF'
     AND d.loan_payment_date > adt_atdate   -- CASE 2 branch เหมือนกัน → ตัด
     AND c.loan_contract_no = as_conno;
  ldc_balance := ldc_balance - coalesce(ldc_payment,0);

  IF ai_seqno > 0 THEN
    SELECT sum(d.payment_amount * i.sign_status::numeric) INTO ldc_sameday
      FROM sc_lon_m_loan_card_detail d
      JOIN sc_lon_m_loan_card c ON c.loan_contract_no = d.loan_contract_no
      JOIN sc_lon_m_ucf_loan_card_item i ON i.item_type_code = d.item_type_code
     WHERE i.sign_status IN (1,-1)
       AND i.item_type_code <> 'BF'
       AND d.loan_payment_date = adt_atdate
       AND d.seq_no > ai_seqno
       AND c.loan_contract_no = as_conno;
    ldc_balance := ldc_balance - coalesce(ldc_sameday,0);
  END IF;

  RETURN ldc_balance;
EXCEPTION WHEN others THEN RETURN NULL;  -- spa_dberror('loan_balance_atdate')
END;
$$;

-- ---- share_balance_atdate : หุ้นคงเหลือ ณ วันที่ [REPTEL 2044] ----
-- ยอดปัจจุบัน − เงินซื้อหุ้นที่มีผลหลัง atdate (วันที่มีผลผ่าน fp_share_effect)
CREATE OR REPLACE FUNCTION pka_rep_tel.share_balance_atdate(as_memno text, adt_atdate timestamp DEFAULT NULL, ai_seqno int DEFAULT NULL)
RETURNS numeric LANGUAGE plpgsql STABLE AS $$
DECLARE
  ldc_balance numeric;
  ldc_payment numeric;
  ldc_sameday numeric;
BEGIN
  SELECT sum(share_stock) INTO ldc_balance
    FROM sc_mem_m_share_mem
   WHERE membership_no = as_memno;
  ldc_balance := coalesce(ldc_balance,0);

  IF adt_atdate IS NULL THEN
    RETURN ldc_balance;
  END IF;

  SELECT sum(h.share_value * t.sign_flag::numeric) INTO ldc_payment
    FROM sc_mem_m_share_holding_detail h
    JOIN sc_mem_m_share_mem m ON m.membership_no = h.membership_no
    JOIN sc_mem_m_ucf_share_item_type t ON t.item_type = h.item_type
   WHERE t.sign_flag IN (1,-1)
     AND t.item_type <> 'BF'
     AND pka_kep_yproc.fp_share_effect(h.membership_no, h.seq_no::int) > adt_atdate
     AND m.membership_no = as_memno;
  ldc_balance := ldc_balance - coalesce(ldc_payment,0);

  IF ai_seqno > 0 THEN
    SELECT sum(h.share_value * t.sign_flag::numeric) INTO ldc_sameday
      FROM sc_mem_m_share_holding_detail h
      JOIN sc_mem_m_share_mem m ON m.membership_no = h.membership_no
      JOIN sc_mem_m_ucf_share_item_type t ON t.item_type = h.item_type
     WHERE t.sign_flag IN (1,-1)
       AND t.item_type <> 'BF'
       AND pka_kep_yproc.fp_share_effect(h.membership_no, h.seq_no::int) = adt_atdate
       AND h.seq_no > ai_seqno
       AND m.membership_no = as_memno;
    ldc_balance := ldc_balance - coalesce(ldc_sameday,0);
  END IF;

  RETURN ldc_balance;
EXCEPTION WHEN others THEN RETURN NULL;  -- spa_dberror('share_balance_atdate')
END;
$$;

-- ---- fp_lon_get_balance_atdate (conno,atdate) : delegate → loan_balance_atdate [FUNC 1232] [14] ----
CREATE OR REPLACE FUNCTION pka_com_function.fp_lon_get_balance_atdate(as_conno text, adt_atdate timestamp)
RETURNS double precision LANGUAGE plpgsql STABLE AS $$
BEGIN
  RETURN pka_rep_tel.loan_balance_atdate(as_conno, adt_atdate)::double precision;
EXCEPTION WHEN others THEN RETURN 0;  -- spa_dberror('fp_lon_get_balance_atdate')
END;
$$;

-- ---- fp_lon_get_balance_atdate (memno,loantype,atdate) : รวมทุกสัญญา [FUNC 1208] ----
CREATE OR REPLACE FUNCTION pka_com_function.fp_lon_get_balance_atdate(as_memno text, as_loantype text, adt_atdate timestamp)
RETURNS double precision LANGUAGE plpgsql STABLE AS $$
DECLARE ldc_sum numeric;
BEGIN
  SELECT coalesce(sum(pka_rep_tel.loan_balance_atdate(c.loan_contract_no, adt_atdate)),0) INTO ldc_sum
    FROM sc_mem_m_membership_registered r
    JOIN sc_lon_m_loan_card c ON c.membership_no = r.membership_no
   WHERE r.membership_no = as_memno
     AND c.loan_type = as_loantype;
  RETURN coalesce(ldc_sum,0)::double precision;
EXCEPTION WHEN others THEN RETURN 0;  -- spa_dberror('fp_lon_get_balance_atdate')
END;
$$;

-- ---- fp_lon_get_balance_atnow : sum principal_balance ปัจจุบัน [FUNC 1802] [3] ----
CREATE OR REPLACE FUNCTION pka_com_function.fp_lon_get_balance_atnow(as_memno text)
RETURNS double precision LANGUAGE plpgsql STABLE AS $$
DECLARE ldc_balance numeric;
BEGIN
  SELECT sum(principal_balance) INTO ldc_balance
    FROM sc_lon_m_loan_card
   WHERE membership_no = as_memno
     AND principal_balance > 0;
  RETURN ldc_balance::double precision;
EXCEPTION WHEN others THEN RETURN NULL;  -- spa_dberror('fp_lon_get_balance_atnow')
END;
$$;

-- ---- fp_shr_get_balance_atdate : delegate → share_balance_atdate [FUNC 1125] [34] ----
-- (มี view dep view_tge_dep_coll_head + ไม่มี param name → CREATE OR REPLACE + $1/$2)
CREATE OR REPLACE FUNCTION pka_com_function.fp_shr_get_balance_atdate(text, timestamp)
RETURNS double precision LANGUAGE plpgsql STABLE AS $$
BEGIN
  RETURN pka_rep_tel.share_balance_atdate($1, $2)::double precision;
EXCEPTION WHEN others THEN RETURN 0;  -- spa_dberror('fp_shr_get_balance_atdate')
END;
$$;

-- ---- fp_get_intarr_card_atdate : ดบ.ค้างฉุกเฉิน ณ วันที่ จาก sc_rep_mem_share_loan_bal [FUNC 1979] [1] ----
CREATE OR REPLACE FUNCTION pka_com_function.fp_get_intarr_card_atdate(adt_date timestamp, as_conno text)
RETURNS text LANGUAGE plpgsql STABLE AS $$
DECLARE ldc_intarr numeric;
BEGIN
  BEGIN
    SELECT emer_intarr_card INTO STRICT ldc_intarr
      FROM sc_rep_mem_share_loan_bal
     WHERE balance_date = adt_date
       AND emer_contract = as_conno;
  EXCEPTION WHEN others THEN ldc_intarr := 0;
  END;
  RETURN ldc_intarr::text;
EXCEPTION WHEN others THEN RETURN '0';
END;
$$;
