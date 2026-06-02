CREATE TABLE sc_kep_m_ucf_yproc (
	yproc_code varchar(3) NOT NULL,
	yproc_desc varchar(100),
	active_status char(1) DEFAULT '0',
	sort_order numeric(38) DEFAULT 0,
	action_desc varchar(500)
) ;
ALTER TABLE sc_kep_m_ucf_yproc ADD PRIMARY KEY (yproc_code);


