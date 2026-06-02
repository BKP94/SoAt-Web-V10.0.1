CREATE TABLE sm_msg_send_d (
	operate_date timestamp NOT NULL,
	msg_no double precision NOT NULL DEFAULT 0,
	entry_id char(16) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	sm_seq bigint NOT NULL DEFAULT 0
) ;
ALTER TABLE sm_msg_send_d ADD PRIMARY KEY (operate_date,msg_no,entry_id,seq_no,sm_seq);
ALTER TABLE sm_msg_send_d ALTER COLUMN sm_seq SET NOT NULL;
ALTER TABLE sm_msg_send_d ALTER COLUMN operate_date SET NOT NULL;
ALTER TABLE sm_msg_send_d ALTER COLUMN msg_no SET NOT NULL;
ALTER TABLE sm_msg_send_d ALTER COLUMN entry_id SET NOT NULL;
ALTER TABLE sm_msg_send_d ALTER COLUMN seq_no SET NOT NULL;


