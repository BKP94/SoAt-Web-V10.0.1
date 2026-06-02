CREATE TABLE sc_fin_m_constant (
	coop_no varchar(15) NOT NULL,
	interest_account_id varchar(8),
	keep_item_type varchar(3),
	paid_arr varchar(3),
	paid_check varchar(3),
	keep_to_fin char(1),
	return_pay_type varchar(3),
	keep_return_item_type varchar(3),
	type_screen_paid_loan char(1),
	wait_paid varchar(3),
	wait_check varchar(3),
	paid_office char(3),
	link_office char(1),
	type_screen_paid_dep char(1),
	wait_check_pay_type varchar(3),
	wait_check_paid varchar(3),
	link_fund char(1),
	return_int_type varchar(3),
	paid_div varchar(3),
	paid_aver varchar(3),
	paid_reward varchar(3),
	rec_coll varchar(3),
	paid_loan_from char(1),
	other_income_limit decimal(15,2),
	account_cash varchar(8),
	account_chqwait varchar(8),
	finance_date timestamp,
	account_share varchar(8),
	blink_status char(1),
	chqwait_style char(1),
	receive_no_spp char(1),
	wait_check_pay_type_paid varchar(3),
	post_to_acc char(1) DEFAULT '0',
	cheque_return varchar(3),
	refer_loan_type varchar(6) DEFAULT '00',
	type_round_method char(1) DEFAULT '0',
	link_keep_return char(1) DEFAULT '0',
	int_close_dep char(1) DEFAULT '0',
	cheque_cancel varchar(3),
	paid_loan_by char(1) DEFAULT '0',
	cheque_not_contract varchar(3),
	deppaidint_account_id varchar(8),
	depintloan_account_id varchar(15),
	month_account_id varchar(8),
	bank_default_cheque_loan varchar(6),
	account_mfee varchar(8),
	counter_split_payment char(1) DEFAULT '0',
	counter_split_receive char(1) DEFAULT '0',
	form_vourcher_r varchar(100),
	form_vourcher_p varchar(100),
	form_cash_return varchar(100),
	form_cash_request varchar(100),
	account_month_return_wait varchar(8),
	account_share_return_wait varchar(8),
	account_other_income varchar(8),
	account_spp_srv varchar(8),
	account_spp_isr varchar(8),
	account_telspp_keeping_wait varchar(8),
	voucher_runing_split char(1) DEFAULT '0',
	return_by_number char(1) DEFAULT '0',
	account_m_agent varchar(8),
	form_vourcher_k varchar(100),
	form_vourcher_m varchar(100),
	account_other_expend varchar(8),
	account_bank_fee varchar(8),
	account_verify_wait varchar(8),
	account_mreturn varchar(8),
	loan_type_chq_default varchar(6) DEFAULT '00',
	account_general_fee varchar(15),
	account_inter varchar(8),
	account_pending varchar(8),
	form_vourcher_rbank varchar(100),
	account_share_method char(1),
	agent_give varchar(8),
	agent_amt decimal(15,2),
	form_vourcher_m_bymem varchar(100),
	form_vourcher_give varchar(100),
	account_telspp_return_wait char(8),
	cut_bank_all char(1) DEFAULT '0',
	form_chq_to_bank varchar(100),
	account_fund char(8)
) ;
COMMENT ON TABLE sc_fin_m_constant IS E'!N???????????????????N!!MM!';
COMMENT ON COLUMN sc_fin_m_constant.account_cash IS E'!N??????????? >:N!!MM!';
COMMENT ON COLUMN sc_fin_m_constant.account_chqwait IS E'!N?????????????? : ??????? >:N!!MM!';
COMMENT ON COLUMN sc_fin_m_constant.account_month_return_wait IS E'!N???????????????????????? >:N!!MM!';
COMMENT ON COLUMN sc_fin_m_constant.account_other_income IS E'!N???????????????? >:N!!MM!';
COMMENT ON COLUMN sc_fin_m_constant.account_share IS E'!N????????????????? >:N!!MM!';
COMMENT ON COLUMN sc_fin_m_constant.account_share_return_wait IS E'!N??????? >:N!!MM!';
COMMENT ON COLUMN sc_fin_m_constant.form_cash_request IS E'!N?????_?????????? :N!!MM!';
COMMENT ON COLUMN sc_fin_m_constant.form_cash_return IS E'!N?????_???????????? :N!!MM!';
COMMENT ON COLUMN sc_fin_m_constant.form_vourcher_p IS E'!N????????????_???? :N!!MM!';
COMMENT ON COLUMN sc_fin_m_constant.form_vourcher_r IS E'!N????????????_??? :N!!MM!';
COMMENT ON COLUMN sc_fin_m_constant.other_income_limit IS E'!N?????????????????? :N!!MM!';
COMMENT ON COLUMN sc_fin_m_constant.receive_no_spp IS E'!N?????????????(???) ??????????????????????????N!!MM!';
ALTER TABLE sc_fin_m_constant ADD PRIMARY KEY (coop_no);


