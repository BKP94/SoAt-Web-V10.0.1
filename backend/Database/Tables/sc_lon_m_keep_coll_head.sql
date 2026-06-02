CREATE TABLE sc_lon_m_keep_coll_head (
	keep_coll_doc_no varchar(15) NOT NULL,
	keep_coll_date timestamp,
	membership_no varchar(15),
	loan_contract_no varchar(15),
	period_payment_amount decimal(15,2) DEFAULT 0.00,
	loan_payment_type_code varchar(6),
	principal_arr_all decimal(15,2) DEFAULT 0.00,
	interest_arrear decimal(15,2) DEFAULT 0.00,
	entry_id varchar(16),
	entry_date timestamp,
	entry_pc varchar(3),
	entry_br varchar(6),
	cancel_status char(1) DEFAULT '0',
	cancel_id varchar(16),
	cancel_date timestamp,
	cancel_pc varchar(3),
	cancel_br varchar(6),
	approve_status char(1) DEFAULT '0',
	approve_id varchar(16),
	approve_date timestamp,
	approve_pc varchar(3),
	approve_br varchar(6),
	proc_year integer,
	proc_month integer
) ;
ALTER TABLE sc_lon_m_keep_coll_head ADD PRIMARY KEY (keep_coll_doc_no);
ALTER TABLE sc_lon_m_keep_coll_head ALTER COLUMN keep_coll_doc_no SET NOT NULL;


