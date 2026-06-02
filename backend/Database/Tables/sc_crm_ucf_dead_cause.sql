CREATE TABLE sc_crm_ucf_dead_cause (
	dead_cause_code varchar(6) NOT NULL DEFAULT '00',
	dead_cause_name varchar(100)
) ;
ALTER TABLE sc_crm_ucf_dead_cause ADD PRIMARY KEY (dead_cause_code);


