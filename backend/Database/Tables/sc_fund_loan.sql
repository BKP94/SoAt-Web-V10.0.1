CREATE TABLE sc_fund_loan (
	fund_loan_no varchar(15) NOT NULL,
	loan_type varchar(6) NOT NULL,
	fund_name varchar(70),
	begin_balance decimal(15,2),
	total_balance decimal(15,2),
	total_interest decimal(15,2),
	last_access_date timestamp,
	remark varchar(200),
	close_status char(1),
	last_user_id varchar(10),
	last_user_date timestamp,
	last_user_branch_id varchar(6),
	last_close_int timestamp,
	round_method decimal(15,2) DEFAULT 0,
	round_method_type char(1) DEFAULT '0',
	int_round_method decimal(15,4) DEFAULT 0,
	int_round_method_type char(1) DEFAULT '0',
	int_or_principal_status char(1) DEFAULT '0',
	max_fund_cal_add decimal(15,2) DEFAULT 0,
	max_fund_percal decimal(15,2) DEFAULT 0,
	min_fund_cal_add decimal(15,2) DEFAULT 0,
	min_fund_percal decimal(15,2) DEFAULT 0
) ;
ALTER TABLE sc_fund_loan ADD PRIMARY KEY (fund_loan_no,loan_type);


