CREATE TABLE sc_mem_m_requestment_resign (
	resign_doc_no char(15) NOT NULL,
	membership_no varchar(15),
	resign_date timestamp,
	resign_code varchar(4),
	approve_result char(1),
	approve_id char(15),
	approve_date timestamp,
	remark varchar(100),
	shr_wid_status char(1),
	loan_debt_status char(1),
	close_sav_status char(1),
	resign_item_type_code char(2),
	different_shareloan decimal(15,2),
	item_type_code char(2),
	trans_bank_status char(1),
	member_status_code char(1),
	member_name varchar(250),
	member_group_no char(15),
	member_appdate timestamp,
	cancel_status char(1),
	cancel_id char(10),
	cancel_date timestamp,
	cancel_branch char(2)
) ;
ALTER TABLE sc_mem_m_requestment_resign ADD PRIMARY KEY (resign_doc_no);


