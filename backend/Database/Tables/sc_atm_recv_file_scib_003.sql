CREATE TABLE sc_atm_recv_file_scib_003 (
	operate_date timestamp,
	item_no smallint DEFAULT 0,
	seq_no smallint DEFAULT 0,
	msg_decrypt varchar(110)
) ;
CREATE INDEX idx_atm_recv_file_scib_003_h ON sc_atm_recv_file_scib_003 (operate_date, item_no);
CREATE UNIQUE INDEX sys_c009609 ON sc_atm_recv_file_scib_003 (operate_date, item_no, seq_no);


