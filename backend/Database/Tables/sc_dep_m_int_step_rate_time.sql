CREATE TABLE sc_dep_m_int_step_rate_time (
	deposit_type_code varchar(6) NOT NULL DEFAULT '00',
	interest_step decimal(15,2) NOT NULL DEFAULT 0,
	month_effect double precision NOT NULL DEFAULT 0,
	int_rate decimal(10,6) DEFAULT 0
) ;
ALTER TABLE sc_dep_m_int_step_rate_time ADD PRIMARY KEY (deposit_type_code,interest_step,month_effect);
ALTER TABLE sc_dep_m_int_step_rate_time ALTER COLUMN deposit_type_code SET NOT NULL;
ALTER TABLE sc_dep_m_int_step_rate_time ALTER COLUMN interest_step SET NOT NULL;
ALTER TABLE sc_dep_m_int_step_rate_time ALTER COLUMN month_effect SET NOT NULL;


