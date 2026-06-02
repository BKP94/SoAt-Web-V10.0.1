CREATE TABLE sc_mem_m_ucf_long_group (
	seq_no double precision NOT NULL,
	long_group varchar(150)
) ;
ALTER TABLE sc_mem_m_ucf_long_group ADD PRIMARY KEY (seq_no);
ALTER TABLE sc_mem_m_ucf_long_group ALTER COLUMN seq_no SET NOT NULL;


