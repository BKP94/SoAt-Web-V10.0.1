CREATE TABLE sc_lon_m_loan_request_step_rep (
	loan_requestment_no char(15) NOT NULL,
	membership_no char(7) NOT NULL,
	period double precision NOT NULL,
	payment_amount double precision,
	interest double precision,
	money_amount double precision,
	principal_balance double precision,
	int_from timestamp,
	int_to timestamp
) ;
CREATE UNIQUE INDEX sc_lon_m_loan_request_step_re_ ON sc_lon_m_loan_request_step_rep (loan_requestment_no, membership_no, period);
ALTER TABLE sc_lon_m_loan_request_step_rep ALTER COLUMN loan_requestment_no SET NOT NULL;
ALTER TABLE sc_lon_m_loan_request_step_rep ALTER COLUMN membership_no SET NOT NULL;
ALTER TABLE sc_lon_m_loan_request_step_rep ALTER COLUMN period SET NOT NULL;


