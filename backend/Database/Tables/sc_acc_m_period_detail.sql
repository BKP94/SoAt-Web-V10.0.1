CREATE TABLE sc_acc_m_period_detail (
	account_year double precision NOT NULL,
	period varchar(18) NOT NULL,
	account_id varchar(8) NOT NULL,
	dr_amount decimal(15,2),
	cr_amount decimal(15,2)
) ;
COMMENT ON TABLE sc_acc_m_period_detail IS E'!NN!';
ALTER TABLE sc_acc_m_period_detail ADD PRIMARY KEY (account_year,period,account_id);


