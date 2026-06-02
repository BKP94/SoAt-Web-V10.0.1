CREATE TABLE sc_mem_m_chang_request (
	membership_no varchar(15),
	document_no varchar(15) NOT NULL,
	operate_date timestamp,
	remark varchar(100),
	approve_status char(1),
	approve_id varchar(16),
	approve_date timestamp,
	dep_code varchar(6),
	reason_code varchar(6),
	confirm_id varchar(6) DEFAULT '00',
	position_code varchar(3),
	end_document_no varchar(15),
	other_method_pay char(1) DEFAULT '0',
	monthly_type char(1) DEFAULT '0',
	share_stock decimal(15,2) DEFAULT 0,
	last_period_share double precision DEFAULT 0,
	salary_amount decimal(15,2) DEFAULT 0,
	drop_all_keeping char(1) DEFAULT '0',
	cancel_status char(1) DEFAULT '0',
	cancel_id varchar(16),
	cancel_date timestamp,
	cancel_br varchar(6),
	cancel_pc varchar(3),
	entry_id varchar(16),
	entry_date timestamp,
	entry_branch varchar(6),
	effactive_date timestamp,
	spare_date timestamp,
	spare_begin timestamp
) ;
COMMENT ON TABLE sc_mem_m_chang_request IS E'!N??????????????? ???????????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_chang_request.approve_status IS E'!V0-??????????,1-???????,2-?????????V!';
COMMENT ON COLUMN sc_mem_m_chang_request.entry_branch IS E'!N?????????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_chang_request.entry_date IS E'!N????????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_chang_request.entry_id IS E'!N?????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_chang_request.salary_amount IS E'!N?????????N!!MM!';
CREATE INDEX idx_chg_req001 ON sc_mem_m_chang_request (membership_no);
CREATE INDEX idx_chg_req_oper_date ON sc_mem_m_chang_request (operate_date);
ALTER TABLE sc_mem_m_chang_request ADD PRIMARY KEY (document_no);


