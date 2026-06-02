CREATE TABLE sc_fin_ucf_keeping_group (
	member_group_keeping varchar(15) NOT NULL,
	member_group_name varchar(100),
	account_id varchar(8),
	mpost_from_file char(1) DEFAULT '0',
	mproc_apart char(1) DEFAULT '0',
	system_satatus char(1) DEFAULT '0',
	default_money_type varchar(3),
	default_bank_fin varchar(6),
	mpost_receive_money char(1) DEFAULT '0',
	control_id smallint DEFAULT 1,
	paid_status char(1) DEFAULT '0',
	agent_not char(1) DEFAULT '0',
	head_name varchar(100),
	sort_order integer DEFAULT 999,
	member_group_gr varchar(15)
) ;
ALTER TABLE sc_fin_ucf_keeping_group ADD PRIMARY KEY (member_group_keeping);
ALTER TABLE sc_fin_ucf_keeping_group ALTER COLUMN member_group_keeping SET NOT NULL;


