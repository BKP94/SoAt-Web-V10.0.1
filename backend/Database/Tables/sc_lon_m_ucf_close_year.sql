CREATE TABLE sc_lon_m_ucf_close_year (
	yproc_code varchar(6) NOT NULL,
	yproc_order smallint,
	yproc_desc varchar(50),
	active_status char(1) DEFAULT '0',
	action_desc varchar(500)
) ;
ALTER TABLE sc_lon_m_ucf_close_year ADD PRIMARY KEY (yproc_code);


