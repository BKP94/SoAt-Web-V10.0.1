CREATE TABLE sc_cnt_m_status_012 (
	status_code char(1) NOT NULL DEFAULT '0',
	status_desc varchar(10)
) ;
COMMENT ON TABLE sc_cnt_m_status_012 IS E'!NN!';
ALTER TABLE sc_cnt_m_status_012 ADD PRIMARY KEY (status_code);


