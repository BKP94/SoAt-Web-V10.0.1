CREATE TABLE sc_lon_m_loan_looping_paid (
	loan_contract_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	period_payment_old double precision DEFAULT 0,
	period_payment_new double precision DEFAULT 0,
	loan_installment_old double precision DEFAULT 0,
	loan_installment_new double precision DEFAULT 0,
	ref_seqno double precision DEFAULT 0,
	cancel_status char(1) DEFAULT '0',
	cancel_date timestamp,
	cancel_id varchar(16),
	vourcher_no varchar(30),
	money_type_id char(3)
) ;
CREATE INDEX idx_lon_looping_refseq ON sc_lon_m_loan_looping_paid (loan_contract_no, ref_seqno);
ALTER TABLE sc_lon_m_loan_looping_paid ADD PRIMARY KEY (loan_contract_no,seq_no);
ALTER TABLE sc_lon_m_loan_looping_paid ALTER COLUMN loan_contract_no SET NOT NULL;
ALTER TABLE sc_lon_m_loan_looping_paid ALTER COLUMN seq_no SET NOT NULL;


