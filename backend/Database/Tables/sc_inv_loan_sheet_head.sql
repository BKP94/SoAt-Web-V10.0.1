CREATE TABLE sc_inv_loan_sheet_head (
	membership_no varchar(15) NOT NULL,
	sheet_date timestamp NOT NULL,
	bank_debt decimal(15,2) DEFAULT 0.00,
	bank_loan decimal(15,2) DEFAULT 0.00,
	loanshot_depin decimal(15,2) DEFAULT 0.00,
	profit_share decimal(15,2) DEFAULT 0.00,
	profit_cap decimal(15,2) DEFAULT 0.00,
	profit_asset decimal(15,2) DEFAULT 0.00,
	profit_income decimal(15,2) DEFAULT 0.00,
	income_cap decimal(15,2) DEFAULT 0.00,
	loanint decimal(15,2) DEFAULT 0.00,
	cap_asset decimal(15,2) DEFAULT 0.00,
	debt_asset decimal(15,2) DEFAULT 0.00,
	depin_asset decimal(15,2) DEFAULT 0.00,
	depin_debt decimal(15,2) DEFAULT 0.00,
	sharegrow decimal(15,2) DEFAULT 0.00,
	debt_cap decimal(15,2) DEFAULT 0.00
) ;
ALTER TABLE sc_inv_loan_sheet_head ADD PRIMARY KEY (membership_no,sheet_date);
ALTER TABLE sc_inv_loan_sheet_head ALTER COLUMN membership_no SET NOT NULL;
ALTER TABLE sc_inv_loan_sheet_head ALTER COLUMN sheet_date SET NOT NULL;


