CREATE TABLE sc_mem_m_ucf_long_subdivision (
	seq_no double precision NOT NULL,
	long_subdivision varchar(150)
) ;
ALTER TABLE sc_mem_m_ucf_long_subdivision ADD PRIMARY KEY (seq_no);
ALTER TABLE sc_mem_m_ucf_long_subdivision ALTER COLUMN seq_no SET NOT NULL;


