CREATE TABLE sc_crm_receipt_item (
	receipt_no varchar(10) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	money_receive decimal(15,2) DEFAULT 0,
	entry_id varchar(16),
	entry_pc varchar(3),
	entry_date timestamp,
	entry_br varchar(6),
	cancel_id varchar(16),
	cancel_date timestamp,
	cancel_branch varchar(6),
	cancel_code varchar(3),
	cancel_status char(1) DEFAULT '0',
	receipt_code varchar(4),
	money_balance decimal(15,2) DEFAULT 0
) ;
ALTER TABLE sc_crm_receipt_item ADD PRIMARY KEY (receipt_no,seq_no);


