CREATE TABLE sc_hr_ucf_allowance_type (
	allowance_type varchar(6) NOT NULL DEFAULT '00',
	allowance_desc varchar(100)
) ;
ALTER TABLE sc_hr_ucf_allowance_type ADD PRIMARY KEY (allowance_type);
ALTER TABLE sc_hr_ucf_allowance_type ALTER COLUMN allowance_type SET NOT NULL;


