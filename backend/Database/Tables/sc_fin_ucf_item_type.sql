CREATE TABLE sc_fin_ucf_item_type (
	item_type varchar(10) NOT NULL,
	item_description varchar(100),
	sign_status char(1),
	application_type varchar(20),
	map_code varchar(3),
	loan_type varchar(6),
	pay_type char(1) DEFAULT 'C',
	account_id varchar(8),
	tran_account_id varchar(8),
	hold_account_id varchar(15),
	adj_dep char(1) DEFAULT '0',
	loan_code char(1) DEFAULT '0',
	have_det char(1) DEFAULT '0',
	default_paidname varchar(200),
	branch_only varchar(6) DEFAULT '01',
	default_amount decimal(15,2) DEFAULT 0,
	mrt_not_journal char(1) DEFAULT '0',
	vourcher_group varchar(7)
) ;
COMMENT ON TABLE sc_fin_ucf_item_type IS E'!NN!';
COMMENT ON COLUMN sc_fin_ucf_item_type.account_id IS E'!N???????????????????????????N!!MM!';
COMMENT ON COLUMN sc_fin_ucf_item_type.branch_only IS E'!N?????????N!!MM!';
COMMENT ON COLUMN sc_fin_ucf_item_type.item_description IS E'!N??????????N!!MM!';
COMMENT ON COLUMN sc_fin_ucf_item_type.item_type IS E'!N????N!!MM!';
COMMENT ON COLUMN sc_fin_ucf_item_type.pay_type IS E'!N?????????????N!!MM!';
COMMENT ON COLUMN sc_fin_ucf_item_type.sign_status IS E'!N??? ????N!!MM!';
COMMENT ON COLUMN sc_fin_ucf_item_type.tran_account_id IS E'!N?????????????????N!!MM!';
ALTER TABLE sc_fin_ucf_item_type ADD PRIMARY KEY (item_type);


