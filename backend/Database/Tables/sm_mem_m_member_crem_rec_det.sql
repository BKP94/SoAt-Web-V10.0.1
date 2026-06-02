CREATE TABLE sm_mem_m_member_crem_rec_det (
	receipt_no varchar(15) NOT NULL,
	item_type varchar(6) NOT NULL,
	crem_type varchar(6) NOT NULL,
	sm_seq bigint NOT NULL DEFAULT 0
) ;
ALTER TABLE sm_mem_m_member_crem_rec_det ADD PRIMARY KEY (receipt_no,item_type,crem_type,sm_seq);
ALTER TABLE sm_mem_m_member_crem_rec_det ALTER COLUMN sm_seq SET NOT NULL;


