CREATE TABLE sc_com_m_file_sys_data (
	criteria_code varchar(50) NOT NULL,
	seq_no smallint NOT NULL,
	caption_name varchar(100),
	horizon_name varchar(20),
	footer_formula varchar(20)
) ;
ALTER TABLE sc_com_m_file_sys_data ADD PRIMARY KEY (criteria_code,seq_no);
ALTER TABLE sc_com_m_file_sys_data ALTER COLUMN criteria_code SET NOT NULL;
ALTER TABLE sc_com_m_file_sys_data ALTER COLUMN seq_no SET NOT NULL;


