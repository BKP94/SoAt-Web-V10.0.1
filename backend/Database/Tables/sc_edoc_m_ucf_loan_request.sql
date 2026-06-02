CREATE TABLE sc_edoc_m_ucf_loan_request (
	loan_req_doc_type varchar(6) NOT NULL DEFAULT '00',
	loan_req_doc_desc varchar(50)
) ;
ALTER TABLE sc_edoc_m_ucf_loan_request ADD PRIMARY KEY (loan_req_doc_type);
ALTER TABLE sc_edoc_m_ucf_loan_request ALTER COLUMN loan_req_doc_type SET NOT NULL;


