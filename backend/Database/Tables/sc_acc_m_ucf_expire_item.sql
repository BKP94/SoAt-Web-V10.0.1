CREATE TABLE sc_acc_m_ucf_expire_item (
	item_type varchar(3) NOT NULL,
	description varchar(100),
	sign_flag double precision DEFAULT 0,
	print_code varchar(4),
	real_sign_flag double precision DEFAULT 0
) ;
ALTER TABLE sc_acc_m_ucf_expire_item ADD PRIMARY KEY (item_type);
ALTER TABLE sc_acc_m_ucf_expire_item ALTER COLUMN item_type SET NOT NULL;


