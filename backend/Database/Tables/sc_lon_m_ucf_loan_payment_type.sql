CREATE TABLE sc_lon_m_ucf_loan_payment_type (
	loan_payment_type_code varchar(6) NOT NULL,
	loan_payment_type_desc varchar(100)
) ;
COMMENT ON TABLE sc_lon_m_ucf_loan_payment_type IS E'!NN!';
ALTER TABLE sc_lon_m_ucf_loan_payment_type ADD PRIMARY KEY (loan_payment_type_code);


