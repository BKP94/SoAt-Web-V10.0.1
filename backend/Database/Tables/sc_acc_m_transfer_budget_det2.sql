CREATE TABLE sc_acc_m_transfer_budget_det2 (
	transfer_id double precision NOT NULL DEFAULT 0,
	seq_no double precision DEFAULT 0,
	budget_id varchar(6),
	account_id varchar(8),
	operate_date timestamp,
	account_budget_old decimal(15,2) DEFAULT 0,
	transfer_budget_old decimal(15,2) DEFAULT 0,
	transfer_budget decimal(15,2) DEFAULT 0,
	entry_id varchar(20),
	branch_id varchar(6),
	entry_date timestamp,
	client_name varchar(20)
) ;
COMMENT ON TABLE sc_acc_m_transfer_budget_det2 IS E'!NN!';
ALTER TABLE sc_acc_m_transfer_budget_det2 ADD PRIMARY KEY (transfer_id);


