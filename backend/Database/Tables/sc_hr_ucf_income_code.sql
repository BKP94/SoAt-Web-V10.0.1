CREATE TABLE sc_hr_ucf_income_code (
	income_code varchar(6) NOT NULL DEFAULT '00',
	income_desc varchar(50),
	income_status char(1) DEFAULT '1',
	account_id varchar(8),
	sort_order integer,
	account_type varchar(6)
) ;
ALTER TABLE sc_hr_ucf_income_code ADD PRIMARY KEY (income_code);
ALTER TABLE sc_hr_ucf_income_code ALTER COLUMN income_code SET NOT NULL;


