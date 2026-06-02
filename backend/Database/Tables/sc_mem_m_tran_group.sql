CREATE TABLE sc_mem_m_tran_group (
	doc_no varchar(10) NOT NULL,
	membership_no varchar(15),
	group_old varchar(6),
	group_new varchar(6),
	entry_date timestamp,
	entry_id varchar(15),
	app_status char(1),
	app_date timestamp,
	app_id varchar(15),
	group_con_old varchar(6),
	group_con_new varchar(6),
	remark varchar(100),
	other_keep char(1) DEFAULT '0',
	share_balance decimal(15,2) DEFAULT 0.00,
	emer_balance decimal(15,2) DEFAULT 0.00,
	norm_balance decimal(15,2) DEFAULT 0.00,
	spec_balance decimal(15,2) DEFAULT 0.00,
	fund_balance decimal(15,2) DEFAULT 0.00,
	resign_status char(1) DEFAULT '0',
	bank_status char(1) DEFAULT '0',
	bank_id varchar(6),
	bank_acc_no varchar(15),
	other_group char(1) DEFAULT '0',
	up_country char(1) DEFAULT '0'
) ;
ALTER TABLE sc_mem_m_tran_group ADD PRIMARY KEY (doc_no);


