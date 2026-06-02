CREATE TABLE sc_cls_confirm_cnt (
	confirm_date timestamp NOT NULL,
	confirm_letter timestamp,
	confirm_return timestamp,
	manager_name varchar(50),
	auditor_name varchar(50),
	auditor_address1 varchar(100),
	auditor_address2 varchar(100),
	auditor_address3 varchar(100),
	auditor_address4 varchar(100),
	letter_no varchar(20),
	m0 char(1) DEFAULT '0',
	m1 char(1) DEFAULT '0',
	m2 char(1) DEFAULT '0',
	m3 char(1) DEFAULT '0',
	m4 char(1) DEFAULT '0',
	m5 char(1) DEFAULT '0',
	m6 char(1) DEFAULT '0',
	m7 char(1) DEFAULT '0',
	m8 char(1) DEFAULT '0',
	m9 char(1) DEFAULT '0'
) ;
ALTER TABLE sc_cls_confirm_cnt ADD PRIMARY KEY (confirm_date);
ALTER TABLE sc_cls_confirm_cnt ALTER COLUMN confirm_date SET NOT NULL;


