CREATE TABLE sc_bill_ucf_payment_item_code (
	payment_item_code varchar(15) NOT NULL,
	bank_code varchar(6) NOT NULL,
	payment_item_decription varchar(100),
	system_code varchar(6),
	object_code varchar(6),
	object_code2 varchar(6)
) ;
ALTER TABLE sc_bill_ucf_payment_item_code ADD PRIMARY KEY (payment_item_code,bank_code);
ALTER TABLE sc_bill_ucf_payment_item_code ALTER COLUMN payment_item_code SET NOT NULL;
ALTER TABLE sc_bill_ucf_payment_item_code ALTER COLUMN bank_code SET NOT NULL;


