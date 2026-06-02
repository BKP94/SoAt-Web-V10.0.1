CREATE TABLE sc_law_loan (
	prosec_no varchar(15) NOT NULL,
	loan_contract_no varchar(15) NOT NULL,
	operate_date timestamp,
	court_name varchar(100),
	principal_balance double precision DEFAULT 0,
	court_interest_rate double precision DEFAULT 0,
	date_before timestamp,
	date_to timestamp
) ;
ALTER TABLE sc_law_loan ADD PRIMARY KEY (prosec_no,loan_contract_no);
ALTER TABLE sc_law_loan ALTER COLUMN prosec_no SET NOT NULL;
ALTER TABLE sc_law_loan ALTER COLUMN loan_contract_no SET NOT NULL;


