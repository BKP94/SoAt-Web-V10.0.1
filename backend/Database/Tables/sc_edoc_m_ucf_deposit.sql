CREATE TABLE sc_edoc_m_ucf_deposit (
	dep_doc_type varchar(6) NOT NULL DEFAULT '00',
	dep_doc_desc varchar(50)
) ;
ALTER TABLE sc_edoc_m_ucf_deposit ADD PRIMARY KEY (dep_doc_type);
ALTER TABLE sc_edoc_m_ucf_deposit ALTER COLUMN dep_doc_type SET NOT NULL;


