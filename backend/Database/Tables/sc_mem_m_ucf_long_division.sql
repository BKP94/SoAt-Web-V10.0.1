CREATE TABLE sc_mem_m_ucf_long_division (
	seq_no double precision NOT NULL,
	long_division varchar(150)
) ;
ALTER TABLE sc_mem_m_ucf_long_division ADD PRIMARY KEY (seq_no);
ALTER TABLE sc_mem_m_ucf_long_division ALTER COLUMN seq_no SET NOT NULL;


