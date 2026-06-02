CREATE TABLE sm_mem_m_ucf_member_group (
	member_group_no varchar(15) NOT NULL,
	sm_seq bigint NOT NULL DEFAULT 0
) ;
ALTER TABLE sm_mem_m_ucf_member_group ADD PRIMARY KEY (member_group_no,sm_seq);
ALTER TABLE sm_mem_m_ucf_member_group ALTER COLUMN sm_seq SET NOT NULL;
ALTER TABLE sm_mem_m_ucf_member_group ALTER COLUMN member_group_no SET NOT NULL;


