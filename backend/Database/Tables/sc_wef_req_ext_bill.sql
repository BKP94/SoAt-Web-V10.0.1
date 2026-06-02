CREATE TABLE sc_wef_req_ext_bill (
	requestment_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	ext_desc varchar(255),
	carefor_out_date timestamp,
	disease_name varchar(255),
	hospital_name varchar(255)
) ;
ALTER TABLE sc_wef_req_ext_bill ADD PRIMARY KEY (requestment_no,seq_no);
ALTER TABLE sc_wef_req_ext_bill ALTER COLUMN requestment_no SET NOT NULL;
ALTER TABLE sc_wef_req_ext_bill ALTER COLUMN seq_no SET NOT NULL;


