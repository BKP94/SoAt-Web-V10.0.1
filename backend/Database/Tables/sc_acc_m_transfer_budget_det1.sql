CREATE TABLE sc_acc_m_transfer_budget_det1 (
	transfer_id double precision DEFAULT 0,
	seq_no double precision DEFAULT 0,
	budget_id varchar(6),
	transfer_budget decimal(15,2) DEFAULT 0,
	entry_id varchar(20),
	branch_id varchar(6),
	entry_date timestamp,
	client_name varchar(20)
) ;
COMMENT ON TABLE sc_acc_m_transfer_budget_det1 IS E'!NN!';


