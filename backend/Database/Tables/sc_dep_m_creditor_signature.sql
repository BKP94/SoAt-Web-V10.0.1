CREATE TABLE sc_dep_m_creditor_signature (
	deposit_account_no varchar(15) NOT NULL,
	seq_no numeric(38) NOT NULL,
	pic bytea,
	entry_id varchar(16),
	entry_date timestamp
) ;
ALTER TABLE sc_dep_m_creditor_signature ADD PRIMARY KEY (deposit_account_no,seq_no);


