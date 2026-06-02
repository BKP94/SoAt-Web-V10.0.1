CREATE TABLE sc_crm_member (
	membership_no varchar(15) NOT NULL,
	dead_status char(1) DEFAULT '0',
	dead_date timestamp,
	keeping_status char(1) DEFAULT '0',
	keeping_date timestamp,
	last_payment numeric(38) DEFAULT 0,
	money_stock decimal(15,2) DEFAULT 0,
	pay_start numeric(38) DEFAULT 0,
	pay_end numeric(38) DEFAULT 0,
	dead_begin double precision DEFAULT 0,
	dead_last double precision DEFAULT 0,
	dead_end double precision DEFAULT 0,
	entry_id varchar(16),
	entry_pc varchar(3),
	entry_date timestamp,
	entry_br varchar(6),
	fee_status char(1) DEFAULT '0',
	year_status char(1) DEFAULT '0',
	reference_memno varchar(15),
	parent_code varchar(6) DEFAULT '00'
) ;
ALTER TABLE sc_crm_member ADD PRIMARY KEY (membership_no);


