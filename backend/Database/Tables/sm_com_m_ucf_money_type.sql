CREATE TABLE sm_com_m_ucf_money_type (
	money_type_id varchar(3) NOT NULL,
	sm_seq bigint NOT NULL DEFAULT 0
) ;
ALTER TABLE sm_com_m_ucf_money_type ADD PRIMARY KEY (money_type_id,sm_seq);
ALTER TABLE sm_com_m_ucf_money_type ALTER COLUMN sm_seq SET NOT NULL;
ALTER TABLE sm_com_m_ucf_money_type ALTER COLUMN money_type_id SET NOT NULL;


