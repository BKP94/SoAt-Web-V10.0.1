CREATE TABLE sm_dep_m_rule (
	deposit_type_code varchar(6) NOT NULL,
	sm_seq bigint NOT NULL DEFAULT 0
) ;
ALTER TABLE sm_dep_m_rule ADD PRIMARY KEY (deposit_type_code,sm_seq);
ALTER TABLE sm_dep_m_rule ALTER COLUMN sm_seq SET NOT NULL;


