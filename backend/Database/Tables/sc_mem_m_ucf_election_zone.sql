CREATE TABLE sc_mem_m_ucf_election_zone (
	election_zone varchar(15) NOT NULL,
	election_zone_name varchar(100),
	election_zone_control varchar(15) NOT NULL
) ;
ALTER TABLE sc_mem_m_ucf_election_zone ADD PRIMARY KEY (election_zone);
ALTER TABLE sc_mem_m_ucf_election_zone ALTER COLUMN election_zone SET NOT NULL;
ALTER TABLE sc_mem_m_ucf_election_zone ALTER COLUMN election_zone_control SET NOT NULL;


