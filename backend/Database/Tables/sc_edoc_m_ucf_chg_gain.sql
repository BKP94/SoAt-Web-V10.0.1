CREATE TABLE sc_edoc_m_ucf_chg_gain (
	chg_gain_doc_type varchar(6) NOT NULL DEFAULT '00',
	chg_gain_doc_desc varchar(50)
) ;
ALTER TABLE sc_edoc_m_ucf_chg_gain ADD PRIMARY KEY (chg_gain_doc_type);
ALTER TABLE sc_edoc_m_ucf_chg_gain ALTER COLUMN chg_gain_doc_type SET NOT NULL;


