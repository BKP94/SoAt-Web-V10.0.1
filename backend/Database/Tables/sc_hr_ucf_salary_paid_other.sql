CREATE TABLE sc_hr_ucf_salary_paid_other (
	paid_other varchar(6) NOT NULL DEFAULT '00',
	paid_other_desc varchar(100) DEFAULT '',
	account_id varchar(8) DEFAULT '',
	posto_dep char(1) DEFAULT '0',
	own_accno_status char(1) DEFAULT '0',
	coop_accno varchar(15)
) ;
ALTER TABLE sc_hr_ucf_salary_paid_other ADD PRIMARY KEY (paid_other);
ALTER TABLE sc_hr_ucf_salary_paid_other ALTER COLUMN paid_other SET NOT NULL;


