CREATE TABLE sc_mem_m_ucf_resign_ins (
	resign_code varchar(2) NOT NULL,
	resign_name varchar(100)
) ;
ALTER TABLE sc_mem_m_ucf_resign_ins ADD PRIMARY KEY (resign_code);
ALTER TABLE sc_mem_m_ucf_resign_ins ALTER COLUMN resign_code SET NOT NULL;


