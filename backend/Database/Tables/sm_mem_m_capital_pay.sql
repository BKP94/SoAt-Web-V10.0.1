CREATE TABLE sm_mem_m_capital_pay (
	account_year double precision NOT NULL,
	membership_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL,
	sm_seq bigint NOT NULL DEFAULT 0
) ;
ALTER TABLE sm_mem_m_capital_pay ADD PRIMARY KEY (account_year,membership_no,seq_no,sm_seq);
ALTER TABLE sm_mem_m_capital_pay ALTER COLUMN sm_seq SET NOT NULL;


