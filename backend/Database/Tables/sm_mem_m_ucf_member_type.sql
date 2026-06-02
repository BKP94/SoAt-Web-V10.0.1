CREATE TABLE sm_mem_m_ucf_member_type (
	mem_type_code varchar(6) NOT NULL DEFAULT '00',
	sm_seq bigint NOT NULL DEFAULT 0
) ;
ALTER TABLE sm_mem_m_ucf_member_type ADD PRIMARY KEY (mem_type_code,sm_seq);
ALTER TABLE sm_mem_m_ucf_member_type ALTER COLUMN sm_seq SET NOT NULL;
ALTER TABLE sm_mem_m_ucf_member_type ALTER COLUMN mem_type_code SET NOT NULL;


