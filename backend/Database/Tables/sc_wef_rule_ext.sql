CREATE TABLE sc_wef_rule_ext (
	ext_type varchar(6) NOT NULL DEFAULT '00',
	ext_desc varchar(100),
	paid_rate decimal(15,2) DEFAULT 0,
	cal_by char(1),
	cal_by_desc varchar(20),
	within_days integer
) ;
ALTER TABLE sc_wef_rule_ext ADD PRIMARY KEY (ext_type);
ALTER TABLE sc_wef_rule_ext ALTER COLUMN ext_type SET NOT NULL;


