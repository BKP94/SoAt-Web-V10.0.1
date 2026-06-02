CREATE TABLE sc_dep_m_rule_intmonth_due (
	deposit_type_code varchar(6) NOT NULL DEFAULT '00',
	intmonth_due numeric(38) NOT NULL DEFAULT 0
) ;
ALTER TABLE sc_dep_m_rule_intmonth_due ADD PRIMARY KEY (deposit_type_code,intmonth_due);


