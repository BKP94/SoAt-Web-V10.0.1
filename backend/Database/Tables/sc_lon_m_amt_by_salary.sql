CREATE TABLE sc_lon_m_amt_by_salary (
	loan_type varchar(6) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	loan_amount decimal(15,2) DEFAULT 0,
	payment_amount decimal(15,2) DEFAULT 0,
	interest_amount decimal(15,2) DEFAULT 0,
	salary_amount decimal(15,2) DEFAULT 0,
	max_loan_amount decimal(15,2),
	effective_date timestamp,
	expire_date timestamp
) ;
ALTER TABLE sc_lon_m_amt_by_salary ADD PRIMARY KEY (loan_type,seq_no);
ALTER TABLE sc_lon_m_amt_by_salary ALTER COLUMN loan_type SET NOT NULL;
ALTER TABLE sc_lon_m_amt_by_salary ALTER COLUMN seq_no SET NOT NULL;


