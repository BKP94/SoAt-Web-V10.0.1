CREATE TABLE sc_fund_int_step_rate (
	loan_type varchar(6) NOT NULL,
	seq_no double precision NOT NULL,
	used_operate_date timestamp,
	amount_max decimal(15,2),
	int_rate decimal(8,6),
	user_id varchar(50),
	user_date timestamp,
	branch_id varchar(6)
) ;
ALTER TABLE sc_fund_int_step_rate ADD PRIMARY KEY (loan_type,seq_no);


