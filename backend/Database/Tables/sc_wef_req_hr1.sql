CREATE TABLE sc_wef_req_hr1 (
	requestment_no varchar(15) NOT NULL,
	hr_code varchar(6),
	hr_date timestamp,
	hr_detail varchar(50)
) ;
ALTER TABLE sc_wef_req_hr1 ADD PRIMARY KEY (requestment_no);
ALTER TABLE sc_wef_req_hr1 ALTER COLUMN requestment_no SET NOT NULL;


