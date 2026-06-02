CREATE TABLE sm_mem_m_membership_registered (
	membership_no varchar(15) NOT NULL,
	sm_seq bigint NOT NULL DEFAULT 0
) ;
ALTER TABLE sm_mem_m_membership_registered ADD PRIMARY KEY (membership_no,sm_seq);
ALTER TABLE sm_mem_m_membership_registered ALTER COLUMN sm_seq SET NOT NULL;
ALTER TABLE sm_mem_m_membership_registered ALTER COLUMN membership_no SET NOT NULL;


