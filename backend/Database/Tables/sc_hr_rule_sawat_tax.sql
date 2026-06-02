CREATE TABLE sc_hr_rule_sawat_tax (
	c_start decimal(15,2) NOT NULL,
	c_stop decimal(15,2) NOT NULL,
	c_tax decimal(15,2),
	c_amout_totax decimal(15,2)
) ;
ALTER TABLE sc_hr_rule_sawat_tax ADD PRIMARY KEY (c_start,c_stop);


