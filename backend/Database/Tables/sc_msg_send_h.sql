CREATE TABLE sc_msg_send_h (
	operate_date timestamp NOT NULL,
	msg_no double precision NOT NULL DEFAULT 0,
	entry_id char(16) NOT NULL,
	status_code varchar(50),
	messages varchar(250),
	send_mode char(1) DEFAULT 'I',
	execute_time timestamp,
	entry_date timestamp
) ;
ALTER TABLE sc_msg_send_h ADD PRIMARY KEY (operate_date,msg_no,entry_id);
ALTER TABLE sc_msg_send_h ALTER COLUMN operate_date SET NOT NULL;
ALTER TABLE sc_msg_send_h ALTER COLUMN msg_no SET NOT NULL;
ALTER TABLE sc_msg_send_h ALTER COLUMN entry_id SET NOT NULL;


