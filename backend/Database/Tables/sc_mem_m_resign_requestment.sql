CREATE TABLE sc_mem_m_resign_requestment (
	resign_doc_no varchar(15) NOT NULL,
	membership_no varchar(15),
	resign_date timestamp,
	resign_code varchar(6) DEFAULT '00',
	approve_result char(1) DEFAULT '2',
	approve_id varchar(16),
	approve_date timestamp,
	remark varchar(100),
	different_shareloan decimal(15,2) DEFAULT 0,
	item_type_code varchar(6) DEFAULT '00',
	member_name varchar(250),
	member_group_no varchar(15),
	cancel_status char(1) DEFAULT '0',
	cancel_id varchar(16),
	cancel_date timestamp,
	cancel_br varchar(6) DEFAULT '01',
	cancel_pc varchar(3),
	entry_id varchar(16),
	entry_date timestamp,
	entry_br varchar(6) DEFAULT '01',
	entry_pc varchar(3),
	operate_date timestamp,
	resign_cause_code varchar(6) DEFAULT '00',
	payment_manage_code varchar(6) DEFAULT '00',
	different_manage_code varchar(6) DEFAULT '00',
	different_amount decimal(15,2) DEFAULT 0,
	resign_status char(1) DEFAULT '0',
	resolutions varchar(6) DEFAULT '00',
	share_stock decimal(15,2) DEFAULT 0.00,
	fund_bal decimal(15,2) DEFAULT 0.00,
	dep_bal decimal(15,2) DEFAULT 0.00,
	dep_int decimal(15,2) DEFAULT 0.00,
	emer_bal decimal(15,2) DEFAULT 0.00,
	emer_int decimal(15,2) DEFAULT 0.00,
	norm_bal decimal(15,2) DEFAULT 0.00,
	norm_int decimal(15,2) DEFAULT 0.00,
	spec_bal decimal(15,2) DEFAULT 0.00,
	spec_int decimal(15,2) DEFAULT 0.00,
	tran_bal decimal(15,2) DEFAULT 0.00,
	resign_bal decimal(15,2) DEFAULT 0.00,
	return_bal decimal(15,2) DEFAULT 0.00,
	coll_bal decimal(15,2) DEFAULT 0.00,
	emer_bf decimal(15,2) DEFAULT 0.00,
	norm_bf decimal(15,2) DEFAULT 0.00,
	spec_bf decimal(15,2) DEFAULT 0.00,
	money_type_id varchar(3),
	bank_acc_no varchar(15),
	return_fund decimal(15,2) DEFAULT 0,
	dead_date timestamp
) ;
COMMENT ON TABLE sc_mem_m_resign_requestment IS E'!NN!';
COMMENT ON COLUMN sc_mem_m_resign_requestment.approve_result IS E'!V,0-??????????, 1-??????? ,2-?????????V!';
CREATE INDEX idx_mem_resign_req_apv_id ON sc_mem_m_resign_requestment (approve_id);
CREATE INDEX idx_mem_resign_req_code ON sc_mem_m_resign_requestment (resign_code);
CREATE INDEX idx_mem_resign_req_entry_id ON sc_mem_m_resign_requestment (entry_id);
CREATE INDEX idx_mem_resign_req_memgroup ON sc_mem_m_resign_requestment (member_group_no);
CREATE INDEX idx_mem_resign_req_memno ON sc_mem_m_resign_requestment (membership_no);
ALTER TABLE sc_mem_m_resign_requestment ADD PRIMARY KEY (resign_doc_no);


