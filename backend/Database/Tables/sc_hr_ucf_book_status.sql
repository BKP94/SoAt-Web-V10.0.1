CREATE TABLE sc_hr_ucf_book_status (
	book_status char(1) NOT NULL DEFAULT '0',
	book_desc varchar(100)
) ;
COMMENT ON TABLE sc_hr_ucf_book_status IS E'!NN!';
ALTER TABLE sc_hr_ucf_book_status ADD PRIMARY KEY (book_status);


