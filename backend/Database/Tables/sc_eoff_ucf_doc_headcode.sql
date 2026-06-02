CREATE TABLE sc_eoff_ucf_doc_headcode (
	doc_headcode varchar(6) NOT NULL,
	doc_desc varchar(100),
	status_in char(1) DEFAULT '0',
	status_out char(1) DEFAULT '0',
	doc_status varchar(8),
	doc_form varchar(50)
) ;
ALTER TABLE sc_eoff_ucf_doc_headcode ADD PRIMARY KEY (doc_headcode);
ALTER TABLE sc_eoff_ucf_doc_headcode ALTER COLUMN doc_headcode SET NOT NULL;


