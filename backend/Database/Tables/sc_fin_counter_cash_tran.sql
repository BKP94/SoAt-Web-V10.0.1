CREATE TABLE sc_fin_counter_cash_tran (
	branch_fin varchar(6) NOT NULL DEFAULT '00',
	journal_date timestamp NOT NULL,
	entry_fin varchar(16) NOT NULL,
	open_no double precision NOT NULL DEFAULT 0,
	seq_no double precision NOT NULL DEFAULT 0,
	cash_amount decimal(15,2) DEFAULT 0,
	tran_type char(1),
	tran_entry_fin varchar(16),
	tran_open_no numeric(38) DEFAULT 0,
	entry_date timestamp,
	entry_branch varchar(6),
	entry_client varchar(3),
	vourcher_no_sub varchar(15),
	vourcher_no_main varchar(15),
	cash_befor_tran decimal(15,2) DEFAULT 0,
	cash_after_tran decimal(15,2) DEFAULT 0,
	coin25s numeric(38),
	coin50s numeric(38),
	coin1b numeric(38),
	coin2b numeric(38),
	coin5b numeric(38),
	coin10b numeric(38),
	bn20 numeric(38),
	bn50 numeric(38),
	bn100 numeric(38),
	bn500 numeric(38),
	bn1000 numeric(38),
	request_group double precision DEFAULT 0
) ;
COMMENT ON TABLE sc_fin_counter_cash_tran IS E'!NN!';
ALTER TABLE sc_fin_counter_cash_tran ADD PRIMARY KEY (branch_fin,journal_date,entry_fin,open_no,seq_no);


