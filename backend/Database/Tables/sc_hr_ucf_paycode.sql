CREATE TABLE sc_hr_ucf_paycode (
	pay_code varchar(6) NOT NULL,
	pay_desc varchar(100),
	account_id varchar(8),
	table_name varchar(30),
	column_money varchar(30),
	column_tax varchar(30),
	column_opdate varchar(30)
) ;
ALTER TABLE sc_hr_ucf_paycode ADD PRIMARY KEY (pay_code);
ALTER TABLE sc_hr_ucf_paycode ALTER COLUMN pay_code SET NOT NULL;


