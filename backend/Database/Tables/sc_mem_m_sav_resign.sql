CREATE TABLE sc_mem_m_sav_resign (
	resign_doc_no char(15) NOT NULL,
	sav_resign_seq double precision NOT NULL,
	dep_account_no char(15),
	sav_type char(50),
	dep_balance decimal(15,2),
	dept_holding decimal(15,2)
) ;
ALTER TABLE sc_mem_m_sav_resign ADD PRIMARY KEY (resign_doc_no,sav_resign_seq);


