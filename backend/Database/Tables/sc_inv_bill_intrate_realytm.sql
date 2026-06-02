CREATE TABLE sc_inv_bill_intrate_realytm (
	bill_no varchar(15) NOT NULL,
	interest_step decimal(15,2) NOT NULL,
	effective_date timestamp NOT NULL,
	interest_rate decimal(15,8) NOT NULL
) ;
ALTER TABLE sc_inv_bill_intrate_realytm ADD PRIMARY KEY (bill_no,interest_step,effective_date);
ALTER TABLE sc_inv_bill_intrate_realytm ALTER COLUMN bill_no SET NOT NULL;
ALTER TABLE sc_inv_bill_intrate_realytm ALTER COLUMN interest_step SET NOT NULL;
ALTER TABLE sc_inv_bill_intrate_realytm ALTER COLUMN effective_date SET NOT NULL;
ALTER TABLE sc_inv_bill_intrate_realytm ALTER COLUMN interest_rate SET NOT NULL;


