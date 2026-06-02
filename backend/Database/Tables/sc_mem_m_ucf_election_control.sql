CREATE TABLE sc_mem_m_ucf_election_control (
	control_no varchar(15) NOT NULL,
	control_name varchar(100),
	control_group varchar(15)
) ;
ALTER TABLE sc_mem_m_ucf_election_control ADD PRIMARY KEY (control_no);
ALTER TABLE sc_mem_m_ucf_election_control ALTER COLUMN control_no SET NOT NULL;


