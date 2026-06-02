CREATE TABLE sc_cnt_m_status_active (
	status_code varchar(50) NOT NULL,
	active_status char(1) DEFAULT '0',
	code_desc varchar(250),
	install_time varchar(23) DEFAULT to_char(statement_timestamp(),'DD-MM-YYYY HH24:MI:SS.MS')
) ;
ALTER TABLE sc_cnt_m_status_active ADD PRIMARY KEY (status_code);


