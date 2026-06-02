CREATE TABLE sc_mem_m_resign_loan (
	resign_doc_no varchar(15) NOT NULL,
	seq_no double precision DEFAULT 0,
	contract_no char(15),
	principal_balance double precision DEFAULT 0,
	interest double precision DEFAULT 0,
	calint_from timestamp,
	interest_arrear double precision DEFAULT 0,
	collateral_info varchar(300),
	loan_contract_no varchar(15) NOT NULL
) ;
CREATE INDEX idx_mem_resign_lon ON sc_mem_m_resign_loan (resign_doc_no);
ALTER TABLE sc_mem_m_resign_loan ADD PRIMARY KEY (resign_doc_no,loan_contract_no);
ALTER TABLE sc_mem_m_resign_loan ALTER COLUMN loan_contract_no SET NOT NULL;


