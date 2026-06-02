CREATE TABLE sc_wef_rule_hrd (
	hrd_type double precision NOT NULL,
	hrd_desc varchar(20),
	paid_rate decimal(15,2)
) ;
ALTER TABLE sc_wef_rule_hrd ADD PRIMARY KEY (hrd_type);
ALTER TABLE sc_wef_rule_hrd ALTER COLUMN hrd_type SET NOT NULL;


