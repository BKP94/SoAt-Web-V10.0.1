CREATE TABLE sc_inv_plan_dep (
	account_year double precision NOT NULL,
	plan_number double precision NOT NULL,
	seq_no double precision NOT NULL,
	month_no double precision,
	month_desc varchar(100),
	newdep decimal(15,2),
	olddep decimal(15,2),
	duedep decimal(15,2),
	balance decimal(15,2),
	int_rate decimal(8,6),
	int_old decimal(15,2),
	int_new decimal(15,2),
	int_all decimal(15,2)
) ;
ALTER TABLE sc_inv_plan_dep ADD PRIMARY KEY (account_year,plan_number,seq_no);
ALTER TABLE sc_inv_plan_dep ALTER COLUMN account_year SET NOT NULL;
ALTER TABLE sc_inv_plan_dep ALTER COLUMN plan_number SET NOT NULL;
ALTER TABLE sc_inv_plan_dep ALTER COLUMN seq_no SET NOT NULL;


