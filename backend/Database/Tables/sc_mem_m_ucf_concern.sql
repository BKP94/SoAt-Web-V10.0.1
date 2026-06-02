CREATE TABLE sc_mem_m_ucf_concern (
	conceern_code varchar(6) NOT NULL,
	related_na varchar(50),
	sort_order integer DEFAULT 0
) ;
ALTER TABLE sc_mem_m_ucf_concern ADD PRIMARY KEY (conceern_code);


