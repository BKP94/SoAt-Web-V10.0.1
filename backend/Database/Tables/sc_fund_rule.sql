CREATE TABLE sc_fund_rule (
	loan_type varchar(6) NOT NULL,
	seq_no double precision NOT NULL,
	principal decimal(15,2),
	keep_month decimal(15,2),
	fund_coll_amt decimal(15,2),
	user_id varchar(50),
	user_date timestamp,
	branch_id varchar(6),
	percent_fund decimal(8,6),
	round_method decimal(15,4),
	type_round_method char(1),
	cal_fund_type char(1) DEFAULT '0',
	recal2me char(1) DEFAULT '0',
	fund_group varchar(6) DEFAULT '00',
	account_id_p varchar(8),
	account_id_i varchar(8)
) ;
ALTER TABLE sc_fund_rule ADD PRIMARY KEY (loan_type,seq_no);


