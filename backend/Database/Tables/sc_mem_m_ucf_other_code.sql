CREATE TABLE sc_mem_m_ucf_other_code (
	mem_type_code varchar(6) NOT NULL,
	mem_type_desc varchar(250),
	sort_order decimal(15,2) DEFAULT 0
) ;
COMMENT ON TABLE sc_mem_m_ucf_other_code IS E'!N?????????????? - ??????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_ucf_other_code.mem_type_code IS E'!N????N!!MM!';
COMMENT ON COLUMN sc_mem_m_ucf_other_code.mem_type_desc IS E'!N??????????N!!MM!';
ALTER TABLE sc_mem_m_ucf_other_code ADD PRIMARY KEY (mem_type_code);


