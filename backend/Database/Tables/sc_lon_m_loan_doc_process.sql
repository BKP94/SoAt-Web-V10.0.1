CREATE TABLE sc_lon_m_loan_doc_process (
	doc_no varchar(15) NOT NULL,
	membership_no varchar(6),
	member_name varchar(100),
	cancel_status char(1) DEFAULT '0',
	entry_id varchar(15),
	entry_date timestamp
) ;
ALTER TABLE sc_lon_m_loan_doc_process ADD PRIMARY KEY (doc_no);
ALTER TABLE sc_lon_m_loan_doc_process ALTER COLUMN doc_no SET NOT NULL;


