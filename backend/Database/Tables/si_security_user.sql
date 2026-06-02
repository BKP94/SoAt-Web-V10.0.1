CREATE TABLE si_security_user (
	user_id varchar(16) NOT NULL,
	membership_no varchar(15),
	user_name varchar(60),
	nick_name varchar(30),
	branch_id varchar(6),
	passwords varchar(50),
	close_status char(1) DEFAULT '0',
	counter_split char(1) DEFAULT '0',
	group_id varchar(16),
	inactive_userid varchar(16),
	inactive_time timestamp,
	programmer char(1),
	d_last_change_password timestamp DEFAULT statement_timestamp(),
	flg_first_login char(1) DEFAULT '1',
	admin_mode char(1) DEFAULT '0',
	user_sign bytea,
	id_card varchar(15)
) ;
ALTER TABLE si_security_user ADD PRIMARY KEY (user_id);
ALTER TABLE si_security_user ALTER COLUMN user_id SET NOT NULL;


