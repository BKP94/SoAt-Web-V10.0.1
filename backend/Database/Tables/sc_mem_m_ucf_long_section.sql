CREATE TABLE sc_mem_m_ucf_long_section (
	seq_no double precision NOT NULL,
	long_section varchar(150)
) ;
ALTER TABLE sc_mem_m_ucf_long_section ADD PRIMARY KEY (seq_no);
ALTER TABLE sc_mem_m_ucf_long_section ALTER COLUMN seq_no SET NOT NULL;


