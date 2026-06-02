CREATE TABLE sc_acc_m_journal_heading (
	acc_book_type_id char(2) NOT NULL,
	journal_date timestamp NOT NULL,
	branch_id char(2) NOT NULL,
	total_dr_amount decimal(15,2) NOT NULL,
	total_cr_amount decimal(15,2) NOT NULL,
	balance_begin decimal(15,2) NOT NULL,
	balance_forward decimal(15,2) NOT NULL,
	post_to_gl_status char(1) NOT NULL,
	entry_name char(15) NOT NULL,
	entry_date timestamp NOT NULL,
	post_app char(10),
	entry_br_id char(2)
) ;
CREATE UNIQUE INDEX sc_acc_m_journal_heading_x ON sc_acc_m_journal_heading (acc_book_type_id, journal_date, branch_id);
ALTER TABLE sc_acc_m_journal_heading ALTER COLUMN acc_book_type_id SET NOT NULL;
ALTER TABLE sc_acc_m_journal_heading ALTER COLUMN journal_date SET NOT NULL;
ALTER TABLE sc_acc_m_journal_heading ALTER COLUMN branch_id SET NOT NULL;
ALTER TABLE sc_acc_m_journal_heading ALTER COLUMN total_dr_amount SET NOT NULL;
ALTER TABLE sc_acc_m_journal_heading ALTER COLUMN total_cr_amount SET NOT NULL;
ALTER TABLE sc_acc_m_journal_heading ALTER COLUMN balance_begin SET NOT NULL;
ALTER TABLE sc_acc_m_journal_heading ALTER COLUMN balance_forward SET NOT NULL;
ALTER TABLE sc_acc_m_journal_heading ALTER COLUMN post_to_gl_status SET NOT NULL;
ALTER TABLE sc_acc_m_journal_heading ALTER COLUMN entry_name SET NOT NULL;
ALTER TABLE sc_acc_m_journal_heading ALTER COLUMN entry_date SET NOT NULL;


