CREATE TABLE sm_mem_m_member_work_info (
	membership_no varchar(15) NOT NULL DEFAULT 'cnv',
	sm_seq bigint NOT NULL DEFAULT 0
) ;
ALTER TABLE sm_mem_m_member_work_info ADD PRIMARY KEY (membership_no,sm_seq);
ALTER TABLE sm_mem_m_member_work_info ALTER COLUMN sm_seq SET NOT NULL;


