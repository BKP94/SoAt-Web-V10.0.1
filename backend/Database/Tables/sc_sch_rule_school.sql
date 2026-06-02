CREATE TABLE sc_sch_rule_school (
	school_code varchar(6) NOT NULL,
	school_name varchar(150),
	school_type varchar(6) DEFAULT '00',
	accept_status char(1) DEFAULT '0',
	school_dist_code varchar(6) DEFAULT '00',
	school_prov_code varchar(6) DEFAULT '00',
	cha3_status char(1) DEFAULT '0'
) ;
ALTER TABLE sc_sch_rule_school ADD PRIMARY KEY (school_code);
ALTER TABLE sc_sch_rule_school ALTER COLUMN school_code SET NOT NULL;


