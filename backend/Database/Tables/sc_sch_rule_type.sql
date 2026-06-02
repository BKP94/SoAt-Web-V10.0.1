CREATE TABLE sc_sch_rule_type (
	sch_class varchar(6) NOT NULL DEFAULT '00',
	sch_type varchar(6) DEFAULT '00',
	sch_desc varchar(100),
	sch_receive decimal(15,2) DEFAULT 0,
	sorting double precision DEFAULT 0,
	sch_class_old varchar(6) DEFAULT '00'
) ;
ALTER TABLE sc_sch_rule_type ADD PRIMARY KEY (sch_class);
ALTER TABLE sc_sch_rule_type ALTER COLUMN sch_class SET NOT NULL;


