CREATE TABLE sc_mem_m_ucf_region_group (
	region_group varchar(15) NOT NULL,
	region_group_name varchar(100),
	region_group_control varchar(15),
	region_place varchar(100)
) ;
ALTER TABLE sc_mem_m_ucf_region_group ADD PRIMARY KEY (region_group);
ALTER TABLE sc_mem_m_ucf_region_group ALTER COLUMN region_group SET NOT NULL;


