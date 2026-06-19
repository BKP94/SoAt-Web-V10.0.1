-- ============================================================================
-- step 6 function-first sweep — batch 9c-2 (INFERRED: fp_rep_collateral_type / fp_rep_req_fee)
-- เรียกโดย: rcTeller/memDetail/r_mwa_tel_mem_loan_detail.xml (main SQL, alias type_collateral/type_fee)
--   pka_rep_loan.fp_rep_collateral_type(loan_contract_no, ',') as type_collateral
--   pka_rep_loan.fp_rep_req_fee(loan_contract_no, ',')         as type_fee
--
-- ⚠️ DEVIATION (Legacy Fidelity) — INFERRED IMPLEMENTATION (ไม่ใช่ port):
--   ทั้ง 2 ฟังก์ชัน **ไม่มี source ใน Oracle export** (C:\SoAt_PEAN\Admin\Export — grep ไม่เจอ
--   ทั้ง PACKAGE_BODY/SPEC). ผู้ใช้สั่ง (Q2 batch9c) = "infer ขั้นต่ำให้ report รัน".
--   จึง implement ตาม pattern พี่น้องที่มี source จริง: pkb_amnat.fp_get_memcoll_str (:1128)
--   = "distinct value → join ด้วย separator → trim → exception→null". signature (conno, sep)
--   ที่ report ส่ง ',' = ตัวคั่น (string_agg separator).
--   ถ้าภายหลังเจอ source จริงของ Oracle ต้อง re-port ทับให้ faithful.
--
--   อนุมานความหมายจากชื่อ + alias + ตารางจริงใน PG:
--     fp_rep_collateral_type = "ชนิดหลักประกันของสัญญา" (distinct collateral_description)
--       sc_lon_m_contract_coll (loan_contract_no) → master sc_lon_m_ucf_collateral_type
--       กรอง active (status='0' OR null) ตาม fp_get_memcoll_str
--     fp_rep_req_fee = "ประเภทค่าธรรมเนียมของคำขอ" (distinct fee_name)
--       contract → loan_requestment_no → sc_lon_m_req_fee → master sc_lon_m_ucf_fee
--
--   verify (01-00213/2564, req ส64/0188): type_collateral = 'เงินฝากค้ำประกัน,สมาชิกค้ำประกัน'
--     (coll 01 ×2 + 03 → distinct 2 ค่า), type_fee = NULL (สัญญานี้ไม่มีแถว req_fee = report ยังรันได้)
--   มาตรฐานแปล: Oracle `||sep` accumulator → string_agg(distinct ..., sep); trim; exception→NULL
-- ============================================================================

CREATE SCHEMA IF NOT EXISTS pka_rep_loan;

-- ---- fp_rep_collateral_type : ชนิดหลักประกันของสัญญา (distinct, join ด้วย as_sep) [INFERRED] ----
CREATE OR REPLACE FUNCTION pka_rep_loan.fp_rep_collateral_type(as_conno text, as_sep text DEFAULT ',')
RETURNS text LANGUAGE plpgsql STABLE AS $$
DECLARE ls_result text;
BEGIN
  SELECT string_agg(DISTINCT trim(t.collateral_description), as_sep)
    INTO ls_result
    FROM sc_lon_m_contract_coll cc
    JOIN sc_lon_m_ucf_collateral_type t USING (collateral_type_code)
   WHERE cc.loan_contract_no = as_conno
     AND (cc.status = '0' OR cc.status IS NULL);
  RETURN trim(ls_result);
EXCEPTION
  WHEN others THEN RETURN NULL;  -- mirror spa_dberror swallow (sibling fp_get_memcoll_str)
END;
$$;

-- ---- fp_rep_req_fee : ประเภทค่าธรรมเนียมของคำขอเงินกู้ (distinct, join ด้วย as_sep) [INFERRED] ----
CREATE OR REPLACE FUNCTION pka_rep_loan.fp_rep_req_fee(as_conno text, as_sep text DEFAULT ',')
RETURNS text LANGUAGE plpgsql STABLE AS $$
DECLARE ls_result text;
BEGIN
  SELECT string_agg(DISTINCT trim(uf.fee_name), as_sep)
    INTO ls_result
    FROM sc_lon_m_contract c
    JOIN sc_lon_m_req_fee rf ON rf.loan_requestment_no = c.loan_requestment_no
    JOIN sc_lon_m_ucf_fee  uf USING (fee_type)
   WHERE c.loan_contract_no = as_conno;
  RETURN trim(ls_result);
EXCEPTION
  WHEN others THEN RETURN NULL;
END;
$$;
