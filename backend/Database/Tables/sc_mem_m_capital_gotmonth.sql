CREATE TABLE sc_mem_m_capital_gotmonth (
	account_year double precision NOT NULL DEFAULT 0,
	membership_no varchar(15) NOT NULL,
	month_paid double precision NOT NULL DEFAULT 0
) ;
ALTER TABLE sc_mem_m_capital_gotmonth ADD PRIMARY KEY (account_year,membership_no,month_paid);
ALTER TABLE sc_mem_m_capital_gotmonth ALTER COLUMN account_year SET NOT NULL;
ALTER TABLE sc_mem_m_capital_gotmonth ALTER COLUMN membership_no SET NOT NULL;
ALTER TABLE sc_mem_m_capital_gotmonth ALTER COLUMN month_paid SET NOT NULL;


