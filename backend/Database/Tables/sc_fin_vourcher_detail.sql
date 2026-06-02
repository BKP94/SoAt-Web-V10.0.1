CREATE TABLE sc_fin_vourcher_detail (
	vourcher_no varchar(30) NOT NULL,
	seq_no double precision NOT NULL,
	item_type varchar(10),
	account_id varchar(8),
	account_tr varchar(8),
	item_amount decimal(15,2),
	bank_id varchar(6),
	bank_br varchar(6),
	cheque_no varchar(20),
	sign_status char(1),
	pay_type char(1) DEFAULT 'C',
	ref_system varchar(3),
	ref_docno varchar(15),
	ref_paid_status char(1) DEFAULT '0',
	ref_paid_date timestamp,
	post_sign_id char(1) DEFAULT '0',
	post_sign_tr char(1) DEFAULT '0',
	money_return_status char(1) DEFAULT '0',
	ref_seqno numeric(38) DEFAULT 0,
	ref_item_code varchar(3) DEFAULT '???',
	cheque_printed decimal(15,2) DEFAULT 0,
	ref_item_type varchar(3) DEFAULT '???',
	cheque_date timestamp,
	ref_memno varchar(15),
	item_desc varchar(100),
	remark varchar(200),
	link_book_bank char(1),
	book_bank_fin varchar(6),
	book_bank_seq numeric(38)
) ;
COMMENT ON TABLE sc_fin_vourcher_detail IS E'!NN!';
ALTER TABLE sc_fin_vourcher_detail ADD PRIMARY KEY (vourcher_no,seq_no);


