CREATE TABLE sc_lon_m_ucf_req_other_loan (
	other_loan_type varchar(6) NOT NULL,
	loan_desc varchar(50),
	doc_note varchar(2000),
	sort_order double precision
) ;
ALTER TABLE sc_lon_m_ucf_req_other_loan ADD PRIMARY KEY (other_loan_type);
ALTER TABLE sc_lon_m_ucf_req_other_loan ALTER COLUMN other_loan_type SET NOT NULL;


