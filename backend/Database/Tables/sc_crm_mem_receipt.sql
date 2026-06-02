CREATE TABLE sc_crm_mem_receipt (
	membership_no varchar(15) NOT NULL,
	receipt_year numeric(38) NOT NULL DEFAULT 0,
	receipt_month numeric(38) NOT NULL DEFAULT 0,
	receipt_no varchar(10)
) ;
ALTER TABLE sc_crm_mem_receipt ADD PRIMARY KEY (membership_no,receipt_year,receipt_month);


