CREATE TABLE sc_mem_m_loan_resign (
	resign_doc_no char(15) NOT NULL,
	loan_resign_seq double precision NOT NULL,
	contract_no char(15),
	principal_balance decimal(15,2),
	interest decimal(15,2),
	calint_from timestamp,
	interest_arrear decimal(15,2)
) ;
ALTER TABLE sc_mem_m_loan_resign ADD PRIMARY KEY (resign_doc_no,loan_resign_seq);


