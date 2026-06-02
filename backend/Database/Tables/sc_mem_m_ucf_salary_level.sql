CREATE TABLE sc_mem_m_ucf_salary_level (
	level_code smallint NOT NULL,
	level_name varchar(50),
	level_code_string varchar(5)
) ;
COMMENT ON TABLE sc_mem_m_ucf_salary_level IS E'!N?????????????? - ?????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_ucf_salary_level.level_code IS E'!N?????N!!MM!';
COMMENT ON COLUMN sc_mem_m_ucf_salary_level.level_name IS E'!N?????????N!!MM!';
ALTER TABLE sc_mem_m_ucf_salary_level ADD PRIMARY KEY (level_code);


