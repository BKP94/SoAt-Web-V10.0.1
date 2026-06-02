CREATE TABLE sc_hr_ucf_doc_head_code_short (
	doc_head_code_short_code varchar(6) NOT NULL,
	doc_head_code_short_desc varchar(250)
) ;
ALTER TABLE sc_hr_ucf_doc_head_code_short ADD PRIMARY KEY (doc_head_code_short_code);
ALTER TABLE sc_hr_ucf_doc_head_code_short ALTER COLUMN doc_head_code_short_code SET NOT NULL;


