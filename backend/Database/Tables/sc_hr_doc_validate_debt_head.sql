CREATE TABLE sc_hr_doc_validate_debt_head (
	doc_no varchar(15) NOT NULL,
	operate_date timestamp,
	entry_id varchar(16),
	cancel_status char(1),
	doc_head_no varchar(20),
	doc_date timestamp,
	group_fr varchar(250),
	doc_headline varchar(100),
	send_date timestamp,
	finish_status char(1),
	express_status char(1),
	doc_head_no_short varchar(6)
) ;
ALTER TABLE sc_hr_doc_validate_debt_head ADD PRIMARY KEY (doc_no);
ALTER TABLE sc_hr_doc_validate_debt_head ALTER COLUMN doc_no SET NOT NULL;


