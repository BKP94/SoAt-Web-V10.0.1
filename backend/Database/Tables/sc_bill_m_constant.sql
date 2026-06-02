CREATE TABLE sc_bill_m_constant (
	coop_registered_no varchar(15) NOT NULL,
	payment_item_size bigint DEFAULT 0,
	split_screen char(1),
	bill_share_status char(1),
	bill_deposit_status char(1),
	bill_loan_status char(1),
	bill_keep_status char(1),
	bill_mem_status char(1),
	bill_etc_status char(1),
	size_bank_code varchar(6),
	size_loan_contract varchar(6),
	size_dep_account varchar(6),
	loancountperiod char(1),
	sharecountperiod char(1),
	loan_method_payment numeric(38) DEFAULT 0
) ;
ALTER TABLE sc_bill_m_constant ADD PRIMARY KEY (coop_registered_no);
ALTER TABLE sc_bill_m_constant ALTER COLUMN coop_registered_no SET NOT NULL;


