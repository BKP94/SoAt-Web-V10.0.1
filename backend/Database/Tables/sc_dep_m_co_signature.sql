CREATE TABLE sc_dep_m_co_signature (
	deposit_account_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL,
	signature bytea
) ;
ALTER TABLE sc_dep_m_co_signature ADD PRIMARY KEY (deposit_account_no,seq_no);


