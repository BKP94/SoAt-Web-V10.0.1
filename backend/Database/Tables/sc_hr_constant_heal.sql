CREATE TABLE sc_hr_constant_heal (
	coop_no varchar(15) NOT NULL,
	heal_limit_cost decimal(15,2) DEFAULT 0,
	heal_limit_bf decimal(15,2) DEFAULT 0,
	child_head_limit_age numeric(38) DEFAULT 0,
	child_notworking_status char(1),
	child_type char(1)
) ;
COMMENT ON TABLE sc_hr_constant_heal IS E'!NN!';
ALTER TABLE sc_hr_constant_heal ADD PRIMARY KEY (coop_no);


