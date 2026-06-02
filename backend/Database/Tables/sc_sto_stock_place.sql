CREATE TABLE sc_sto_stock_place (
	place_id varchar(6) NOT NULL,
	product_id varchar(15) NOT NULL,
	n_price decimal(15,2),
	l_price decimal(15,2),
	n_quality decimal(15,2),
	l_quality decimal(15,2),
	input_qua decimal(15,2),
	output_qua decimal(15,2),
	t_quality decimal(15,2),
	t_price decimal(15,2),
	qty_balance decimal(15,2)
) ;
ALTER TABLE sc_sto_stock_place ADD PRIMARY KEY (place_id,product_id);
ALTER TABLE sc_sto_stock_place ALTER COLUMN place_id SET NOT NULL;


