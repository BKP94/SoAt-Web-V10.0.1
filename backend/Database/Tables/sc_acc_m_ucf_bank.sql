CREATE TABLE sc_acc_m_ucf_bank (
	bank_id varchar(6) NOT NULL,
	bank_name varchar(100),
	ext_status char(1),
	map_code varchar(6),
	contract_bank_status char(1),
	bank_acc_no char(10),
	bank_branch_id char(5),
	atm_online char(1),
	atm_account varchar(15),
	edit_mask varchar(20),
	atm_code varchar(20),
	atm_status char(1),
	account_id varchar(8),
	print_cheque char(1),
	name_resize varchar(10),
	yearpaid_account_id varchar(8),
	account_return_money varchar(8),
	dividend_status char(1) DEFAULT '0',
	paid_loan char(1) DEFAULT '0',
	dep_monthly_int char(1) DEFAULT '0',
	sort_order bigint,
	short_name varchar(50),
	group_report varchar(2) DEFAULT '00',
	div_status char(1),
	coop_atm_code_new varchar(15),
	coop_atm_code varchar(15)
) ;
COMMENT ON TABLE sc_acc_m_ucf_bank IS E'!N????????????????? - ??????N!!MM!';
COMMENT ON COLUMN sc_acc_m_ucf_bank.account_id IS E'!N??????????????????????N!!MM!';
COMMENT ON COLUMN sc_acc_m_ucf_bank.bank_id IS E'!N????N!!MM!';
COMMENT ON COLUMN sc_acc_m_ucf_bank.bank_name IS E'!N??????????N!!MM!';
COMMENT ON COLUMN sc_acc_m_ucf_bank.contract_bank_status IS E'!N??????N!!MM!';
COMMENT ON COLUMN sc_acc_m_ucf_bank.name_resize IS E'!N???????N!!MM!';
COMMENT ON COLUMN sc_acc_m_ucf_bank.yearpaid_account_id IS E'!N?????????????????????????N!!MM!';
ALTER TABLE sc_acc_m_ucf_bank ADD PRIMARY KEY (bank_id);


