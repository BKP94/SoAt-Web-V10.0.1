CREATE TABLE sc_sch_class_graduate (
	scholarship_type varchar(6) NOT NULL,
	child_class_code varchar(6) NOT NULL,
	scholarship_number decimal(15,2),
	total_graduate_amt decimal(15,2),
	scholarship_int decimal(15,2)
) ;
ALTER TABLE sc_sch_class_graduate ADD PRIMARY KEY (scholarship_type,child_class_code);


