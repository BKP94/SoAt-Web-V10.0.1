CREATE TABLE sc_law_prosec_loan (
	prosec_no varchar(15) NOT NULL,
	loan_contract_no varchar(15) NOT NULL,
	principal_balance decimal(15,2) DEFAULT 0,
	interest_arrear decimal(15,2) DEFAULT 0,
	last_calcint_date timestamp,
	proc_principal_balance decimal(15,2) DEFAULT 0,
	proc_interest_arrear decimal(15,2) DEFAULT 0,
	begining_of_contract timestamp,
	loan_approve_amount decimal(15,2) DEFAULT 0
) ;
ALTER TABLE sc_law_prosec_loan ADD PRIMARY KEY (prosec_no,loan_contract_no);
ALTER TABLE sc_law_prosec_loan ALTER COLUMN prosec_no SET NOT NULL;
ALTER TABLE sc_law_prosec_loan ALTER COLUMN loan_contract_no SET NOT NULL;


