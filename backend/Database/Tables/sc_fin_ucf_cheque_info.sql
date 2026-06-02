CREATE TABLE sc_fin_ucf_cheque_info (
	info_type varchar(6) NOT NULL,
	info_name varchar(100),
	calc_desc varchar(50),
	active_status char(1) DEFAULT '0',
	sort_order integer,
	note varchar(1000)
) ;
ALTER TABLE sc_fin_ucf_cheque_info ADD PRIMARY KEY (info_type);
ALTER TABLE sc_fin_ucf_cheque_info ALTER COLUMN info_type SET NOT NULL;


