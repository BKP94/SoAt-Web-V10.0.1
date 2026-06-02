CREATE TABLE sc_mem_m_capital_pay_agn (
	account_year double precision NOT NULL,
	member_group_no varchar(15) NOT NULL,
	group_pay_code varchar(3),
	bank_acc_no varchar(15),
	bank_acc_name varchar(100),
	remark varchar(100),
	entry_date timestamp,
	entry_id varchar(16)
) ;
ALTER TABLE sc_mem_m_capital_pay_agn ADD PRIMARY KEY (account_year,member_group_no);
ALTER TABLE sc_mem_m_capital_pay_agn ALTER COLUMN account_year SET NOT NULL;
ALTER TABLE sc_mem_m_capital_pay_agn ALTER COLUMN member_group_no SET NOT NULL;


