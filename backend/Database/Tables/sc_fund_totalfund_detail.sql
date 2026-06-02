CREATE TABLE sc_fund_totalfund_detail (
	fund_loan_no varchar(15) NOT NULL,
	loan_type varchar(6) NOT NULL,
	seq_no double precision NOT NULL,
	operate_date timestamp,
	item_type varchar(3),
	ref_doc_no varchar(30),
	amount decimal(15,2),
	balance decimal(15,2),
	interest decimal(15,2),
	accu_interest decimal(15,2),
	membership_amt double precision,
	user_id varchar(50),
	user_date timestamp,
	workingday timestamp,
	branch_id varchar(6),
	old_accu_int decimal(15,2) DEFAULT 0,
	cancel_status char(1) DEFAULT '0'
) ;
ALTER TABLE sc_fund_totalfund_detail ADD PRIMARY KEY (fund_loan_no,loan_type,seq_no);


