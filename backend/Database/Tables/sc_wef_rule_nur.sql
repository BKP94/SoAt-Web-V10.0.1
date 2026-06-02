CREATE TABLE sc_wef_rule_nur (
	nur_type varchar(6) NOT NULL,
	nur_desc varchar(50),
	paid_rate decimal(15,2),
	nur_night double precision
) ;
ALTER TABLE sc_wef_rule_nur ADD PRIMARY KEY (nur_type);
ALTER TABLE sc_wef_rule_nur ALTER COLUMN nur_type SET NOT NULL;


