CREATE TABLE sm_mem_m_member_member_refer (
	membership_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	sm_seq bigint NOT NULL DEFAULT 0
) ;
ALTER TABLE sm_mem_m_member_member_refer ADD PRIMARY KEY (membership_no,seq_no,sm_seq);
ALTER TABLE sm_mem_m_member_member_refer ALTER COLUMN sm_seq SET NOT NULL;
ALTER TABLE sm_mem_m_member_member_refer ALTER COLUMN membership_no SET NOT NULL;
ALTER TABLE sm_mem_m_member_member_refer ALTER COLUMN seq_no SET NOT NULL;


