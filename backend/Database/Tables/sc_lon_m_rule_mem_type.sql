CREATE TABLE sc_lon_m_rule_mem_type (
	loan_type varchar(6) NOT NULL DEFAULT '00',
	mem_type varchar(6) NOT NULL DEFAULT '00',
	status_loan char(1) DEFAULT '0'
) ;
ALTER TABLE sc_lon_m_rule_mem_type ADD PRIMARY KEY (loan_type,mem_type);
ALTER TABLE sc_lon_m_rule_mem_type ALTER COLUMN loan_type SET NOT NULL;
ALTER TABLE sc_lon_m_rule_mem_type ALTER COLUMN mem_type SET NOT NULL;


