CREATE TABLE sc_sto_reci_prod_detail (
	doc_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL,
	product_categlory varchar(6),
	product_id varchar(15),
	quantity bigint,
	unit_price decimal(10,2),
	amount decimal(20,2),
	reduce_per_unit_c decimal(10,2),
	no_product varchar(20),
	place_id varchar(6),
	branch varchar(6),
	code_work varchar(6),
	chk char(1)
) ;
ALTER TABLE sc_sto_reci_prod_detail ADD PRIMARY KEY (doc_no,seq_no);
ALTER TABLE sc_sto_reci_prod_detail ALTER COLUMN doc_no SET NOT NULL;
ALTER TABLE sc_sto_reci_prod_detail ALTER COLUMN seq_no SET NOT NULL;


