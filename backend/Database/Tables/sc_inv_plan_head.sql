CREATE TABLE sc_inv_plan_head (
	account_year double precision NOT NULL,
	plan_number double precision NOT NULL,
	plan_detail varchar(100)
) ;
ALTER TABLE sc_inv_plan_head ADD PRIMARY KEY (account_year,plan_number);
ALTER TABLE sc_inv_plan_head ALTER COLUMN account_year SET NOT NULL;
ALTER TABLE sc_inv_plan_head ALTER COLUMN plan_number SET NOT NULL;


