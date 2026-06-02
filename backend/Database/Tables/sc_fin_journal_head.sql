CREATE TABLE sc_fin_journal_head (
	branch_fin varchar(6) NOT NULL,
	journal_date timestamp NOT NULL,
	entry_fin varchar(16) NOT NULL,
	open_no double precision NOT NULL,
	fin_book char(1) NOT NULL,
	balance_begin decimal(15,2),
	total_receive decimal(15,2),
	total_payment decimal(15,2),
	balance_forward decimal(15,2),
	main_counter char(1),
	close_day char(1),
	close_id varchar(16),
	close_time timestamp,
	close_clientid varchar(3)
) ;
COMMENT ON TABLE sc_fin_journal_head IS E'!NN!';
CREATE UNIQUE INDEX idx_unique_entry ON sc_fin_journal_head (journal_date, entry_fin, open_no, fin_book);
ALTER TABLE sc_fin_journal_head ADD PRIMARY KEY (branch_fin,journal_date,entry_fin,open_no,fin_book);


