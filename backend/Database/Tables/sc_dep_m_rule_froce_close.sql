CREATE TABLE sc_dep_m_rule_froce_close (
	deposit_type_code varchar(6) NOT NULL DEFAULT '00',
	withdrawfroce_close char(1) DEFAULT '0',
	withdraw_predue_froce_close char(1) DEFAULT '0',
	close_preduewith_tax char(1) DEFAULT '0',
	max_nodep double precision DEFAULT 0,
	max_nodep_continue double precision DEFAULT 0,
	min_depmonthly double precision DEFAULT 0,
	withdraw_bf_due_method char(1) DEFAULT '0',
	withdraw_bf_use_type_code varchar(6) DEFAULT '00',
	ret_int_paid char(1) DEFAULT '0',
	paidintfirstwhendue char(1) DEFAULT '0',
	paidint_bycountopen char(1) DEFAULT '0',
	paidint_monthly_bycountopen double precision DEFAULT 0,
	afterdue_paidint_type_code varchar(6) DEFAULT '00',
	afterdue_depcontinue char(1) DEFAULT '0',
	tax_status char(1) DEFAULT '0',
	maxnotdep_donotdep char(1) DEFAULT '0',
	maxnotdep_calint_status char(1) DEFAULT '0',
	warning_equa_dep char(1) DEFAULT '0',
	maxnotdepcon_donotdep char(1) DEFAULT '0',
	days_calint_withwrong char(1) DEFAULT '0',
	depdatelast char(1) DEFAULT '0',
	methodnodep char(1) DEFAULT '0',
	afterdue_paidint_monthly double precision DEFAULT 0,
	min_depmonthly_method char(1) DEFAULT '0',
	withdraw_bf_not_intpaid_cal char(1) DEFAULT '0',
	afterdue_setnext_frocedate char(1) DEFAULT '0',
	number_of_month_to_due double precision DEFAULT 0,
	day_deposit_limit double precision DEFAULT 0
) ;
COMMENT ON TABLE sc_dep_m_rule_froce_close IS E'!NN!';
ALTER TABLE sc_dep_m_rule_froce_close ADD PRIMARY KEY (deposit_type_code);


