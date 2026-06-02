CREATE TABLE sc_crem_pay (
	receipt_no varchar(10) NOT NULL,
	receipt_date timestamp NOT NULL,
	crem_code varchar(10) NOT NULL,
	receipt_status char(1) NOT NULL,
	pay_type varchar(3) NOT NULL,
	entry_date timestamp NOT NULL,
	entry_id varchar(10) NOT NULL,
	cancel_date timestamp,
	cancel_id varchar(10),
	branch_id varchar(2) NOT NULL,
	crem_balance decimal(18,2),
	carcass_paid double precision
) ;
ALTER TABLE sc_crem_pay ADD PRIMARY KEY (receipt_no);
ALTER TABLE sc_crem_pay ALTER COLUMN receipt_no SET NOT NULL;
ALTER TABLE sc_crem_pay ALTER COLUMN receipt_date SET NOT NULL;
ALTER TABLE sc_crem_pay ALTER COLUMN crem_code SET NOT NULL;
ALTER TABLE sc_crem_pay ALTER COLUMN receipt_status SET NOT NULL;
ALTER TABLE sc_crem_pay ALTER COLUMN pay_type SET NOT NULL;
ALTER TABLE sc_crem_pay ALTER COLUMN entry_date SET NOT NULL;
ALTER TABLE sc_crem_pay ALTER COLUMN entry_id SET NOT NULL;
ALTER TABLE sc_crem_pay ALTER COLUMN branch_id SET NOT NULL;


