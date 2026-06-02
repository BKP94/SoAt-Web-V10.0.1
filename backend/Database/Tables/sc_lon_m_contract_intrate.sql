CREATE TABLE sc_lon_m_contract_intrate (
	loan_contract_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL,
	effective_begin_date timestamp,
	effective_end_date timestamp,
	intrate_effective decimal(15,4)
) ;
ALTER TABLE sc_lon_m_contract_intrate ADD PRIMARY KEY (loan_contract_no,seq_no);


