CREATE TABLE sc_hr_ucf_official_position (
	official_position varchar(6) NOT NULL,
	official_desc varchar(100),
	money_rank decimal(15,2) DEFAULT 0,
	c_level integer,
	position_eng varchar(200)
) ;
ALTER TABLE sc_hr_ucf_official_position ADD PRIMARY KEY (official_position);
ALTER TABLE sc_hr_ucf_official_position ALTER COLUMN official_position SET NOT NULL;


