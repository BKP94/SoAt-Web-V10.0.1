CREATE TABLE sc_mem_m_ucf_salary_rate (
	level_code smallint NOT NULL,
	salary_rate_code decimal(3,1) NOT NULL,
	salary_amount decimal(15,2)
) ;
COMMENT ON TABLE sc_mem_m_ucf_salary_rate IS E'!N?????????????? - ?????????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_ucf_salary_rate.level_code IS E'!N?????N!!MM!';
COMMENT ON COLUMN sc_mem_m_ucf_salary_rate.salary_amount IS E'!N?????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_ucf_salary_rate.salary_rate_code IS E'!N????N!!MM!';
ALTER TABLE sc_mem_m_ucf_salary_rate ADD PRIMARY KEY (level_code,salary_rate_code);


