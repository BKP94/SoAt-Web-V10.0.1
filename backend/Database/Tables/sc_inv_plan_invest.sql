CREATE TABLE sc_inv_plan_invest (
	account_year double precision NOT NULL,
	plan_number double precision NOT NULL,
	seq_no double precision NOT NULL,
	month_no double precision,
	month_desc varchar(100),
	net_amt decimal(15,2),
	estimate_paid decimal(15,2),
	estimate_receive decimal(15,2),
	new_profit decimal(15,2),
	old_profit decimal(15,2),
	sum_profit decimal(15,2)
) ;
ALTER TABLE sc_inv_plan_invest ADD PRIMARY KEY (account_year,plan_number,seq_no);
ALTER TABLE sc_inv_plan_invest ALTER COLUMN account_year SET NOT NULL;
ALTER TABLE sc_inv_plan_invest ALTER COLUMN plan_number SET NOT NULL;
ALTER TABLE sc_inv_plan_invest ALTER COLUMN seq_no SET NOT NULL;


