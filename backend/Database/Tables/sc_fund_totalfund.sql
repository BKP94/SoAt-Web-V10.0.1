CREATE TABLE sc_fund_totalfund (
	fund_loan_no varchar(15) NOT NULL,
	loan_type varchar(6) NOT NULL,
	name varchar(70),
	begin_balance decimal(15,2),
	total_balance decimal(15,2),
	total_interest decimal(15,2),
	last_access_date timestamp,
	remark varchar(200),
	close_status char(1),
	last_user_id varchar(50),
	last_user_date timestamp,
	last_user_branch_id varchar(6)
) ;
ALTER TABLE sc_fund_totalfund ADD PRIMARY KEY (fund_loan_no,loan_type);


