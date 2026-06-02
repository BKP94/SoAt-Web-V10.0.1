CREATE TABLE sc_wef_rule_bon (
	bon_date timestamp NOT NULL,
	paid_rate decimal(15,2) DEFAULT 0
) ;
ALTER TABLE sc_wef_rule_bon ADD PRIMARY KEY (bon_date);


