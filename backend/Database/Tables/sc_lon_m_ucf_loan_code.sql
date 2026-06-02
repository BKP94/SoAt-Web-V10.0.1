CREATE TABLE sc_lon_m_ucf_loan_code (
	loan_code char(1) NOT NULL DEFAULT '0',
	loan_code_desc varchar(50),
	account_id varchar(8),
	int_account_id varchar(8)
) ;
COMMENT ON TABLE sc_lon_m_ucf_loan_code IS E'!NN!';
COMMENT ON COLUMN sc_lon_m_ucf_loan_code.account_id IS E'!N????????????N!!MM!';
COMMENT ON COLUMN sc_lon_m_ucf_loan_code.int_account_id IS E'!N?????????????N!!MM!';
COMMENT ON COLUMN sc_lon_m_ucf_loan_code.loan_code IS E'!N????N!!MM!';
COMMENT ON COLUMN sc_lon_m_ucf_loan_code.loan_code_desc IS E'!N??????????N!!MM!';
ALTER TABLE sc_lon_m_ucf_loan_code ADD PRIMARY KEY (loan_code);


