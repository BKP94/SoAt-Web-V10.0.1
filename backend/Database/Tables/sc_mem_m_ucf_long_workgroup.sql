CREATE TABLE sc_mem_m_ucf_long_workgroup (
	seq_no double precision NOT NULL,
	long_workgroup varchar(150)
) ;
ALTER TABLE sc_mem_m_ucf_long_workgroup ADD PRIMARY KEY (seq_no);
ALTER TABLE sc_mem_m_ucf_long_workgroup ALTER COLUMN seq_no SET NOT NULL;


