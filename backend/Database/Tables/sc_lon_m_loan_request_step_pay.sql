CREATE TABLE sc_lon_m_loan_request_step_pay (
	loan_requestment_no varchar(15) NOT NULL,
	effective_date timestamp NOT NULL,
	period_step double precision NOT NULL,
	period_payment double precision
) ;
ALTER TABLE sc_lon_m_loan_request_step_pay ADD PRIMARY KEY (loan_requestment_no,effective_date,period_step);
ALTER TABLE sc_lon_m_loan_request_step_pay ALTER COLUMN loan_requestment_no SET NOT NULL;
ALTER TABLE sc_lon_m_loan_request_step_pay ALTER COLUMN effective_date SET NOT NULL;
ALTER TABLE sc_lon_m_loan_request_step_pay ALTER COLUMN period_step SET NOT NULL;


