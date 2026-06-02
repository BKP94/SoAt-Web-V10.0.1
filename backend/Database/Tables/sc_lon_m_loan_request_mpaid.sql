CREATE TABLE sc_lon_m_loan_request_mpaid (
	loan_requestment_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	type_pay_money varchar(3) NOT NULL DEFAULT 'CSH',
	bank_code varchar(6),
	bank_acc_no varchar(20),
	paid_amount decimal(15,2) DEFAULT 0,
	branch_code varchar(6),
	acc_paid_type char(1) DEFAULT '0',
	bank_fin varchar(6),
	other_loan_status char(1),
	other_loan_remark varchar(100),
	period decimal(15,2) DEFAULT 0
) ;
ALTER TABLE sc_lon_m_loan_request_mpaid ADD PRIMARY KEY (loan_requestment_no,seq_no);
ALTER TABLE sc_lon_m_loan_request_mpaid ALTER COLUMN type_pay_money SET NOT NULL;


