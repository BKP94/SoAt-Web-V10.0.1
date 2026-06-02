CREATE TABLE sc_dep_m_saving_deposit_cond (
	deposit_type_code varchar(6) NOT NULL,
	period_calculate_bonus double precision,
	withdraw_count double precision,
	withdraw_month double precision,
	charge_money_rate1 decimal(15,2),
	charge_money_rate2 decimal(15,2),
	charge_percent_rate1 decimal(15,2),
	charge_percent_rate2 decimal(15,2),
	method_fee double precision,
	method_paid_fee double precision,
	op_compound_date timestamp,
	stm_compound_date timestamp,
	close_typecode varchar(6),
	charge_money_max1 decimal(15,2) DEFAULT 0,
	charge_money_max2 decimal(15,2) DEFAULT 0,
	deposit_widtraw decimal(15,2) DEFAULT 0,
	deposit_widtraw_count double precision DEFAULT 0,
	deposit_witdraw_type char(1) DEFAULT '0',
	paid_fee_outside char(1) DEFAULT '0',
	complex_fixed char(1) DEFAULT '0',
	withdraw_due timestamp
) ;
COMMENT ON TABLE sc_dep_m_saving_deposit_cond IS E'!NN!';
ALTER TABLE sc_dep_m_saving_deposit_cond ADD PRIMARY KEY (deposit_type_code);


