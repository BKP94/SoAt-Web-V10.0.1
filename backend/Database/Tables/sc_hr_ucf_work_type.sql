CREATE TABLE sc_hr_ucf_work_type (
	work_type char(2) NOT NULL DEFAULT '00',
	work_desc varchar(100)
) ;
ALTER TABLE sc_hr_ucf_work_type ADD PRIMARY KEY (work_type);
ALTER TABLE sc_hr_ucf_work_type ALTER COLUMN work_type SET NOT NULL;


