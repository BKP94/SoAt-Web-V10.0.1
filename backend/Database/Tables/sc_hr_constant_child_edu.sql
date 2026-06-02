CREATE TABLE sc_hr_constant_child_edu (
	coop_no char(1) NOT NULL DEFAULT '0',
	child_age_limit numeric(38) DEFAULT 0,
	child_type char(1),
	bachelor_limit_peryear decimal(15,2) DEFAULT 0
) ;
COMMENT ON TABLE sc_hr_constant_child_edu IS E'!NN!';
ALTER TABLE sc_hr_constant_child_edu ADD PRIMARY KEY (coop_no);


