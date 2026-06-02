CREATE TABLE sc_wef_req_nur (
	requestment_no varchar(15) NOT NULL,
	carefor_in_date timestamp,
	carefor_out_date timestamp,
	carefor_amount decimal(15,2) DEFAULT 0,
	doc_type varchar(6) DEFAULT '00',
	doc_no varchar(15),
	count_paid_day numeric(38) DEFAULT 0,
	req_count_day numeric(38) DEFAULT 0,
	begin_age_date timestamp,
	age_mem bigint DEFAULT 0,
	amount_carefor decimal(15,2) DEFAULT 0,
	paid_amount_all decimal(15,2) DEFAULT 0,
	hospital_name varchar(200),
	disease_name varchar(200),
	sso_rejected char(1) DEFAULT '0',
	receive_name varchar(200),
	money_type_id varchar(6),
	bank_id varchar(6),
	bank_acc_no varchar(15)
) ;
ALTER TABLE sc_wef_req_nur ADD PRIMARY KEY (requestment_no);
ALTER TABLE sc_wef_req_nur ALTER COLUMN requestment_no SET NOT NULL;


