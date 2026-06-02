CREATE TABLE sc_inv_money_sheet_rep (
	account_year double precision NOT NULL,
	plan_number double precision NOT NULL,
	moneysheet_seq double precision NOT NULL,
	month_1 decimal(15,2) DEFAULT 0.00,
	month_2 decimal(15,2) DEFAULT 0.00,
	month_3 decimal(15,2) DEFAULT 0.00,
	month_4 decimal(15,2) DEFAULT 0.00,
	month_5 decimal(15,2) DEFAULT 0.00,
	month_6 decimal(15,2) DEFAULT 0.00,
	month_7 decimal(15,2) DEFAULT 0.00,
	month_8 decimal(15,2) DEFAULT 0.00,
	month_9 decimal(15,2) DEFAULT 0.00,
	month_10 decimal(15,2) DEFAULT 0.00,
	month_11 decimal(15,2) DEFAULT 0.00,
	month_12 decimal(15,2) DEFAULT 0.00
) ;
ALTER TABLE sc_inv_money_sheet_rep ADD PRIMARY KEY (account_year,plan_number,moneysheet_seq);
ALTER TABLE sc_inv_money_sheet_rep ALTER COLUMN account_year SET NOT NULL;
ALTER TABLE sc_inv_money_sheet_rep ALTER COLUMN plan_number SET NOT NULL;
ALTER TABLE sc_inv_money_sheet_rep ALTER COLUMN moneysheet_seq SET NOT NULL;


