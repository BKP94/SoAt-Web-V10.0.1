CREATE TABLE sc_msg_constant (
	coop_registered_no varchar(15) NOT NULL,
	user_name varchar(50),
	user_pass varchar(50),
	sender_name varchar(50),
	parm_format varchar(100),
	api_url varchar(100),
	send_time_limit double precision DEFAULT 0
) ;
ALTER TABLE sc_msg_constant ADD PRIMARY KEY (coop_registered_no);


