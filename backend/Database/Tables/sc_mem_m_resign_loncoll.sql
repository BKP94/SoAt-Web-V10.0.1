CREATE TABLE sc_mem_m_resign_loncoll (
	resign_doc_no varchar(15) NOT NULL,
	seq_no double precision DEFAULT 0,
	contract_no char(15),
	contract_memno varchar(15) NOT NULL,
	coll_amount double precision DEFAULT 0,
	loan_contract_no varchar(15) NOT NULL,
	contract_mem_name varchar(100)
) ;
CREATE INDEX idx_mem_resign_loncoll ON sc_mem_m_resign_loncoll (resign_doc_no);
ALTER TABLE sc_mem_m_resign_loncoll ADD PRIMARY KEY (resign_doc_no,loan_contract_no,contract_memno);
ALTER TABLE sc_mem_m_resign_loncoll ALTER COLUMN loan_contract_no SET NOT NULL;


