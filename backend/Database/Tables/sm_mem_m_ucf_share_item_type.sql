CREATE TABLE sm_mem_m_ucf_share_item_type (
	item_type varchar(6) NOT NULL,
	sm_seq bigint NOT NULL DEFAULT 0
) ;
ALTER TABLE sm_mem_m_ucf_share_item_type ADD PRIMARY KEY (item_type,sm_seq);
ALTER TABLE sm_mem_m_ucf_share_item_type ALTER COLUMN sm_seq SET NOT NULL;


