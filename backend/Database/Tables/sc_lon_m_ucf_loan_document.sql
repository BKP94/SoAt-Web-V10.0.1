CREATE TABLE sc_lon_m_ucf_loan_document (
	loan_type varchar(6) NOT NULL,
	document_code varchar(6) NOT NULL,
	description varchar(30)
) ;
ALTER TABLE sc_lon_m_ucf_loan_document ADD PRIMARY KEY (loan_type,document_code);
ALTER TABLE sc_lon_m_ucf_loan_document ALTER COLUMN loan_type SET NOT NULL;
ALTER TABLE sc_lon_m_ucf_loan_document ALTER COLUMN document_code SET NOT NULL;


