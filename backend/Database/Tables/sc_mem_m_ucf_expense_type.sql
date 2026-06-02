CREATE TABLE sc_mem_m_ucf_expense_type (
	expense_type_code varchar(6) NOT NULL,
	expense_type_description varchar(100),
	group_code char(1) DEFAULT '+',
	expense_ref_code varchar(3)
) ;
ALTER TABLE sc_mem_m_ucf_expense_type ADD PRIMARY KEY (expense_type_code);
ALTER TABLE sc_mem_m_ucf_expense_type ALTER COLUMN expense_type_code SET NOT NULL;


