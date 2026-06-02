CREATE TABLE sc_wef_req_evt (
	requestment_no varchar(15) NOT NULL,
	evt_type varchar(6),
	evt_date timestamp,
	evt_detail varchar(50),
	remark varchar(200),
	receive_name varchar(200),
	money_type_id varchar(6),
	bank_id varchar(6),
	bank_acc_no varchar(15),
	spounse_status char(1),
	address_id varchar(15)
) ;
ALTER TABLE sc_wef_req_evt ADD PRIMARY KEY (requestment_no);
ALTER TABLE sc_wef_req_evt ALTER COLUMN requestment_no SET NOT NULL;


