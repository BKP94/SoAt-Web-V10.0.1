CREATE TABLE sc_wef_req_bon (
	requestment_no varchar(15) NOT NULL,
	bon_date timestamp,
	pre_name varchar(6),
	child_name varchar(100),
	child_surname varchar(100),
	child_id_card varchar(15),
	remark varchar(200),
	receive_name varchar(200),
	money_type_id varchar(6),
	bank_id varchar(6),
	bank_acc_no varchar(15),
	first_id varchar(15),
	first_name varchar(100),
	first_surname varchar(100),
	secound_id varchar(15),
	secound_name varchar(100),
	secound_surname varchar(100),
	third_id varchar(15),
	third_name varchar(100),
	third_surname varchar(100)
) ;
ALTER TABLE sc_wef_req_bon ADD PRIMARY KEY (requestment_no);
ALTER TABLE sc_wef_req_bon ALTER COLUMN requestment_no SET NOT NULL;


