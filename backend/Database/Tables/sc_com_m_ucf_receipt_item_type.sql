CREATE TABLE sc_com_m_ucf_receipt_item_type (
	item_type_id varchar(6) NOT NULL,
	item_type_name varchar(50),
	sign_flag double precision,
	print_code varchar(6),
	group_item varchar(3),
	sort_order smallint DEFAULT 0,
	mpay_code varchar(3),
	mpay_reftype varchar(6) DEFAULT '00',
	mpay_account varchar(8),
	post_to_dep_no varchar(15),
	post_to_dep_type varchar(6),
	open_auto char(1)
) ;
COMMENT ON TABLE sc_com_m_ucf_receipt_item_type IS E'!NN!';
COMMENT ON COLUMN sc_com_m_ucf_receipt_item_type.group_item IS E'!N???????????N!!MM!';
COMMENT ON COLUMN sc_com_m_ucf_receipt_item_type.item_type_id IS E'!N??????????N!!MM!';
COMMENT ON COLUMN sc_com_m_ucf_receipt_item_type.item_type_name IS E'!N????????N!!MM!';
COMMENT ON COLUMN sc_com_m_ucf_receipt_item_type.print_code IS E'!N????????????N!!MM!';
ALTER TABLE sc_com_m_ucf_receipt_item_type ADD PRIMARY KEY (item_type_id);


