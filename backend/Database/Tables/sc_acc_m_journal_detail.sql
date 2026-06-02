CREATE TABLE sc_acc_m_journal_detail (
	acc_book_type_id char(2) NOT NULL,
	journal_date timestamp NOT NULL,
	branch_id char(2) NOT NULL,
	nature char(2) NOT NULL,
	sequence_no double precision NOT NULL,
	doc_no char(15),
	account_id char(8) NOT NULL,
	desc_journal_detail char(255),
	dr_amount decimal(15,2) NOT NULL,
	cr_amount decimal(15,2) NOT NULL,
	remark char(200),
	entry_id char(50) NOT NULL,
	entry_date timestamp NOT NULL,
	post_system char(1) NOT NULL,
	post_day timestamp,
	pay_type char(3),
	post_merge_status char(1),
	item_type char(3),
	post_app char(10)
) ;
CREATE UNIQUE INDEX sc_acc_m_journal_detail_x ON sc_acc_m_journal_detail (acc_book_type_id, journal_date, branch_id, nature, sequence_no);
ALTER TABLE sc_acc_m_journal_detail ALTER COLUMN acc_book_type_id SET NOT NULL;
ALTER TABLE sc_acc_m_journal_detail ALTER COLUMN journal_date SET NOT NULL;
ALTER TABLE sc_acc_m_journal_detail ALTER COLUMN branch_id SET NOT NULL;
ALTER TABLE sc_acc_m_journal_detail ALTER COLUMN nature SET NOT NULL;
ALTER TABLE sc_acc_m_journal_detail ALTER COLUMN sequence_no SET NOT NULL;
ALTER TABLE sc_acc_m_journal_detail ALTER COLUMN account_id SET NOT NULL;
ALTER TABLE sc_acc_m_journal_detail ALTER COLUMN dr_amount SET NOT NULL;
ALTER TABLE sc_acc_m_journal_detail ALTER COLUMN cr_amount SET NOT NULL;
ALTER TABLE sc_acc_m_journal_detail ALTER COLUMN entry_id SET NOT NULL;
ALTER TABLE sc_acc_m_journal_detail ALTER COLUMN entry_date SET NOT NULL;
ALTER TABLE sc_acc_m_journal_detail ALTER COLUMN post_system SET NOT NULL;


