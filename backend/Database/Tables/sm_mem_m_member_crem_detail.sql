CREATE TABLE sm_mem_m_member_crem_detail (
	membership_no varchar(15) NOT NULL,
	crem_type varchar(6) NOT NULL,
	crem_memno varchar(15) NOT NULL,
	seq_no double precision NOT NULL,
	seq_no_det double precision NOT NULL,
	sm_seq bigint NOT NULL DEFAULT 0
) ;
ALTER TABLE sm_mem_m_member_crem_detail ADD PRIMARY KEY (membership_no,crem_type,crem_memno,seq_no,seq_no_det,sm_seq);
ALTER TABLE sm_mem_m_member_crem_detail ALTER COLUMN sm_seq SET NOT NULL;
ALTER TABLE sm_mem_m_member_crem_detail ALTER COLUMN membership_no SET NOT NULL;
ALTER TABLE sm_mem_m_member_crem_detail ALTER COLUMN crem_type SET NOT NULL;
ALTER TABLE sm_mem_m_member_crem_detail ALTER COLUMN crem_memno SET NOT NULL;
ALTER TABLE sm_mem_m_member_crem_detail ALTER COLUMN seq_no SET NOT NULL;
ALTER TABLE sm_mem_m_member_crem_detail ALTER COLUMN seq_no_det SET NOT NULL;


