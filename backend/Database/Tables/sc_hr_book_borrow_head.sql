CREATE TABLE sc_hr_book_borrow_head (
	borrow_no varchar(15) NOT NULL,
	borrow_user_id varchar(16),
	entry_id varchar(16),
	entry_date timestamp,
	entry_branch varchar(6),
	entry_clientid varchar(30),
	cancel_status char(1) DEFAULT '0',
	cancel_id varchar(16),
	cancel_date timestamp,
	cancel_branch varchar(6)
) ;
COMMENT ON TABLE sc_hr_book_borrow_head IS E'!NN!';
ALTER TABLE sc_hr_book_borrow_head ADD PRIMARY KEY (borrow_no);


