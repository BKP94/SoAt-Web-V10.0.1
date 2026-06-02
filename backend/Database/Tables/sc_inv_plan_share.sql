CREATE TABLE sc_inv_plan_share (
	account_year double precision NOT NULL,
	plan_number double precision NOT NULL,
	seq_no double precision NOT NULL,
	month_no double precision,
	month_desc varchar(100),
	newshare decimal(15,2),
	oldshare decimal(15,2),
	balance decimal(15,2),
	div_old decimal(15,2),
	div_new1 decimal(15,2),
	div_new2 decimal(15,2)
) ;
ALTER TABLE sc_inv_plan_share ADD PRIMARY KEY (account_year,plan_number,seq_no);
ALTER TABLE sc_inv_plan_share ALTER COLUMN account_year SET NOT NULL;
ALTER TABLE sc_inv_plan_share ALTER COLUMN plan_number SET NOT NULL;
ALTER TABLE sc_inv_plan_share ALTER COLUMN seq_no SET NOT NULL;


