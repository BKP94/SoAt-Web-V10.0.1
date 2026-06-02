CREATE TABLE sc_wef_rule_edu (
	edu_type varchar(6) NOT NULL,
	edu_desc varchar(50),
	paid_rate decimal(15,2) DEFAULT '0',
	max_continue integer DEFAULT 0
) ;
ALTER TABLE sc_wef_rule_edu ADD PRIMARY KEY (edu_type);
ALTER TABLE sc_wef_rule_edu ALTER COLUMN edu_type SET NOT NULL;


