CREATE TABLE sc_inv_bill_interest_rate_use (
	bill_no varchar(15) NOT NULL,
	interest_step decimal(15,2) NOT NULL,
	effective_date timestamp NOT NULL,
	interest_rate decimal(15,8) NOT NULL
) ;
ALTER TABLE sc_inv_bill_interest_rate_use ADD PRIMARY KEY (bill_no,interest_step,effective_date);
ALTER TABLE sc_inv_bill_interest_rate_use ALTER COLUMN bill_no SET NOT NULL;
ALTER TABLE sc_inv_bill_interest_rate_use ALTER COLUMN interest_step SET NOT NULL;
ALTER TABLE sc_inv_bill_interest_rate_use ALTER COLUMN effective_date SET NOT NULL;
ALTER TABLE sc_inv_bill_interest_rate_use ALTER COLUMN interest_rate SET NOT NULL;


