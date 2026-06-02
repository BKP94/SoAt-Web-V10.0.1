CREATE TABLE sc_lon_m_paid_statement (
	loan_contract_no char(15),
	seq_no double precision,
	paid_method char(3),
	paid_amount decimal(15,2),
	paid_date timestamp,
	paid_status char(1),
	entry_id char(10),
	entry_branch char(2),
	entry_date timestamp,
	paid_entry_id varchar(15),
	paid_entry_branch char(2),
	paid_entry_date timestamp,
	paid_number double precision,
	cancel_status char(1),
	cancel_id char(10),
	cancel_branch char(2),
	cancel_date timestamp
) ;


