CREATE TABLE sc_fin_cheque_print_item (
	bank_fin varchar(6) NOT NULL,
	book_no double precision NOT NULL DEFAULT 0,
	cheque_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	item_no double precision NOT NULL DEFAULT 0,
	vourcher_no varchar(30),
	print_amount decimal(15,2) DEFAULT 0.00,
	v_seq_no numeric(38) DEFAULT 0,
	v_seq_fqp numeric(38) DEFAULT 0
) ;
COMMENT ON TABLE sc_fin_cheque_print_item IS E'!NN!';
ALTER TABLE sc_fin_cheque_print_item ADD PRIMARY KEY (bank_fin,book_no,cheque_no,seq_no,item_no);


