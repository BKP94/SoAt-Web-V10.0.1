CREATE TABLE sc_hr_ucf_salary_living (
	seq_no double precision NOT NULL DEFAULT 0,
	salary_limit decimal(15,2) DEFAULT 0,
	salary_from decimal(15,2) DEFAULT 0,
	salary_to decimal(15,2) DEFAULT 0,
	salary_amount decimal(15,2) DEFAULT 0
) ;
ALTER TABLE sc_hr_ucf_salary_living ADD PRIMARY KEY (seq_no);


