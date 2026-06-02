CREATE TABLE sc_mem_m_app_picture (
	application_form_no varchar(15) NOT NULL,
	app_picture bytea
) ;
ALTER TABLE sc_mem_m_app_picture ADD PRIMARY KEY (application_form_no);


