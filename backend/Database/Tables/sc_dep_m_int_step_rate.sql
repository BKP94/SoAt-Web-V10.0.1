CREATE TABLE sc_dep_m_int_step_rate (
	deposit_type_code varchar(6) NOT NULL,
	interest_step decimal(15,2) NOT NULL,
	effective_date timestamp NOT NULL,
	interest_rate decimal(8,6),
	month_due double precision DEFAULT 0,
	intrate_year_2 decimal(10,6)
) ;
COMMENT ON TABLE sc_dep_m_int_step_rate IS E'!NN!';
CREATE INDEX idx_dep_inttype ON sc_dep_m_int_step_rate (deposit_type_code);
CREATE INDEX idx_dep_int_eff_date ON sc_dep_m_int_step_rate (effective_date);
CREATE INDEX idx_dep_int_step ON sc_dep_m_int_step_rate (interest_step);
ALTER TABLE sc_dep_m_int_step_rate ADD PRIMARY KEY (deposit_type_code,interest_step,effective_date);


