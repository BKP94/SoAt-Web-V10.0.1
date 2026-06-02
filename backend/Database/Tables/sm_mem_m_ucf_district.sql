CREATE TABLE sm_mem_m_ucf_district (
	district_code varchar(6) NOT NULL,
	province_code varchar(6) NOT NULL,
	sm_seq bigint NOT NULL DEFAULT 0
) ;
ALTER TABLE sm_mem_m_ucf_district ADD PRIMARY KEY (district_code,province_code,sm_seq);
ALTER TABLE sm_mem_m_ucf_district ALTER COLUMN sm_seq SET NOT NULL;
ALTER TABLE sm_mem_m_ucf_district ALTER COLUMN province_code SET NOT NULL;


