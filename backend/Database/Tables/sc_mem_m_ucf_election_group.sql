CREATE TABLE sc_mem_m_ucf_election_group (
	election_group varchar(15) NOT NULL,
	election_group_name varchar(100),
	election_zone varchar(15) NOT NULL,
	election_place varchar(100),
	election_help varchar(15) DEFAULT '00',
	count_mem double precision DEFAULT 0,
	begin_mem varchar(15) DEFAULT '000000',
	end_mem varchar(15) DEFAULT '999999'
) ;
ALTER TABLE sc_mem_m_ucf_election_group ADD PRIMARY KEY (election_group);
ALTER TABLE sc_mem_m_ucf_election_group ALTER COLUMN election_group SET NOT NULL;
ALTER TABLE sc_mem_m_ucf_election_group ALTER COLUMN election_zone SET NOT NULL;


