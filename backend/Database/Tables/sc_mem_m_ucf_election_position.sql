CREATE TABLE sc_mem_m_ucf_election_position (
	position_code varchar(6) NOT NULL,
	position_desc varchar(100),
	sort_order double precision DEFAULT 0
) ;
ALTER TABLE sc_mem_m_ucf_election_position ADD PRIMARY KEY (position_code);
ALTER TABLE sc_mem_m_ucf_election_position ALTER COLUMN position_code SET NOT NULL;


