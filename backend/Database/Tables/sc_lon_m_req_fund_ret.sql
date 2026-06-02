CREATE TABLE sc_lon_m_req_fund_ret (
	loan_requestment_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	loan_contract_no varchar(15),
	fund_ret decimal(15,2) DEFAULT 0,
	approve_amount decimal(15,2) NOT NULL DEFAULT 0,
	fund_int decimal(15,2) DEFAULT 0,
	fund_int_add decimal(15,2) DEFAULT 0.00,
	fund_real decimal(15,2) DEFAULT 0,
	deposit_account_no varchar(15)
) ;
ALTER TABLE sc_lon_m_req_fund_ret ADD PRIMARY KEY (loan_requestment_no,seq_no);
ALTER TABLE sc_lon_m_req_fund_ret ALTER COLUMN loan_requestment_no SET NOT NULL;
ALTER TABLE sc_lon_m_req_fund_ret ALTER COLUMN seq_no SET NOT NULL;
ALTER TABLE sc_lon_m_req_fund_ret ALTER COLUMN approve_amount SET NOT NULL;


