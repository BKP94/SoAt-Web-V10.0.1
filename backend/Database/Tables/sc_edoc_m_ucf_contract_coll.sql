CREATE TABLE sc_edoc_m_ucf_contract_coll (
	loan_coll_doc_type varchar(6) NOT NULL DEFAULT '00',
	loan_coll_doc_desc varchar(50)
) ;
ALTER TABLE sc_edoc_m_ucf_contract_coll ADD PRIMARY KEY (loan_coll_doc_type);


