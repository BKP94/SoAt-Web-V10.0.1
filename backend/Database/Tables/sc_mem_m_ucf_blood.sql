CREATE TABLE sc_mem_m_ucf_blood (
	blood_code varchar(6) NOT NULL,
	blood_desc varchar(15)
) ;
COMMENT ON TABLE sc_mem_m_ucf_blood IS E'!NN!';
ALTER TABLE sc_mem_m_ucf_blood ADD PRIMARY KEY (blood_code);


