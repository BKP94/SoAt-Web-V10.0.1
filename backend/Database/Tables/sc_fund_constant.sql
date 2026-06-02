CREATE TABLE sc_fund_constant (
	coop_req_no varchar(15) NOT NULL,
	working_date timestamp,
	last_close_day timestamp,
	int_or_principal_status char(1),
	day_in_year double precision,
	round_method decimal(10,4),
	round_method_type char(1),
	int_round_method decimal(15,4) DEFAULT 0,
	int_round_method_type char(1) DEFAULT '0',
	account_co varchar(8),
	account_int varchar(8)
) ;
ALTER TABLE sc_fund_constant ADD PRIMARY KEY (coop_req_no);


