CREATE TABLE sc_fund_ucf_return_method (
	return_method varchar(6) NOT NULL DEFAULT '00',
	item_desc varchar(30)
) ;
ALTER TABLE sc_fund_ucf_return_method ADD PRIMARY KEY (return_method);
ALTER TABLE sc_fund_ucf_return_method ALTER COLUMN return_method SET NOT NULL;


