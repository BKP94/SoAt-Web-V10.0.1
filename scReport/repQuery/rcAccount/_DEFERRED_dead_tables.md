# rcAccount — Phase 4c deferred reports (dead backing tables)

Phase 2/4a (Oracle dialect hand-rewrite) สำเร็จครบ: 48 → 0 real failures.

เหลือ 8 report ที่ EXPLAIN ไม่ผ่าน เพราะ **อ้างตารางที่ไม่มีอยู่จริงใน source Oracle** (ไม่ใช่ปัญหา dialect):

| report | missing table | หลักฐาน |
|---|---|---|
| accSheet/r_accsheet_105_mem_begin.xml | sc_cls_mon_mem_shr | ไม่มีใน Oracle TABLE export; PKA_CLS_MON อ้างถึงแต่ commented out ทั้งหมด |
| accSheet/r_accsheet_105_mem_forward.xml | sc_cls_mon_mem_shr | เดียวกัน |
| accSheet/r_accsheet_105_mem_loan.xml | sc_cls_mon_mem_shr | เดียวกัน |
| accSheet/r_accsheet_105_mem_new.xml | sc_cls_mon_mem_shr | เดียวกัน |
| accSheet/r_accsheet_105_mem_resign.xml | sc_cls_mon_mem_shr | เดียวกัน |
| accSheet/r_accsheet_305_loan.xml | sc_cls_mon_mem_loncard | เดียวกัน |
| expDetail/r_sc_acc_expire_detail_exp_new_export.xml | sc_acc_m_expire_rep_export | ไม่ถูกอ้างที่ไหนเลยใน Oracle export นอกจาก report XML นี้ |
| expDetail/r_sc_acc_expire_insura.xml | sc_acc_m_expire_warranty_detail | เดียวกัน |

**สรุป:** report เหล่านี้ตายตั้งแต่ legacy (ตาราง snapshot month-end ถูกเลิกใช้ — โค้ดที่ populate ใน PKA_CLS_MON ถูก comment ออกหมด). ไม่สร้าง schema เดา ตาม Legacy Fidelity + no-invent. รอจน PL team ยืนยันว่าต้องการ revive month-end close snapshot tables หรือไม่.
