CREATE TABLE sc_sch_history_child (
	application_form_no varchar(15) NOT NULL,
	seq_no decimal(15,2) NOT NULL,
	child_prename_code varchar(3),
	child_name varchar(50),
	child_surname varchar(50),
	child_class_code varchar(6),
	child_school varchar(100),
	child_status char(1),
	child_age decimal(15,2)
) ;
ALTER TABLE sc_sch_history_child ADD PRIMARY KEY (application_form_no,seq_no);


