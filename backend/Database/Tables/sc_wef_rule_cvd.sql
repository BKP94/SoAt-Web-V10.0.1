CREATE TABLE sc_wef_rule_cvd (
	cvd_type varchar(6) NOT NULL DEFAULT '00',
	cvd_date timestamp NOT NULL,
	cvd_desc varchar(100),
	paid_rate decimal(15,2) DEFAULT 0,
	within_days integer DEFAULT 0
) ;
ALTER TABLE sc_wef_rule_cvd ADD PRIMARY KEY (cvd_type,cvd_date);
ALTER TABLE sc_wef_rule_cvd ALTER COLUMN cvd_type SET NOT NULL;
ALTER TABLE sc_wef_rule_cvd ALTER COLUMN cvd_date SET NOT NULL;


