CREATE TABLE sc_sch_rule_payment_type (
	payment_type_code varchar(3) NOT NULL,
	payment_type_decs varchar(50),
	dep_status char(1) DEFAULT '0',
	fin_status char(1)
) ;
ALTER TABLE sc_sch_rule_payment_type ADD PRIMARY KEY (payment_type_code);
ALTER TABLE sc_sch_rule_payment_type ALTER COLUMN payment_type_code SET NOT NULL;


