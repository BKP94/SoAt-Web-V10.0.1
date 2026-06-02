CREATE TABLE sm_dep_m_ucf_dep_item_type (
	deposit_item_type varchar(3) NOT NULL,
	sm_seq bigint NOT NULL DEFAULT 0
) ;
ALTER TABLE sm_dep_m_ucf_dep_item_type ADD PRIMARY KEY (deposit_item_type,sm_seq);
ALTER TABLE sm_dep_m_ucf_dep_item_type ALTER COLUMN sm_seq SET NOT NULL;


