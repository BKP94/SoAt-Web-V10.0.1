CREATE TABLE sc_hr_rule_social_security (
	seq_no double precision NOT NULL DEFAULT 0,
	salary_amount decimal(15,2) DEFAULT 0,
	social_security_percent decimal(10,6) DEFAULT 0,
	social_security_amount decimal(15,2) DEFAULT 0
) ;
ALTER TABLE sc_hr_rule_social_security ADD PRIMARY KEY (seq_no);
ALTER TABLE sc_hr_rule_social_security ALTER COLUMN seq_no SET NOT NULL;


