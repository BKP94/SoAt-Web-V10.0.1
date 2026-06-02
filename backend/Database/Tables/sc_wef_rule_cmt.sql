CREATE TABLE sc_wef_rule_cmt (
	cmt_type varchar(6) NOT NULL DEFAULT '00',
	cmt_desc varchar(200),
	paid_rate decimal(15,2) DEFAULT 0,
	life_limit integer
) ;
ALTER TABLE sc_wef_rule_cmt ADD PRIMARY KEY (cmt_type);
ALTER TABLE sc_wef_rule_cmt ALTER COLUMN cmt_type SET NOT NULL;


