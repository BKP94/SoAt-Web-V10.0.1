CREATE TABLE sc_mem_m_ucf_marriage_status (
	marriage_status_code char(1) NOT NULL,
	marriage_status varchar(20)
) ;
COMMENT ON TABLE sc_mem_m_ucf_marriage_status IS E'!N?????????????? - ????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_ucf_marriage_status.marriage_status IS E'!N????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_ucf_marriage_status.marriage_status_code IS E'!N????N!!MM!';
ALTER TABLE sc_mem_m_ucf_marriage_status ADD PRIMARY KEY (marriage_status_code);


