CREATE TABLE sc_dep_m_creditor_item (
	deposit_account_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL,
	refer_to_deposit_doc_no varchar(20),
	operate_date timestamp,
	item_type varchar(3),
	deposit_balance decimal(15,2),
	total_balance decimal(15,2),
	old_acc_int decimal(15,2),
	refer_seq_no double precision,
	fee_amount decimal(15,2),
	int_amount decimal(15,2),
	tax_amount decimal(15,2),
	cheque_no varchar(20),
	bank_code varchar(6),
	bank_branch_id varchar(6),
	cheque_due timestamp,
	start_int_cheque_date timestamp,
	cheque_clearing_status char(1),
	clearing_date timestamp,
	clearing_user varchar(15),
	ret_int decimal(15,2),
	dep_ret_to_int decimal(15,2),
	ref_doc_adj varchar(15),
	deposit_real decimal(15,2),
	total_real decimal(15,2),
	print_status char(1),
	cancle_status char(1),
	officer_id varchar(16),
	last_access_date timestamp,
	branch_id varchar(6),
	working_day timestamp,
	fin_status char(1),
	book_status char(1),
	ref_seq_no_adj double precision,
	ref_item_type_adj varchar(3),
	client_name varchar(30),
	seq_no_bk double precision,
	card_status char(1),
	old_acc_int_new decimal(15,2),
	accu_int_item decimal(15,2),
	ref_int_rate decimal(15,8),
	saving_amount decimal(15,2),
	paidintnostm decimal(15,2) DEFAULT 0,
	old_acc_int_copy decimal(15,2) DEFAULT 0,
	conclude_book double precision DEFAULT 0,
	auto_print_status char(1) DEFAULT '0',
	auto_print_id varchar(20),
	auto_print_branch varchar(6),
	auto_print_date timestamp,
	auto_working_date timestamp,
	calpaidintdate timestamp,
	deposit_account_no_other varchar(15),
	print_workingdate timestamp,
	client_id varchar(3),
	withdrawable_amount decimal(15,2) DEFAULT 0,
	cheque_pending_amount decimal(15,2) DEFAULT 0,
	ref_item_seq double precision DEFAULT 0,
	remark_adjust varchar(100),
	count_day double precision,
	last_calcint_date timestamp,
	interest_rate decimal(15,6),
	agent_sended_date timestamp,
	rollback_int char(1),
	rollback_date timestamp,
	accu_spec_int decimal(15,2),
	int_spec_rate decimal(15,2)
) ;
COMMENT ON TABLE sc_dep_m_creditor_item IS E'!NN!';
CREATE INDEX idx_creditor_item_refno ON sc_dep_m_creditor_item (refer_to_deposit_doc_no);
CREATE INDEX idx_dep_item_accno ON sc_dep_m_creditor_item (deposit_account_no);
CREATE INDEX idx_dep_item_branch_id ON sc_dep_m_creditor_item (branch_id);
CREATE INDEX idx_dep_item_fin_status ON sc_dep_m_creditor_item (fin_status);
CREATE INDEX idx_dep_item_item_type ON sc_dep_m_creditor_item (item_type);
CREATE INDEX idx_dep_item_opdate ON sc_dep_m_creditor_item (operate_date);
CREATE INDEX idx_dep_item_working_day ON sc_dep_m_creditor_item (working_day);
CREATE INDEX idx_findep ON sc_dep_m_creditor_item (deposit_account_no, item_type, refer_to_deposit_doc_no, working_day);
CREATE INDEX idx_findep_s ON sc_dep_m_creditor_item (deposit_account_no, item_type, refer_to_deposit_doc_no);
ALTER TABLE sc_dep_m_creditor_item ADD PRIMARY KEY (deposit_account_no,seq_no);
ALTER TABLE sc_dep_m_creditor_item ALTER COLUMN deposit_account_no SET NOT NULL;
ALTER TABLE sc_dep_m_creditor_item ALTER COLUMN seq_no SET NOT NULL;


