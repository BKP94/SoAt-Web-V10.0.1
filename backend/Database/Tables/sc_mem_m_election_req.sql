CREATE TABLE sc_mem_m_election_req (
	membership_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL,
	member_group_no varchar(16) NOT NULL,
	pre_election_zone varchar(15) NOT NULL,
	election_zone varchar(15) NOT NULL,
	remark varchar(100),
	operate_date timestamp NOT NULL,
	entry_date timestamp NOT NULL,
	entry_id varchar(16) NOT NULL,
	cancel_status char(1) NOT NULL,
	cancel_date timestamp
) ;
ALTER TABLE sc_mem_m_election_req ADD PRIMARY KEY (membership_no,seq_no);
ALTER TABLE sc_mem_m_election_req ALTER COLUMN membership_no SET NOT NULL;
ALTER TABLE sc_mem_m_election_req ALTER COLUMN seq_no SET NOT NULL;
ALTER TABLE sc_mem_m_election_req ALTER COLUMN member_group_no SET NOT NULL;
ALTER TABLE sc_mem_m_election_req ALTER COLUMN pre_election_zone SET NOT NULL;
ALTER TABLE sc_mem_m_election_req ALTER COLUMN election_zone SET NOT NULL;
ALTER TABLE sc_mem_m_election_req ALTER COLUMN operate_date SET NOT NULL;
ALTER TABLE sc_mem_m_election_req ALTER COLUMN entry_date SET NOT NULL;
ALTER TABLE sc_mem_m_election_req ALTER COLUMN entry_id SET NOT NULL;
ALTER TABLE sc_mem_m_election_req ALTER COLUMN cancel_status SET NOT NULL;


