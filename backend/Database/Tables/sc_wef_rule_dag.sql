CREATE TABLE sc_wef_rule_dag (
	dag_type varchar(6) NOT NULL,
	dag_desc varchar(50),
	paid_rate decimal(15,2) DEFAULT '0'
) ;
ALTER TABLE sc_wef_rule_dag ADD PRIMARY KEY (dag_type);
ALTER TABLE sc_wef_rule_dag ALTER COLUMN dag_type SET NOT NULL;


