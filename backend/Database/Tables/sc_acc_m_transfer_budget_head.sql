CREATE TABLE sc_acc_m_transfer_budget_head (
	transfer_id double precision NOT NULL DEFAULT 0,
	budget_id varchar(6),
	pre_totalbudget_old decimal(15,2) DEFAULT 0,
	pre_tranfer_old decimal(15,2) DEFAULT 0,
	total_transfer_budget decimal(15,2) DEFAULT 0,
	operate_date timestamp,
	account_year double precision DEFAULT 0,
	entry_id varchar(20),
	branch_id varchar(6),
	entry_date timestamp,
	client_name varchar(20)
) ;
COMMENT ON TABLE sc_acc_m_transfer_budget_head IS E'!NN!';
ALTER TABLE sc_acc_m_transfer_budget_head ADD PRIMARY KEY (transfer_id);


