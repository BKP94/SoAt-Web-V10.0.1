CREATE TABLE sc_hr_ucf_group_fr (
	group_fr_code varchar(15) NOT NULL,
	group_fr_name varchar(250),
	group_fr_full_name varchar(250),
	group_fr_sup varchar(250)
) ;
ALTER TABLE sc_hr_ucf_group_fr ADD PRIMARY KEY (group_fr_code);
ALTER TABLE sc_hr_ucf_group_fr ALTER COLUMN group_fr_code SET NOT NULL;


