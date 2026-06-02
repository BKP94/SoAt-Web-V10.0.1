CREATE TABLE sc_wef_req_cvd (
	requestment_no varchar(15) NOT NULL,
	cvd_type varchar(6) DEFAULT '00',
	cvd_date timestamp,
	cvd_desc varchar(100),
	doc_no varchar(50),
	hospital_name varchar(100),
	remark varchar(100),
	receive_name varchar(200),
	money_type_id varchar(6),
	bank_id varchar(6),
	bank_acc_no varchar(15)
) ;
ALTER TABLE sc_wef_req_cvd ADD PRIMARY KEY (requestment_no);
ALTER TABLE sc_wef_req_cvd ALTER COLUMN requestment_no SET NOT NULL;


