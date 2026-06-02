CREATE TABLE sc_acc_journal_heading_firm (
	doc_type varchar(6) NOT NULL,
	doc_no varchar(15) NOT NULL,
	journal_date timestamp NOT NULL,
	branch_id varchar(6) NOT NULL,
	description varchar(250),
	total_amount decimal(15,2),
	post_to_gl_status char(1),
	entry_name varchar(16),
	entry_date timestamp,
	entry_br_id varchar(6) NOT NULL DEFAULT '01',
	adj_status char(1) DEFAULT '0',
	post_app varchar(10),
	cancel_status char(1) DEFAULT '0',
	cancel_id varchar(16),
	cancel_date timestamp,
	cancel_branchid varchar(6),
	doc_no_temp varchar(15),
	vourcher_group varchar(7)
) ;
COMMENT ON TABLE sc_acc_journal_heading_firm IS E'!N????? - Journal.HN!!MM!';
COMMENT ON COLUMN sc_acc_journal_heading_firm.cancel_status IS E'!NN!!MM!';
COMMENT ON COLUMN sc_acc_journal_heading_firm.post_to_gl_status IS E'!NN!!MM!';
CREATE INDEX idx_date_fimhead ON sc_acc_journal_heading_firm (journal_date);
ALTER TABLE sc_acc_journal_heading_firm ADD PRIMARY KEY (doc_type,doc_no,journal_date,branch_id,entry_br_id);


