CREATE TABLE sc_acc_m_ucf_expire_item_type (
	item_type varchar(3) NOT NULL,
	description varchar(100),
	sign_flag double precision,
	print_code varchar(4),
	real_sign_flag double precision
) ;
COMMENT ON TABLE sc_acc_m_ucf_expire_item_type IS E'!NN!';
ALTER TABLE sc_acc_m_ucf_expire_item_type ADD PRIMARY KEY (item_type);


