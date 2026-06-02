CREATE TABLE sc_atm_send_file_ktb_mem (
	operate_date timestamp NOT NULL,
	item_no smallint NOT NULL DEFAULT 0,
	file_line smallint NOT NULL DEFAULT 0,
	msg_decrypt varchar(100)
) ;
CREATE INDEX idx_atm_send_file_ktb_mem_h ON sc_atm_send_file_ktb_mem (operate_date, item_no);
ALTER TABLE sc_atm_send_file_ktb_mem ADD PRIMARY KEY (operate_date,item_no,file_line);


