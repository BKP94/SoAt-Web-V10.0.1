CREATE TABLE sc_mem_m_ucf_credit_management (
	credit_code varchar(6) NOT NULL DEFAULT '00',
	credit_desc varchar(50),
	marktype varchar(6) DEFAULT '00',
	priority double precision DEFAULT 0
) ;
ALTER TABLE sc_mem_m_ucf_credit_management ADD PRIMARY KEY (credit_code);
ALTER TABLE sc_mem_m_ucf_credit_management ALTER COLUMN credit_code SET NOT NULL;


