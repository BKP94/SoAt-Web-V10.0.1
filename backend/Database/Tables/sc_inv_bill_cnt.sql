CREATE TABLE sc_inv_bill_cnt (
	coop_registered_no varchar(15) NOT NULL,
	day_inyear integer NOT NULL,
	receipt_format varchar(20),
	bill_format varchar(20),
	payment_receipt_name varchar(100),
	dep_pn varchar(6),
	dep_loan varchar(6)
) ;
ALTER TABLE sc_inv_bill_cnt ADD PRIMARY KEY (coop_registered_no);
ALTER TABLE sc_inv_bill_cnt ALTER COLUMN coop_registered_no SET NOT NULL;
ALTER TABLE sc_inv_bill_cnt ALTER COLUMN day_inyear SET NOT NULL;


