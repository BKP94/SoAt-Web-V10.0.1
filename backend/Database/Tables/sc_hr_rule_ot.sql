CREATE TABLE sc_hr_rule_ot (
	dayofweek double precision NOT NULL DEFAULT 0,
	seq_no double precision NOT NULL DEFAULT 0,
	time_begin timestamp,
	time_end timestamp,
	ot_rate decimal(10,4) DEFAULT 0
) ;
COMMENT ON TABLE sc_hr_rule_ot IS E'!NN!';
ALTER TABLE sc_hr_rule_ot ADD PRIMARY KEY (dayofweek,seq_no);


