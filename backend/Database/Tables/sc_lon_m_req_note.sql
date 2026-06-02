CREATE TABLE sc_lon_m_req_note (
	loan_requestment_no varchar(15) NOT NULL DEFAULT 'cnv',
	seq_no double precision NOT NULL,
	entry_id varchar(16) NOT NULL,
	entry_date timestamp NOT NULL,
	note varchar(200),
	status char(1) DEFAULT '0'
) ;
ALTER TABLE sc_lon_m_req_note ADD PRIMARY KEY (loan_requestment_no,seq_no);
ALTER TABLE sc_lon_m_req_note ALTER COLUMN loan_requestment_no SET NOT NULL;
ALTER TABLE sc_lon_m_req_note ALTER COLUMN seq_no SET NOT NULL;
ALTER TABLE sc_lon_m_req_note ALTER COLUMN entry_id SET NOT NULL;
ALTER TABLE sc_lon_m_req_note ALTER COLUMN entry_date SET NOT NULL;


