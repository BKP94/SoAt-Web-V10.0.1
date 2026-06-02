CREATE TABLE sc_fund_mem_backup (
	membership_no varchar(15) NOT NULL,
	loan_contract_no char(15) NOT NULL,
	loan_type varchar(6),
	pricipal_balance decimal(15,2),
	begin_balance decimal(15,2),
	total_balance decimal(15,2),
	keep_month decimal(15,2),
	keep_arrear decimal(15,2),
	keep_total decimal(15,2),
	accu_interest decimal(15,2),
	last_access_date timestamp,
	remark varchar(50),
	keep_status char(1),
	close_status char(1),
	last_user_id char(50),
	last_user_date timestamp,
	last_user_branch_id varchar(6),
	pending_amt decimal(15,2),
	last_period double precision,
	last_cal_int_date timestamp,
	balance_cal_int decimal(15,2),
	paid_return_method varchar(6),
	open_day timestamp,
	branch_id varchar(6),
	fund_status decimal(15,2),
	fund_res_status char(1)
) ;
ALTER TABLE sc_fund_mem_backup ADD PRIMARY KEY (loan_contract_no,membership_no);


