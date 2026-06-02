CREATE TABLE sc_wef_rule_smt (
	mem_type varchar(6) NOT NULL,
	seq_no numeric(38) NOT NULL,
	level_memage numeric(38),
	paid_rate decimal(15,2) DEFAULT 0
) ;
ALTER TABLE sc_wef_rule_smt ADD PRIMARY KEY (mem_type,seq_no);
ALTER TABLE sc_wef_rule_smt ALTER COLUMN mem_type SET NOT NULL;
ALTER TABLE sc_wef_rule_smt ALTER COLUMN seq_no SET NOT NULL;


