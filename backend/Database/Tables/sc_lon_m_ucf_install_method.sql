CREATE TABLE sc_lon_m_ucf_install_method (
	item_type varchar(3) NOT NULL,
	item_desc varchar(35),
	system_code varchar(3),
	active_status char(1),
	sort_order numeric(38) DEFAULT 0,
	real_keep_post char(1),
	bank_id varchar(6),
	keep_from_agent char(1) DEFAULT '0',
	keep_from_file char(1) DEFAULT '0',
	keep_from_keeeping char(1),
	keep_multi_time char(1) DEFAULT '0'
) ;
COMMENT ON TABLE sc_lon_m_ucf_install_method IS E'!N???????? - ??????????????????N!!MM!';
COMMENT ON COLUMN sc_lon_m_ucf_install_method.active_status IS E'!N??????????N!!MM!';
COMMENT ON COLUMN sc_lon_m_ucf_install_method.item_desc IS E'!N??????????N!!MM!';
COMMENT ON COLUMN sc_lon_m_ucf_install_method.item_type IS E'!N????????????????N!!MM!';
COMMENT ON COLUMN sc_lon_m_ucf_install_method.real_keep_post IS E'!N????????????????????????N!!MM!';
COMMENT ON COLUMN sc_lon_m_ucf_install_method.sort_order IS E'!N??????????N!!MM!';
ALTER TABLE sc_lon_m_ucf_install_method ADD PRIMARY KEY (item_type);


