CREATE TABLE sc_mem_m_ucf_subdistrict (
	subdistrict_code varchar(6) NOT NULL,
	subdistrict_name varchar(50),
	district_code varchar(6) NOT NULL
) ;
ALTER TABLE sc_mem_m_ucf_subdistrict ADD PRIMARY KEY (subdistrict_code);
ALTER TABLE sc_mem_m_ucf_subdistrict ALTER COLUMN subdistrict_code SET NOT NULL;
ALTER TABLE sc_mem_m_ucf_subdistrict ALTER COLUMN district_code SET NOT NULL;


