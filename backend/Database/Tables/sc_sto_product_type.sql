CREATE TABLE sc_sto_product_type (
	product_categlory char(6),
	product_id varchar(15) NOT NULL,
	product_name varchar(50),
	product_class varchar(50),
	product_color varchar(15),
	product_brand varchar(20),
	product_barcode varchar(13),
	product_u varchar(20),
	qty_min decimal(15,2),
	section_id varchar(6),
	barcode varchar(50)
) ;
ALTER TABLE sc_sto_product_type ADD PRIMARY KEY (product_id);


