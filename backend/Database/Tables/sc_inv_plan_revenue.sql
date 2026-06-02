CREATE TABLE sc_inv_plan_revenue (
	account_year double precision NOT NULL,
	plan_number double precision NOT NULL,
	seq_no double precision NOT NULL,
	month_no double precision,
	month_desc varchar(100),
	share_amt decimal(15,2),
	loan_amt decimal(15,2),
	dep_amt decimal(15,2),
	int_amt decimal(15,2),
	invest_in decimal(15,2),
	newloan_amt decimal(15,2),
	int_dep decimal(15,2),
	dep_due decimal(15,2),
	invest_out decimal(15,2),
	net_amt decimal(15,2),
	net_accu decimal(15,2) DEFAULT 0.00
) ;
ALTER TABLE sc_inv_plan_revenue ADD PRIMARY KEY (account_year,plan_number,seq_no);
ALTER TABLE sc_inv_plan_revenue ALTER COLUMN account_year SET NOT NULL;
ALTER TABLE sc_inv_plan_revenue ALTER COLUMN plan_number SET NOT NULL;
ALTER TABLE sc_inv_plan_revenue ALTER COLUMN seq_no SET NOT NULL;


