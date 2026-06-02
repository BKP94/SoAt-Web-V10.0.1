CREATE TABLE sc_wef_req_hrd (
	requestment_no varchar(15) NOT NULL,
	hrd_type varchar(6),
	birth_date timestamp,
	dead_date timestamp,
	dead_reason varchar(100),
	dead_doc_no varchar(200),
	prename varchar(3),
	first_name varchar(30),
	last_surname varchar(30),
	id_card varchar(13),
	remark varchar(100),
	receive_name varchar(200),
	money_type_id varchar(6),
	bank_id varchar(6),
	bank_acc_no varchar(15),
	receive_id_card varchar(15)
) ;
ALTER TABLE sc_wef_req_hrd ADD PRIMARY KEY (requestment_no);
ALTER TABLE sc_wef_req_hrd ALTER COLUMN requestment_no SET NOT NULL;


