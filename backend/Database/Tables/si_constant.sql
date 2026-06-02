CREATE TABLE si_constant (
	coop_id varchar(15) NOT NULL,
	last_udpate_combo varchar(15)
) ;
ALTER TABLE si_constant ADD PRIMARY KEY (coop_id);
ALTER TABLE si_constant ALTER COLUMN coop_id SET NOT NULL;


