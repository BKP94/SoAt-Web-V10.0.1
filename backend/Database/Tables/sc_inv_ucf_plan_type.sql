CREATE TABLE sc_inv_ucf_plan_type (
	inv_type varchar(15) NOT NULL,
	inv_desc varchar(50),
	paid_status double precision,
	active_status char(1) DEFAULT '0',
	fix_status char(1) DEFAULT '0',
	soat_note varchar(100)
) ;
ALTER TABLE sc_inv_ucf_plan_type ADD PRIMARY KEY (inv_type);
ALTER TABLE sc_inv_ucf_plan_type ALTER COLUMN inv_type SET NOT NULL;


