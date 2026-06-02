CREATE TABLE sc_lon_m_rule_coll (
	loan_type varchar(6) NOT NULL,
	seq_no double precision NOT NULL,
	member_term double precision,
	member_term_to double precision,
	salary_amount decimal(15,2),
	share_amount decimal(15,2),
	coll_permit_amount decimal(15,2)
) ;
COMMENT ON TABLE sc_lon_m_rule_coll IS E'!NN!';
COMMENT ON COLUMN sc_lon_m_rule_coll.coll_permit_amount IS E'!N???????????N!!MM!';
COMMENT ON COLUMN sc_lon_m_rule_coll.member_term_to IS E'!N???????(?????)N!!MM!';
ALTER TABLE sc_lon_m_rule_coll ADD PRIMARY KEY (loan_type,seq_no);


