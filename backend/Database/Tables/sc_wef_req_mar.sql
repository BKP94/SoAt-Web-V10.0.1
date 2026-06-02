CREATE TABLE sc_wef_req_mar (
	requestment_no varchar(15) NOT NULL,
	mar_date timestamp,
	mar_reason varchar(100),
	conceern_code varchar(6) DEFAULT '00',
	doc_no_dead varchar(200),
	prename varchar(3),
	first_name varchar(30),
	last_surname varchar(30),
	id_card varchar(13),
	begin_age_date timestamp,
	age_mem bigint DEFAULT 0,
	amount_dead2 decimal(15,2) DEFAULT 0,
	paid_amount_all decimal(15,2) DEFAULT 0,
	receive_name varchar(200),
	money_type_id varchar(6),
	bank_id varchar(6),
	bank_acc_no varchar(15),
	mar_doc_no varchar(15),
	remark varchar(200)
) ;
ALTER TABLE sc_wef_req_mar ADD PRIMARY KEY (requestment_no);
ALTER TABLE sc_wef_req_mar ALTER COLUMN requestment_no SET NOT NULL;


