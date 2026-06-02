CREATE TABLE sc_inv_money_sheet (
	moneysheet_code varchar(8) NOT NULL,
	moneysheet_seq double precision NOT NULL,
	data_type varchar(6),
	data_group double precision,
	data_desc varchar(250),
	description varchar(200),
	plan_data varchar(15)
) ;
ALTER TABLE sc_inv_money_sheet ADD PRIMARY KEY (moneysheet_code,moneysheet_seq);
ALTER TABLE sc_inv_money_sheet ALTER COLUMN moneysheet_code SET NOT NULL;
ALTER TABLE sc_inv_money_sheet ALTER COLUMN moneysheet_seq SET NOT NULL;


