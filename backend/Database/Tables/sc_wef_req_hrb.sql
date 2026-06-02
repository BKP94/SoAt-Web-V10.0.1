CREATE TABLE sc_wef_req_hrb (
	requestment_no varchar(15) NOT NULL,
	first_hrb_date timestamp,
	first_pre_name varchar(6),
	first_child_name varchar(100),
	first_child_surname varchar(100),
	first_child_id_card varchar(15),
	secound_hrb_date timestamp,
	secound_pre_name varchar(6),
	secound_child_name varchar(100),
	secound_child_surname varchar(100),
	secound_child_id_card varchar(15),
	third_hrb_date timestamp,
	third_pre_name varchar(6),
	third_child_name varchar(100),
	third_child_surname varchar(100),
	third_child_id_card varchar(15),
	remark varchar(200),
	receive_name varchar(200),
	money_type_id varchar(6),
	bank_id varchar(6),
	bank_acc_no varchar(15)
) ;
ALTER TABLE sc_wef_req_hrb ADD PRIMARY KEY (requestment_no);
ALTER TABLE sc_wef_req_hrb ALTER COLUMN requestment_no SET NOT NULL;


