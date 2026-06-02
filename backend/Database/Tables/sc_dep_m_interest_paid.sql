CREATE TABLE sc_dep_m_interest_paid (
	deposit_account_no varchar(15) NOT NULL,
	deposit_type_code varchar(6) NOT NULL,
	seq_no double precision NOT NULL,
	principal decimal(15,2),
	interest_paid decimal(15,2),
	total_balance decimal(15,2),
	enter_acc_no varchar(15),
	int_to_bank decimal(15,2),
	account_bank varchar(25),
	item_type double precision,
	attention_bank varchar(50),
	attention_date timestamp,
	tax_paid decimal(15,2),
	fixed_date timestamp,
	fixed_seq_no double precision,
	fixed_due_status char(1),
	interest_arrear decimal(15,2),
	interest_arrear_date timestamp,
	paid_status char(1),
	officer_id varchar(15),
	operate_date timestamp,
	branch_id varchar(6),
	working_day timestamp,
	ref_doc_no varchar(15),
	client_name varchar(20),
	int_rate decimal(6,4),
	trans_bank_status char(1) DEFAULT '0'
) ;
COMMENT ON TABLE sc_dep_m_interest_paid IS E'!NN!';
CREATE INDEX idx_dep_m_intpaid_opdate ON sc_dep_m_interest_paid (operate_date);
ALTER TABLE sc_dep_m_interest_paid ADD PRIMARY KEY (deposit_account_no,deposit_type_code,seq_no);


