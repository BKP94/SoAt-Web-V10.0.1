CREATE TABLE sc_atm_recv_file_bay_tst (
	operate_date timestamp NOT NULL,
	item_no smallint NOT NULL DEFAULT 0,
	seq_no smallint NOT NULL DEFAULT 0,
	msg_decrypt varchar(160)
) ;
CREATE INDEX idx_atm_recv_file_bay_tst_h ON sc_atm_recv_file_bay_tst (operate_date, item_no);
ALTER TABLE sc_atm_recv_file_bay_tst ADD PRIMARY KEY (operate_date,item_no,seq_no);


