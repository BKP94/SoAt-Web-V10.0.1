CREATE TABLE sc_mem_m_ucf_ocupation (
	occupation_code varchar(6) NOT NULL,
	occupation_description varchar(100)
) ;
COMMENT ON TABLE sc_mem_m_ucf_ocupation IS E'!N?????????????? - ?????N!!MM!';
COMMENT ON COLUMN sc_mem_m_ucf_ocupation.occupation_code IS E'!N????N!!MM!';
COMMENT ON COLUMN sc_mem_m_ucf_ocupation.occupation_description IS E'!N?????N!!MM!';
ALTER TABLE sc_mem_m_ucf_ocupation ADD PRIMARY KEY (occupation_code);


