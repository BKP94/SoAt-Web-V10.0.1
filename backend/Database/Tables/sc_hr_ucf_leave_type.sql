CREATE TABLE sc_hr_ucf_leave_type (
	leave_type varchar(6) NOT NULL DEFAULT '00',
	leave_desc varchar(50),
	leave_maxday double precision DEFAULT 0,
	form_leave varchar(50)
) ;
ALTER TABLE sc_hr_ucf_leave_type ADD PRIMARY KEY (leave_type);
ALTER TABLE sc_hr_ucf_leave_type ALTER COLUMN leave_type SET NOT NULL;


