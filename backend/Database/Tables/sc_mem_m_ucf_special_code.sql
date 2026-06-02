CREATE TABLE sc_mem_m_ucf_special_code (
	special_code varchar(6) NOT NULL,
	special_desc varchar(100),
	priority_level numeric(38) DEFAULT 0,
	wsheet_save_action varchar(50)
) ;
COMMENT ON TABLE sc_mem_m_ucf_special_code IS E'!NN!';
ALTER TABLE sc_mem_m_ucf_special_code ADD PRIMARY KEY (special_code);


