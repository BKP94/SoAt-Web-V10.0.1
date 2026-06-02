CREATE TABLE sc_com_m_file_sys_config (
	file_sys varchar(10) NOT NULL,
	file_desc varchar(50),
	active_status char(1) DEFAULT '0',
	transfer_type char(1) DEFAULT 'X',
	saveas_colheading char(1) DEFAULT '0',
	criteria_code varchar(50) NOT NULL,
	data_view varchar(60),
	exec_preload varchar(60),
	exec_post varchar(60),
	remark varchar(500),
	sort_order integer
) ;
ALTER TABLE sc_com_m_file_sys_config ADD PRIMARY KEY (file_sys);
ALTER TABLE sc_com_m_file_sys_config ALTER COLUMN file_sys SET NOT NULL;
ALTER TABLE sc_com_m_file_sys_config ALTER COLUMN criteria_code SET NOT NULL;


