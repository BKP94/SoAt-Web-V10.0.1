CREATE TABLE sc_lon_m_ucf_loan_card_item (
	item_type_code varchar(6) NOT NULL,
	item_type_description varchar(50),
	sign_status double precision,
	print_code varchar(10),
	item_adjust varchar(6),
	add_loan char(1) DEFAULT '0'
) ;
ALTER TABLE sc_lon_m_ucf_loan_card_item ADD PRIMARY KEY (item_type_code);
ALTER TABLE sc_lon_m_ucf_loan_card_item ALTER COLUMN item_type_code SET NOT NULL;


