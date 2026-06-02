CREATE TABLE sc_lon_m_req_salnet_inc (
	loan_requestment_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	item_amount decimal(15,2) DEFAULT 0,
	item_code varchar(6)
) ;
ALTER TABLE sc_lon_m_req_salnet_inc ADD PRIMARY KEY (loan_requestment_no,seq_no);
ALTER TABLE sc_lon_m_req_salnet_inc ALTER COLUMN loan_requestment_no SET NOT NULL;
ALTER TABLE sc_lon_m_req_salnet_inc ALTER COLUMN seq_no SET NOT NULL;


