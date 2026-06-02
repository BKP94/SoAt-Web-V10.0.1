CREATE TABLE sc_hr_lup_province (
	c_province_code varchar(6) NOT NULL,
	c_province varchar(30)
) ;
ALTER TABLE sc_hr_lup_province ADD PRIMARY KEY (c_province_code);
ALTER TABLE sc_hr_lup_province ALTER COLUMN c_province_code SET NOT NULL;


