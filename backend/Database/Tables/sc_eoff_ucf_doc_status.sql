CREATE TABLE sc_eoff_ucf_doc_status (
	doc_status varchar(6) NOT NULL DEFAULT '0',
	doc_status_desc varchar(100)
) ;
ALTER TABLE sc_eoff_ucf_doc_status ADD PRIMARY KEY (doc_status);
ALTER TABLE sc_eoff_ucf_doc_status ALTER COLUMN doc_status SET NOT NULL;


