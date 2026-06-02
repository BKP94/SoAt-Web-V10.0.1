CREATE TABLE sc_inv_plan_estimate_det (
	account_year double precision NOT NULL,
	plan_number double precision NOT NULL,
	seq_no double precision NOT NULL,
	seq_det double precision NOT NULL,
	operate_date timestamp,
	paid_amount decimal(15,2),
	prin_amount decimal(15,2),
	int_amount decimal(15,2),
	net_amt decimal(15,2)
) ;
ALTER TABLE sc_inv_plan_estimate_det ADD PRIMARY KEY (account_year,plan_number,seq_no,seq_det);
ALTER TABLE sc_inv_plan_estimate_det ALTER COLUMN account_year SET NOT NULL;
ALTER TABLE sc_inv_plan_estimate_det ALTER COLUMN plan_number SET NOT NULL;
ALTER TABLE sc_inv_plan_estimate_det ALTER COLUMN seq_no SET NOT NULL;
ALTER TABLE sc_inv_plan_estimate_det ALTER COLUMN seq_det SET NOT NULL;


