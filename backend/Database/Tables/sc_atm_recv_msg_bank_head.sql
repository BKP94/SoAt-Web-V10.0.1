CREATE TABLE sc_atm_recv_msg_bank_head (
	atm_msg char(150) NOT NULL,
	seq_no double precision NOT NULL,
	rec_type char(1),
	seq_num char(6),
	bank_code char(3),
	company_code char(10),
	company_account_no char(12),
	company_name char(40),
	post_date char(8),
	fillter_1 char(70),
	entry_id char(15),
	entry_date timestamp,
	entry_branch varchar(6),
	post_date_date timestamp
) ;
ALTER TABLE sc_atm_recv_msg_bank_head ADD PRIMARY KEY (atm_msg,seq_no);


