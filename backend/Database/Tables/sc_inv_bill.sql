CREATE TABLE sc_inv_bill (
	bill_no varchar(15) NOT NULL,
	instrument_type_id varchar(6),
	bill_date timestamp,
	due_date timestamp,
	due_date_status char(1),
	next_due_date timestamp,
	interest decimal(15,2),
	pay_amount decimal(15,2),
	bill_money decimal(15,2),
	discount_amount decimal(15,2),
	tax decimal(15,2),
	remarsk varchar(200),
	pay_endores varchar(100),
	endores_date timestamp,
	endores_status char(1),
	guarantee_status char(1),
	pay_date timestamp,
	with_status char(1),
	entry_date timestamp NOT NULL,
	entry_id varchar(16) NOT NULL,
	branch_id varchar(6) NOT NULL,
	client_id varchar(20) NOT NULL,
	cancel_status char(1) NOT NULL,
	bill_no_rec varchar(50) NOT NULL,
	bill_period integer,
	rec_int varchar(50),
	rec_status char(1),
	rec_bank_code varchar(6),
	rec_account_no varchar(15),
	rec_account_type char(1),
	agent_bank varchar(6),
	term_recieveint integer,
	bill_period_unit char(1),
	bill_name varchar(200),
	method_int_status char(1),
	method_int_cal char(1),
	term_recieveint_unit char(1),
	last_cal_int_date timestamp NOT NULL,
	last_operate_date timestamp NOT NULL,
	dep_times integer NOT NULL,
	bill_money_arrear decimal(15,2) NOT NULL,
	rec_bank_branch varchar(6),
	bill_type char(1) NOT NULL,
	interest_paid_fw decimal(15,2),
	selling_ytm decimal(15,8),
	ref_bill_no varchar(15),
	bill_money_priceperunit decimal(15,6),
	bill_money_totalunit decimal(15,2),
	days_in_year integer,
	bill_nicname varchar(50),
	fin_bank varchar(6),
	approve_status char(1) NOT NULL,
	approve_id varchar(16),
	approve_date timestamp,
	approve_branch varchar(6),
	paid_status char(1),
	approve_remark varchar(200),
	account_bill varchar(8),
	account_fee varchar(8),
	account_int varchar(8),
	account_tax varchar(8),
	account_profit varchar(8),
	account_draft varchar(8),
	account_cheque varchar(8),
	account_profit_loss varchar(8),
	rate varchar(50),
	last_calcint_date timestamp,
	interest_arrear decimal(15,2),
	arrear_date timestamp,
	membership_no varchar(15) DEFAULT '000000',
	account_int_arrear varchar(8),
	total_loan_int decimal(15,2) DEFAULT 0.00,
	year_int_forward decimal(15,2) DEFAULT 0.00,
	year_int_arr decimal(15,2) DEFAULT 0.00,
	year_int_net decimal(15,2) DEFAULT 0.00
) ;
ALTER TABLE sc_inv_bill ADD PRIMARY KEY (bill_no);
ALTER TABLE sc_inv_bill ALTER COLUMN bill_no SET NOT NULL;
ALTER TABLE sc_inv_bill ALTER COLUMN entry_date SET NOT NULL;
ALTER TABLE sc_inv_bill ALTER COLUMN entry_id SET NOT NULL;
ALTER TABLE sc_inv_bill ALTER COLUMN branch_id SET NOT NULL;
ALTER TABLE sc_inv_bill ALTER COLUMN client_id SET NOT NULL;
ALTER TABLE sc_inv_bill ALTER COLUMN cancel_status SET NOT NULL;
ALTER TABLE sc_inv_bill ALTER COLUMN bill_no_rec SET NOT NULL;
ALTER TABLE sc_inv_bill ALTER COLUMN last_cal_int_date SET NOT NULL;
ALTER TABLE sc_inv_bill ALTER COLUMN last_operate_date SET NOT NULL;
ALTER TABLE sc_inv_bill ALTER COLUMN dep_times SET NOT NULL;
ALTER TABLE sc_inv_bill ALTER COLUMN bill_money_arrear SET NOT NULL;
ALTER TABLE sc_inv_bill ALTER COLUMN bill_type SET NOT NULL;
ALTER TABLE sc_inv_bill ALTER COLUMN approve_status SET NOT NULL;


