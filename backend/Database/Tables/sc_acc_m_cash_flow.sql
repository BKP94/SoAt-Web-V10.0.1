CREATE TABLE sc_acc_m_cash_flow (
	account_id varchar(8) NOT NULL,
	account_name varchar(100),
	amount_net_first decimal(15,2) DEFAULT 0,
	amount_net_secound decimal(15,2) DEFAULT 0,
	group_acc integer DEFAULT 0,
	seq_no double precision NOT NULL DEFAULT 0
) ;
COMMENT ON TABLE sc_acc_m_cash_flow IS E'!NN!';
ALTER TABLE sc_acc_m_cash_flow ADD PRIMARY KEY (account_id,seq_no);
ALTER TABLE sc_acc_m_cash_flow ALTER COLUMN seq_no SET NOT NULL;


