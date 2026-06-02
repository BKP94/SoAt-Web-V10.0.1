CREATE TABLE sc_lon_req_coll_law_borrow (
	borrow_type varchar(6),
	borrow_no varchar(15) NOT NULL DEFAULT '<NEW>',
	borrow_date timestamp,
	borrow_id varchar(16),
	borrow_objective varchar(100),
	doc_no varchar(15) NOT NULL,
	begin_date timestamp,
	end_date timestamp,
	remark varchar(100),
	cancel_status char(1) DEFAULT '0',
	approve_status char(1) DEFAULT '2',
	entry_id varchar(16),
	entry_date timestamp,
	approve_id varchar(16),
	approve_date timestamp,
	borrow_deep_status char(1),
	borrow_mortgage_status char(1),
	borrow_loan_status char(1),
	requester_name varchar(100),
	loan_doc char(1) DEFAULT '0',
	coop_buy char(1)
) ;
ALTER TABLE sc_lon_req_coll_law_borrow ADD PRIMARY KEY (borrow_no);
ALTER TABLE sc_lon_req_coll_law_borrow ALTER COLUMN borrow_no SET NOT NULL;
ALTER TABLE sc_lon_req_coll_law_borrow ALTER COLUMN doc_no SET NOT NULL;


