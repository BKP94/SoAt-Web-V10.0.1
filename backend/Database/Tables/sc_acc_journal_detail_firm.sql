CREATE TABLE sc_acc_journal_detail_firm (
	doc_type varchar(6) NOT NULL,
	doc_no varchar(15) NOT NULL,
	journal_date timestamp NOT NULL,
	branch_id varchar(6) NOT NULL,
	sequence_no double precision NOT NULL,
	nature varchar(6),
	account_id varchar(8),
	dr_amount decimal(15,2),
	cr_amount decimal(15,2),
	remark varchar(200),
	entry_id varchar(16),
	entry_date timestamp,
	post_system char(1),
	post_day timestamp,
	pay_type varchar(7),
	post_merge_status char(1),
	item_type varchar(3),
	post_app varchar(10),
	desc_journal_detail varchar(250),
	page_show double precision DEFAULT 0,
	budget_id varchar(5),
	doc_no_temp varchar(15)
) ;
COMMENT ON TABLE sc_acc_journal_detail_firm IS E'!NN!';
CREATE INDEX idx_acc_jnl_det_date ON sc_acc_journal_detail_firm (journal_date);
ALTER TABLE sc_acc_journal_detail_firm ADD PRIMARY KEY (doc_type,doc_no,journal_date,branch_id,sequence_no);


