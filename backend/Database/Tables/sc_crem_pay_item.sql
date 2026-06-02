CREATE TABLE sc_crem_pay_item (
	receipt_no varchar(10) NOT NULL,
	seq_no double precision NOT NULL,
	item_type varchar(10) NOT NULL,
	description varchar(100),
	amount decimal(18,2),
	balance decimal(18,2)
) ;
ALTER TABLE sc_crem_pay_item ADD PRIMARY KEY (receipt_no,seq_no);
ALTER TABLE sc_crem_pay_item ALTER COLUMN receipt_no SET NOT NULL;
ALTER TABLE sc_crem_pay_item ALTER COLUMN seq_no SET NOT NULL;
ALTER TABLE sc_crem_pay_item ALTER COLUMN item_type SET NOT NULL;


