CREATE TABLE sm_mem_m_share_mem (
	membership_no varchar(15) NOT NULL,
	sm_seq bigint NOT NULL DEFAULT 0
) ;
ALTER TABLE sm_mem_m_share_mem ADD PRIMARY KEY (membership_no,sm_seq);
ALTER TABLE sm_mem_m_share_mem ALTER COLUMN sm_seq SET NOT NULL;
ALTER TABLE sm_mem_m_share_mem ALTER COLUMN membership_no SET NOT NULL;


