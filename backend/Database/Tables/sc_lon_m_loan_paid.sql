CREATE TABLE sc_lon_m_loan_paid (
	loan_contract_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL,
	operate_date timestamp,
	item_type_code varchar(6),
	ref_loan_doc_no varchar(15),
	loan_paid_amount decimal(15,2),
	financial_balance decimal(15,2),
	principal_balance decimal(15,2),
	type_pay_money varchar(3),
	bank_acc_no varchar(15),
	deposit_account_no varchar(15),
	fin_status char(1) DEFAULT '0',
	vourcher_no varchar(30),
	entry_id varchar(16),
	entry_date timestamp,
	entry_pc varchar(3),
	entry_br varchar(6),
	bank_code varchar(6)
) ;
ALTER TABLE sc_lon_m_loan_paid ADD PRIMARY KEY (loan_contract_no,seq_no);


