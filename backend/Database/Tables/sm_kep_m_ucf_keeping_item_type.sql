CREATE TABLE sm_kep_m_ucf_keeping_item_type (
	keeping_type_code varchar(5) NOT NULL,
	sm_seq bigint NOT NULL DEFAULT 0
) ;
ALTER TABLE sm_kep_m_ucf_keeping_item_type ADD PRIMARY KEY (keeping_type_code,sm_seq);
ALTER TABLE sm_kep_m_ucf_keeping_item_type ALTER COLUMN sm_seq SET NOT NULL;
ALTER TABLE sm_kep_m_ucf_keeping_item_type ALTER COLUMN keeping_type_code SET NOT NULL;


