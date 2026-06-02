CREATE TABLE sc_inv_bill_close_month (
	monthly_date timestamp NOT NULL,
	bill_no varchar(15) NOT NULL,
	instrument_type_id varchar(6),
	membership_no varchar(15) DEFAULT '000000',
	bill_date timestamp,
	due_date timestamp,
	due_date_status char(1),
	pay_amount decimal(15,2),
	bill_money decimal(15,2),
	remarsk varchar(200),
	pay_endores varchar(100),
	endores_date timestamp,
	endores_status char(1),
	guarantee_status char(1),
	pay_date timestamp,
	with_status char(1),
	cancel_status char(1) NOT NULL,
	bill_no_rec varchar(50) NOT NULL,
	bill_period integer,
	term_recieveint integer,
	bill_period_unit char(1),
	bill_name varchar(200),
	method_int_status char(1),
	method_int_cal char(1),
	term_recieveint_unit char(1),
	dep_times integer NOT NULL,
	bill_money_priceperunit decimal(15,6),
	bill_money_totalunit decimal(15,2),
	days_in_year integer,
	bill_nicname varchar(50),
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
	account_profit_loss varchar(8),
	rate varchar(50),
	account_int_arrear varchar(8),
	interest_arrear decimal(15,2),
	arrear_date timestamp,
	total_loan_int decimal(15,2) DEFAULT 0.00,
	year_int_forward decimal(15,2) DEFAULT 0.00,
	year_int_net decimal(15,2) DEFAULT 0.00,
	last_calcint_date timestamp,
	month_int_arr decimal(15,2) DEFAULT 0.00,
	year_int_arr decimal(15,2) DEFAULT 0.00
) ;
ALTER TABLE sc_inv_bill_close_month ADD PRIMARY KEY (monthly_date,bill_no);
ALTER TABLE sc_inv_bill_close_month ALTER COLUMN monthly_date SET NOT NULL;
ALTER TABLE sc_inv_bill_close_month ALTER COLUMN bill_no SET NOT NULL;
ALTER TABLE sc_inv_bill_close_month ALTER COLUMN cancel_status SET NOT NULL;
ALTER TABLE sc_inv_bill_close_month ALTER COLUMN bill_no_rec SET NOT NULL;
ALTER TABLE sc_inv_bill_close_month ALTER COLUMN dep_times SET NOT NULL;
ALTER TABLE sc_inv_bill_close_month ALTER COLUMN approve_status SET NOT NULL;


