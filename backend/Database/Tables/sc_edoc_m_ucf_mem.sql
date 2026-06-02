CREATE TABLE sc_edoc_m_ucf_mem (
	mem_doc_type varchar(6) NOT NULL DEFAULT '00',
	mem_doc_desc varchar(50)
) ;
ALTER TABLE sc_edoc_m_ucf_mem ADD PRIMARY KEY (mem_doc_type);
ALTER TABLE sc_edoc_m_ucf_mem ALTER COLUMN mem_doc_type SET NOT NULL;


