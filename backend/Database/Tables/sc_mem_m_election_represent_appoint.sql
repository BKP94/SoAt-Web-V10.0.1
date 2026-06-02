CREATE TABLE sc_mem_m_election_represent_appoint (
	election_year double precision NOT NULL,
	running double precision NOT NULL,
	point_no double precision,
	point_seq double precision,
	memno varchar(15),
	status char(1) NOT NULL,
	seq_app double precision
) ;
ALTER TABLE sc_mem_m_election_represent_appoint ADD PRIMARY KEY (election_year,running);
ALTER TABLE sc_mem_m_election_represent_appoint ALTER COLUMN election_year SET NOT NULL;
ALTER TABLE sc_mem_m_election_represent_appoint ALTER COLUMN running SET NOT NULL;
ALTER TABLE sc_mem_m_election_represent_appoint ALTER COLUMN status SET NOT NULL;


