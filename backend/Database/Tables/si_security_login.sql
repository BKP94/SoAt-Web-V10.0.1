CREATE TABLE si_security_login (
	center_name varchar(1000) NOT NULL,
	session_id varchar(24) NOT NULL,
	site_target varchar(60) NOT NULL,
	user_id varchar(16),
	branch_id varchar(6)
) ;
ALTER TABLE si_security_login ADD PRIMARY KEY (center_name,session_id,site_target);
ALTER TABLE si_security_login ALTER COLUMN center_name SET NOT NULL;
ALTER TABLE si_security_login ALTER COLUMN session_id SET NOT NULL;
ALTER TABLE si_security_login ALTER COLUMN site_target SET NOT NULL;


