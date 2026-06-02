CREATE TABLE sc_election_constant (
	seq_no double precision NOT NULL DEFAULT 1,
	member_date timestamp,
	min_represent double precision,
	max_represent double precision,
	min_group double precision,
	max_group double precision
) ;
ALTER TABLE sc_election_constant ADD PRIMARY KEY (seq_no);
ALTER TABLE sc_election_constant ALTER COLUMN seq_no SET NOT NULL;


