CREATE TABLE sc_mem_m_ucf_province (
	province_code varchar(6) NOT NULL,
	province_name varchar(50),
	inorder integer,
	control_id smallint,
	shot_name varchar(10)
) ;
COMMENT ON TABLE sc_mem_m_ucf_province IS E'!N?????????????? - ???????N!!MM!';
COMMENT ON COLUMN sc_mem_m_ucf_province.province_code IS E'!N???????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_ucf_province.province_name IS E'!N???????????N!!MM!';
ALTER TABLE sc_mem_m_ucf_province ADD PRIMARY KEY (province_code);


