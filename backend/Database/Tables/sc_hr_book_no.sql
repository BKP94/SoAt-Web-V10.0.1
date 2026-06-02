CREATE TABLE sc_hr_book_no (
	book_no varchar(15),
	book_desc varchar(100),
	book_status char(1) DEFAULT '0',
	department_id varchar(3),
	operate_date timestamp,
	destroy_status char(1) DEFAULT '0',
	destroy_date timestamp,
	destroy_id varchar(16),
	keep_placement varchar(3),
	entry_id varchar(16),
	entry_date timestamp,
	entry_branch varchar(6),
	entry_clientid varchar(30),
	cancel_status char(1) DEFAULT '0',
	cancel_id varchar(16),
	cancel_date timestamp,
	cancel_branch varchar(6)
) ;
COMMENT ON TABLE sc_hr_book_no IS E'!NN!';


