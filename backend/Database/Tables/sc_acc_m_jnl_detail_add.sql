CREATE TABLE sc_acc_m_jnl_detail_add (
	acc_book_type_id varchar(6) NOT NULL,
	journal_date timestamp NOT NULL,
	branch_id varchar(6) NOT NULL,
	nature varchar(6) NOT NULL,
	sequence_no double precision NOT NULL,
	seq_no double precision NOT NULL,
	desc_journal_detail varchar(250),
	amount double precision,
	page_show double precision DEFAULT 0
) ;
COMMENT ON TABLE sc_acc_m_jnl_detail_add IS E'!NN!';
ALTER TABLE sc_acc_m_jnl_detail_add ADD PRIMARY KEY (acc_book_type_id,journal_date,branch_id,nature,sequence_no,seq_no);


