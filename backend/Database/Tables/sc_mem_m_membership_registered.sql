CREATE TABLE sc_mem_m_membership_registered (
	membership_no varchar(15) NOT NULL,
	application_form_no varchar(15),
	member_group_no varchar(15),
	prename_code varchar(6),
	member_name varchar(50),
	member_surname varchar(50),
	member_status_code char(1),
	sex char(1) DEFAULT 'M',
	date_of_birth timestamp,
	nationality_code varchar(6) DEFAULT '01',
	graduate_code varchar(6),
	marriage_status char(1),
	apply_date timestamp,
	approve_date timestamp,
	approve_id varchar(16),
	resignation_remark varchar(100),
	resignation_approve_id varchar(16),
	resignation_approve_date timestamp,
	remark varchar(200),
	drop_loanemer_status char(1),
	drop_loanspec_status char(1),
	drop_loannormal_status char(1),
	collactelral_status char(1),
	total_loan_int decimal(15,2),
	emer_loan_int decimal(15,2),
	norm_loan_int decimal(15,2),
	spec_loan_int decimal(15,2),
	id_card varchar(15),
	deposit_post_status char(1),
	mem_type varchar(6) DEFAULT '01',
	other_loan decimal(15,2),
	password varchar(10),
	debtor_code varchar(6),
	share_coll_status char(1),
	adj_payroll char(1),
	att_loan_permit char(1),
	drop_divident char(1),
	drop_average char(1),
	eng_name varchar(50),
	app_type char(1),
	other_code varchar(6),
	shareloan_code varchar(6),
	card_type char(1),
	deposit_account_id varchar(20),
	refund_amt decimal(15,2),
	branch_id varchar(6),
	occupation_code varchar(6),
	blood_code varchar(6),
	insurance_no varchar(15),
	member_name_eng varchar(100),
	member_surname_eng varchar(100),
	id_card_exdat timestamp,
	method_recieve_dividend varchar(3),
	seize_average char(1),
	seize_divident char(1),
	crem_memno varchar(15),
	retire_id varchar(10),
	retire_text varchar(50),
	retire_date timestamp,
	dividend_at_resign char(1) DEFAULT '0',
	tax_id varchar(15),
	force_keeping char(1) DEFAULT '0',
	member_pass varchar(15),
	doc_place_status varchar(6) DEFAULT '00',
	group_advance varchar(15),
	resign_doc_no varchar(15),
	active_keepmethod_docno varchar(15),
	active_chgshare_docno varchar(15),
	active_chgloan_docno varchar(15),
	resign_code varchar(6) DEFAULT '00',
	drop_all_keeping char(1) DEFAULT '0',
	crem_status char(1) DEFAULT '0',
	approve_resolutions varchar(6) DEFAULT '00',
	resign_apve_resolutions varchar(6) DEFAULT '00',
	email varchar(100),
	member_group_ref varchar(15),
	member_group_vote varchar(15),
	receipt_send_home char(1) DEFAULT '0',
	represent_status char(1) DEFAULT '0',
	committee_status char(1) DEFAULT '0',
	official_status char(1) DEFAULT '0',
	agent_status char(1) DEFAULT '0',
	inspector_status char(1) DEFAULT '0',
	coll_resign char(1) DEFAULT '0',
	father varchar(50),
	mother varchar(50),
	dead_status char(1),
	dividend_payment decimal(15,2),
	other_saving_member varchar(6),
	drop_chgloanmonth_status char(1),
	drop_chgsharemonth_status char(1),
	lose_send_share char(1),
	share_sequester char(1),
	sal_status char(1),
	sal_date timestamp,
	insurance_cost decimal(15,2) DEFAULT 0.00,
	insurance_pay decimal(15,2) DEFAULT 0.00,
	keep_memno varchar(15),
	spouse_name varchar(50),
	present_address varchar(200),
	present_road varchar(30),
	present_tambol varchar(50),
	present_district_code varchar(6),
	present_province_code varchar(6),
	present_postcode varchar(10),
	position_code varchar(6),
	level_code varchar(6),
	salary_id varchar(15),
	salary_rate_code decimal(15,2),
	salary_amount decimal(15,2),
	mem_password varchar(10),
	working_date timestamp,
	retire_status char(1),
	group_position varchar(6),
	phone varchar(50),
	bank_acc_no varchar(15),
	drop_all_loan_status char(1),
	permanent_address varchar(50),
	permanent_road varchar(30),
	permanent_tambol varchar(50),
	permanent_district_code varchar(6),
	permanent_province_code varchar(6),
	permanent_post_code varchar(10),
	atm_accno varchar(19),
	bank_accno varchar(10),
	atm_bank_code varchar(6),
	branch_bank_code varchar(6),
	return_rep_status char(1),
	return_member_again char(1),
	chg_buyshare_status char(1),
	drop_loan_status char(1),
	ending_contractdate timestamp,
	employee_status char(1),
	present_soi varchar(60),
	present_moo varchar(10),
	work_part varchar(6),
	work_telephone varchar(50),
	work_phone varchar(20),
	department varchar(30),
	present_telephone varchar(50),
	bank_code varchar(6),
	team_work varchar(50),
	coop_position varchar(6),
	bank_transfer varchar(15),
	atm_branch_code varchar(6),
	fixed_keep decimal(15,2),
	keep_gain_code varchar(6),
	academic_amount decimal(15,2),
	remuneration_amount decimal(15,2),
	id_card_enddate timestamp,
	id_card_date timestamp,
	prename_eng varchar(50),
	name_eng varchar(50),
	surname_eng varchar(50),
	atm_open_status char(1),
	card_memno varchar(7),
	card_year varchar(6),
	card_date timestamp,
	card_date_end timestamp,
	print_card_status char(1),
	atm_no varchar(20),
	atm_accno_dep varchar(19),
	atm_bank_branch varchar(6),
	bank_acc_dividend varchar(15),
	pragun_amount decimal(15,2),
	paid_loan_amount decimal(15,2),
	aryus_amount decimal(15,2),
	insur_count numeric(38),
	status_loan_other char(1),
	atm_confirm_open_date timestamp,
	atm_accno_old varchar(10),
	atm_accno_dep_old varchar(10),
	grade char(1),
	refer_keep char(1) DEFAULT '0',
	grade_bk varchar(6),
	other_date timestamp,
	other_chg_code varchar(6),
	share_remain char(1) DEFAULT '0',
	internal_auditor char(1) DEFAULT '0',
	advisor_president char(1) DEFAULT '0',
	representive_position char(1) DEFAULT '0',
	advisor_coop char(1) DEFAULT '0',
	id_card_number varchar(50),
	id_card_organize varchar(100),
	election_group varchar(15) DEFAULT '00',
	lon_restruc char(1) DEFAULT '0',
	spare_date timestamp,
	sms_status char(1) DEFAULT 'Y',
	dead_date timestamp,
	yearly_reason varchar(50),
	share_new decimal(15,2),
	share_old decimal(15,2),
	salary_new decimal(15,2),
	salary_old decimal(15,2),
	deposit_account_no char(20),
	hum_id char(20),
	group_mem_type char(1),
	bank_acc_no_ktb varchar(15),
	membership_no_old char(7),
	permanent_telephone char(50),
	permanent_soi char(50),
	permanent_moo char(10),
	membership_no_ref char(7),
	reason_stop varchar(250),
	multimethod_docno_loan char(15),
	age_group varchar(6),
	shr_group varchar(6),
	reward_hbd_dep_accno varchar(15),
	invest_status char(1) DEFAULT '0',
	concern_code_ref char(2),
	salary_pure_amount decimal(15,2) DEFAULT 0,
	other_amount decimal(15,2) DEFAULT 0,
	position_amount decimal(15,2) DEFAULT 0,
	bank_code_backup char(6),
	total_loan_int_last_year decimal(15,2) DEFAULT 0,
	keep_bank_status char(3),
	other_status varchar(6),
	mobile_number varchar(15)
) ;
COMMENT ON TABLE sc_mem_m_membership_registered IS E'!N?????????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_membership_registered.active_keepmethod_docno IS E'!Nเลขที่คำขอเปลี่ยนแปลงวิธีการชำระN!';
COMMENT ON COLUMN sc_mem_m_membership_registered.adj_payroll IS E'!Nปรับแต่งสลิปเงินเดือนN!!Mสถานะปรับแต่งสลิปเงินเดือนM!';
COMMENT ON COLUMN sc_mem_m_membership_registered.app_type IS E'!NประเภทการสมัครN!';
COMMENT ON COLUMN sc_mem_m_membership_registered.application_form_no IS E'!Nหน่วยงานN!';
COMMENT ON COLUMN sc_mem_m_membership_registered.apply_date IS E'!Nวันที่สมัครN!';
COMMENT ON COLUMN sc_mem_m_membership_registered.approve_date IS E'!Nวันที่อนุมัติN!';
COMMENT ON COLUMN sc_mem_m_membership_registered.approve_id IS E'!Nผู้อนุมัติN!';
COMMENT ON COLUMN sc_mem_m_membership_registered.att_loan_permit IS E'!Nถูกลดสิทธิการกู้N!!Mสถานะถูกลดสิทธิการกู้M!';
COMMENT ON COLUMN sc_mem_m_membership_registered.blood_code IS E'!Nหมู่เลือดN!';
COMMENT ON COLUMN sc_mem_m_membership_registered.branch_id IS E'!Nสาขาที่สังกัดN!';
COMMENT ON COLUMN sc_mem_m_membership_registered.collactelral_status IS E'!Nงดค้ำประกันN!';
COMMENT ON COLUMN sc_mem_m_membership_registered.date_of_birth IS E'!NวันเกิดN!!MM!';
COMMENT ON COLUMN sc_mem_m_membership_registered.debtor_code IS E'!Nประเภทลูกหนี้N!';
COMMENT ON COLUMN sc_mem_m_membership_registered.dividend_at_resign IS E'!Nลาออกแล้วN!!Mลาออกแล้ว จะได้รับเงินปันผลหรือไม่M!';
COMMENT ON COLUMN sc_mem_m_membership_registered.doc_place_status IS E'!Nสถานที่ส่งเอกสารN!';
COMMENT ON COLUMN sc_mem_m_membership_registered.drop_average IS E'!Nถูกงดเฉลี่ยคืนN!!Mสถานะถูกงดเฉลี่ยคืนM!';
COMMENT ON COLUMN sc_mem_m_membership_registered.drop_divident IS E'!NถูกงดปันผลN!!MสถานะถูกงดปันผลM!';
COMMENT ON COLUMN sc_mem_m_membership_registered.drop_loanemer_status IS E'!Nงดกู้หมวดเงินกู้ฉุกเฉินN!';
COMMENT ON COLUMN sc_mem_m_membership_registered.drop_loannormal_status IS E'!Nงดกู้หมวดเงินกู้สามัญN!';
COMMENT ON COLUMN sc_mem_m_membership_registered.drop_loanspec_status IS E'!Nงดกู้หมวดเงินกู้พิเศษN!';
COMMENT ON COLUMN sc_mem_m_membership_registered.emer_loan_int IS E'!Nดอกเบี้ยสะสม สำหรับเฉลี่ยคืน(ฉ)N!';
COMMENT ON COLUMN sc_mem_m_membership_registered.eng_name IS E'!Nชื่อ-สกุล(อังกฤษ)N!';
COMMENT ON COLUMN sc_mem_m_membership_registered.force_keeping IS E'!Nเรียกเก็บหนี้เมื่อลาออกN!';
COMMENT ON COLUMN sc_mem_m_membership_registered.graduate_code IS E'!NระดับการศึกษาN!';
COMMENT ON COLUMN sc_mem_m_membership_registered.group_advance IS E'!Nหน่วยล่วงหน้า ... กรณีทำการย้ายหน่วยงานล่วงหน้าN!';
COMMENT ON COLUMN sc_mem_m_membership_registered.id_card IS E'!Nบัตร ปชช.N!';
COMMENT ON COLUMN sc_mem_m_membership_registered.id_card_exdat IS E'!NวันหมดอายุN!!Mวันที่หมดอายุของบัตรประชาชนM!';
COMMENT ON COLUMN sc_mem_m_membership_registered.lon_restruc IS E'!Nปรับโครงสร้างหนี้N!';
COMMENT ON COLUMN sc_mem_m_membership_registered.marriage_status IS E'!NสถานะภาพN!';
COMMENT ON COLUMN sc_mem_m_membership_registered.mem_type IS E'!NประเภทN!!MประเภทสมาชิกM!';
COMMENT ON COLUMN sc_mem_m_membership_registered.member_group_no IS E'!Nหน่วยN!';
COMMENT ON COLUMN sc_mem_m_membership_registered.member_name IS E'!Nชื่อN!';
COMMENT ON COLUMN sc_mem_m_membership_registered.member_pass IS E'!Nรหัสผ่านของสมาชิกN!';
COMMENT ON COLUMN sc_mem_m_membership_registered.member_status_code IS E'!NสถานะN!!M!V0-ปกติ,3-ลาออกV!M!';
COMMENT ON COLUMN sc_mem_m_membership_registered.member_surname IS E'!NนามสกุลN!';
COMMENT ON COLUMN sc_mem_m_membership_registered.membership_no IS E'!NทะเบียนN!';
COMMENT ON COLUMN sc_mem_m_membership_registered.method_recieve_dividend IS E'!NวิธีรับเงินปันผลN!';
COMMENT ON COLUMN sc_mem_m_membership_registered.nationality_code IS E'!NสัญชาติN!';
COMMENT ON COLUMN sc_mem_m_membership_registered.norm_loan_int IS E'!Nดอกเบี้ยสะสม สำหรับเฉลี่ยคืน(ส)N!';
COMMENT ON COLUMN sc_mem_m_membership_registered.other_code IS E'!Nสถานะอื่นๆN!';
COMMENT ON COLUMN sc_mem_m_membership_registered.other_saving_member IS E'!Nเป็นสมาชิกสอ.อื่นN!';
COMMENT ON COLUMN sc_mem_m_membership_registered.prename_code IS E'!Nคำนำหน้าชื่อN!';
COMMENT ON COLUMN sc_mem_m_membership_registered.remark IS E'!NหมายเหตุN!';
COMMENT ON COLUMN sc_mem_m_membership_registered.resign_doc_no IS E'!Nเลขที่ใบคำขอลาออกN!';
COMMENT ON COLUMN sc_mem_m_membership_registered.resignation_approve_date IS E'!Nวันที่ลาออกN!!Mวันที่อนุมัติลาออกจากการเป็นสมาชิกM!';
COMMENT ON COLUMN sc_mem_m_membership_registered.resignation_approve_id IS E'!Nผู้อนุมัติลาออกN!';
COMMENT ON COLUMN sc_mem_m_membership_registered.sex IS E'!NเพศN!';
COMMENT ON COLUMN sc_mem_m_membership_registered.shareloan_code IS E'!Nสถานะหุ้นหนี้N!';
COMMENT ON COLUMN sc_mem_m_membership_registered.spec_loan_int IS E'!Nดอกเบี้ยสะสม สำหรับเฉลี่ยคืน(พ)N!';
COMMENT ON COLUMN sc_mem_m_membership_registered.total_loan_int IS E'!Nดบ.สะสมN!!Mดอกเบี้ยสะสม สำหรับเฉลี่ยคืนM!';
CREATE INDEX idx_memname ON sc_mem_m_membership_registered (member_name);
CREATE INDEX idx_memregis_appform ON sc_mem_m_membership_registered (application_form_no);
CREATE INDEX idx_mem_appdate ON sc_mem_m_membership_registered (approve_date);
CREATE INDEX idx_mem_birth ON sc_mem_m_membership_registered (date_of_birth);
CREATE INDEX idx_mem_regis_approve_id ON sc_mem_m_membership_registered (approve_id);
CREATE INDEX idx_mem_regis_apptype ON sc_mem_m_membership_registered (app_type);
CREATE INDEX idx_mem_regis_branch_id ON sc_mem_m_membership_registered (branch_id);
CREATE INDEX idx_mem_regis_debtorcode ON sc_mem_m_membership_registered (debtor_code);
CREATE INDEX idx_mem_regis_docplace ON sc_mem_m_membership_registered (doc_place_status);
CREATE INDEX idx_mem_regis_graduate ON sc_mem_m_membership_registered (graduate_code);
CREATE INDEX idx_mem_regis_groupno ON sc_mem_m_membership_registered (member_group_no);
CREATE INDEX idx_mem_regis_groupno_prename ON sc_mem_m_membership_registered (member_group_no, prename_code);
CREATE INDEX idx_mem_regis_group_adv ON sc_mem_m_membership_registered (group_advance);
CREATE INDEX idx_mem_regis_marriage ON sc_mem_m_membership_registered (marriage_status);
CREATE INDEX idx_mem_regis_memno_group ON sc_mem_m_membership_registered (membership_no, member_group_no);
CREATE INDEX idx_mem_regis_mem_group_pre ON sc_mem_m_membership_registered (membership_no, member_group_no, prename_code);
CREATE INDEX idx_mem_regis_mem_status ON sc_mem_m_membership_registered (member_status_code);
CREATE INDEX idx_mem_regis_mem_type ON sc_mem_m_membership_registered (mem_type);
CREATE INDEX idx_mem_regis_method_dividend ON sc_mem_m_membership_registered (method_recieve_dividend);
CREATE INDEX idx_mem_regis_nation ON sc_mem_m_membership_registered (nationality_code);
CREATE INDEX idx_mem_regis_other_code ON sc_mem_m_membership_registered (other_code);
CREATE INDEX idx_mem_regis_resign_apvid ON sc_mem_m_membership_registered (resignation_approve_id);
CREATE INDEX idx_mem_regis_resign_code ON sc_mem_m_membership_registered (resign_code);
CREATE INDEX idx_mem_regis_resign_docno ON sc_mem_m_membership_registered (resign_doc_no);
CREATE INDEX idx_mem_regis_shareloan_code ON sc_mem_m_membership_registered (shareloan_code);
CREATE INDEX idx_prename ON sc_mem_m_membership_registered (prename_code);
CREATE INDEX idx_suraname ON sc_mem_m_membership_registered (member_surname);
ALTER TABLE sc_mem_m_membership_registered ADD PRIMARY KEY (membership_no);


