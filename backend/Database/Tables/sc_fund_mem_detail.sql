CREATE TABLE sc_fund_mem_detail (
	membership_no varchar(15) NOT NULL DEFAULT 'cnv',
	loan_contract_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL,
	operate_date timestamp,
	item_type varchar(3),
	ref_doc_no varchar(30),
	amount decimal(15,2),
	balance decimal(15,2),
	interest decimal(15,2),
	user_id varchar(16),
	user_date timestamp,
	workingday timestamp,
	branch_id varchar(6),
	period double precision,
	client_name varchar(15),
	loan_type varchar(6),
	paid_status char(1),
	paid_entry_id varchar(15),
	paid_date timestamp,
	old_accu_int decimal(15,2) DEFAULT 0,
	cancel_status char(1) DEFAULT '0',
	status char(1) DEFAULT '0'
) ;
CREATE INDEX idx_fund_det001 ON sc_fund_mem_detail (operate_date);
CREATE INDEX idx_fund_det002 ON sc_fund_mem_detail (item_type);
CREATE INDEX idx_fund_det003 ON sc_fund_mem_detail (balance);
CREATE INDEX idx_fund_det_mem ON sc_fund_mem_detail (membership_no);
CREATE INDEX idx_fund_mem_det_conno ON sc_fund_mem_detail (loan_contract_no);
CREATE INDEX idx_fund_mem_det_plus ON sc_fund_mem_detail (membership_no, loan_contract_no);
ALTER TABLE sc_fund_mem_detail ADD PRIMARY KEY (membership_no,loan_contract_no,seq_no);


