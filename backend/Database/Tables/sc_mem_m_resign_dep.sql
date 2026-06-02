CREATE TABLE sc_mem_m_resign_dep (
	resign_doc_no varchar(15) NOT NULL,
	seq_no double precision DEFAULT 0,
	dep_account_no char(15),
	dep_balance decimal(15,2) DEFAULT 0,
	dept_holding decimal(15,2) DEFAULT 0,
	deposit_account_no varchar(15) NOT NULL,
	deposit_account_name varchar(100),
	deposit_balance double precision DEFAULT 0,
	loan_holding_amount double precision DEFAULT 0,
	close_status char(1) DEFAULT '0',
	op_receive_int decimal(15,2) DEFAULT 0
) ;
CREATE INDEX idx_mem_resign_dep ON sc_mem_m_resign_dep (resign_doc_no);
ALTER TABLE sc_mem_m_resign_dep ADD PRIMARY KEY (resign_doc_no,deposit_account_no);
ALTER TABLE sc_mem_m_resign_dep ALTER COLUMN deposit_account_no SET NOT NULL;


