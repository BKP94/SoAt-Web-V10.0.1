CREATE TABLE sc_lon_m_req_fund_new (
	loan_requestment_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	loan_contract_no varchar(15),
	fund_cur double precision DEFAULT 0,
	fund_new double precision DEFAULT 0,
	fund_add double precision DEFAULT 0,
	fund_extra decimal(15,2) DEFAULT 0,
	approve_amount decimal(15,2) NOT NULL DEFAULT 0
) ;
ALTER TABLE sc_lon_m_req_fund_new ADD PRIMARY KEY (loan_requestment_no,seq_no);
ALTER TABLE sc_lon_m_req_fund_new ALTER COLUMN loan_requestment_no SET NOT NULL;
ALTER TABLE sc_lon_m_req_fund_new ALTER COLUMN seq_no SET NOT NULL;
ALTER TABLE sc_lon_m_req_fund_new ALTER COLUMN approve_amount SET NOT NULL;


