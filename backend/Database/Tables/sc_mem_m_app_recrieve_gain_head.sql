CREATE TABLE sc_mem_m_app_recrieve_gain_head (
	application_form_no varchar(15) NOT NULL DEFAULT null,
	condition_1 varchar(4000),
	condition_2 varchar(4000),
	condition_3 varchar(4000)
) ;
ALTER TABLE sc_mem_m_app_recrieve_gain_head ADD PRIMARY KEY (application_form_no);
ALTER TABLE sc_mem_m_app_recrieve_gain_head ALTER COLUMN application_form_no SET NOT NULL;


