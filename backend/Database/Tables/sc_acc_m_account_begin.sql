CREATE TABLE sc_acc_m_account_begin (
	account_year double precision NOT NULL,
	account_id varchar(8) NOT NULL,
	branch_id varchar(6) NOT NULL,
	balance_begin decimal(15,2)
) ;
COMMENT ON TABLE sc_acc_m_account_begin IS E'!NN!';
ALTER TABLE sc_acc_m_account_begin ADD PRIMARY KEY (account_year,account_id,branch_id);


