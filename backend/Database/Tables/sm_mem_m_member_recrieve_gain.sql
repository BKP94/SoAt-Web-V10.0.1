CREATE TABLE sm_mem_m_member_recrieve_gain (
	membership_no varchar(15) NOT NULL,
	rec_no double precision NOT NULL DEFAULT 0,
	sm_seq bigint NOT NULL DEFAULT 0
) ;
ALTER TABLE sm_mem_m_member_recrieve_gain ADD PRIMARY KEY (membership_no,rec_no,sm_seq);
ALTER TABLE sm_mem_m_member_recrieve_gain ALTER COLUMN sm_seq SET NOT NULL;
ALTER TABLE sm_mem_m_member_recrieve_gain ALTER COLUMN membership_no SET NOT NULL;
ALTER TABLE sm_mem_m_member_recrieve_gain ALTER COLUMN rec_no SET NOT NULL;


