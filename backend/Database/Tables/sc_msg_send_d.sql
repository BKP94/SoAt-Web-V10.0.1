CREATE TABLE sc_msg_send_d (
	operate_date timestamp NOT NULL,
	msg_no double precision NOT NULL DEFAULT 0,
	entry_id char(16) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	mobile_no varchar(15),
	membership_no varchar(15),
	send_status char(1) DEFAULT '0',
	send_count double precision DEFAULT 0,
	send_time timestamp,
	send_name varchar(50),
	result_status char(1) DEFAULT '#',
	result_detail varchar(100)
) ;
ALTER TABLE sc_msg_send_d ADD PRIMARY KEY (operate_date,msg_no,entry_id,seq_no);
ALTER TABLE sc_msg_send_d ALTER COLUMN operate_date SET NOT NULL;
ALTER TABLE sc_msg_send_d ALTER COLUMN msg_no SET NOT NULL;
ALTER TABLE sc_msg_send_d ALTER COLUMN entry_id SET NOT NULL;
ALTER TABLE sc_msg_send_d ALTER COLUMN seq_no SET NOT NULL;


