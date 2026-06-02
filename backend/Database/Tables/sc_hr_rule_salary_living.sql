CREATE TABLE sc_hr_rule_salary_living (
	seq_no integer NOT NULL DEFAULT 0,
	salary_amount_min decimal(15,2) NOT NULL,
	salary_amount_max decimal(15,2) NOT NULL,
	salary_living_cal decimal(15,2) DEFAULT 0,
	salary_living_fixed decimal(15,2) DEFAULT 0
) ;
ALTER TABLE sc_hr_rule_salary_living ADD PRIMARY KEY (seq_no);
ALTER TABLE sc_hr_rule_salary_living ALTER COLUMN seq_no SET NOT NULL;
ALTER TABLE sc_hr_rule_salary_living ALTER COLUMN salary_amount_min SET NOT NULL;
ALTER TABLE sc_hr_rule_salary_living ALTER COLUMN salary_amount_max SET NOT NULL;


