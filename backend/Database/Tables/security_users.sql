CREATE TABLE security_users (
	names char(16) NOT NULL,
	branch_id char(2),
	description varchar(32),
	priority double precision,
	user_type double precision,
	passwords varchar(30),
	confirmpwd varchar(30),
	base_status char(1),
	level_receive double precision,
	level_payable double precision,
	manager_status char(1),
	password_expire timestamp,
	user_fin char(16),
	status char(1),
	mis_password_status char(1),
	nickname varchar(30),
	counter_split char(1)
) ;
ALTER TABLE security_users ADD PRIMARY KEY (names);


