CREATE TABLE sc_lon_m_loan_doc_process_det (
	doc_no varchar(20) NOT NULL,
	seq_no double precision NOT NULL,
	operate_date timestamp,
	remark varchar(250),
	process_id char(2),
	entry_id varchar(15),
	entry_date timestamp
) ;
ALTER TABLE sc_lon_m_loan_doc_process_det ADD PRIMARY KEY (doc_no,seq_no);
ALTER TABLE sc_lon_m_loan_doc_process_det ALTER COLUMN doc_no SET NOT NULL;
ALTER TABLE sc_lon_m_loan_doc_process_det ALTER COLUMN seq_no SET NOT NULL;


