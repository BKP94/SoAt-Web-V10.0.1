CREATE TABLE sc_hr_book_borrow_detail (
	borrow_no varchar(15) NOT NULL,
	book_no varchar(15) NOT NULL,
	return_status char(1) DEFAULT '0',
	return_date timestamp,
	borrow_date timestamp
) ;
COMMENT ON TABLE sc_hr_book_borrow_detail IS E'!NN!';
ALTER TABLE sc_hr_book_borrow_detail ADD PRIMARY KEY (borrow_no,book_no);


