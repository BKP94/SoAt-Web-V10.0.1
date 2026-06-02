CREATE TABLE sc_fin_journal_detail (
	branch_fin varchar(6) NOT NULL,
	journal_date timestamp NOT NULL,
	entry_fin varchar(16) NOT NULL,
	open_no double precision NOT NULL,
	fin_book char(1) NOT NULL,
	seq_no double precision NOT NULL,
	item_amount decimal(15,2),
	account_id varchar(8),
	fin_sign char(1),
	slip_group varchar(7),
	postto_account char(1),
	postto_acc_docno varchar(15),
	vourcher_no varchar(15)
) ;
COMMENT ON TABLE sc_fin_journal_detail IS E'!NN!';
ALTER TABLE sc_fin_journal_detail ADD PRIMARY KEY (branch_fin,journal_date,entry_fin,open_no,fin_book,seq_no);


