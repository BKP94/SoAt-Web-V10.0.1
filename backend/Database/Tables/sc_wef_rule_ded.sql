CREATE TABLE sc_wef_rule_ded (
	ded_code varchar(6) NOT NULL,
	level_memage numeric(38) NOT NULL,
	paid_rate decimal(15,2) DEFAULT 0,
	family_rate decimal(15,2)
) ;
ALTER TABLE sc_wef_rule_ded ADD PRIMARY KEY (ded_code,level_memage);
ALTER TABLE sc_wef_rule_ded ALTER COLUMN ded_code SET NOT NULL;
ALTER TABLE sc_wef_rule_ded ALTER COLUMN level_memage SET NOT NULL;


