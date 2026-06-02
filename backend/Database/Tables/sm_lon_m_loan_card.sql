CREATE TABLE sm_lon_m_loan_card (
	loan_contract_no varchar(15) NOT NULL,
	sm_seq bigint NOT NULL DEFAULT 0
) ;
ALTER TABLE sm_lon_m_loan_card ADD PRIMARY KEY (loan_contract_no,sm_seq);
ALTER TABLE sm_lon_m_loan_card ALTER COLUMN sm_seq SET NOT NULL;
ALTER TABLE sm_lon_m_loan_card ALTER COLUMN loan_contract_no SET NOT NULL;


