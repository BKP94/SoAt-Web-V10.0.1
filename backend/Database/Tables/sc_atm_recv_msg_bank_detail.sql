CREATE TABLE sc_atm_recv_msg_bank_detail (
	atm_msg char(150) NOT NULL,
	seq_no double precision NOT NULL,
	rec_type char(1) NOT NULL,
	seq_num char(6) NOT NULL,
	trans_date char(10),
	trans_time char(6),
	cust_account_no char(12),
	atm_no char(6),
	atm_seq char(6),
	trans_flag char(1),
	trans_code char(12),
	trans_amt char(13),
	cust_name char(50),
	filter_2 char(29),
	membership_no varchar(15),
	ref_contract_no char(15),
	post_status char(1),
	type_status char(1),
	sign_status decimal(15,2),
	trans_date_date timestamp
) ;
CREATE INDEX idx_atm_bank_detail_atm_no ON sc_atm_recv_msg_bank_detail (atm_no);
CREATE INDEX idx_atm_bank_detail_atm_seq ON sc_atm_recv_msg_bank_detail (atm_seq);
CREATE INDEX idx_atm_bank_detail_conno ON sc_atm_recv_msg_bank_detail (ref_contract_no);
CREATE INDEX idx_atm_bank_detail_memno ON sc_atm_recv_msg_bank_detail (membership_no);
CREATE INDEX idx_atm_bank_detail_msg ON sc_atm_recv_msg_bank_detail (atm_msg);
CREATE INDEX idx_atm_bank_detail_seq ON sc_atm_recv_msg_bank_detail (seq_no);
CREATE INDEX idx_atm_bank_detail_tdate ON sc_atm_recv_msg_bank_detail (trans_date_date);
CREATE UNIQUE INDEX sys_c0024663 ON sc_atm_recv_msg_bank_detail (atm_msg, seq_no);
ALTER TABLE sc_atm_recv_msg_bank_detail ADD PRIMARY KEY (atm_msg,seq_no,rec_type,seq_num);


