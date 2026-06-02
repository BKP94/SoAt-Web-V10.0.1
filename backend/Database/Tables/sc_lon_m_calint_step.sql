CREATE TABLE sc_lon_m_calint_step (
	calintstep_code varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	calint_mode char(1) DEFAULT '0',
	calint_loantype varchar(6) DEFAULT '00',
	date_begin timestamp,
	date_end timestamp,
	principal_amount decimal(15,2) DEFAULT 0,
	interest_rate decimal(10,6) DEFAULT 0,
	day_count decimal(15,2) DEFAULT 0,
	day_inyear double precision DEFAULT 0,
	interest_cal decimal(15,2) DEFAULT 0
) ;
COMMENT ON TABLE sc_lon_m_calint_step IS E'!NN!';
CREATE INDEX idx_calint_step_head ON sc_lon_m_calint_step (calintstep_code);
ALTER TABLE sc_lon_m_calint_step ADD PRIMARY KEY (calintstep_code,seq_no);


