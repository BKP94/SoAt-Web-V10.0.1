CREATE TABLE sc_atm_send_file_ktb_permit (
	operate_date timestamp NOT NULL,
	item_no smallint NOT NULL DEFAULT 0,
	file_line smallint NOT NULL DEFAULT 0,
	msg_decrypt varchar(154)
) ;
CREATE INDEX idx_atm_send_file_ktb_permit_h ON sc_atm_send_file_ktb_permit (operate_date, item_no);
ALTER TABLE sc_atm_send_file_ktb_permit ADD PRIMARY KEY (operate_date,item_no,file_line);


