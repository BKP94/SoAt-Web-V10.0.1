CREATE TABLE sc_inv_plan_loan (
	account_year double precision NOT NULL,
	plan_number double precision NOT NULL,
	seq_no double precision NOT NULL,
	month_no double precision,
	month_desc varchar(100),
	newloan decimal(15,2),
	payment decimal(15,2),
	balance decimal(15,2),
	int_rate decimal(8,6),
	int_old decimal(15,2),
	int_new decimal(15,2),
	int_all decimal(15,2)
) ;
ALTER TABLE sc_inv_plan_loan ADD PRIMARY KEY (account_year,plan_number,seq_no);
ALTER TABLE sc_inv_plan_loan ALTER COLUMN account_year SET NOT NULL;
ALTER TABLE sc_inv_plan_loan ALTER COLUMN plan_number SET NOT NULL;
ALTER TABLE sc_inv_plan_loan ALTER COLUMN seq_no SET NOT NULL;


