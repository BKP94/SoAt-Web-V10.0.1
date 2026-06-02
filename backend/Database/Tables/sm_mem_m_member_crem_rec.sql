CREATE TABLE sm_mem_m_member_crem_rec (
	receipt_no varchar(15) NOT NULL,
	sm_seq bigint NOT NULL DEFAULT 0
) ;
ALTER TABLE sm_mem_m_member_crem_rec ADD PRIMARY KEY (receipt_no,sm_seq);
ALTER TABLE sm_mem_m_member_crem_rec ALTER COLUMN sm_seq SET NOT NULL;


