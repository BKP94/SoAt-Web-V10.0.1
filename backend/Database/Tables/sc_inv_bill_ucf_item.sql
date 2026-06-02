CREATE TABLE sc_inv_bill_ucf_item (
	bill_item_type varchar(3) NOT NULL,
	bill_item_desc varchar(35) NOT NULL,
	sign_status integer NOT NULL,
	print_code varchar(3) NOT NULL
) ;
ALTER TABLE sc_inv_bill_ucf_item ADD PRIMARY KEY (bill_item_type);
ALTER TABLE sc_inv_bill_ucf_item ALTER COLUMN bill_item_type SET NOT NULL;
ALTER TABLE sc_inv_bill_ucf_item ALTER COLUMN bill_item_desc SET NOT NULL;
ALTER TABLE sc_inv_bill_ucf_item ALTER COLUMN sign_status SET NOT NULL;
ALTER TABLE sc_inv_bill_ucf_item ALTER COLUMN print_code SET NOT NULL;


