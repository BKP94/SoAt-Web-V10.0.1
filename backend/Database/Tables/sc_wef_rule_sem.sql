CREATE TABLE sc_wef_rule_sem (
	sem_code varchar(2) NOT NULL,
	sem_desc varchar(100),
	paid_rate decimal(15,2)
) ;
ALTER TABLE sc_wef_rule_sem ADD PRIMARY KEY (sem_code);
ALTER TABLE sc_wef_rule_sem ALTER COLUMN sem_code SET NOT NULL;


