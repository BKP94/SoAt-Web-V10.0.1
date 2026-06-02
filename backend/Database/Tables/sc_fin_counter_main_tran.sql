CREATE TABLE sc_fin_counter_main_tran (
	branch_fin varchar(6) NOT NULL DEFAULT '00',
	journal_date timestamp NOT NULL,
	entry_fin varchar(16) NOT NULL,
	open_no double precision NOT NULL DEFAULT 0,
	cash_move decimal(15,2) DEFAULT 0,
	new_entry_fin varchar(16),
	new_open_no numeric(38) DEFAULT 0,
	entry_time timestamp,
	entry_pc varchar(3)
) ;
COMMENT ON TABLE sc_fin_counter_main_tran IS E'!NN!';
ALTER TABLE sc_fin_counter_main_tran ADD PRIMARY KEY (branch_fin,journal_date,entry_fin,open_no);


