CREATE TABLE sc_acc_m_money_sheet_det (
	moneysheet_code varchar(8) NOT NULL,
	moneysheet_seq double precision NOT NULL,
	data_type varchar(6),
	data_group double precision,
	data_desc varchar(500),
	description varchar(200),
	amount1 decimal(15,2),
	amount2 decimal(15,2),
	percent1 decimal(10,6),
	percent2 decimal(6,2),
	percent_group varchar(5),
	upperline_status char(1),
	underline_status char(1),
	fontbold_status char(1),
	novisible char(1),
	account_id varchar(8),
	account_level double precision,
	percent4 decimal(6,2) DEFAULT 0,
	percent3 decimal(10,6) DEFAULT 0,
	amount3 decimal(15,2) DEFAULT 0,
	amount4 decimal(15,2) DEFAULT 0,
	amount5 decimal(15,2) DEFAULT 0,
	amount6 decimal(15,2) DEFAULT 0,
	percent5 decimal(6,2) DEFAULT 0,
	percent6 decimal(6,2) DEFAULT 0
) ;
COMMENT ON TABLE sc_acc_m_money_sheet_det IS E'!NN!';
ALTER TABLE sc_acc_m_money_sheet_det ADD PRIMARY KEY (moneysheet_code,moneysheet_seq);


