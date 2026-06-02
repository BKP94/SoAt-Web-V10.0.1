CREATE TABLE sm_mem_m_ucf_prename (
	prename_code varchar(7) NOT NULL,
	sm_seq bigint NOT NULL DEFAULT 0
) ;
ALTER TABLE sm_mem_m_ucf_prename ADD PRIMARY KEY (prename_code,sm_seq);
ALTER TABLE sm_mem_m_ucf_prename ALTER COLUMN sm_seq SET NOT NULL;
ALTER TABLE sm_mem_m_ucf_prename ALTER COLUMN prename_code SET NOT NULL;


