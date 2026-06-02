CREATE TABLE sc_inv_ucf_plan_data (
	plan_data varchar(15) NOT NULL,
	plan_desc varchar(100),
	soat_note varchar(100)
) ;
ALTER TABLE sc_inv_ucf_plan_data ADD PRIMARY KEY (plan_data);
ALTER TABLE sc_inv_ucf_plan_data ALTER COLUMN plan_data SET NOT NULL;


