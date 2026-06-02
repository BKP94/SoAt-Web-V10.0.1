CREATE TABLE sc_atm_recv_msg_bank (
	atm_msg char(150) NOT NULL,
	seq_no double precision NOT NULL
) ;
ALTER TABLE sc_atm_recv_msg_bank ADD PRIMARY KEY (atm_msg,seq_no);


