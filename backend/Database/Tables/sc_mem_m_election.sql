CREATE TABLE sc_mem_m_election (
	election_year double precision NOT NULL,
	membership_no varchar(15) NOT NULL,
	member_group_no varchar(16) NOT NULL,
	election_group varchar(15) NOT NULL,
	position_code varchar(6),
	remark varchar(100),
	status_a char(1) NOT NULL DEFAULT '0',
	status_b char(1) NOT NULL DEFAULT '0',
	entry_date timestamp NOT NULL,
	entry_id varchar(16) NOT NULL,
	election_zone varchar(15) NOT NULL,
	election_seq double precision DEFAULT 0,
	member_name varchar(100)
) ;
ALTER TABLE sc_mem_m_election ADD PRIMARY KEY (election_year,membership_no);
ALTER TABLE sc_mem_m_election ALTER COLUMN election_year SET NOT NULL;
ALTER TABLE sc_mem_m_election ALTER COLUMN membership_no SET NOT NULL;
ALTER TABLE sc_mem_m_election ALTER COLUMN member_group_no SET NOT NULL;
ALTER TABLE sc_mem_m_election ALTER COLUMN election_group SET NOT NULL;
ALTER TABLE sc_mem_m_election ALTER COLUMN status_a SET NOT NULL;
ALTER TABLE sc_mem_m_election ALTER COLUMN status_b SET NOT NULL;
ALTER TABLE sc_mem_m_election ALTER COLUMN entry_date SET NOT NULL;
ALTER TABLE sc_mem_m_election ALTER COLUMN entry_id SET NOT NULL;
ALTER TABLE sc_mem_m_election ALTER COLUMN election_zone SET NOT NULL;


