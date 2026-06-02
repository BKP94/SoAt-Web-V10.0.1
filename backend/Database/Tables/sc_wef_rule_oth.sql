CREATE TABLE sc_wef_rule_oth (
	oth_code varchar(6) NOT NULL,
	oth_desc varchar(100),
	paid_rate decimal(15,2) DEFAULT '0'
) ;
ALTER TABLE sc_wef_rule_oth ADD PRIMARY KEY (oth_code);
ALTER TABLE sc_wef_rule_oth ALTER COLUMN oth_code SET NOT NULL;


