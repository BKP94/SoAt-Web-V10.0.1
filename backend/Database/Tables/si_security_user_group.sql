CREATE TABLE si_security_user_group (
	user_id varchar(20) NOT NULL,
	group_id varchar(20) NOT NULL,
	d_create timestamp NOT NULL DEFAULT statement_timestamp(),
	d_change timestamp NOT NULL DEFAULT statement_timestamp()
) ;
ALTER TABLE si_security_user_group ADD PRIMARY KEY (group_id,user_id);
ALTER TABLE si_security_user_group ALTER COLUMN user_id SET NOT NULL;
ALTER TABLE si_security_user_group ALTER COLUMN group_id SET NOT NULL;
ALTER TABLE si_security_user_group ALTER COLUMN d_create SET NOT NULL;
ALTER TABLE si_security_user_group ALTER COLUMN d_change SET NOT NULL;


