CREATE TABLE sc_crm_receipt_constant (
	receipt_code varchar(4) NOT NULL,
	receipt_desc varchar(100),
	visible_status char(1) DEFAULT '0',
	order_no numeric(38) DEFAULT 0
) ;
ALTER TABLE sc_crm_receipt_constant ADD PRIMARY KEY (receipt_code);


