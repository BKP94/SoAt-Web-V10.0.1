CREATE TABLE sc_inv_money_sheet_invbal (
	account_year double precision NOT NULL,
	moneysheet_code varchar(8) NOT NULL,
	moneysheet_seq double precision NOT NULL,
	amount decimal(15,2) DEFAULT 0.00
) ;
ALTER TABLE sc_inv_money_sheet_invbal ADD PRIMARY KEY (account_year,moneysheet_code,moneysheet_seq);
ALTER TABLE sc_inv_money_sheet_invbal ALTER COLUMN account_year SET NOT NULL;
ALTER TABLE sc_inv_money_sheet_invbal ALTER COLUMN moneysheet_code SET NOT NULL;
ALTER TABLE sc_inv_money_sheet_invbal ALTER COLUMN moneysheet_seq SET NOT NULL;


