CREATE TABLE sc_inv_plan_sheet (
	plan_seq double precision NOT NULL,
	plan_desc varchar(250),
	plan_default decimal(15,2) DEFAULT 0.00,
	plan_point varchar(10) DEFAULT '%',
	plan_data varchar(15)
) ;
ALTER TABLE sc_inv_plan_sheet ADD PRIMARY KEY (plan_seq);
ALTER TABLE sc_inv_plan_sheet ALTER COLUMN plan_seq SET NOT NULL;


