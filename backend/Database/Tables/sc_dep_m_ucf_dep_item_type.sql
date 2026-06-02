CREATE TABLE sc_dep_m_ucf_dep_item_type (
	deposit_item_type varchar(3) NOT NULL,
	deposit_item_description varchar(100),
	sign_flag double precision,
	print_code varchar(6),
	item_group varchar(3),
	paid_cheque char(1),
	ref_pay_type varchar(3),
	acc_ref_item varchar(3),
	split_deptype char(1) DEFAULT '0',
	ref_fin_item varchar(6),
	ref_cash char(1) DEFAULT '0',
	ref_tran_bank char(1) DEFAULT '0',
	ref_tran_oth char(1) DEFAULT '0',
	ref_account_type char(1) DEFAULT '0',
	not_posttofin char(1) DEFAULT '0',
	item_fin_slip varchar(3),
	pay_type varchar(3),
	account_from varchar(8),
	witdraw_return char(1) DEFAULT '0',
	sign_show double precision DEFAULT 0,
	trans_group char(1),
	cheque_forward char(1),
	movement_status char(1) DEFAULT '1'
) ;
ALTER TABLE sc_dep_m_ucf_dep_item_type ADD PRIMARY KEY (deposit_item_type);
ALTER TABLE sc_dep_m_ucf_dep_item_type ALTER COLUMN deposit_item_type SET NOT NULL;


