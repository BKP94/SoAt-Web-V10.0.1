CREATE TABLE sm_acc_m_ucf_bank (
	bank_id varchar(6) NOT NULL,
	sm_seq bigint NOT NULL DEFAULT 0
) ;
ALTER TABLE sm_acc_m_ucf_bank ADD PRIMARY KEY (bank_id,sm_seq);
ALTER TABLE sm_acc_m_ucf_bank ALTER COLUMN sm_seq SET NOT NULL;


