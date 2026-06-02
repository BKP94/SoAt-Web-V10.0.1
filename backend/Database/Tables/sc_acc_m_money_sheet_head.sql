CREATE TABLE sc_acc_m_money_sheet_head (
	moneysheet_code varchar(8) NOT NULL,
	moneysheet_name varchar(100),
	report_heading varchar(100),
	c1_heading varchar(50),
	c2_heading varchar(50),
	c1_compute varchar(18),
	c2_compute varchar(18),
	c1_percent_status char(1),
	c2_percent_status char(1),
	process_column double precision,
	zero_show_status char(1),
	percent_adjust_status char(1),
	compare_status char(1) DEFAULT '0',
	active_status char(1) DEFAULT '1',
	invest_status char(1) DEFAULT '0'
) ;
COMMENT ON TABLE sc_acc_m_money_sheet_head IS E'!NN!';
ALTER TABLE sc_acc_m_money_sheet_head ADD PRIMARY KEY (moneysheet_code);


