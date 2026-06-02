CREATE TABLE sc_wef_rule_hre (
	hre_type varchar(6) NOT NULL,
	hre_desc varchar(50),
	paid_rate decimal(15,2) DEFAULT '0'
) ;
ALTER TABLE sc_wef_rule_hre ADD PRIMARY KEY (hre_type);
ALTER TABLE sc_wef_rule_hre ALTER COLUMN hre_type SET NOT NULL;


