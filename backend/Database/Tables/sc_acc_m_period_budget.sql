CREATE TABLE sc_acc_m_period_budget (
	account_year double precision NOT NULL,
	period varchar(18) NOT NULL,
	account_id varchar(8) NOT NULL,
	budget_amount varchar(18)
) ;
COMMENT ON TABLE sc_acc_m_period_budget IS E'!NN!';
ALTER TABLE sc_acc_m_period_budget ADD PRIMARY KEY (account_year,period,account_id);


