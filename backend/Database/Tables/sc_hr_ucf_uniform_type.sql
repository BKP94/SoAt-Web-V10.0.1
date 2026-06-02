CREATE TABLE sc_hr_ucf_uniform_type (
	uniform_type varchar(6) NOT NULL DEFAULT '00',
	uniform_desc varchar(100)
) ;
ALTER TABLE sc_hr_ucf_uniform_type ADD PRIMARY KEY (uniform_type);
ALTER TABLE sc_hr_ucf_uniform_type ALTER COLUMN uniform_type SET NOT NULL;


