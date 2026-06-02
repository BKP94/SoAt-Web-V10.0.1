CREATE TABLE sc_mem_m_capital_stock_int_con (
	account_year numeric(38) NOT NULL,
	membership_no varchar(15) NOT NULL,
	loan_contract_no varchar(15) NOT NULL,
	int_total decimal(15,2),
	int_calc decimal(15,2),
	int_diff decimal(15,2) DEFAULT 0
) ;
ALTER TABLE sc_mem_m_capital_stock_int_con ADD PRIMARY KEY (account_year,membership_no,loan_contract_no);
ALTER TABLE sc_mem_m_capital_stock_int_con ALTER COLUMN account_year SET NOT NULL;
ALTER TABLE sc_mem_m_capital_stock_int_con ALTER COLUMN membership_no SET NOT NULL;
ALTER TABLE sc_mem_m_capital_stock_int_con ALTER COLUMN loan_contract_no SET NOT NULL;


