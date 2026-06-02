CREATE TABLE sc_crm_member_dead (
	dead_no double precision NOT NULL DEFAULT 0,
	membership_no varchar(15),
	member_name varchar(250),
	member_group_no varchar(15),
	dead_date timestamp,
	operate_date timestamp,
	keeping_status char(1) DEFAULT '0',
	keeping_date timestamp,
	count_member double precision DEFAULT 0,
	money_receive decimal(15,2) DEFAULT 0,
	receive_status char(1) DEFAULT '0',
	receive_date timestamp,
	receive_full_status char(1) DEFAULT '0',
	remark varchar(100),
	entry_id varchar(16),
	entry_pc varchar(3),
	entry_date timestamp,
	entry_br varchar(6),
	cancel_id varchar(16),
	cancel_date timestamp,
	cancel_branch varchar(6),
	cancel_code varchar(3),
	cancel_status char(1) DEFAULT '0'
) ;
ALTER TABLE sc_crm_member_dead ADD PRIMARY KEY (dead_no);


