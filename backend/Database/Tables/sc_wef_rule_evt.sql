CREATE TABLE sc_wef_rule_evt (
	evt_type varchar(6) NOT NULL,
	evt_desc varchar(50),
	paid_rate decimal(15,2) DEFAULT '0'
) ;
ALTER TABLE sc_wef_rule_evt ADD PRIMARY KEY (evt_type);
ALTER TABLE sc_wef_rule_evt ALTER COLUMN evt_type SET NOT NULL;


