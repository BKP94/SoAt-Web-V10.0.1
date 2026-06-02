CREATE TABLE sc_lon_m_ucf_fee (
	fee_type varchar(3) NOT NULL DEFAULT '00',
	fee_name varchar(50),
	system varchar(10),
	status char(1),
	fee_amonth smallint DEFAULT 0,
	sign double precision DEFAULT 0,
	account_id varchar(8),
	print_cheque char(1),
	item_amount decimal(15,2) DEFAULT 0,
	insur_status char(1) DEFAULT '0',
	calc_fee varchar(50),
	insur_company varchar(6),
	group_code char(3),
	active_status char(1) DEFAULT '0',
	note varchar(1000),
	insurance_type varchar(5),
	ref_item_type_id varchar(3)
) ;
COMMENT ON TABLE sc_lon_m_ucf_fee IS E'!NN!';
COMMENT ON COLUMN sc_lon_m_ucf_fee.account_id IS E'!N???????????N!!MM!';
COMMENT ON COLUMN sc_lon_m_ucf_fee.fee_amonth IS E'!N????????????N!!MM!';
COMMENT ON COLUMN sc_lon_m_ucf_fee.fee_name IS E'!N??????????N!!MM!';
COMMENT ON COLUMN sc_lon_m_ucf_fee.fee_type IS E'!N????N!!MM!';
COMMENT ON COLUMN sc_lon_m_ucf_fee.print_cheque IS E'!N?????????N!!MM!';
COMMENT ON COLUMN sc_lon_m_ucf_fee.sign IS E'!N????N!!MM!';
ALTER TABLE sc_lon_m_ucf_fee ADD PRIMARY KEY (fee_type);


