CREATE TABLE sc_inv_plan_inv (
	account_year double precision NOT NULL,
	plan_number double precision NOT NULL,
	seq_no double precision NOT NULL,
	real_status char(1) NOT NULL DEFAULT '0',
	real_desc varchar(50),
	month_no double precision,
	month_desc varchar(100),
	bond_prin decimal(15,2),
	bond_int decimal(15,2),
	bond_profit decimal(15,2),
	debt_prin decimal(15,2),
	debt_int decimal(15,2),
	debt_profit decimal(15,2),
	depout_prin decimal(15,2),
	depout_int decimal(15,2),
	shr_div decimal(15,2),
	shr_aver decimal(15,2),
	loanout_prin decimal(15,2),
	loanout_int decimal(15,2),
	common_prin decimal(15,2),
	common_int decimal(15,2),
	common_profit decimal(15,2),
	fund_prin decimal(15,2),
	fund_int decimal(15,2),
	fund_profit decimal(15,2),
	bank_int decimal(15,2),
	pn_prin decimal(15,2),
	pn_int decimal(15,2),
	depin_prin decimal(15,2),
	depin_int decimal(15,2),
	loanin_prin decimal(15,2),
	loanin_int decimal(15,2),
	expense decimal(15,2),
	net_profit decimal(15,2)
) ;
ALTER TABLE sc_inv_plan_inv ADD PRIMARY KEY (account_year,plan_number,seq_no,real_status);
ALTER TABLE sc_inv_plan_inv ALTER COLUMN account_year SET NOT NULL;
ALTER TABLE sc_inv_plan_inv ALTER COLUMN plan_number SET NOT NULL;
ALTER TABLE sc_inv_plan_inv ALTER COLUMN seq_no SET NOT NULL;
ALTER TABLE sc_inv_plan_inv ALTER COLUMN real_status SET NOT NULL;


