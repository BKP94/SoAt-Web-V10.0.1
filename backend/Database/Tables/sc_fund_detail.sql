CREATE TABLE sc_fund_detail (
	fund_loan_no varchar(15) NOT NULL,
	loan_type varchar(6) NOT NULL,
	seq_no integer NOT NULL,
	operate_date timestamp,
	item_type varchar(3),
	ref_doc_no varchar(30),
	amount decimal(15,2),
	balance decimal(15,2),
	interest decimal(15,2),
	accu_interest decimal(15,2),
	membership_amt bigint,
	user_id varchar(10),
	user_date timestamp,
	workingday timestamp,
	branch_id varchar(6),
	status char(1) DEFAULT '0',
	ref_seq_no integer DEFAULT 0,
	remark varchar(250)
) ;
ALTER TABLE sc_fund_detail ADD PRIMARY KEY (fund_loan_no,loan_type,seq_no);


