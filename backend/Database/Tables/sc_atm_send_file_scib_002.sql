CREATE TABLE sc_atm_send_file_scib_002 (
	operate_date timestamp,
	item_no smallint DEFAULT 0,
	file_line smallint DEFAULT 0,
	msg_decrypt varchar(139)
) ;
CREATE INDEX idx_atm_send_file_scib_002_h ON sc_atm_send_file_scib_002 (operate_date, item_no);
CREATE UNIQUE INDEX sys_c009642 ON sc_atm_send_file_scib_002 (operate_date, item_no, file_line);


