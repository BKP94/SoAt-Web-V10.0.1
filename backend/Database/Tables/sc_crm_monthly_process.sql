CREATE TABLE sc_crm_monthly_process (
	keeping_date timestamp NOT NULL,
	dead_count numeric(38) DEFAULT 0,
	dead_perunit decimal(15,2) DEFAULT 0,
	keeping_confirm char(1) DEFAULT '0',
	count_member numeric(38) DEFAULT 0
) ;
ALTER TABLE sc_crm_monthly_process ADD PRIMARY KEY (keeping_date);


