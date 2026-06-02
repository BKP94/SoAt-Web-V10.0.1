CREATE TABLE sc_mem_m_ucf_graduation (
	graduate_code varchar(6) NOT NULL,
	graduate_description varchar(100)
) ;
COMMENT ON TABLE sc_mem_m_ucf_graduation IS E'!NN!';
ALTER TABLE sc_mem_m_ucf_graduation ADD PRIMARY KEY (graduate_code);


