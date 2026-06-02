CREATE TABLE sc_lon_m_int_step_rate_conno (
	loan_contract_no varchar(15) NOT NULL,
	loan_step decimal(15,2) NOT NULL DEFAULT 0,
	effective_date timestamp NOT NULL,
	loan_interest_rate decimal(6,6) DEFAULT 0,
	float_status char(1) DEFAULT '0',
	float_rate decimal(6,6) DEFAULT 0
) ;
COMMENT ON TABLE sc_lon_m_int_step_rate_conno IS E'!NN!';
ALTER TABLE sc_lon_m_int_step_rate_conno ADD PRIMARY KEY (loan_contract_no,loan_step,effective_date);


