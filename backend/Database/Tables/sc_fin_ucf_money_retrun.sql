CREATE TABLE sc_fin_ucf_money_retrun (
	return_method varchar(3) NOT NULL,
	active_status char(1) DEFAULT '0',
	return_desc varchar(100),
	account_id varchar(8),
	form_vourcher_p varchar(100),
	public_capital char(1) DEFAULT '0',
	return_mrt varchar(3) DEFAULT 'SPP',
	app_name varchar(15)
) ;
ALTER TABLE sc_fin_ucf_money_retrun ADD PRIMARY KEY (return_method);


