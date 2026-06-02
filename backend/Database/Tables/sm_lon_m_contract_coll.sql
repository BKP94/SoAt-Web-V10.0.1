CREATE TABLE sm_lon_m_contract_coll (
	loan_contract_no varchar(15) NOT NULL,
	collateral_no varchar(15) NOT NULL,
	sm_seq bigint NOT NULL DEFAULT 0
) ;
CREATE UNIQUE INDEX sys_c00101964 ON sm_lon_m_contract_coll (loan_contract_no, collateral_no);
ALTER TABLE sm_lon_m_contract_coll ADD PRIMARY KEY (loan_contract_no,collateral_no,sm_seq);
ALTER TABLE sm_lon_m_contract_coll ALTER COLUMN sm_seq SET NOT NULL;
ALTER TABLE sm_lon_m_contract_coll ALTER COLUMN loan_contract_no SET NOT NULL;
ALTER TABLE sm_lon_m_contract_coll ALTER COLUMN collateral_no SET NOT NULL;


