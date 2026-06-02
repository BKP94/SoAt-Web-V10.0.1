CREATE TABLE sc_wef_req_ext (
	requestment_no varchar(15) NOT NULL,
	ext_type varchar(6) DEFAULT '00',
	ext_date timestamp,
	ext_desc varchar(100),
	in_date timestamp,
	out_date timestamp,
	amount decimal(15,2) DEFAULT 0,
	doc_no varchar(50),
	hospital_name varchar(100),
	remark varchar(100),
	receive_name varchar(200),
	money_type_id varchar(6),
	bank_id varchar(6),
	bank_acc_no varchar(15),
	sick_no varchar(5)
) ;
ALTER TABLE sc_wef_req_ext ADD PRIMARY KEY (requestment_no);
ALTER TABLE sc_wef_req_ext ALTER COLUMN requestment_no SET NOT NULL;


