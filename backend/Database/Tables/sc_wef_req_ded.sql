CREATE TABLE sc_wef_req_ded (
	requestment_no varchar(15) NOT NULL,
	dead_type varchar(6),
	dead_date timestamp,
	reason_type varchar(6),
	dead_doc_no varchar(15),
	remark varchar(100),
	receive_id_card varchar(15),
	receive_name varchar(200),
	money_type_id varchar(3),
	bank_id varchar(6),
	bank_acc_no varchar(15),
	permit_amount decimal(15,2),
	return_count integer,
	age_mem varchar(100),
	ded_name varchar(250),
	receive_date timestamp,
	ded_remark varchar(250),
	person_status char(1),
	conceern_code char(2)
) ;
ALTER TABLE sc_wef_req_ded ADD PRIMARY KEY (requestment_no);
ALTER TABLE sc_wef_req_ded ALTER COLUMN requestment_no SET NOT NULL;


