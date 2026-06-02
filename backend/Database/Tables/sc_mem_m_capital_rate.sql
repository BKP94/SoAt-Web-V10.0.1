CREATE TABLE sc_mem_m_capital_rate (
	lon_year numeric(38) NOT NULL,
	share_rate decimal(7,6),
	share_round_money decimal(4,2) DEFAULT 0,
	share_round_method char(1) DEFAULT '0',
	lonint_rate decimal(7,6),
	lonint_round_money decimal(4,2) DEFAULT 0,
	lonint_round_method char(1) DEFAULT '0',
	entry_id varchar(16),
	entry_date timestamp,
	entry_br varchar(6),
	entry_pc varchar(3),
	share_reward decimal(15,2) DEFAULT 0,
	money_reward decimal(15,2)
) ;
ALTER TABLE sc_mem_m_capital_rate ADD PRIMARY KEY (lon_year);


