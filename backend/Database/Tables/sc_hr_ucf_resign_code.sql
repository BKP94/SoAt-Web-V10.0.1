CREATE TABLE sc_hr_ucf_resign_code (
	resign_code varchar(6) NOT NULL DEFAULT '00',
	resign_desc varchar(100)
) ;
ALTER TABLE sc_hr_ucf_resign_code ADD PRIMARY KEY (resign_code);
ALTER TABLE sc_hr_ucf_resign_code ALTER COLUMN resign_code SET NOT NULL;


