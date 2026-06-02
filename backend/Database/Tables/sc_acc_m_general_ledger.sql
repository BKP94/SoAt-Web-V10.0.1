CREATE TABLE sc_acc_m_general_ledger (
	account_id varchar(8) NOT NULL,
	account_year double precision NOT NULL,
	sequence_gl_no double precision NOT NULL,
	acc_book_type_id varchar(6),
	journal_date timestamp,
	doc_no varchar(15),
	desc_journal_detail varchar(250),
	dr_amount decimal(15,2),
	cr_amount decimal(15,2),
	dr_balance decimal(15,2),
	cr_balance decimal(15,2),
	gl_date timestamp,
	entry_id varchar(50),
	entry_date timestamp,
	branch_id varchar(6) NOT NULL,
	item_close_status char(1),
	row_show double precision DEFAULT 0,
	from_banch varchar(6) DEFAULT '00',
	budget_id varchar(5),
	temp_seq double precision
) ;
COMMENT ON TABLE sc_acc_m_general_ledger IS E'!NN!';
CREATE INDEX idx_book ON sc_acc_m_general_ledger (acc_book_type_id);
CREATE INDEX idx_date ON sc_acc_m_general_ledger (journal_date);
CREATE INDEX idx_gl_accid ON sc_acc_m_general_ledger (account_id);
ALTER TABLE sc_acc_m_general_ledger ADD PRIMARY KEY (account_id,account_year,sequence_gl_no,branch_id);


