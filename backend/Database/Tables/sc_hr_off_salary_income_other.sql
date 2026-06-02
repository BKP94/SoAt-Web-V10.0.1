CREATE TABLE sc_hr_off_salary_income_other (
	official_no varchar(15) NOT NULL,
	sal_year double precision NOT NULL DEFAULT 0,
	sal_month double precision NOT NULL DEFAULT 0,
	seq_no double precision NOT NULL DEFAULT 0,
	income_status char(1) NOT NULL DEFAULT '1',
	income_code varchar(6) DEFAULT '00',
	income_amount decimal(15,2) DEFAULT 0
) ;
ALTER TABLE sc_hr_off_salary_income_other ADD PRIMARY KEY (official_no,sal_year,sal_month,seq_no,income_status);
ALTER TABLE sc_hr_off_salary_income_other ALTER COLUMN official_no SET NOT NULL;
ALTER TABLE sc_hr_off_salary_income_other ALTER COLUMN sal_year SET NOT NULL;
ALTER TABLE sc_hr_off_salary_income_other ALTER COLUMN sal_month SET NOT NULL;
ALTER TABLE sc_hr_off_salary_income_other ALTER COLUMN seq_no SET NOT NULL;
ALTER TABLE sc_hr_off_salary_income_other ALTER COLUMN income_status SET NOT NULL;


