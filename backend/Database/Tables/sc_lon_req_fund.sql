CREATE TABLE sc_lon_req_fund (
	loan_requestment_no varchar(15) NOT NULL,
	loan_contract_no varchar(15),
	old_fund_amount decimal(15,2),
	new_fund_amount decimal(15,2),
	paymonth_amount decimal(15,2),
	method_pay char(1) DEFAULT 'P',
	seq_no double precision NOT NULL DEFAULT '0',
	ref_conno varchar(15),
	old_fund_approve decimal(15,2) DEFAULT 0,
	old_fund_paymonth decimal(15,2) DEFAULT 0,
	add_manual char(1) DEFAULT '0',
	fund_extra decimal(15,2) DEFAULT 0
) ;
ALTER TABLE sc_lon_req_fund ADD PRIMARY KEY (loan_requestment_no,seq_no);
ALTER TABLE sc_lon_req_fund ALTER COLUMN loan_requestment_no SET NOT NULL;
ALTER TABLE sc_lon_req_fund ALTER COLUMN seq_no SET NOT NULL;


