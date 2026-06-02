CREATE TABLE sc_mem_m_ucf_member_group_section (
	group_section varchar(15) NOT NULL,
	group_section_control varchar(15),
	group_section_name varchar(250)
) ;
ALTER TABLE sc_mem_m_ucf_member_group_section ADD PRIMARY KEY (group_section);
ALTER TABLE sc_mem_m_ucf_member_group_section ALTER COLUMN group_section SET NOT NULL;


