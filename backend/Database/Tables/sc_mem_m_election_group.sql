CREATE TABLE sc_mem_m_election_group (
	election_year double precision NOT NULL,
	election_group varchar(15) NOT NULL,
	num_member double precision,
	num_represent double precision,
	entry_date timestamp NOT NULL,
	entry_id varchar(16) NOT NULL,
	member_date timestamp
) ;
ALTER TABLE sc_mem_m_election_group ADD PRIMARY KEY (election_year,election_group);
ALTER TABLE sc_mem_m_election_group ALTER COLUMN election_year SET NOT NULL;
ALTER TABLE sc_mem_m_election_group ALTER COLUMN election_group SET NOT NULL;
ALTER TABLE sc_mem_m_election_group ALTER COLUMN entry_date SET NOT NULL;
ALTER TABLE sc_mem_m_election_group ALTER COLUMN entry_id SET NOT NULL;


