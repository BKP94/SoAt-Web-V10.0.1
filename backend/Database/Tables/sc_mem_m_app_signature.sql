CREATE TABLE sc_mem_m_app_signature (
	application_form_no varchar(15) NOT NULL,
	app_signature bytea
) ;
ALTER TABLE sc_mem_m_app_signature ADD PRIMARY KEY (application_form_no);


