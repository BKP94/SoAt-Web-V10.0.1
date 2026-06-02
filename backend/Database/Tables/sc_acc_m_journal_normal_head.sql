CREATE TABLE sc_acc_m_journal_normal_head (
	acc_book_type_id varchar(6),
	doc_no varchar(15),
	branch_id varchar(6),
	journal_date timestamp,
	journal_description varchar(200),
	journal_amount decimal(15,2),
	post_to_gl_status double precision,
	entry_name varchar(50),
	entry_date timestamp
) ;
COMMENT ON TABLE sc_acc_m_journal_normal_head IS E'!NN!';


