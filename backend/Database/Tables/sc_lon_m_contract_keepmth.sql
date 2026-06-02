CREATE TABLE sc_lon_m_contract_keepmth (
	loan_contract_no char(15) NOT NULL,
	effective_date timestamp NOT NULL,
	period_last numeric(38) NOT NULL,
	period_payment_amount decimal(15,2) NOT NULL,
	entry_id varchar(20),
	entry_date timestamp NOT NULL,
	client_name varchar(50) NOT NULL,
	branch_id char(2) NOT NULL
) ;
ALTER TABLE sc_lon_m_contract_keepmth ALTER COLUMN loan_contract_no SET NOT NULL;
ALTER TABLE sc_lon_m_contract_keepmth ALTER COLUMN effective_date SET NOT NULL;
ALTER TABLE sc_lon_m_contract_keepmth ALTER COLUMN period_last SET NOT NULL;
ALTER TABLE sc_lon_m_contract_keepmth ALTER COLUMN period_payment_amount SET NOT NULL;
ALTER TABLE sc_lon_m_contract_keepmth ALTER COLUMN entry_date SET NOT NULL;
ALTER TABLE sc_lon_m_contract_keepmth ALTER COLUMN client_name SET NOT NULL;
ALTER TABLE sc_lon_m_contract_keepmth ALTER COLUMN branch_id SET NOT NULL;


