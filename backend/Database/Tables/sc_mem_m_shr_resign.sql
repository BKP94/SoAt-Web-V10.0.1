CREATE TABLE sc_mem_m_shr_resign (
	resign_doc_no char(15) NOT NULL,
	shr_value decimal(15,2),
	shr_qty decimal(15,2)
) ;
ALTER TABLE sc_mem_m_shr_resign ADD PRIMARY KEY (resign_doc_no);


