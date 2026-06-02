CREATE TABLE sc_acc_m_account_budget_group (
	account_year double precision NOT NULL DEFAULT 0,
	budget_id varchar(6) NOT NULL,
	budget_name varchar(100),
	nature varchar(6),
	branch_id varchar(6) NOT NULL DEFAULT '00',
	total_budjet decimal(15,2) DEFAULT 0,
	month_status char(1),
	total_transfer_budget decimal(15,2) DEFAULT 0,
	account_group_id varchar(6)
) ;
COMMENT ON TABLE sc_acc_m_account_budget_group IS E'!NN!';
ALTER TABLE sc_acc_m_account_budget_group ADD PRIMARY KEY (account_year,budget_id,branch_id);


