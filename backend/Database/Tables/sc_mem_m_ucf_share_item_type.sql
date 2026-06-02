CREATE TABLE sc_mem_m_ucf_share_item_type (
	item_type varchar(6) NOT NULL,
	item_type_description varchar(60),
	sign_flag double precision,
	not_div_in_year char(1),
	cancel_item_ref varchar(5),
	cancel_status char(1) DEFAULT '0',
	item_adjust varchar(6) DEFAULT '00'
) ;
COMMENT ON TABLE sc_mem_m_ucf_share_item_type IS E'!NN!';
COMMENT ON COLUMN sc_mem_m_ucf_share_item_type.item_type IS E'!N????N!!MM!';
COMMENT ON COLUMN sc_mem_m_ucf_share_item_type.item_type_description IS E'!N??????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_ucf_share_item_type.sign_flag IS E'!N????N!!MM!';
ALTER TABLE sc_mem_m_ucf_share_item_type ADD PRIMARY KEY (item_type);


