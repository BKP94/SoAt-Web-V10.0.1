CREATE TABLE sc_hr_ucf_salary_level (
	salary_level double precision NOT NULL DEFAULT 0,
	salary_amount decimal(15,2) DEFAULT 0
) ;
ALTER TABLE sc_hr_ucf_salary_level ADD PRIMARY KEY (salary_level);


