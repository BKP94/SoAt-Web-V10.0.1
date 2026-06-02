CREATE TABLE sc_crm_application_form (
	application_form_no varchar(15) NOT NULL DEFAULT '<NEW>',
	reference_memno varchar(15),
	parent_code varchar(6) DEFAULT '00'
) ;
ALTER TABLE sc_crm_application_form ADD PRIMARY KEY (application_form_no);


