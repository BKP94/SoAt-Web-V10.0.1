CREATE TABLE sc_lon_m_rule_fee (
	loan_type varchar(6) NOT NULL DEFAULT '00',
	install_loan_more numeric(38) DEFAULT 0,
	install_lower_than numeric(38) DEFAULT 0,
	loan_fee_percent decimal(8,6) DEFAULT 0,
	account_id varchar(8),
	loan_fee_type varchar(6) NOT NULL DEFAULT '00',
	loan_fee_amount decimal(15,2) DEFAULT 0,
	mem_request_amount decimal(15,2),
	on_firstload char(1) DEFAULT '0',
	fee_amount decimal(15,2) DEFAULT (0),
	period_limit double precision DEFAULT (0)
) ;
ALTER TABLE sc_lon_m_rule_fee ADD PRIMARY KEY (loan_type,loan_fee_type);
ALTER TABLE sc_lon_m_rule_fee ALTER COLUMN loan_type SET NOT NULL;
ALTER TABLE sc_lon_m_rule_fee ALTER COLUMN loan_fee_type SET NOT NULL;


