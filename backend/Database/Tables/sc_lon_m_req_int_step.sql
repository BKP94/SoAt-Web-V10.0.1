CREATE TABLE sc_lon_m_req_int_step (
	loan_requestment_no varchar(15) NOT NULL,
	loan_step decimal(15,2) NOT NULL DEFAULT 0,
	effective_date timestamp NOT NULL,
	loan_interest_rate decimal(6,6) DEFAULT 0
) ;
ALTER TABLE sc_lon_m_req_int_step ADD PRIMARY KEY (loan_requestment_no,loan_step,effective_date);
ALTER TABLE sc_lon_m_req_int_step ALTER COLUMN loan_requestment_no SET NOT NULL;
ALTER TABLE sc_lon_m_req_int_step ALTER COLUMN loan_step SET NOT NULL;
ALTER TABLE sc_lon_m_req_int_step ALTER COLUMN effective_date SET NOT NULL;


