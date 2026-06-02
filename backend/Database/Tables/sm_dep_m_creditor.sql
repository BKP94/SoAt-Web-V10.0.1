CREATE TABLE sm_dep_m_creditor (
	deposit_account_no varchar(15) NOT NULL,
	sm_seq bigint NOT NULL DEFAULT 0
) ;
ALTER TABLE sm_dep_m_creditor ADD PRIMARY KEY (deposit_account_no,sm_seq);
ALTER TABLE sm_dep_m_creditor ALTER COLUMN sm_seq SET NOT NULL;
ALTER TABLE sm_dep_m_creditor ALTER COLUMN deposit_account_no SET NOT NULL;


