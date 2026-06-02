CREATE TABLE sc_lon_m_rule_month_count (
	loan_type varchar(6) NOT NULL,
	not_calint_type double precision,
	not_calint_date double precision,
	half_receive_type double precision,
	half_receive_date double precision,
	half_payment_type double precision,
	half_payment_date double precision
) ;
COMMENT ON TABLE sc_lon_m_rule_month_count IS E'!N??????????????? - ????????????????N!!MM!';
COMMENT ON COLUMN sc_lon_m_rule_month_count.half_payment_date IS E'!N???N!!MM!';
COMMENT ON COLUMN sc_lon_m_rule_month_count.half_payment_type IS E'!N?????????????N!!MM!';
COMMENT ON COLUMN sc_lon_m_rule_month_count.half_receive_date IS E'!N???N!!MM!';
COMMENT ON COLUMN sc_lon_m_rule_month_count.half_receive_type IS E'!N???????????N!!MM!';
COMMENT ON COLUMN sc_lon_m_rule_month_count.loan_type IS E'!NN!!MM!';
COMMENT ON COLUMN sc_lon_m_rule_month_count.not_calint_date IS E'!N???N!!MM!';
COMMENT ON COLUMN sc_lon_m_rule_month_count.not_calint_type IS E'!N???N!!MM!';
ALTER TABLE sc_lon_m_rule_month_count ADD PRIMARY KEY (loan_type);


