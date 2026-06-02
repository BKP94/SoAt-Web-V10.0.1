CREATE TABLE sc_msg_code_head (
	status_code varchar(50) NOT NULL,
	wait_approve_status char(1) DEFAULT '0'
) ;
ALTER TABLE sc_msg_code_head ADD PRIMARY KEY (status_code);
ALTER TABLE sc_msg_code_head ALTER COLUMN status_code SET NOT NULL;


