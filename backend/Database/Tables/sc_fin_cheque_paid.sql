CREATE TABLE sc_fin_cheque_paid (
	bank_fin varchar(6) NOT NULL,
	book_no double precision NOT NULL DEFAULT 0,
	cheque_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	item_no double precision NOT NULL DEFAULT 0,
	paid_date timestamp,
	paid_amount decimal(15,2) DEFAULT 0,
	entry_id varchar(16),
	entry_date timestamp,
	entry_branch varchar(6),
	entry_client varchar(3),
	cancel_status char(1),
	cancel_id varchar(16),
	cancel_date timestamp,
	cancel_branch varchar(6),
	cancel_client varchar(3),
	operate_date timestamp,
	cheque_status char(1) DEFAULT '0',
	cheque_date timestamp,
	return_status char(1) DEFAULT '0',
	return_date timestamp,
	not_contract_status char(1) DEFAULT '0',
	not_contract_date timestamp,
	tran_status char(1) DEFAULT '0',
	tran_date timestamp,
	cut_entry_id varchar(16),
	cut_entry_date timestamp,
	cut_vourcher varchar(30),
	cut_vourcher_pot varchar(30),
	cut_amount decimal(15,2) DEFAULT 0
) ;
COMMENT ON TABLE sc_fin_cheque_paid IS E'!NN!';
ALTER TABLE sc_fin_cheque_paid ADD PRIMARY KEY (bank_fin,book_no,cheque_no,seq_no,item_no);


