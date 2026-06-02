CREATE TABLE sc_lon_m_req_doc (
	loan_requestment_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	doc_code varchar(6) NOT NULL,
	remark varchar(50),
	status char(1) DEFAULT '0',
	doc_date timestamp,
	doc_year varchar(6),
	child_id varchar(15),
	child_name varchar(100)
) ;
ALTER TABLE sc_lon_m_req_doc ADD PRIMARY KEY (loan_requestment_no,seq_no);
ALTER TABLE sc_lon_m_req_doc ALTER COLUMN loan_requestment_no SET NOT NULL;
ALTER TABLE sc_lon_m_req_doc ALTER COLUMN seq_no SET NOT NULL;
ALTER TABLE sc_lon_m_req_doc ALTER COLUMN doc_code SET NOT NULL;


