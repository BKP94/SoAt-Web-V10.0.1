CREATE TABLE sc_rep_loan_approx_d (
	entry_id varchar(16) NOT NULL,
	loan_payment_date timestamp NOT NULL,
	pay_period double precision DEFAULT 0,
	payment_interest decimal(15,2) DEFAULT 0,
	payment_amount decimal(15,2) DEFAULT 0,
	principal_balance decimal(15,2) DEFAULT 0,
	loan_int_rate decimal(15,2) DEFAULT 0
) ;
ALTER TABLE sc_rep_loan_approx_d ADD PRIMARY KEY (entry_id,loan_payment_date);
ALTER TABLE sc_rep_loan_approx_d ALTER COLUMN entry_id SET NOT NULL;
ALTER TABLE sc_rep_loan_approx_d ALTER COLUMN loan_payment_date SET NOT NULL;


