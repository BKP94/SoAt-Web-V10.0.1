CREATE TABLE sc_atm_recv_msg (
	operate_time varchar(23) NOT NULL,
	item_no smallint NOT NULL DEFAULT 0,
	seq_no smallint NOT NULL DEFAULT 0,
	opdate_date timestamp,
	bank_code varchar(3),
	revers_state char(1) DEFAULT '0',
	trans_datetime timestamp,
	trans_timefrac smallint DEFAULT 0,
	effect_date timestamp,
	trans_amount decimal(15,2) DEFAULT 0,
	trans_fee decimal(6,2) DEFAULT 0,
	trans_mode varchar(3),
	trans_type varchar(6) DEFAULT '00',
	trans_coop varchar(6),
	payment_channel varchar(4),
	terminal_no char(16),
	trans_seqno varchar(9),
	terminal_lacation char(30),
	membership_no varchar(15),
	member_group_no varchar(15),
	overdraft_available decimal(15,2) DEFAULT 0,
	coop_account varchar(10),
	member_account varchar(15),
	ref_contract varchar(15) DEFAULT '<>',
	ref_seqno double precision DEFAULT 0,
	approve_amount decimal(15,2) DEFAULT 0,
	response_code varchar(4),
	response_text varchar(253),
	bank_branch_code varchar(6),
	account_status char(1) DEFAULT '1',
	receipt_no varchar(10),
	vourcher_no varchar(30),
	cancel_id varchar(16),
	vourcher_no_fee varchar(30),
	fee_type char(1) DEFAULT '0',
	diff_retport_status char(1) DEFAULT '0'
) ;
CREATE INDEX idx_atm_msg_all_1 ON sc_atm_recv_msg (revers_state, effect_date, trans_mode, trans_type, terminal_no, ref_contract, seq_no);
CREATE INDEX idx_atm_msg_analy_h ON sc_atm_recv_msg (operate_time);
CREATE INDEX idx_atm_msg_contract ON sc_atm_recv_msg (ref_contract);
CREATE INDEX idx_atm_msg_date ON sc_atm_recv_msg (opdate_date);
CREATE INDEX idx_atm_msg_eff_date ON sc_atm_recv_msg (effect_date);
CREATE INDEX idx_atm_msg_itm_no ON sc_atm_recv_msg (item_no);
CREATE INDEX idx_atm_msg_memno ON sc_atm_recv_msg (membership_no);
CREATE INDEX idx_atm_msg_seq ON sc_atm_recv_msg (seq_no);
CREATE INDEX idx_atm_msg_terminal ON sc_atm_recv_msg (terminal_no);
CREATE INDEX idx_atm_msg_trn_seq ON sc_atm_recv_msg (trans_seqno);
CREATE INDEX idx_atm_msg_trn_type ON sc_atm_recv_msg (trans_type);
ALTER TABLE sc_atm_recv_msg ADD PRIMARY KEY (operate_time,item_no,seq_no);


