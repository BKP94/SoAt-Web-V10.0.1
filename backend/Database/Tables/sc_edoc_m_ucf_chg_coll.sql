CREATE TABLE sc_edoc_m_ucf_chg_coll (
	chg_coll_doc_type varchar(6) NOT NULL DEFAULT '00',
	chg_coll_doc_desc varchar(50)
) ;
ALTER TABLE sc_edoc_m_ucf_chg_coll ADD PRIMARY KEY (chg_coll_doc_type);
ALTER TABLE sc_edoc_m_ucf_chg_coll ALTER COLUMN chg_coll_doc_type SET NOT NULL;


