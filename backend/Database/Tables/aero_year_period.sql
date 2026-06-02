CREATE TABLE aero_year_period (
	balance_date timestamp NOT NULL,
	loan_contract_no varchar(15) NOT NULL,
	loan_payment_date timestamp NOT NULL,
	item_type_code varchar(6) DEFAULT '00',
	payment_amount decimal(15,2) DEFAULT 0,
	interest_amout decimal(15,2) DEFAULT 0,
	principal_balance decimal(15,2) DEFAULT 0,
	period integer DEFAULT 0
) ;
ALTER TABLE aero_year_period ADD PRIMARY KEY (balance_date,loan_contract_no,loan_payment_date);
ALTER TABLE aero_year_period ALTER COLUMN balance_date SET NOT NULL;
ALTER TABLE aero_year_period ALTER COLUMN loan_contract_no SET NOT NULL;
ALTER TABLE aero_year_period ALTER COLUMN loan_payment_date SET NOT NULL;


