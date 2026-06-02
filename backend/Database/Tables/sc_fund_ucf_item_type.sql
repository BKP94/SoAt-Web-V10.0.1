CREATE TABLE sc_fund_ucf_item_type (
	item_type varchar(3) NOT NULL,
	description varchar(70),
	sign_flag double precision,
	print_code varchar(3)
) ;
ALTER TABLE sc_fund_ucf_item_type ADD PRIMARY KEY (item_type);


