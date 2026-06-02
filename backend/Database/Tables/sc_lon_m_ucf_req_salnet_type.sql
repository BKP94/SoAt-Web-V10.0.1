CREATE TABLE sc_lon_m_ucf_req_salnet_type (
	item_code varchar(6) NOT NULL,
	item_code_desc varchar(100),
	item_salnet_type varchar(6),
	sort_order smallint,
	calc_percent decimal(10,6) DEFAULT 0,
	on_firstload char(1) DEFAULT '0',
	is_cal_with_sal char(1) DEFAULT '0',
	fixed_amount decimal(15,2)
) ;
ALTER TABLE sc_lon_m_ucf_req_salnet_type ADD PRIMARY KEY (item_code);


