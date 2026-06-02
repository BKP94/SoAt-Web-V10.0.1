CREATE TABLE sc_lon_m_ucf_loan_colltype (
	loan_type varchar(6) NOT NULL,
	collateral_type_code varchar(6) NOT NULL,
	estimate_value decimal(15,2) DEFAULT 0
) ;
ALTER TABLE sc_lon_m_ucf_loan_colltype ADD PRIMARY KEY (loan_type,collateral_type_code);


