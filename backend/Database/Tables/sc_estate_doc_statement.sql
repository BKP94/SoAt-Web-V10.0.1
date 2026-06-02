CREATE TABLE sc_estate_doc_statement (
	doc_no varchar(15) NOT NULL,
	deed_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL,
	item_type varchar(6),
	operate_date timestamp,
	doc_date_get timestamp,
	doc_date_to_return timestamp,
	borrow_id varchar(15),
	sign_flag integer,
	remark_01 varchar(200),
	borrow_deep_status char(1),
	borrow_mortgage_status char(1),
	borrow_loan_status char(1),
	borrow_objective varchar(100),
	entry_date timestamp,
	requester_name varchar(100),
	loan_doc char(1)
) ;
ALTER TABLE sc_estate_doc_statement ADD PRIMARY KEY (doc_no,seq_no);
ALTER TABLE sc_estate_doc_statement ALTER COLUMN doc_no SET NOT NULL;
ALTER TABLE sc_estate_doc_statement ALTER COLUMN deed_no SET NOT NULL;
ALTER TABLE sc_estate_doc_statement ALTER COLUMN seq_no SET NOT NULL;


