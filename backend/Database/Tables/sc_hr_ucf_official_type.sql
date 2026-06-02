CREATE TABLE sc_hr_ucf_official_type (
	official_type varchar(6) NOT NULL DEFAULT '00',
	official_type_desc varchar(100),
	monthly_amount_stats char(1) DEFAULT '0'
) ;
ALTER TABLE sc_hr_ucf_official_type ADD PRIMARY KEY (official_type);
ALTER TABLE sc_hr_ucf_official_type ALTER COLUMN official_type SET NOT NULL;


