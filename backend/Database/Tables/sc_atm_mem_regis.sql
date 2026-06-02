CREATE TABLE sc_atm_mem_regis (
	membership_no varchar(15) NOT NULL,
	atm_open_status char(1) DEFAULT '0',
	open_lon char(1) DEFAULT '0',
	open_dep char(1) DEFAULT '0',
	current_account varchar(15)
) ;
ALTER TABLE sc_atm_mem_regis ADD PRIMARY KEY (membership_no);


