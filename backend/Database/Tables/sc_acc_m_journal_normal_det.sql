CREATE TABLE sc_acc_m_journal_normal_det (
	acc_book_type_id varchar(6) NOT NULL,
	doc_no varchar(15) NOT NULL,
	branch_id varchar(6) NOT NULL,
	sequence_no double precision NOT NULL,
	account_id varchar(8),
	desc_journal_detail varchar(200),
	dr_amount decimal(15,2),
	cr_amount decimal(15,2),
	journal_no varchar(15),
	nature varchar(6)
) ;
COMMENT ON TABLE sc_acc_m_journal_normal_det IS E'!NN!';
ALTER TABLE sc_acc_m_journal_normal_det ADD PRIMARY KEY (acc_book_type_id,doc_no,branch_id,sequence_no);


