CREATE TABLE sc_lon_m_con_by_custom (
	loan_type varchar(6) NOT NULL DEFAULT '00',
	seq_no double precision NOT NULL DEFAULT 0,
	mem_level double precision DEFAULT 0,
	member_term double precision DEFAULT 0,
	share_holding decimal(15,2) DEFAULT 0,
	salary_amount decimal(15,2) DEFAULT 0,
	entry_id varchar(15),
	entry_date timestamp,
	percent_share_per_loan decimal(15,4) DEFAULT 0,
	max_share_percent decimal(15,4) DEFAULT 0,
	period double precision DEFAULT 0,
	period_m char(1) DEFAULT 'a'
) ;
COMMENT ON TABLE sc_lon_m_con_by_custom IS E'!N??????????????? : ?????????????????????N!!MM!';
COMMENT ON COLUMN sc_lon_m_con_by_custom.loan_type IS E'!NN!!MM!';
COMMENT ON COLUMN sc_lon_m_con_by_custom.max_share_percent IS E'!N????????????????(????)N!!MM!';
COMMENT ON COLUMN sc_lon_m_con_by_custom.mem_level IS E'!N????N!!MM!';
COMMENT ON COLUMN sc_lon_m_con_by_custom.member_term IS E'!N????(?.)N!!MM!';
COMMENT ON COLUMN sc_lon_m_con_by_custom.period IS E'!N???????????????(???)N!!MM!';
COMMENT ON COLUMN sc_lon_m_con_by_custom.salary_amount IS E'!N?????????N!!MM!';
COMMENT ON COLUMN sc_lon_m_con_by_custom.share_holding IS E'!N????????????N!!MM!';
CREATE INDEX idx__c007139_loan_type ON sc_lon_m_con_by_custom (loan_type);
ALTER TABLE sc_lon_m_con_by_custom ADD PRIMARY KEY (loan_type,seq_no);


