CREATE TABLE sc_wef_req_dag (
	requestment_no varchar(15) NOT NULL,
	dag_type varchar(6) DEFAULT '00',
	dag_date timestamp,
	dag_desc varchar(100),
	remark varchar(200),
	address_no varchar(200),
	dag_amount decimal(15,2) DEFAULT 0,
	dag_no varchar(15),
	receive_name varchar(200),
	money_type_id varchar(6),
	bank_id varchar(6),
	bank_acc_no varchar(15)
) ;
ALTER TABLE sc_wef_req_dag ADD PRIMARY KEY (requestment_no);
ALTER TABLE sc_wef_req_dag ALTER COLUMN requestment_no SET NOT NULL;


