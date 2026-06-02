CREATE TABLE sc_lon_m_loan_history_old (
	loan_requestment_no char(15) NOT NULL,
	sequence_no double precision NOT NULL,
	loan_contract_no char(15) NOT NULL,
	principal_balance_of_loan decimal(15,2),
	principal_of_loan decimal(15,2),
	interest_arrear decimal(15,2),
	remark char(100),
	interest_amount decimal(15,2),
	payment_amount decimal(15,2),
	last_period double precision,
	clear_focus char(1) NOT NULL,
	interest_return decimal(15,2) NOT NULL,
	principal_pending_holding decimal(15,2) NOT NULL,
	loan_installment smallint NOT NULL,
	clear_target char(1) NOT NULL,
	monthly_pay decimal(15,2) NOT NULL,
	loan_approve_amount decimal(15,2) NOT NULL,
	salary_time double precision NOT NULL,
	monthly_pay_p decimal(15,2) NOT NULL,
	monthly_pay_i decimal(15,2) NOT NULL
) ;
CREATE UNIQUE INDEX sc_lon_m_loan_history_x ON sc_lon_m_loan_history_old (loan_requestment_no, sequence_no);
ALTER TABLE sc_lon_m_loan_history_old ALTER COLUMN loan_requestment_no SET NOT NULL;
ALTER TABLE sc_lon_m_loan_history_old ALTER COLUMN sequence_no SET NOT NULL;
ALTER TABLE sc_lon_m_loan_history_old ALTER COLUMN loan_contract_no SET NOT NULL;
ALTER TABLE sc_lon_m_loan_history_old ALTER COLUMN clear_focus SET NOT NULL;
ALTER TABLE sc_lon_m_loan_history_old ALTER COLUMN interest_return SET NOT NULL;
ALTER TABLE sc_lon_m_loan_history_old ALTER COLUMN principal_pending_holding SET NOT NULL;
ALTER TABLE sc_lon_m_loan_history_old ALTER COLUMN loan_installment SET NOT NULL;
ALTER TABLE sc_lon_m_loan_history_old ALTER COLUMN clear_target SET NOT NULL;
ALTER TABLE sc_lon_m_loan_history_old ALTER COLUMN monthly_pay SET NOT NULL;
ALTER TABLE sc_lon_m_loan_history_old ALTER COLUMN loan_approve_amount SET NOT NULL;
ALTER TABLE sc_lon_m_loan_history_old ALTER COLUMN salary_time SET NOT NULL;
ALTER TABLE sc_lon_m_loan_history_old ALTER COLUMN monthly_pay_p SET NOT NULL;
ALTER TABLE sc_lon_m_loan_history_old ALTER COLUMN monthly_pay_i SET NOT NULL;


