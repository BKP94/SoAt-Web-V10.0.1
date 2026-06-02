CREATE TABLE sc_edoc_m_ucf_chg_payment (
	chg_pay_doc_type varchar(6) NOT NULL DEFAULT '00',
	chg_pay_doc_desc varchar(50)
) ;
ALTER TABLE sc_edoc_m_ucf_chg_payment ADD PRIMARY KEY (chg_pay_doc_type);
ALTER TABLE sc_edoc_m_ucf_chg_payment ALTER COLUMN chg_pay_doc_type SET NOT NULL;


