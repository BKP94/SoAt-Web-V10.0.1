CREATE TABLE sc_inv_bill_ins_type (
	instrument_type_id varchar(6) NOT NULL,
	org_id varchar(7),
	instrument_name varchar(50),
	time_period_status char(1),
	time_period_amount integer,
	sale_price decimal(15,2),
	instrument_age integer,
	objective varchar(30),
	sale_time varchar(30),
	interest_rate decimal(10,4),
	tax decimal(15,2),
	instrument_group char(1),
	return_fund char(1),
	redeposit_fund char(1),
	active_status char(1) DEFAULT '0',
	account_profit varchar(8),
	account_loss varchar(8)
) ;
ALTER TABLE sc_inv_bill_ins_type ADD PRIMARY KEY (instrument_type_id);
ALTER TABLE sc_inv_bill_ins_type ALTER COLUMN instrument_type_id SET NOT NULL;


