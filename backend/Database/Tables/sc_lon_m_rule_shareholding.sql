CREATE TABLE sc_lon_m_rule_shareholding (
	loan_type varchar(6) NOT NULL DEFAULT '00',
	seqno double precision NOT NULL DEFAULT 0,
	loan_amount decimal(15,2) DEFAULT 0,
	share_value decimal(15,2) DEFAULT 0,
	percent_share decimal(15,4) DEFAULT 0
) ;
COMMENT ON TABLE sc_lon_m_rule_shareholding IS E'!NN!';
COMMENT ON COLUMN sc_lon_m_rule_shareholding.loan_amount IS E'!N?????????N!!MM!';
COMMENT ON COLUMN sc_lon_m_rule_shareholding.loan_type IS E'!NN!!MM!';
COMMENT ON COLUMN sc_lon_m_rule_shareholding.share_value IS E'!N????????????N!!MM!';
ALTER TABLE sc_lon_m_rule_shareholding ADD PRIMARY KEY (loan_type,seqno);


