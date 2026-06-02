CREATE TABLE sc_amnat_insure_rep (
	balance_date timestamp NOT NULL,
	membership_no varchar(15) NOT NULL,
	member_group_no varchar(15),
	mem_type varchar(6),
	member_status_code char(1) DEFAULT '0',
	share_balance decimal(15,2) DEFAULT 0.00,
	loan_balance decimal(15,2) DEFAULT 0.00,
	loan_coll_balance decimal(15,2) DEFAULT 0.00,
	coop_paid_mem integer DEFAULT 0,
	coop_paid_krom integer DEFAULT 0,
	coop_paid_amount decimal(15,2) DEFAULT 0.00,
	div_paid_mem integer DEFAULT 0,
	div_paid_krom integer DEFAULT 0,
	div_paid_amount decimal(15,2) DEFAULT 0.00,
	cash_paid_mem integer DEFAULT 0,
	cash_paid_krom integer DEFAULT 0,
	cash_paid_amount decimal(15,2) DEFAULT 0,
	insure_paid_mem integer DEFAULT 0,
	insure_paid_krom integer DEFAULT 0,
	insure_paid_amount decimal(15,2) DEFAULT 0.00,
	insure_status char(1) DEFAULT '0',
	insure_remark varchar(100) DEFAULT ' ',
	insure_add decimal(15,2) DEFAULT 0.00,
	insure_year integer DEFAULT 0
) ;
ALTER TABLE sc_amnat_insure_rep ADD PRIMARY KEY (balance_date,membership_no);


