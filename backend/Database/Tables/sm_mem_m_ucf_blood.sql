CREATE TABLE sm_mem_m_ucf_blood (
	blood_code varchar(6) NOT NULL DEFAULT '00',
	sm_seq bigint NOT NULL DEFAULT 0
) ;
ALTER TABLE sm_mem_m_ucf_blood ADD PRIMARY KEY (blood_code,sm_seq);
ALTER TABLE sm_mem_m_ucf_blood ALTER COLUMN sm_seq SET NOT NULL;
ALTER TABLE sm_mem_m_ucf_blood ALTER COLUMN blood_code SET NOT NULL;


