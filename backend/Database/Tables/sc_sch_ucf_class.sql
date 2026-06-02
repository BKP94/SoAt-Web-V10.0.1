CREATE TABLE sc_sch_ucf_class (
	child_class_code varchar(6) NOT NULL,
	graduate_type varchar(6),
	description varchar(50)
) ;
ALTER TABLE sc_sch_ucf_class ADD PRIMARY KEY (child_class_code);


