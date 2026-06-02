CREATE TABLE sc_wef_req_smt (
	requestment_no varchar(15) NOT NULL,
	manual_status char(1),
	smt_date timestamp,
	smt_detail varchar(100),
	remark varchar(100),
	receive_name varchar(200),
	money_type_id varchar(6),
	bank_id varchar(6),
	bank_acc_no varchar(15),
	date_of_birth timestamp,
	approve_date timestamp,
	age_life varchar(100),
	age_mem varchar(100)
) ;
ALTER TABLE sc_wef_req_smt ADD PRIMARY KEY (requestment_no);
ALTER TABLE sc_wef_req_smt ALTER COLUMN requestment_no SET NOT NULL;


