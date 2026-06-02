CREATE TABLE sc_fund_mem (
	membership_no varchar(15) NOT NULL,
	loan_contract_no varchar(15) NOT NULL,
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
	last_user_id varchar(50),
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
	fund_res_status char(1),
	return_date timestamp,
	fund_loan_no varchar(6),
	loan_32 char(1) DEFAULT '0',
	to_sybase char(1) DEFAULT '0'
) ;
CREATE INDEX idx_fund_mem_conno ON sc_fund_mem (loan_contract_no);
CREATE INDEX idx_loan_type ON sc_fund_mem (loan_type);
CREATE INDEX idx_memno ON sc_fund_mem (membership_no);
CREATE INDEX idx_total_balance ON sc_fund_mem (total_balance);
ALTER TABLE sc_fund_mem ADD PRIMARY KEY (membership_no,loan_contract_no);


