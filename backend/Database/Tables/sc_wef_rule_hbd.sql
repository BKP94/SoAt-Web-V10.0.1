CREATE TABLE sc_wef_rule_hbd (
	hbd_code varchar(6) NOT NULL,
	level_memage numeric(38) NOT NULL,
	paid_rate decimal(15,2) DEFAULT 0
) ;
ALTER TABLE sc_wef_rule_hbd ADD PRIMARY KEY (hbd_code,level_memage);
ALTER TABLE sc_wef_rule_hbd ALTER COLUMN hbd_code SET NOT NULL;
ALTER TABLE sc_wef_rule_hbd ALTER COLUMN level_memage SET NOT NULL;


