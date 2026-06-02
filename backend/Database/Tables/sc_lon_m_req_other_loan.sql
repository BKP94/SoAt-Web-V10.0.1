CREATE TABLE sc_lon_m_req_other_loan (
	loan_requestment_no varchar(15) NOT NULL DEFAULT 'cnv',
	seq_no double precision NOT NULL,
	other_loan_type varchar(6),
	loan_approve_amount decimal(15,2),
	int_rate decimal(10,6),
	principal_balance decimal(15,2),
	monthly_pay_p decimal(15,2) DEFAULT 0,
	monthly_pay_i decimal(15,2) DEFAULT 0,
	monthly_pay decimal(15,2) DEFAULT 0,
	clear_target char(1),
	last_period double precision,
	remark varchar(100),
	loan_installment smallint DEFAULT 0
) ;
ALTER TABLE sc_lon_m_req_other_loan ADD PRIMARY KEY (loan_requestment_no,seq_no);
ALTER TABLE sc_lon_m_req_other_loan ALTER COLUMN loan_requestment_no SET NOT NULL;
ALTER TABLE sc_lon_m_req_other_loan ALTER COLUMN seq_no SET NOT NULL;


