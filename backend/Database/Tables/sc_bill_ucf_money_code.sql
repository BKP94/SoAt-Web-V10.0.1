CREATE TABLE sc_bill_ucf_money_code (
	payment_money_code varchar(15) NOT NULL,
	system_code varchar(6) NOT NULL,
	payment_decription varchar(100),
	sign_flag double precision DEFAULT 0,
	print_code varchar(6),
	transaction_code varchar(6)
) ;
ALTER TABLE sc_bill_ucf_money_code ADD PRIMARY KEY (payment_money_code,system_code);
ALTER TABLE sc_bill_ucf_money_code ALTER COLUMN payment_money_code SET NOT NULL;
ALTER TABLE sc_bill_ucf_money_code ALTER COLUMN system_code SET NOT NULL;


