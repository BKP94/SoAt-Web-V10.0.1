CREATE TABLE sc_acc_balance_cashfolw (
	account_id varchar(8) NOT NULL,
	acc_year varchar(5) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	account_name varchar(100),
	acc_begin decimal(15,2) DEFAULT 0,
	acc_between_dr decimal(15,2) DEFAULT 0,
	acc_between_cr decimal(15,2) DEFAULT 0,
	acc_amount decimal(15,2) DEFAULT 0,
	acc_nature varchar(10),
	cash_flow_status char(1) DEFAULT '0',
	dr_num bigint DEFAULT 0,
	cr_num bigint DEFAULT 0,
	sec_cashfolw smallint DEFAULT 0,
	sec_status smallint DEFAULT 0,
	od_account char(1) DEFAULT '0'
) ;
ALTER TABLE sc_acc_balance_cashfolw ADD PRIMARY KEY (account_id,acc_year,seq_no);
ALTER TABLE sc_acc_balance_cashfolw ALTER COLUMN account_id SET NOT NULL;
ALTER TABLE sc_acc_balance_cashfolw ALTER COLUMN acc_year SET NOT NULL;
ALTER TABLE sc_acc_balance_cashfolw ALTER COLUMN seq_no SET NOT NULL;


