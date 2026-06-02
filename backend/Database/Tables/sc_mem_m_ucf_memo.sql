CREATE TABLE sc_mem_m_ucf_memo (
	memo_code varchar(15) NOT NULL DEFAULT '00',
	memo_desc varchar(50)
) ;
ALTER TABLE sc_mem_m_ucf_memo ADD PRIMARY KEY (memo_code);
ALTER TABLE sc_mem_m_ucf_memo ALTER COLUMN memo_code SET NOT NULL;


