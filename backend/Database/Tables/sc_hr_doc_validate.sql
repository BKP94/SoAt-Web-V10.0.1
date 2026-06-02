CREATE TABLE sc_hr_doc_validate (
	doc_no varchar(15) NOT NULL,
	doc_headline varchar(100) NOT NULL,
	operate_date timestamp,
	memgroup_fr varchar(15),
	membership_no varchar(15),
	prename_code varchar(6),
	member_name varchar(50),
	member_surname varchar(50),
	book_receive_date timestamp,
	book_send_date timestamp,
	book_form varchar(6) NOT NULL,
	member_fullname varchar(250),
	chg_share char(1) DEFAULT '0',
	chg_dept char(1) DEFAULT '0',
	chg_name char(1) DEFAULT '0',
	chg_group char(1) DEFAULT '0',
	entry_id varchar(16),
	old_member char(1),
	chg_tel char(1) DEFAULT '0',
	chg_increase char(1) DEFAULT '0',
	chg_reduce char(1) DEFAULT '0',
	chg_address char(1) DEFAULT '0',
	id_card varchar(13)
) ;
ALTER TABLE sc_hr_doc_validate ADD PRIMARY KEY (doc_no,doc_headline);
ALTER TABLE sc_hr_doc_validate ALTER COLUMN doc_no SET NOT NULL;
ALTER TABLE sc_hr_doc_validate ALTER COLUMN doc_headline SET NOT NULL;
ALTER TABLE sc_hr_doc_validate ALTER COLUMN book_form SET NOT NULL;


