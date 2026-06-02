CREATE TABLE sc_lon_m_int_step_rate (
	loan_type varchar(6) NOT NULL,
	loan_step decimal(15,2) NOT NULL,
	loan_interest_rate decimal(10,6),
	effective_date timestamp NOT NULL,
	share_interest_rate decimal(18,5)
) ;
COMMENT ON TABLE sc_lon_m_int_step_rate IS E'!N??????????????????N!!MM!';
COMMENT ON COLUMN sc_lon_m_int_step_rate.effective_date IS E'!N??????????????N!!MM!';
COMMENT ON COLUMN sc_lon_m_int_step_rate.loan_interest_rate IS E'!N?????????????(%)N!!MM!';
COMMENT ON COLUMN sc_lon_m_int_step_rate.loan_step IS E'!N???N!!M?????????????M!';
COMMENT ON COLUMN sc_lon_m_int_step_rate.loan_type IS E'!N?????????????N!!MM!';
CREATE INDEX idx_lon_int_step_eff_date ON sc_lon_m_int_step_rate (effective_date);
CREATE INDEX idx_lon_int_step_loan_step ON sc_lon_m_int_step_rate (loan_step);
CREATE INDEX idx_lon_int_step_loan_type ON sc_lon_m_int_step_rate (loan_type);
ALTER TABLE sc_lon_m_int_step_rate ADD PRIMARY KEY (loan_type,loan_step,effective_date);


