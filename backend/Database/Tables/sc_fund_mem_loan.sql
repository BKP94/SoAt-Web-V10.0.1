CREATE TABLE sc_fund_mem_loan (
	membership_no varchar(15) NOT NULL,
	loan_type varchar(6) NOT NULL,
	loan_contract_no varchar(15),
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
	last_user_id varchar(10),
	last_user_date timestamp,
	last_user_branch_id varchar(6),
	pending_amt decimal(15,2),
	last_period double precision,
	last_cal_int_date timestamp,
	balance_cal_int decimal(15,2)
) ;
CREATE INDEX idx_fund_loan001 ON sc_fund_mem_loan (membership_no);
CREATE INDEX idx_fund_loan002 ON sc_fund_mem_loan (loan_contract_no);
ALTER TABLE sc_fund_mem_loan ADD PRIMARY KEY (membership_no,loan_type);


