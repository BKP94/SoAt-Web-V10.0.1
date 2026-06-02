CREATE TABLE sc_mem_m_ucf_resign_cause (
	resign_cause_code varchar(6) NOT NULL,
	resign_cause_name varchar(100),
	member_status_code char(1),
	dead_status char(1) DEFAULT '0',
	beyond_resign varchar(4) DEFAULT '0',
	transmem_status char(1) DEFAULT '0',
	transmem_type varchar(6),
	dividend_status char(1) DEFAULT '0',
	resign_group varchar(6)
) ;
COMMENT ON TABLE sc_mem_m_ucf_resign_cause IS E'!N?????????????? - ????????????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_ucf_resign_cause.resign_cause_code IS E'!N????N!!MM!';
COMMENT ON COLUMN sc_mem_m_ucf_resign_cause.resign_cause_name IS E'!N??????N!!MM!';
ALTER TABLE sc_mem_m_ucf_resign_cause ADD PRIMARY KEY (resign_cause_code);


