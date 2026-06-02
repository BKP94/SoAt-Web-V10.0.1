CREATE TABLE sc_mem_m_ucf_long_office (
	seq_no double precision NOT NULL,
	long_office varchar(150)
) ;
ALTER TABLE sc_mem_m_ucf_long_office ADD PRIMARY KEY (seq_no);
ALTER TABLE sc_mem_m_ucf_long_office ALTER COLUMN seq_no SET NOT NULL;


