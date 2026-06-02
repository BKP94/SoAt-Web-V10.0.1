CREATE TABLE sc_cnt_m_coop (
	coop_registered_no varchar(15) NOT NULL,
	coop_name varchar(100),
	registration_date timestamp,
	address varchar(50),
	tumbol_name varchar(30),
	district_code varchar(6),
	province_code varchar(6),
	postcode varchar(15),
	telephone_no varchar(50),
	fax_no varchar(30),
	registration_fee decimal(15,2),
	day_allow_buy_share double precision,
	start_keep_loan timestamp,
	dividend_rate decimal(5,2),
	int_return_rate decimal(5,2),
	max_miss_pay double precision,
	allowance_rate decimal(5,2),
	count_return_day decimal(15,2),
	date_build_report_shr_lon_bal timestamp,
	div_month_count decimal(15,2) DEFAULT 11,
	dividend_method decimal(15,2) DEFAULT 3,
	picture_path varchar(50),
	manager_name varchar(50),
	president_name varchar(50),
	auditor_name varchar(50),
	date_type varchar(6) DEFAULT '??',
	format_date varchar(15),
	special_receipt_name varchar(50),
	share_withdraw_name varchar(50),
	deposit_visible char(1),
	sharecoll_visible char(1),
	dividend_pay_resign char(1),
	dividend_share_coll double precision,
	share_coll_rate decimal(15,2),
	begin_choose_statement char(1),
	begin_statement timestamp,
	send_share_status char(1),
	over_share_gain bigint,
	percent_share decimal(15,2),
	size_member_no char(1),
	sharespec_count_period char(1),
	address_auditor1 varchar(100),
	address_auditor2 varchar(100),
	address_auditor3 varchar(100),
	address_auditor4 varchar(100),
	sign_contract_date timestamp,
	receipt_format varchar(15),
	atm_can_status char(1),
	atm_start char(6),
	atm_endt char(6),
	fin_colse char(6),
	file_time char(6),
	fin_start char(6),
	process_bal_start char(6),
	app_loan_autostatus char(1),
	app_loan char(6),
	app_dep_autostatus char(1),
	app_dep char(6),
	atm_start_date timestamp,
	atm_loan_can char(1),
	atm_loan_can_wit char(1),
	atm_loan_can_dep char(1),
	atm_loan_can_check char(1),
	atm_dep_can_dep char(1),
	atm_dep_can_wit char(1),
	atm_dep_can_check char(1),
	atm_dep_can char(1),
	atm_dep_can_up char(1),
	atm_loan_can_up char(1),
	fin_realtime_cash char(1) DEFAULT '0',
	id_card_mask varchar(20),
	budget_dd smallint DEFAULT 31,
	budget_mm smallint DEFAULT 12,
	gain_detail_mode char(1),
	auto_refresh bigint,
	endcode_password char(1) DEFAULT '1',
	password_expire_day double precision,
	edit_report_service char(1),
	number_client_active double precision,
	batfile_payment_able char(1) DEFAULT '0',
	member_digit char(1),
	smart_refno varchar(15),
	smart_active_status char(1),
	loan_table_payment varchar(100),
	ivr_status char(1),
	year_doom double precision,
	sys_name varchar(4),
	calendar_able char(1),
	return_money_style char(1),
	edit_emmdata_mutilrow char(1),
	trans_memno_able char(1),
	loan_vourcher_addloan varchar(100),
	loan_vourcher_sharewithdraw varchar(100),
	loan_vourcher_loanrequest varchar(100),
	return_money_muitle char(1),
	return_money_type char(3),
	retire_age_type char(1),
	keeping_ref_other char(1),
	loan_vourcher_payment varchar(100),
	auto_approve_newmem char(1),
	retire_age double precision,
	retire_month double precision DEFAULT '09',
	retire_bymonth_status char(1),
	branch_support char(1),
	share_reality char(1),
	ask_show_history char(1),
	cal_retire_method char(1),
	sharebuyamt_account_month integer,
	ask_pending char(1),
	other_receipt_name varchar(50),
	clear_rep_shrln_bal_each smallint,
	post_reward_to_dep char(1),
	specpay_periodmonth char(1),
	periodmonth_maxdatestyle char(1),
	pl_ask_countperiod char(1),
	max_int_rate decimal(15,2),
	drop_name varchar(15),
	stopday_week_first double precision,
	unique_repno char(1),
	sharebuy_account_year double precision,
	sharebuyamt_account_year double precision,
	change_share_monthcount double precision,
	reward_status char(1),
	reward_method char(1),
	reward_percent_amount decimal(15,2),
	reward_fixed_amount decimal(15,2),
	buyshare_reward_limit decimal(15,2),
	monthly_statement char(1),
	buyshare_dividen_limit decimal(15,2),
	dividen_pay_cash_to_cheque decimal(15,2),
	sharebuy_account_month decimal(15,2),
	transfer_mem_drop_coll char(1),
	color_scheme char(1),
	dividend_type varchar(6),
	multithed_disible_user char(1),
	user_compname_status char(1),
	taxid_coop varchar(15),
	stopday_week_last double precision,
	loanpayment_receipt_name varchar(50),
	multi_objecttive char(1),
	resigndateend_notpaydivide timestamp,
	dividen_pay_cash_all decimal(15,2),
	print_receive_status char(1),
	method_div_default varchar(3),
	column_mem_bank_default varchar(30),
	show_tranbank_at_sch char(1),
	alter_version varchar(20),
	in_convert char(1),
	member_coll_support char(1) DEFAULT '0',
	report_manager char(1) DEFAULT '0',
	sharebuy_life_member decimal(15,2) DEFAULT 0,
	sharecount_account_month double precision DEFAULT 0,
	own_share_percent decimal(15,2) DEFAULT 0,
	share_withdraw_count double precision DEFAULT 0,
	age_sharewithdraw_able double precision DEFAULT 0,
	sharewithdraw_pecent_ofshare decimal(10,2) DEFAULT 0,
	wef_amount_rep decimal(15,2) DEFAULT 0,
	treasurer_name varchar(100),
	multi_salary char(1) DEFAULT '0',
	mem_position_long char(1) DEFAULT '0',
	touch_mem_login_mode char(1) DEFAULT '0',
	mem_card_active char(1) DEFAULT '0',
	mem_card_expire double precision DEFAULT 0,
	mem_doc_status char(1) DEFAULT '0',
	use_over_buyshare char(1) DEFAULT '0',
	parallel_enddate timestamp,
	proc_daily_last timestamp,
	proc_daily_time varchar(7),
	loan_vourcher_returnint varchar(100),
	count_resign double precision DEFAULT 0,
	count_resign_m char(1) DEFAULT '0',
	www_adrr varchar(100),
	mem_type_ongroup char(1) DEFAULT '0',
	day_limit_return_paidable double precision DEFAULT 0,
	under_maintenance char(1) DEFAULT '0',
	auto_approve_chgpay char(1) DEFAULT '0',
	auto_approve_chgcoll char(1) DEFAULT '0',
	beyond_resign integer,
	auto_approve_chglon char(1) DEFAULT '0',
	auto_approve_chgshr char(1) DEFAULT '0',
	ads_code varchar(10),
	mooban varchar(100),
	soi varchar(100),
	road varchar(100),
	muu varchar(100),
	mobile_can_status char(1) DEFAULT '0',
	mobile_dep_can char(1) DEFAULT '0',
	mobile_dep_can_dep char(1) DEFAULT '0',
	mobile_dep_can_wit char(1) DEFAULT '0',
	mobile_loan_can char(1) DEFAULT '0',
	mobile_loan_can_dep char(1) DEFAULT '0',
	mobile_loan_can_wit char(1) DEFAULT '0',
	min_tran decimal(15,2) DEFAULT 0,
	min_withdraw decimal(15,2) DEFAULT 0,
	min_deposit decimal(15,2) DEFAULT 0,
	min_addloan decimal(15,2) DEFAULT 0,
	min_payment decimal(15,2) DEFAULT 0,
	max_tran decimal(15,2) DEFAULT 0,
	max_withdraw decimal(15,2) DEFAULT 0,
	max_deposit decimal(15,2) DEFAULT 0,
	max_addloan decimal(15,2) DEFAULT 0,
	max_payment decimal(15,2) DEFAULT 0,
	mobile_chgshare_can char(1) DEFAULT '0',
	share_withdrawapprove char(1),
	atm_tana_new char(1),
	assit_manager varchar(50),
	finance_name varchar(50),
	salary_percent_af_retire decimal(16,4),
	salary_life_af_retire decimal(16,4),
	dividen_percent decimal(16,2),
	salary_rate_estimate decimal(16,4),
	manager_position varchar(100),
	sharebuy_work_age double precision,
	password_min double precision DEFAULT 0,
	password_max double precision DEFAULT 0,
	password_symbol char(1) DEFAULT '0',
	password_number char(1) DEFAULT '0',
	password_lower char(1) DEFAULT '0',
	password_upper char(1) DEFAULT '0',
	password_forget char(1) DEFAULT '0',
	password_notsame_user char(1) DEFAULT '0',
	max_tran_day decimal(15,2) DEFAULT 0,
	max_withdraw_day decimal(15,2) DEFAULT 0,
	max_deposit_day decimal(15,2) DEFAULT 0,
	max_addloan_day decimal(15,2) DEFAULT 0,
	max_payment_day decimal(15,2) DEFAULT 0,
	max_tran_default decimal(15,2) DEFAULT 0,
	max_withdraw_default decimal(15,2) DEFAULT 0,
	max_deposit_default decimal(15,2) DEFAULT 0,
	max_addloan_default decimal(15,2) DEFAULT 0,
	max_payment_default decimal(15,2) DEFAULT 0,
	crem_time char(6)
) ;
COMMENT ON TABLE sc_cnt_m_coop IS E'!N??????????????N!!MM!';
COMMENT ON COLUMN sc_cnt_m_coop.address IS E'!Nที่อยู่N!!MM!';
COMMENT ON COLUMN sc_cnt_m_coop.auditor_name IS E'!Nชื่อจนท.การเงิน:N!';
COMMENT ON COLUMN sc_cnt_m_coop.auto_approve_newmem IS E'!N?????????????????????????? ?????????????????????N!!MM!';
COMMENT ON COLUMN sc_cnt_m_coop.batfile_payment_able IS E'!N????????????????? Batch File ???N!!MM!';
COMMENT ON COLUMN sc_cnt_m_coop.branch_support IS E'!N??????????????????????N!!MM!';
COMMENT ON COLUMN sc_cnt_m_coop.cal_retire_method IS E'!N???????????????????????:N!!MM!';
COMMENT ON COLUMN sc_cnt_m_coop.calendar_able IS E'!N????????????????????N!!MM!';
COMMENT ON COLUMN sc_cnt_m_coop.change_share_monthcount IS E'!N????????????????????????????????????????(?????)N!!MM!';
COMMENT ON COLUMN sc_cnt_m_coop.coop_name IS E'!Nชื่อสหกรณ์N!';
COMMENT ON COLUMN sc_cnt_m_coop.coop_registered_no IS E'!Nเลขทะเบียนสหกรณ์N!';
COMMENT ON COLUMN sc_cnt_m_coop.date_type IS E'!NประเภทปีN!!MM!';
COMMENT ON COLUMN sc_cnt_m_coop.day_allow_buy_share IS E'!Nนับซื้อหุ้นในเดือนนั้น ถ้าซื้อก่อนวันที่: ... ใช้กับการปันผลรายเดือน เช่น ถ้าค่าเป็น 7 สมาชิกที่ซื้อหุ้นวันที่รายการ เป็นวันที่ 7/12/2540  เดือนที่จ่ายปันผลจะเป็นเดือน 11/2540N!!MM!';
COMMENT ON COLUMN sc_cnt_m_coop.deposit_visible IS E'!Nเปิดให้เห็นรายการเงินฝากที่หน้าจอประวัติN!!MM!';
COMMENT ON COLUMN sc_cnt_m_coop.district_code IS E'!NรหัสอำเภอN!';
COMMENT ON COLUMN sc_cnt_m_coop.div_month_count IS E'!Nปันผลเดือนที่ 1  ให้หาร 11หรือ12N!!MM!';
COMMENT ON COLUMN sc_cnt_m_coop.dividend_method IS E'!NวิธีการคิดปันผลN!!MM';
COMMENT ON COLUMN sc_cnt_m_coop.dividend_pay_resign IS E'!Nสถานะจ่ายเงินปันผลเมื่อพวกที่ลาออกแล้วN!!MM!';
COMMENT ON COLUMN sc_cnt_m_coop.drop_name IS E'!N?????????????:N!';
COMMENT ON COLUMN sc_cnt_m_coop.edit_emmdata_mutilrow IS E'!N??????????????????????????????????N!!MM!';
COMMENT ON COLUMN sc_cnt_m_coop.endcode_password IS E'!N???????????????????????N!!MM!';
COMMENT ON COLUMN sc_cnt_m_coop.fax_no IS E'!Nเบอร์แฟก์N!!';
COMMENT ON COLUMN sc_cnt_m_coop.fin_realtime_cash IS E'!NเปิดระบบการเงินคุมเงินสดอัตโนมัติN!!MM!';
COMMENT ON COLUMN sc_cnt_m_coop.id_card_mask IS E'!Nรูปแบบบัตรปปช.N!!MรูปแบบบัตรประชาชนM!';
COMMENT ON COLUMN sc_cnt_m_coop.ivr_status IS E'!N????????????????????????????(IVR)N!!MM!';
COMMENT ON COLUMN sc_cnt_m_coop.keeping_ref_other IS E'!N??????????????????????????????????????????N!!MM!';
COMMENT ON COLUMN sc_cnt_m_coop.loan_table_payment IS E'!N???????????????????????:N!';
COMMENT ON COLUMN sc_cnt_m_coop.loan_vourcher_addloan IS E'!N???????????????????????????????:N!';
COMMENT ON COLUMN sc_cnt_m_coop.loan_vourcher_loanrequest IS E'!N?????????????????????:N!';
COMMENT ON COLUMN sc_cnt_m_coop.loan_vourcher_payment IS E'!N???????????????????????:N!';
COMMENT ON COLUMN sc_cnt_m_coop.loan_vourcher_sharewithdraw IS E'!N???????????????????????:N!';
COMMENT ON COLUMN sc_cnt_m_coop.loanpayment_receipt_name IS E'!N??????????????????:N!';
COMMENT ON COLUMN sc_cnt_m_coop.manager_name IS E'!Nชื่อผู้จัดการ:N!';
COMMENT ON COLUMN sc_cnt_m_coop.member_digit IS E'!N????????????????N!';
COMMENT ON COLUMN sc_cnt_m_coop.number_client_active IS E'!N??????????????????????????????????????N!!MM!';
COMMENT ON COLUMN sc_cnt_m_coop.over_share_gain IS E'!Nหุ้นรายเดือนสูงสุด(บาท)N!!MM!';
COMMENT ON COLUMN sc_cnt_m_coop.password_expire_day IS E'!N???????????????????????????????(???)N!!MM!';
COMMENT ON COLUMN sc_cnt_m_coop.percent_share IS E'!Nเปอร์เซ็นต์การส่งหุ้นN!!MM!';
COMMENT ON COLUMN sc_cnt_m_coop.pl_ask_countperiod IS E'!N????????????????????????????N!!MM!';
COMMENT ON COLUMN sc_cnt_m_coop.postcode IS E'!Nรหัสไปรษณีย์N!';
COMMENT ON COLUMN sc_cnt_m_coop.president_name IS E'!Nชื่อประธาน:N!';
COMMENT ON COLUMN sc_cnt_m_coop.province_code IS E'!NรหัสจังหวัดN!!MM!';
COMMENT ON COLUMN sc_cnt_m_coop.receipt_format IS E'!Nแบบฟอร์มใบเสร็จชำระหนี้:N!';
COMMENT ON COLUMN sc_cnt_m_coop.retire_age IS E'!N??????????(??): ... ?????????????????????????????????? ???????????????????????N!!MM!';
COMMENT ON COLUMN sc_cnt_m_coop.retire_age_type IS E'!N??????????????????????N!!MM!';
COMMENT ON COLUMN sc_cnt_m_coop.retire_bymonth_status IS E'!N??????????????N!!MM!';
COMMENT ON COLUMN sc_cnt_m_coop.retire_month IS E'!N??????????????N!!MM!';
COMMENT ON COLUMN sc_cnt_m_coop.send_share_status IS E'!Nวิธีคำนวณหุ้นส่งรายเดือนN!!MM!';
COMMENT ON COLUMN sc_cnt_m_coop.sharebuy_account_year IS E'!N??????????????????????????????(?????)N!';
COMMENT ON COLUMN sc_cnt_m_coop.sharebuyamt_account_year IS E'!N??????????????????????????????(???)N!';
COMMENT ON COLUMN sc_cnt_m_coop.sharespec_count_period IS E'!Nนับงวดชำระพิเศษ (หุ้น)N!!V1=เปิดใช้งาน,0=ไม่เปิดใช้งานV!';
COMMENT ON COLUMN sc_cnt_m_coop.size_member_no IS E'!NจำนวนอักขระเลขสมาชิกN!';
COMMENT ON COLUMN sc_cnt_m_coop.smart_active_status IS E'!N??????????? SmartN!';
COMMENT ON COLUMN sc_cnt_m_coop.smart_refno IS E'!N?????????????N!';
COMMENT ON COLUMN sc_cnt_m_coop.special_receipt_name IS E'!Nฟอร์มใบเสร็จชำระพิเศษ:N!';
COMMENT ON COLUMN sc_cnt_m_coop.specpay_periodmonth IS E'!N????????? ????????????????(????????)N!!V1=??????????,0=??????????V!';
COMMENT ON COLUMN sc_cnt_m_coop.sys_name IS E'!N????????????.??????N!';
COMMENT ON COLUMN sc_cnt_m_coop.telephone_no IS E'!Nโทรศัพท์N!';
COMMENT ON COLUMN sc_cnt_m_coop.trans_memno_able IS E'!N???????????????????????????????????????????N!!MM!';
COMMENT ON COLUMN sc_cnt_m_coop.tumbol_name IS E'!Nตำบล/แขวงN!';
COMMENT ON COLUMN sc_cnt_m_coop.unique_repno IS E'!N??????????????????????????????(??????????????????)N!';
COMMENT ON COLUMN sc_cnt_m_coop.year_doom IS E'!N?????????????(???)N!!MM!';
ALTER TABLE sc_cnt_m_coop ADD PRIMARY KEY (coop_registered_no);


