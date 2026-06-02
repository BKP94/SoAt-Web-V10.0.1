CREATE TABLE sc_wef_req_oth (
	requestment_no varchar(15) NOT NULL,
	oth_code varchar(6),
	oth_date timestamp,
	oth_detail varchar(50),
	money_type_id varchar(3),
	bank_id varchar(6),
	bank_branch_id varchar(6),
	bank_acc_no varchar(15),
	receive_name varchar(100)
) ;
ALTER TABLE sc_wef_req_oth ADD PRIMARY KEY (requestment_no);
ALTER TABLE sc_wef_req_oth ALTER COLUMN requestment_no SET NOT NULL;


