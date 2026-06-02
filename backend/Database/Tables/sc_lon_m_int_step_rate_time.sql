CREATE TABLE sc_lon_m_int_step_rate_time (
	loan_type varchar(6) NOT NULL,
	loan_step decimal(15,2) NOT NULL,
	month_effect numeric(38) NOT NULL,
	int_rate decimal(10,6)
) ;
ALTER TABLE sc_lon_m_int_step_rate_time ADD PRIMARY KEY (loan_type,loan_step,month_effect);


