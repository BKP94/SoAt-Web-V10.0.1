CREATE TABLE sm_mem_m_ucf_subdistrict (
	subdistrict_code varchar(6) NOT NULL,
	sm_seq bigint NOT NULL DEFAULT 0
) ;
ALTER TABLE sm_mem_m_ucf_subdistrict ADD PRIMARY KEY (subdistrict_code,sm_seq);
ALTER TABLE sm_mem_m_ucf_subdistrict ALTER COLUMN sm_seq SET NOT NULL;
ALTER TABLE sm_mem_m_ucf_subdistrict ALTER COLUMN subdistrict_code SET NOT NULL;


