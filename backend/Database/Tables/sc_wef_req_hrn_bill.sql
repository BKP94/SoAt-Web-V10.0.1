CREATE TABLE sc_wef_req_hrn_bill (
	requestment_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL,
	hrn_desc varchar(255),
	bill_date timestamp,
	bill_amount decimal(15,2),
	remark varchar(255)
) ;
ALTER TABLE sc_wef_req_hrn_bill ADD PRIMARY KEY (requestment_no,seq_no);
ALTER TABLE sc_wef_req_hrn_bill ALTER COLUMN requestment_no SET NOT NULL;
ALTER TABLE sc_wef_req_hrn_bill ALTER COLUMN seq_no SET NOT NULL;


