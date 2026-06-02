CREATE TABLE sc_wef_req_ret (
	requestment_no varchar(15) NOT NULL,
	ret_date timestamp,
	manual_status char(1),
	ret_detail varchar(50),
	remark varchar(200),
	receive_name varchar(200),
	money_type_id varchar(6),
	bank_id varchar(6),
	bank_acc_no varchar(15),
	date_of_birth timestamp,
	approve_date timestamp,
	age_life varchar(100),
	age_mem varchar(100),
	bank_branch_id varchar(6)
) ;
ALTER TABLE sc_wef_req_ret ADD PRIMARY KEY (requestment_no);
ALTER TABLE sc_wef_req_ret ALTER COLUMN requestment_no SET NOT NULL;


