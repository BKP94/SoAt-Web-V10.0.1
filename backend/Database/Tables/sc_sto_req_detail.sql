CREATE TABLE sc_sto_req_detail (
	doc_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL,
	product_categlory varchar(6),
	product_id varchar(15),
	quantity bigint,
	no_product varchar(20),
	code_work varchar(6),
	chk char(1),
	operate_datetime timestamp,
	operate_date timestamp,
	sign_flag integer,
	remark_1 varchar(200),
	remark_2 varchar(200),
	remark_3 varchar(200),
	remark_4 varchar(200),
	status char(1),
	amount_foruse decimal(15,2),
	unit_price decimal(15,2),
	balance_quantity decimal(15,2),
	return_status char(1)
) ;
ALTER TABLE sc_sto_req_detail ADD PRIMARY KEY (doc_no,seq_no);
ALTER TABLE sc_sto_req_detail ALTER COLUMN doc_no SET NOT NULL;
ALTER TABLE sc_sto_req_detail ALTER COLUMN seq_no SET NOT NULL;


