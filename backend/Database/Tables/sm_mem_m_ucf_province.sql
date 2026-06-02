CREATE TABLE sm_mem_m_ucf_province (
	province_code varchar(6) NOT NULL,
	sm_seq bigint NOT NULL DEFAULT 0
) ;
ALTER TABLE sm_mem_m_ucf_province ADD PRIMARY KEY (province_code,sm_seq);
ALTER TABLE sm_mem_m_ucf_province ALTER COLUMN sm_seq SET NOT NULL;


