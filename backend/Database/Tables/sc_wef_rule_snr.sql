CREATE TABLE sc_wef_rule_snr (
	snr_type varchar(6) NOT NULL,
	snr_desc varchar(250) NOT NULL,
	level_memage numeric(38),
	paid_rate decimal(15,2) DEFAULT 0
) ;
ALTER TABLE sc_wef_rule_snr ADD PRIMARY KEY (snr_type);
ALTER TABLE sc_wef_rule_snr ALTER COLUMN snr_type SET NOT NULL;
ALTER TABLE sc_wef_rule_snr ALTER COLUMN snr_desc SET NOT NULL;


