CREATE TABLE sc_sch_guarantor (
	application_form_no varchar(15) NOT NULL,
	guarantor_date timestamp,
	guar_prename_code varchar(3),
	guarantor_name varchar(50),
	guarantor_surname varchar(50),
	position_code varchar(6)
) ;
ALTER TABLE sc_sch_guarantor ADD PRIMARY KEY (application_form_no);


