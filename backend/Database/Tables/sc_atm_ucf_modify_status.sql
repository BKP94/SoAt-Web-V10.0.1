CREATE TABLE sc_atm_ucf_modify_status (
	modify_status char(1) NOT NULL DEFAULT '0',
	modify_desc varchar(50),
	soat_desc varchar(100),
	active_status char(1) DEFAULT '0',
	sort_order integer
) ;
ALTER TABLE sc_atm_ucf_modify_status ADD PRIMARY KEY (modify_status);
ALTER TABLE sc_atm_ucf_modify_status ALTER COLUMN modify_status SET NOT NULL;


