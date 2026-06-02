CREATE TABLE sc_mem_m_ucf_revenue_type (
	revenue_type_code varchar(6) NOT NULL,
	revenue_type_description varchar(100),
	group_code char(1) DEFAULT '0',
	revenue_ref_code varchar(3)
) ;
ALTER TABLE sc_mem_m_ucf_revenue_type ADD PRIMARY KEY (revenue_type_code);
ALTER TABLE sc_mem_m_ucf_revenue_type ALTER COLUMN revenue_type_code SET NOT NULL;


