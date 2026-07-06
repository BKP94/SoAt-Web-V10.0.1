-- ════════════════════════════════════════════════════════════════════════════
--  scteldet_seed.sql — seed กลุ่ม/แท็บ ของเมนู "สอบถามประวัติสมาชิก" (scteldet)
--  ตาราง: si_security_apps   (PK = i_menu_id)
--  รันที่ pgAdmin โดย PL team (schema เป็น pgAdmin-managed — Claude ไม่รันเอง)
--
--  ⚠ ที่มาข้อมูล: MIRROR 1:1 จาก Oracle production (192.168.101.29/PEAN)
--     query: SELECT i_menu_id,i_parent_id,i_level,i_sequence,order_no,active,s_url,app_text
--            FROM si_security_apps WHERE sub_app_name='scteldet'
--     ดึงจริงเมื่อ 2026-07-04 → 8 กลุ่ม (i_level=4) + 66 แท็บ (i_level=5)
--     ** seed เดิม (id 2002-2090, 50 แท็บ) ประดิษฐ์เอง → ทิ้ง แทนด้วยของจริงทั้งหมด **
--
--  โครง legacy panTabs.ascx.cs (ordinal-based hierarchy — คง Oracle เป๊ะ):
--    เมนู scteldet = i_menu_id 182 (i_level=3)  — มีอยู่แล้ว ไม่แตะ
--    กลุ่ม  = i_level=4, i_parent_id=1        (NavBar group; parent = ลำดับเมนู level-3)
--    แท็บ   = i_level=5, i_parent_id=1..8      (= i_sequence ของกลุ่มที่สังกัด ไม่ใช่ i_menu_id)
--           order by i_parent_id, i_sequence  (เหมือน legacy ทุกประการ)
--    → service join แท็บเข้ากลุ่มด้วย  tab.i_parent_id == group.i_sequence
--
--  ⚠ s_url = "ชื่อ component .razor ตรงๆ" (PascalCase ของชื่อ control legacy)
--     เช่น legacy u_tabpg_mem_spouse_info → UTabpgMemSpouseInfo
--     PanTabs.ResolveType โหลด component ด้วยชื่อนี้ตรงๆ (ไม่มี map/แปลง)
--     แท็บที่ยังไม่ได้ migrate เป็น .razor → PanTabs แสดง "ไม่พบ component" (s_url ตั้งชื่อ
--     ตาม convention รอไว้ พอสร้าง .razor ชื่อตรงก็ใช้ได้ทันที)
--
--  active : Oracle CHAR '1'/'0' → PG boolean true/false (คงค่า production; inactive=false)
--  order_no: Oracle เป็น NULL แต่ PG NOT NULL → ใช้ค่า = i_sequence (ไม่กระทบการเรียง)
-- ════════════════════════════════════════════════════════════════════════════

-- ── ล้าง scteldet level 4/5 ของเดิม (id ประดิษฐ์ 2002-2090 + ที่ค้าง) ก่อน seed ใหม่ ──
DELETE FROM si_security_apps WHERE sub_app_name = 'scteldet' AND i_level IN (4, 5);

-- ── กลุ่ม (i_level=4, i_parent_id=1) — 8 กลุ่ม ─────────────────────────────────
INSERT INTO si_security_apps
    (i_menu_id, app_name, app_text, active, i_level, i_sequence, order_no, s_url, i_parent_id, sub_app_name)
VALUES
    (319, 'scTeller', 'ข้อมูลหลักสมาชิก',        true, 4, 1, 1, NULL, 1, 'scteldet'),
    (320, 'scTeller', 'ข้อมูลสิทธิของสมาชิก',     true, 4, 2, 2, NULL, 1, 'scteldet'),
    (321, 'scTeller', 'ข้อมูลเงินกู้ และหุ้น',    true, 4, 3, 3, NULL, 1, 'scteldet'),
    (322, 'scTeller', 'ข้อมูลเรียกเก็บฯ',         true, 4, 4, 4, NULL, 1, 'scteldet'),
    (323, 'scTeller', 'ข้อมูลการเงิน และเงินฝาก', true, 4, 5, 5, NULL, 1, 'scteldet'),
    (324, 'scTeller', 'ข้อมูลรายละเอียดอื่นๆ',    true, 4, 6, 6, NULL, 1, 'scteldet'),
    (325, 'scTeller', 'รายการแก้ไข',              true, 4, 7, 7, NULL, 1, 'scteldet'),
    (395, 'scTeller', 'E-Document',               true, 4, 8, 8, NULL, 1, 'scteldet');

-- ── แท็บ (i_level=5) — 66 แท็บ, i_parent_id = ลำดับกลุ่ม (1..8) ────────────────

-- G1 (parent=1) ข้อมูลหลักสมาชิก
INSERT INTO si_security_apps
    (i_menu_id, app_name, app_text, active, i_level, i_sequence, order_no, s_url, i_parent_id, sub_app_name)
VALUES
    (330, 'scTeller', 'ข้อมูลครอบครัว',              true,  5,  1,  1, 'UTabpgMemSpouseInfo',              1, 'scteldet'),
    (331, 'scTeller', 'ข้อมูลการทำงาน',              true,  5,  2,  2, 'UTabpgMemDetailWorkInfo',          1, 'scteldet'),
    (332, 'scTeller', 'ข้อมูลสมาชิกโอนมา',           true,  5,  3,  3, 'UTabpgMemOwn',                     1, 'scteldet'),
    (333, 'scTeller', 'ผู้รับผลประโยชน์',            true,  5,  4,  4, 'UTabpgMemDetailGainDetail',        1, 'scteldet'),
    (350, 'scTeller', 'ปันผลเฉลี่ยคืน',              true,  5,  5,  5, 'UTabpgMemDetailDevidendDetail',    1, 'scteldet'),
    (736, 'scTeller', 'ปันผลเฉลี่ยคืน(รวม)',         true,  5,  6,  6, 'UTabpgMemDetailDevidendDetailAll', 1, 'scteldet'),
    (334, 'scTeller', 'ข้อมูลบัญชีธนาคาร',           true,  5,  7,  7, 'UTabpgMemBankinfo',                1, 'scteldet'),
    (353, 'scTeller', 'ATM',                          true,  5,  8,  8, 'UTabpgMemDetailAtm',               1, 'scteldet'),
    (459, 'scTeller', 'ข้อมูลเบอร์โทรศัพท์มือถือ',   true,  5,  9,  9, 'UTabpgMemMobileNumber',            1, 'scteldet'),
    (746, 'scTeller', 'ประวัติการสัมมนา',            true,  5, 10, 10, 'UTabpgMemSurminar',                1, 'scteldet');

-- G2 (parent=2) ข้อมูลสิทธิของสมาชิก
INSERT INTO si_security_apps
    (i_menu_id, app_name, app_text, active, i_level, i_sequence, order_no, s_url, i_parent_id, sub_app_name)
VALUES
    (335, 'scTeller', 'สิทธิ์สมาชิก',                    true, 5, 1, 1, 'UTabpgMemAdmstatus',            2, 'scteldet'),
    (336, 'scTeller', 'การงดกู้',                        true, 5, 2, 2, 'UTabpgMemDetailDropLoan',       2, 'scteldet'),
    (337, 'scTeller', 'อายัดเงินได้',                    true, 5, 3, 3, 'UTabpgMemDetailSequester',      2, 'scteldet'),
    (338, 'scTeller', 'สถานะพิเศษ',                      true, 5, 4, 4, 'UTabpgMemDetailStatusDetail',   2, 'scteldet'),
    (339, 'scTeller', 'สถานะติดตามหนี้',                 true, 5, 5, 5, 'UTabpgMemDetailCredit',         2, 'scteldet'),
    (384, 'scTeller', 'ประวัติการเปลี่ยนแปลงสิทธิ',      true, 5, 6, 6, 'UTabpgMemDetailPermitChanged',  2, 'scteldet'),
    (620, 'scTeller', 'สวัสดิการ',                       true, 5, 7, 7, 'UTabpgMemDetailWelfare',        2, 'scteldet'),
    (707, 'scTeller', 'ลูกหนี้ดำเนินคดี',               true, 5, 8, 8, 'UTabpgMemDetailLawProsec',      2, 'scteldet');

-- G3 (parent=3) ข้อมูลเงินกู้ และหุ้น
INSERT INTO si_security_apps
    (i_menu_id, app_name, app_text, active, i_level, i_sequence, order_no, s_url, i_parent_id, sub_app_name)
VALUES
    (340, 'scTeller', 'เงินกู้',              true,  5, 1, 1, 'UTabpgMemDetailLoanDetail',        3, 'scteldet'),
    (341, 'scTeller', 'ค้ำประกัน',            true,  5, 2, 2, 'UTabpgMemDetailCollDetail',        3, 'scteldet'),
    (342, 'scTeller', 'หลักประกัน',           true,  5, 3, 3, 'UTabpgMemDetailMemcollDetail',     3, 'scteldet'),
    (343, 'scTeller', 'ทุนเรือนหุ้น',         true,  5, 4, 4, 'UTabpgMemDetailShareState',        3, 'scteldet'),
    (344, 'scTeller', 'กองทุนผู้ค้ำ',         false, 5, 5, 5, 'UTabpgMemDetailShareColl',         3, 'scteldet'),
    (691, 'scTeller', 'ประวัติการกู้',        true,  5, 6, 6, 'UTabpgMemDetailLoanDetailHistory', 3, 'scteldet'),
    (729, 'scTeller', 'ฝากเก็บฐานะผู้ค้ำ',    false, 5, 6, 7, 'UTabpgMemDetailDebtByColl',        3, 'scteldet');

-- G4 (parent=4) ข้อมูลเรียกเก็บฯ
INSERT INTO si_security_apps
    (i_menu_id, app_name, app_text, active, i_level, i_sequence, order_no, s_url, i_parent_id, sub_app_name)
VALUES
    (345,  'scTeller', 'เรียกเก็บรายเดือน', true, 5, 1, 1, 'UTabpgMemDetailMonthDetail',      4, 'scteldet'),
    (346,  'scTeller', 'คืนใบแจ้งหนี้',     true, 5, 2, 2, 'UTabpgMemDetailMonthlyReturn',    4, 'scteldet'),
    (1019, 'scTeller', 'เรียกเก็บจากไฟล์',  true, 5, 4, 4, 'UTabpgMemDetailMonthGiroDetail',  4, 'scteldet');

-- G5 (parent=5) ข้อมูลการเงิน และเงินฝาก
INSERT INTO si_security_apps
    (i_menu_id, app_name, app_text, active, i_level, i_sequence, order_no, s_url, i_parent_id, sub_app_name)
VALUES
    (348, 'scTeller', 'เงินฝาก',          true,  5, 1, 1, 'UTabpgMemDetailDeptDetail',    5, 'scteldet'),
    (349, 'scTeller', 'เงินรอจ่ายคืน',    true,  5, 2, 2, 'UTabpgMemDetailMoneyReturn',   5, 'scteldet'),
    (351, 'scTeller', 'ชำระเงินรายวัน',   true,  5, 3, 3, 'UTabpgMemDetailMoneyPayment',  5, 'scteldet'),
    (352, 'scTeller', 'ทุนการศึกษา',      false, 5, 4, 4, 'UTabpgMemDetailSchDetail',     5, 'scteldet');

-- G6 (parent=6) ข้อมูลรายละเอียดอื่นๆ
INSERT INTO si_security_apps
    (i_menu_id, app_name, app_text, active, i_level, i_sequence, order_no, s_url, i_parent_id, sub_app_name)
VALUES
    (354, 'scTeller', 'วิธีชำระเงิน',           true,  5, 1, 1, 'UTabpgMemCremationPaidDet',      6, 'scteldet'),
    (347, 'scTeller', 'ประกัน',                 true,  5, 2, 2, 'UTabpgMemDetailInsuranceDetail', 6, 'scteldet'),
    (355, 'scTeller', 'สมาคมฌาปนกิจ',           true,  5, 3, 3, 'UTabpgMemCremationDet',          6, 'scteldet'),
    (356, 'scTeller', 'ผู้รับ สสอร.',           false, 5, 4, 4, 'UTabpgMemRecipientSs1',          6, 'scteldet'),
    (360, 'scTeller', 'บันทึกช่วยจำ',           true,  5, 4, 5, 'UTabpgMemCommentLog',            6, 'scteldet'),
    (357, 'scTeller', 'สมาคมครูไทย/ชุมนุม',     false, 5, 5, 6, 'UTabpgMemDetailSmk',             6, 'scteldet'),
    (468, 'scTeller', 'สมาชิกหลัก',             true,  5, 5, 7, 'UTabpgMemMemberRefer',           6, 'scteldet'),
    (358, 'scTeller', 'ผู้รับ สส.ชสอ.',         false, 5, 6, 8, 'UTabpgMemRecipientSs2',          6, 'scteldet'),
    (469, 'scTeller', 'สมาชิกสมทบ',             true,  5, 6, 9, 'UTabpgMemUserefer',              6, 'scteldet'),
    (359, 'scTeller', 'ผู้รับ สสอค.',           false, 5, 7,10, 'UTabpgMemRecipientSs3',          6, 'scteldet');

-- G7 (parent=7) รายการแก้ไข
INSERT INTO si_security_apps
    (i_menu_id, app_name, app_text, active, i_level, i_sequence, order_no, s_url, i_parent_id, sub_app_name)
VALUES
    (361,  'scTeller', 'ประวัติการเปลี่ยนชื่อ-นามสกุล',        true, 5,  1,  1, 'UTabpgMemDetailNamehistory',        7, 'scteldet'),
    (696,  'scTeller', 'ประวัติการเปลี่ยนแปลงงวดชำระหนี้',     true, 5,  2,  2, 'UTabpgMemDetailChgLoanSendMonth',   7, 'scteldet'),
    (697,  'scTeller', 'ประวัติการเปลี่ยนแปลงค่าหุ้น',         true, 5,  3,  3, 'UTabpgMemDetailChgShareSendMonth',  7, 'scteldet'),
    (362,  'scTeller', 'ประวัติการย้ายหน่วยงาน',              true, 5,  4,  4, 'UTabpgMemDetailMovejobhistory',     7, 'scteldet'),
    (363,  'scTeller', 'ประวัติการเปลี่ยนที่อยู่',            true, 5,  5,  5, 'UTabpgMemDetailAddresshistory',     7, 'scteldet'),
    (427,  'scTeller', 'ประวัติการแก้ไขเงินเดือน',            true, 5,  6,  6, 'UTabpgMemDetailHistorySalary',      7, 'scteldet'),
    (452,  'scTeller', 'ประวัติการเปลี่ยนแปลงผู้ค้ำประกัน',    true, 5,  7,  7, 'UTabpgMemDetailChgCollHistory',     7, 'scteldet'),
    (473,  'scTeller', 'ประวัติการเปลี่ยนเกรด',               true, 5,  8,  8, 'UTabpgMemDetailChgGradeHistory',    7, 'scteldet'),
    (585,  'scTeller', 'ประวัติการเปลี่ยนสถานะหุ้นหนี้',       true, 5,  9,  9, 'UTabpgMemDetailChgShareloanCode',   7, 'scteldet'),
    (586,  'scTeller', 'ประวัติโนติส',                        true, 5, 10, 10, 'UTabpgMemDetailChgDebtorCode',      7, 'scteldet'),
    (693,  'scTeller', 'ประวัติ MEMO',                        true, 5, 11, 11, 'UTabpgMemDetailChgMemoStatus',      7, 'scteldet'),
    (1025, 'scTeller', 'ประวัติการเปลี่ยนสถานะอื่นๆ',         true, 5, 12, 12, 'UTabpgMemDetailChgOtherStatus',     7, 'scteldet'),
    (1027, 'scTeller', 'ประวัติการเปลี่ยนเป็นสมาชิก สอ. อื่น', true, 5, 13, 13, 'UTabpgMemDetailChgOtSavingMember',  7, 'scteldet'),
    (1031, 'scTeller', 'ประวัติการเปลี่ยนแปลงวิธีจ่ายปันผล',   true, 5, 14, 14, 'UTabpgMemDetailChgRecieveDividend', 7, 'scteldet');

-- G8 (parent=8) E-Document
INSERT INTO si_security_apps
    (i_menu_id, app_name, app_text, active, i_level, i_sequence, order_no, s_url, i_parent_id, sub_app_name)
VALUES
    (399, 'scTeller', 'บังคับคดี/อื่นๆ',                false, 5,  1,  1, 'UTabpgEdcMemoth',           8, 'scteldet'),
    (396, 'scTeller', 'ทะเบียน',                        false, 5,  2,  2, 'UTabpgEdcMemregis',         8, 'scteldet'),
    (405, 'scTeller', 'เปลี่ยนแปลงผู้รับผลประโยชน์',    false, 5,  3,  3, 'UTabpgEdcChggain',          8, 'scteldet'),
    (401, 'scTeller', 'สัญญาเงินกู้',                   true,  5,  4,  4, 'UTabpgEdcLoancontract',     8, 'scteldet'),
    (402, 'scTeller', 'ค้ำประกันเงินกู้',              false, 5,  5,  5, 'UTabpgEdcLoancontractcoll', 8, 'scteldet'),
    (404, 'scTeller', 'เปลี่ยนแปลงหลักประกัน',         false, 5,  6,  6, 'UTabpgEdcChgcoll',          8, 'scteldet'),
    (403, 'scTeller', 'เปลี่ยนแปลงการชำระรายเดือน',    false, 5,  7,  7, 'UTabpgEdcChgpayment',       8, 'scteldet'),
    (400, 'scTeller', 'คำขอกู้',                        false, 5,  8,  8, 'UTabpgEdcLoanrequestment',  8, 'scteldet'),
    (406, 'scTeller', 'บัญชีเงินฝาก',                  false, 5,  9,  9, 'UTabpgEdcDeposit',          8, 'scteldet'),
    (398, 'scTeller', 'ลาออก',                          false, 5, 10, 10, 'UTabpgEdcMemresign',        8, 'scteldet');

-- ตรวจผล (ควรได้ 8 กลุ่ม + 66 แท็บ = 74 แถว; active=true ที่แสดงจริง = 8 กลุ่ม + 47 แท็บ):
--   SELECT i_level, count(*) FROM si_security_apps WHERE sub_app_name='scteldet'
--     AND i_level IN (4,5) GROUP BY i_level;
--   SELECT g.app_text AS grp, t.i_sequence, t.app_text, t.s_url, t.active
--   FROM si_security_apps g JOIN si_security_apps t
--     ON t.i_level=5 AND t.i_parent_id=g.i_sequence AND t.sub_app_name=g.sub_app_name
--   WHERE g.i_level=4 AND g.sub_app_name='scteldet'
--   ORDER BY g.i_sequence, t.i_sequence;
