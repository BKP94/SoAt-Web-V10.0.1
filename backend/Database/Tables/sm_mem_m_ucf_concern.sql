CREATE TABLE sm_mem_m_ucf_concern (
	conceern_code varchar(6) NOT NULL,
	sm_seq bigint NOT NULL DEFAULT 0
) ;
ALTER TABLE sm_mem_m_ucf_concern ADD PRIMARY KEY (conceern_code,sm_seq);
ALTER TABLE sm_mem_m_ucf_concern ALTER COLUMN sm_seq SET NOT NULL;


