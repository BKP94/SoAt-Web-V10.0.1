CREATE TABLE sc_inv_plan_estimate (
	account_year double precision NOT NULL,
	plan_number double precision NOT NULL,
	seq_no double precision NOT NULL,
	inv_type varchar(15) NOT NULL,
	paid_desc varchar(100),
	plan_begin double precision,
	approve_amount decimal(15,2),
	int_rate decimal(8,6),
	period_pay decimal(15,2),
	installment double precision,
	term_profit double precision
) ;
ALTER TABLE sc_inv_plan_estimate ADD PRIMARY KEY (account_year,plan_number,seq_no);
ALTER TABLE sc_inv_plan_estimate ALTER COLUMN account_year SET NOT NULL;
ALTER TABLE sc_inv_plan_estimate ALTER COLUMN plan_number SET NOT NULL;
ALTER TABLE sc_inv_plan_estimate ALTER COLUMN seq_no SET NOT NULL;
ALTER TABLE sc_inv_plan_estimate ALTER COLUMN inv_type SET NOT NULL;


