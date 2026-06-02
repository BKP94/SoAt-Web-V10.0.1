CREATE TABLE sc_lon_m_loan_addloan_detail (
	loan_contract_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	item_type varchar(3) NOT NULL,
	item_amount decimal(15,2)
) ;
ALTER TABLE sc_lon_m_loan_addloan_detail ADD PRIMARY KEY (loan_contract_no,seq_no,item_type);
ALTER TABLE sc_lon_m_loan_addloan_detail ALTER COLUMN loan_contract_no SET NOT NULL;
ALTER TABLE sc_lon_m_loan_addloan_detail ALTER COLUMN seq_no SET NOT NULL;
ALTER TABLE sc_lon_m_loan_addloan_detail ALTER COLUMN item_type SET NOT NULL;


