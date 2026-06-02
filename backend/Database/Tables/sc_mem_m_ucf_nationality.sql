CREATE TABLE sc_mem_m_ucf_nationality (
	nationality_code varchar(6) NOT NULL,
	nationality_description varchar(100)
) ;
COMMENT ON TABLE sc_mem_m_ucf_nationality IS E'!N?????????????? - ???????N!!MM!';
COMMENT ON COLUMN sc_mem_m_ucf_nationality.nationality_code IS E'!N????N!!MM!';
COMMENT ON COLUMN sc_mem_m_ucf_nationality.nationality_description IS E'!N??????????N!!MM!';
ALTER TABLE sc_mem_m_ucf_nationality ADD PRIMARY KEY (nationality_code);


