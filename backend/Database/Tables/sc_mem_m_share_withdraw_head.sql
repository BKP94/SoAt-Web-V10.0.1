CREATE TABLE sc_mem_m_share_withdraw_head (
	withdraw_doc_no varchar(10) NOT NULL,
	membership_no varchar(15),
	withdraw_date timestamp,
	withdraw_status char(1),
	entry_id varchar(16),
	entry_date timestamp,
	cancel_id varchar(20),
	cancel_date timestamp,
	fin_status char(1),
	coll_status char(1),
	free_status char(1),
	trans_type varchar(3),
	paid_status char(1) DEFAULT '0',
	money_type_id varchar(3) DEFAULT 'CSH',
	bank_id varchar(6),
	bank_br varchar(6),
	bank_account_no varchar(15),
	vourcher_no varchar(15),
	vourcher_no_cancel varchar(15),
	branch_id varchar(6),
	bank_fin varchar(6),
	pay_reason_id varchar(6) DEFAULT '00',
	share_stock decimal(15,2) DEFAULT 0,
	member_status_code char(1) DEFAULT '0',
	member_group_no varchar(15),
	total_loan decimal(15,2) DEFAULT 0,
	share_withdraw double precision DEFAULT 0,
	money_return_item double precision DEFAULT 0,
	approve_status char(1),
	begin_balance decimal(15,2) DEFAULT 0.00,
	approve_date timestamp,
	approve_id varchar(16),
	bank_acc char(6),
	bank_branch char(6),
	cheque_no char(15),
	cheque_date timestamp,
	paid_date timestamp
) ;
COMMENT ON TABLE sc_mem_m_share_withdraw_head IS E'!NN!';
COMMENT ON COLUMN sc_mem_m_share_withdraw_head.bank_id IS E'!NN!!VV!!MM!';
COMMENT ON COLUMN sc_mem_m_share_withdraw_head.money_type_id IS E'!N?????????????N!!VV!!MM!';
CREATE INDEX idx_sh_withdraw_head_date ON sc_mem_m_share_withdraw_head (withdraw_date);
CREATE INDEX idx_sh_withdraw_head_fin ON sc_mem_m_share_withdraw_head (fin_status);
CREATE INDEX idx_sh_withdraw_head_status ON sc_mem_m_share_withdraw_head (withdraw_status);
ALTER TABLE sc_mem_m_share_withdraw_head ADD PRIMARY KEY (withdraw_doc_no);


