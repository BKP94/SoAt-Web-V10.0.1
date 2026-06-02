CREATE TABLE sc_mem_m_resign_share (
	resign_doc_no varchar(15) NOT NULL,
	shr_value double precision DEFAULT 0,
	shr_qty double precision DEFAULT 0,
	period_recrieve double precision DEFAULT 0
) ;
ALTER TABLE sc_mem_m_resign_share ADD PRIMARY KEY (resign_doc_no);


