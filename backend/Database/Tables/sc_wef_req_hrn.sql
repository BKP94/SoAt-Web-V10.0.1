CREATE TABLE sc_wef_req_hrn (
	requestment_no varchar(15) NOT NULL,
	hrn_type varchar(6),
	class_type varchar(6),
	carefor_in_date timestamp,
	carefor_out_date timestamp,
	doc_no varchar(200),
	prename varchar(3),
	first_name varchar(50),
	last_surname varchar(50),
	id_card varchar(13),
	remark varchar(200),
	receive_name varchar(200),
	money_type_id varchar(6),
	bank_id varchar(6),
	bank_acc_no varchar(15),
	receive_id_card varchar(15),
	money_req decimal(15,2),
	hospital_name varchar(200)
) ;
ALTER TABLE sc_wef_req_hrn ADD PRIMARY KEY (requestment_no);
ALTER TABLE sc_wef_req_hrn ALTER COLUMN requestment_no SET NOT NULL;


