CREATE TABLE sc_fin_cheque_unused (
	bank_fin varchar(6) NOT NULL,
	book_no double precision NOT NULL DEFAULT 0,
	cheque_no varchar(15) NOT NULL,
	unused_status char(1) DEFAULT '0',
	entry_id varchar(16),
	entry_date timestamp,
	entry_branch varchar(6),
	entry_client varchar(3),
	remark varchar(100)
) ;
COMMENT ON TABLE sc_fin_cheque_unused IS E'!NN!';
ALTER TABLE sc_fin_cheque_unused ADD PRIMARY KEY (bank_fin,book_no,cheque_no);


