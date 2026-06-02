CREATE TABLE sc_hr_off_salary_paid_other (
	official_no varchar(15) NOT NULL,
	sal_year double precision NOT NULL DEFAULT 0,
	sal_month double precision NOT NULL DEFAULT 0,
	seq_no double precision NOT NULL DEFAULT 0,
	paid_other varchar(6),
	paid_amount decimal(15,2) DEFAULT 0,
	year double precision,
	month double precision
) ;
ALTER TABLE sc_hr_off_salary_paid_other ADD PRIMARY KEY (official_no,sal_year,sal_month,seq_no);
ALTER TABLE sc_hr_off_salary_paid_other ALTER COLUMN official_no SET NOT NULL;
ALTER TABLE sc_hr_off_salary_paid_other ALTER COLUMN sal_year SET NOT NULL;
ALTER TABLE sc_hr_off_salary_paid_other ALTER COLUMN sal_month SET NOT NULL;
ALTER TABLE sc_hr_off_salary_paid_other ALTER COLUMN seq_no SET NOT NULL;


