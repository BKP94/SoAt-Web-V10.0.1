CREATE TABLE sm_mem_m_capital_stock_detail (
	account_year double precision NOT NULL DEFAULT '0',
	membership_no varchar(15) NOT NULL,
	sm_seq bigint NOT NULL DEFAULT 0
) ;
ALTER TABLE sm_mem_m_capital_stock_detail ADD PRIMARY KEY (account_year,membership_no,sm_seq);
ALTER TABLE sm_mem_m_capital_stock_detail ALTER COLUMN sm_seq SET NOT NULL;
ALTER TABLE sm_mem_m_capital_stock_detail ALTER COLUMN account_year SET NOT NULL;
ALTER TABLE sm_mem_m_capital_stock_detail ALTER COLUMN membership_no SET NOT NULL;


