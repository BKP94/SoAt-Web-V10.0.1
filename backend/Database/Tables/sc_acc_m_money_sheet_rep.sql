CREATE TABLE sc_acc_m_money_sheet_rep (
	moneysheet_code varchar(8) NOT NULL,
	seq_no integer NOT NULL DEFAULT 0,
	column_heading varchar(50),
	account_year integer DEFAULT 0,
	start_date timestamp,
	end_date timestamp
) ;
COMMENT ON TABLE sc_acc_m_money_sheet_rep IS E'!NN!';
ALTER TABLE sc_acc_m_money_sheet_rep ADD PRIMARY KEY (moneysheet_code,seq_no);


