-- ============================================================================
-- step 6 function-first sweep — batch 9b (fp_* เบ็ดเตล็ดที่ report เรียกแต่ยัง missing)
-- port:
--   pka_rep_tel.fp_get_number_thai(numeric)         [REPTEL 1451] แปลงตัวเลข → เลขไทย (digit)
--   pka_mem_edit.fp_loan_approve(text)              [MEMEDIT 231] ยอดอนุมัติเงินกู้ของสัญญา
--
-- หมายเหตุ (ไม่อยู่ในไฟล์นี้):
--   - pka_lon_reqfee.fp_tge_calc_replace_share_return : stub ใน PG คืน 0 อยู่แล้ว = faithful
--       (Oracle body ถูก comment ออกทั้งหมด เหลือ `return 0;` บนสุด → ปิดใช้งานจริง) → ไม่ต้องแตะ
--   - pka_rep_loan.fp_rep_collateral_type / fp_rep_req_fee : ไม่มี source ใน Oracle export
--       (เรียกแค่ 1 ไฟล์ r_mwa_tel_mem_loan_detail.xml, signature (conno,',') = aggregator)
--       → รอผู้ใช้ยืนยัน intent ก่อน infer (เคสเดียวกับ fp_get_member_id_card batch5)
--
-- deviation (Legacy Fidelity):
--   - fp_get_number_thai: replace chain เป๊ะตาม Oracle รวม quirk '0'→'o' (latin o ไม่ใช่ '๐')
--     number → text ผ่าน to_char เดิม → ใช้ as_number::text (ตัด .00 ของ integer? Oracle to_char(number)
--     ให้สตริงเต็ม — ที่นี่ใช้ trim(to_char(...,'fm999...')) ไม่ได้เพราะไม่รู้ scale → ใช้ ::text ตรง)
--   - fp_loan_approve: number→double precision (ตรง family pka_com_function), nvl→coalesce,
--     no_data→0, others(spa_dberror ตัดทิ้ง)→ fall-through ไม่ return → mirror RETURN NULL
-- ============================================================================

CREATE SCHEMA IF NOT EXISTS pka_mem_edit;

-- ---- fp_get_number_thai : แปลงเลขอารบิก → เลขไทย (เฉพาะ digit) [REPTEL 1451] ----
CREATE OR REPLACE FUNCTION pka_rep_tel.fp_get_number_thai(as_number numeric)
RETURNS text LANGUAGE sql IMMUTABLE AS $$
  SELECT translate(as_number::text, '1234567890', '๑๒๓๔๕๖๗๘๙o');
$$;

-- ---- fp_loan_approve : ยอดอนุมัติเงินกู้ของสัญญา [MEMEDIT 231] ----
CREATE OR REPLACE FUNCTION pka_mem_edit.fp_loan_approve(as_conno text)
RETURNS double precision LANGUAGE plpgsql STABLE AS $$
DECLARE ldc_amount numeric;
BEGIN
  SELECT loan_approve_amount INTO STRICT ldc_amount
    FROM sc_lon_m_contract
   WHERE loan_contract_no = as_conno;
  RETURN coalesce(ldc_amount,0)::double precision;
EXCEPTION
  WHEN no_data_found THEN RETURN 0;
  WHEN others THEN RETURN NULL;  -- spa_dberror('fp_loan_approve')
END;
$$;
