CREATE TABLE sc_law_prosec_loan_int (
	prosec_no varchar(15) NOT NULL,
	loan_contract_no varchar(15) NOT NULL,
	seq_no integer NOT NULL DEFAULT 0,
	int_from timestamp,
	int_to timestamp,
	interest_amount decimal(15,2) DEFAULT 0,
	int_rate decimal(15,6) DEFAULT 0
) ;
ALTER TABLE sc_law_prosec_loan_int ADD PRIMARY KEY (prosec_no,loan_contract_no,seq_no);
ALTER TABLE sc_law_prosec_loan_int ALTER COLUMN prosec_no SET NOT NULL;
ALTER TABLE sc_law_prosec_loan_int ALTER COLUMN loan_contract_no SET NOT NULL;
ALTER TABLE sc_law_prosec_loan_int ALTER COLUMN seq_no SET NOT NULL;


