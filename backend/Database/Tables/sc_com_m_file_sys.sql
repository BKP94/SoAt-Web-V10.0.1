CREATE TABLE sc_com_m_file_sys (
	file_sys varchar(6) NOT NULL,
	shot_app varchar(3),
	file_desc varchar(50),
	active_status char(1) DEFAULT '0',
	transfer_type char(1) DEFAULT 'X',
	saveas_colheading char(1) DEFAULT '0',
	dataobject_arg varchar(30),
	dataobject_data varchar(30),
	exec_preload varchar(60),
	exec_prepost_fp varchar(60),
	exec_prepost_sp varchar(60),
	exec_post varchar(60),
	config_string varchar(1000),
	bank_fin varchar(6),
	post_confirm_fp varchar(60),
	disable_status char(1)
) ;
ALTER TABLE sc_com_m_file_sys ADD PRIMARY KEY (file_sys);


