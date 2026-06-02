CREATE TABLE sc_acc_t_journal_detail (
	acc_book_type_id varchar(6),
	journal_date timestamp,
	nature varchar(6),
	sequence_no numeric(38),
	doc_no varchar(10),
	account_id varchar(8),
	desc_journal_detail varchar(200),
	dr_amount decimal(15,2),
	cr_amount decimal(15,2)
) ;


