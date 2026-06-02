CREATE TABLE sm_dep_m_creditor_item (
	deposit_account_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	sm_seq bigint NOT NULL DEFAULT 0
) ;
ALTER TABLE sm_dep_m_creditor_item ADD PRIMARY KEY (deposit_account_no,seq_no,sm_seq);
ALTER TABLE sm_dep_m_creditor_item ALTER COLUMN sm_seq SET NOT NULL;
ALTER TABLE sm_dep_m_creditor_item ALTER COLUMN deposit_account_no SET NOT NULL;
ALTER TABLE sm_dep_m_creditor_item ALTER COLUMN seq_no SET NOT NULL;


