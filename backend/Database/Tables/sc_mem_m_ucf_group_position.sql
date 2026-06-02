CREATE TABLE sc_mem_m_ucf_group_position (
	group_position varchar(6) NOT NULL,
	description varchar(50),
	grooup_contract char(1) DEFAULT '0',
	retire_age_male numeric(38) DEFAULT 0,
	retire_age_female numeric(38) DEFAULT 0,
	mproc_lon smallint DEFAULT 1,
	salary_time smallint DEFAULT 1,
	group_report varchar(6) DEFAULT '00',
	retire_loan_install numeric(38),
	salbal_percent decimal(6,4) DEFAULT 0,
	sort_order integer DEFAULT 0
) ;
COMMENT ON TABLE sc_mem_m_ucf_group_position IS E'!N?????????????? - ???????????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_ucf_group_position.description IS E'!N???????????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_ucf_group_position.grooup_contract IS E'!N???????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_ucf_group_position.group_position IS E'!N????N!!MM!';
COMMENT ON COLUMN sc_mem_m_ucf_group_position.retire_age_female IS E'!N?????????(?)N!!MM!';
COMMENT ON COLUMN sc_mem_m_ucf_group_position.retire_age_male IS E'!N?????????(?)N!!MM!';
ALTER TABLE sc_mem_m_ucf_group_position ADD PRIMARY KEY (group_position);


