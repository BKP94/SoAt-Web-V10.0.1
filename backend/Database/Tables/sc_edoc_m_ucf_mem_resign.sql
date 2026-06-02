CREATE TABLE sc_edoc_m_ucf_mem_resign (
	resign_doc_type varchar(6) NOT NULL DEFAULT '00',
	resign_doc_desc varchar(50)
) ;
ALTER TABLE sc_edoc_m_ucf_mem_resign ADD PRIMARY KEY (resign_doc_type);
ALTER TABLE sc_edoc_m_ucf_mem_resign ALTER COLUMN resign_doc_type SET NOT NULL;


