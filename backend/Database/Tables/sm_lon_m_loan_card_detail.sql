CREATE TABLE sm_lon_m_loan_card_detail (
	loan_contract_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	sm_seq bigint NOT NULL DEFAULT 0
) ;
CREATE UNIQUE INDEX sys_c008073 ON sm_lon_m_loan_card_detail (loan_contract_no, seq_no);
ALTER TABLE sm_lon_m_loan_card_detail ADD PRIMARY KEY (loan_contract_no,seq_no,sm_seq);
ALTER TABLE sm_lon_m_loan_card_detail ALTER COLUMN sm_seq SET NOT NULL;
ALTER TABLE sm_lon_m_loan_card_detail ALTER COLUMN loan_contract_no SET NOT NULL;
ALTER TABLE sm_lon_m_loan_card_detail ALTER COLUMN seq_no SET NOT NULL;


