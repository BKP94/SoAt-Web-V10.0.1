CREATE TABLE sc_atm_recv_file_scib_006 (
	operate_date timestamp,
	item_no smallint DEFAULT 0,
	seq_no smallint DEFAULT 0,
	msg_decrypt varchar(95)
) ;
CREATE UNIQUE INDEX sys_c009611 ON sc_atm_recv_file_scib_006 (operate_date, item_no, seq_no);


