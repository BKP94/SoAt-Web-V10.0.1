CREATE TABLE sc_crm_mem_receipt_item (
	membership_no varchar(15) NOT NULL,
	receipt_year numeric(38) NOT NULL DEFAULT 0,
	receipt_month numeric(38) NOT NULL DEFAULT 0,
	seq_no double precision NOT NULL DEFAULT 0,
	member_own_no varchar(7),
	receipt_code varchar(4),
	money_amount decimal(15,2) DEFAULT 0,
	pay_status char(1) DEFAULT '0',
	real_payment decimal(15,2) DEFAULT 0
) ;
ALTER TABLE sc_crm_mem_receipt_item ADD PRIMARY KEY (membership_no,receipt_year,receipt_month,seq_no);


