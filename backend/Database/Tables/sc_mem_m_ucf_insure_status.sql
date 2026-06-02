CREATE TABLE sc_mem_m_ucf_insure_status (
	company_status varchar(6) NOT NULL DEFAULT '0',
	company_desc varchar(50),
	company_status_control char(1) DEFAULT '0'
) ;
ALTER TABLE sc_mem_m_ucf_insure_status ADD PRIMARY KEY (company_status);


