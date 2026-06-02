CREATE TABLE sc_fin_cheque_tobank (
	vourcher_no varchar(30) NOT NULL,
	item_no double precision NOT NULL DEFAULT 0,
	cheque_amount decimal(15,2) DEFAULT 0,
	bank_fin varchar(6),
	tobank_status char(1),
	tobank_date timestamp,
	entry_id varchar(16),
	entry_date timestamp,
	entry_branch varchar(6),
	cancel_status char(1),
	cancel_id varchar(16),
	cancel_date timestamp,
	cancel_branch varchar(6),
	clearing_status char(1) DEFAULT '2',
	clearing_id varchar(16),
	clearing_br varchar(6),
	clearing_pc varchar(3),
	clearing_findate timestamp,
	clearing_time timestamp,
	clearing_bankdate timestamp,
	cheque_bank_id varchar(6),
	cheque_bank_br varchar(6),
	cheque_no varchar(15),
	vourcher_seq numeric(38),
	voucher_save varchar(15)
) ;
COMMENT ON TABLE sc_fin_cheque_tobank IS E'!NN!';
ALTER TABLE sc_fin_cheque_tobank ADD PRIMARY KEY (vourcher_no,item_no);


