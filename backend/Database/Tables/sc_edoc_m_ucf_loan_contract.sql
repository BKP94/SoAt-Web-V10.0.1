CREATE TABLE sc_edoc_m_ucf_loan_contract (
	loan_con_doc_type varchar(6) NOT NULL DEFAULT '00',
	loan_con_doc_desc varchar(50)
) ;
ALTER TABLE sc_edoc_m_ucf_loan_contract ADD PRIMARY KEY (loan_con_doc_type);
ALTER TABLE sc_edoc_m_ucf_loan_contract ALTER COLUMN loan_con_doc_type SET NOT NULL;


