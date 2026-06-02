CREATE TABLE sc_fin_cheque_print (
	bank_fin varchar(6) NOT NULL,
	book_no double precision NOT NULL DEFAULT 0,
	cheque_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	print_date timestamp,
	print_amount_total decimal(15,2) DEFAULT 0,
	paid_name varchar(100),
	paid_memno varchar(15),
	paid_info varchar(1000),
	set_cross_account char(1),
	set_cross_general char(1),
	set_cross_member char(1),
	set_without_date char(1),
	cancel_status char(1),
	paid_status char(1),
	bank_status char(1),
	entry_id varchar(16),
	entry_date timestamp,
	entry_branch varchar(6),
	entry_client varchar(3),
	cancel_id varchar(16),
	cancel_date timestamp,
	cancel_branch varchar(6),
	cancel_client varchar(3),
	paid_gift varchar(250),
	sign_name_1 varchar(30),
	sign_name_2 varchar(30),
	paid_name2 varchar(100),
	paid_info2 varchar(100),
	by_other char(1),
	receive_name varchar(100),
	desc_type varchar(6)
) ;
COMMENT ON TABLE sc_fin_cheque_print IS E'!NN!';
ALTER TABLE sc_fin_cheque_print ADD PRIMARY KEY (bank_fin,book_no,cheque_no,seq_no);


