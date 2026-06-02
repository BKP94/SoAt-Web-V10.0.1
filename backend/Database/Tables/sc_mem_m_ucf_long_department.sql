CREATE TABLE sc_mem_m_ucf_long_department (
	seq_no double precision NOT NULL,
	long_department varchar(150)
) ;
ALTER TABLE sc_mem_m_ucf_long_department ADD PRIMARY KEY (seq_no);
ALTER TABLE sc_mem_m_ucf_long_department ALTER COLUMN seq_no SET NOT NULL;


