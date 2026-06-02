CREATE TABLE sm_fin_m_constant (
	coop_no varchar(15) NOT NULL,
	finance_date timestamp,
	sm_seq bigint NOT NULL DEFAULT 0
) ;
ALTER TABLE sm_fin_m_constant ADD PRIMARY KEY (coop_no,sm_seq);
ALTER TABLE sm_fin_m_constant ALTER COLUMN sm_seq SET NOT NULL;
ALTER TABLE sm_fin_m_constant ALTER COLUMN coop_no SET NOT NULL;


