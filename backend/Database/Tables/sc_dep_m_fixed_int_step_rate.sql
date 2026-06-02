CREATE TABLE sc_dep_m_fixed_int_step_rate (
	deposit_type_code varchar(6) NOT NULL,
	month_due double precision NOT NULL,
	interest_step decimal(15,2) NOT NULL DEFAULT 0,
	effective_date timestamp NOT NULL,
	interest_rate decimal(8,6) DEFAULT 0,
	calc_method char(1) DEFAULT '0',
	int_month_status char(1),
	period_int_month double precision,
	int_month_paid_status char(1),
	ret_int_month_status char(1),
	ret_int_month_type varchar(6),
	mininum_dep_times double precision,
	method_ret_paid_int char(1),
	method_int_ret char(1),
	minbalancefornextdeposit decimal(15,2)
) ;
ALTER TABLE sc_dep_m_fixed_int_step_rate ADD PRIMARY KEY (deposit_type_code,month_due,interest_step,effective_date);


