CREATE TABLE sc_atm_recv_msg_reverse (
	operate_time varchar(23) NOT NULL,
	item_no double precision NOT NULL,
	seq_no double precision NOT NULL,
	bank_refno varchar(20) NOT NULL,
	membership_no varchar(15),
	effect_date timestamp,
	loan_contract_no char(15)
) ;
CREATE INDEX idx_atm_recv_msg_reverse ON sc_atm_recv_msg_reverse (bank_refno);
ALTER TABLE sc_atm_recv_msg_reverse ADD PRIMARY KEY (operate_time,item_no,seq_no,bank_refno);


