CREATE TABLE sc_atm_recv_online_ktb (
	operate_time varchar(23) NOT NULL,
	msg_decrypt char(320)
) ;
ALTER TABLE sc_atm_recv_online_ktb ADD PRIMARY KEY (operate_time);


