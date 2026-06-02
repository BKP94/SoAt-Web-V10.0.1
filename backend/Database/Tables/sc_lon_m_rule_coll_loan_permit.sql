CREATE TABLE sc_lon_m_rule_coll_loan_permit (
	loan_type varchar(6) NOT NULL,
	seq_no double precision NOT NULL,
	loan_permit_begin decimal(15,2),
	loan_permit_end decimal(15,2),
	coll_use double precision,
	coll_use_max double precision
) ;
ALTER TABLE sc_lon_m_rule_coll_loan_permit ADD PRIMARY KEY (loan_type,seq_no);


