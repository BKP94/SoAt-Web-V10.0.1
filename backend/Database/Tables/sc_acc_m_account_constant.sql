CREATE TABLE sc_acc_m_account_constant (
	coop_registered_no varchar(18) NOT NULL,
	tax_id varchar(18),
	vat decimal(5,2),
	reserve_money_percent decimal(5,2),
	cash_account_code varchar(8),
	cash_book_type_code varchar(6),
	close_book_type_code varchar(6),
	present_account_year double precision,
	beginning_of_account timestamp,
	ending_of_account timestamp,
	used_depreciate char(1),
	use_firm char(1),
	slip_account_format varchar(15),
	useopsiteaccount char(1),
	type_gen_doc char(1),
	len_doc_no double precision,
	account_mask varchar(15),
	split_branch char(1) DEFAULT '0',
	profit_acc_id varchar(8),
	close_revert char(1) DEFAULT '0',
	close_adj_month char(1) DEFAULT '0',
	pv_rv_equa_jv char(1) DEFAULT '0',
	journal_slip varchar(50),
	use_desc_jn_firm char(1) DEFAULT '0',
	account_tax varchar(8)
) ;
COMMENT ON TABLE sc_acc_m_account_constant IS E'!N?????????????????N!!MM!';
COMMENT ON COLUMN sc_acc_m_account_constant.beginning_of_account IS E'!N??????????????????????N!!MM!';
COMMENT ON COLUMN sc_acc_m_account_constant.cash_account_code IS E'!N???????????????N!!MM!';
COMMENT ON COLUMN sc_acc_m_account_constant.coop_registered_no IS E'!N???????????????????N!!MM!';
COMMENT ON COLUMN sc_acc_m_account_constant.ending_of_account IS E'!N?????????????????????N!!MM!';
COMMENT ON COLUMN sc_acc_m_account_constant.journal_slip IS E'!N?????????N!!MM!';
COMMENT ON COLUMN sc_acc_m_account_constant.len_doc_no IS E'!NN!!MM!';
COMMENT ON COLUMN sc_acc_m_account_constant.present_account_year IS E'!N???????????????N!!MM!';
COMMENT ON COLUMN sc_acc_m_account_constant.reserve_money_percent IS E'!N???????????????N!!MM!';
COMMENT ON COLUMN sc_acc_m_account_constant.slip_account_format IS E'!N???????????????N!!MM!';
COMMENT ON COLUMN sc_acc_m_account_constant.tax_id IS E'!N??????????????????????N!!MM!';
COMMENT ON COLUMN sc_acc_m_account_constant.use_firm IS E'!N???????????N!!MM!';
COMMENT ON COLUMN sc_acc_m_account_constant.vat IS E'!N???????????????N!!MM!';
ALTER TABLE sc_acc_m_account_constant ADD PRIMARY KEY (coop_registered_no);


