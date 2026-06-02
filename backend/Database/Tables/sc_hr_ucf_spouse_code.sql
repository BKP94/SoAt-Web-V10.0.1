CREATE TABLE sc_hr_ucf_spouse_code (
	spouse_code char(1) NOT NULL DEFAULT '0',
	spouse_description varchar(50)
) ;
ALTER TABLE sc_hr_ucf_spouse_code ADD PRIMARY KEY (spouse_code);
ALTER TABLE sc_hr_ucf_spouse_code ALTER COLUMN spouse_code SET NOT NULL;


