CREATE TABLE sc_crm_receipt (
	receipt_no varchar(10) NOT NULL,
	membership_no varchar(15),
	member_group_no varchar(15),
	receipt_date timestamp,
	receipt_status char(1) DEFAULT '0',
	money_recieve decimal(15,2) DEFAULT 0,
	remark varchar(100),
	entry_id varchar(16),
	entry_pc varchar(3),
	entry_date timestamp,
	entry_br varchar(6),
	pay_type varchar(6) DEFAULT '00',
	cancel_id varchar(16),
	cancel_date timestamp,
	cancel_branch varchar(6),
	cancel_code varchar(3),
	cancel_status char(1) DEFAULT '0'
) ;
ALTER TABLE sc_crm_receipt ADD PRIMARY KEY (receipt_no);


