CREATE TABLE sm_lon_m_rule (
	loan_type varchar(6) NOT NULL,
	sm_seq bigint NOT NULL DEFAULT 0
) ;
ALTER TABLE sm_lon_m_rule ADD PRIMARY KEY (loan_type,sm_seq);
ALTER TABLE sm_lon_m_rule ALTER COLUMN sm_seq SET NOT NULL;


