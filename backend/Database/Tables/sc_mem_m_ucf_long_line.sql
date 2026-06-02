CREATE TABLE sc_mem_m_ucf_long_line (
	seq_no double precision NOT NULL,
	long_line varchar(150)
) ;
ALTER TABLE sc_mem_m_ucf_long_line ADD PRIMARY KEY (seq_no);
ALTER TABLE sc_mem_m_ucf_long_line ALTER COLUMN seq_no SET NOT NULL;


