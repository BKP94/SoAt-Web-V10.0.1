CREATE TABLE sc_atm_m_imp_file_temp (
	loan_contract_no char(15) NOT NULL,
	seq_no double precision NOT NULL,
	trans_date timestamp,
	remark varchar(80),
	tran_amt decimal(15,2)
) ;
ALTER TABLE sc_atm_m_imp_file_temp ADD PRIMARY KEY (loan_contract_no,seq_no);


