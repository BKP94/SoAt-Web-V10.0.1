CREATE TABLE sc_lon_m_loan_addloan (
	loan_contract_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	operate_date timestamp,
	period_payment_old double precision DEFAULT 0,
	period_payment_new double precision DEFAULT 0,
	loan_installment_old double precision DEFAULT 0,
	loan_installment_new double precision DEFAULT 0,
	ref_seqno double precision DEFAULT 0,
	cancel_status char(1) DEFAULT '0',
	entry_date timestamp,
	entry_br varchar(6),
	entry_id varchar(16),
	cancel_date timestamp,
	cancel_br varchar(6),
	cancel_id varchar(16),
	addloan_amount double precision DEFAULT 0,
	balance_after double precision DEFAULT 0,
	money_type_id char(3) NOT NULL DEFAULT 'CSH',
	intarr_add double precision DEFAULT 0,
	addloan_balance double precision DEFAULT 0,
	vourcher_no varchar(30),
	last_period double precision DEFAULT 0,
	bank_code varchar(6),
	bank_acc_no varchar(20),
	fin_status char(1) DEFAULT '0',
	ref_loan_doc_no varchar(15),
	int_first_status char(1) DEFAULT '0',
	int_first decimal(15,2) DEFAULT 0,
	int_first_to timestamp,
	receipt_no varchar(15),
	addloan_real decimal(15,2) DEFAULT 0,
	trans_bank_status char(1) DEFAULT '0'
) ;
ALTER TABLE sc_lon_m_loan_addloan ADD PRIMARY KEY (loan_contract_no,seq_no);
ALTER TABLE sc_lon_m_loan_addloan ALTER COLUMN loan_contract_no SET NOT NULL;
ALTER TABLE sc_lon_m_loan_addloan ALTER COLUMN seq_no SET NOT NULL;
ALTER TABLE sc_lon_m_loan_addloan ALTER COLUMN money_type_id SET NOT NULL;


