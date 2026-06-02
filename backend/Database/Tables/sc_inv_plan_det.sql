CREATE TABLE sc_inv_plan_det (
	account_year double precision NOT NULL,
	plan_number double precision NOT NULL,
	plan_seq double precision NOT NULL,
	plan_default decimal(15,2) DEFAULT 0.00,
	plan_target decimal(15,2) DEFAULT 0.00,
	plan_begin double precision DEFAULT 0
) ;
ALTER TABLE sc_inv_plan_det ADD PRIMARY KEY (account_year,plan_number,plan_seq);
ALTER TABLE sc_inv_plan_det ALTER COLUMN account_year SET NOT NULL;
ALTER TABLE sc_inv_plan_det ALTER COLUMN plan_number SET NOT NULL;
ALTER TABLE sc_inv_plan_det ALTER COLUMN plan_seq SET NOT NULL;


