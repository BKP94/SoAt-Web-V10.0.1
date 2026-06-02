CREATE TABLE sc_mem_m_ucf_position (
	position_code varchar(6) NOT NULL,
	position_name varchar(150),
	group_position varchar(6),
	paid_fdm char(1) DEFAULT '0',
	sort_order integer DEFAULT 0
) ;
COMMENT ON TABLE sc_mem_m_ucf_position IS E'!N?????????????? - ??????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_ucf_position.position_code IS E'!N????N!!MM!';
COMMENT ON COLUMN sc_mem_m_ucf_position.position_name IS E'!N??????????N!!MM!';
ALTER TABLE sc_mem_m_ucf_position ADD PRIMARY KEY (position_code);


