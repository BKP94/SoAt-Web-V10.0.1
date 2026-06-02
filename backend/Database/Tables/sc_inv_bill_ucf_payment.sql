CREATE TABLE sc_inv_bill_ucf_payment (
	payment_id char(1) NOT NULL,
	payment_desc char(10)
) ;
ALTER TABLE sc_inv_bill_ucf_payment ADD PRIMARY KEY (payment_id);
ALTER TABLE sc_inv_bill_ucf_payment ALTER COLUMN payment_id SET NOT NULL;


