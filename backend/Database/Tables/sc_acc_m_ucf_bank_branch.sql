CREATE TABLE sc_acc_m_ucf_bank_branch (
	bank_id varchar(6) NOT NULL,
	bank_branch_id varchar(6) NOT NULL,
	bank_name varchar(100),
	cheque_code char(1),
	balance decimal(15,2),
	account_no varchar(10),
	account_type varchar(6),
	account_name varchar(200),
	remark varchar(200),
	criteria varchar(200),
	close_date timestamp,
	close_status char(1),
	open_date timestamp,
	principal_balance decimal(15,2),
	account_id varchar(8),
	sort_order integer DEFAULT 0,
	coop_branch varchar(6),
	ignor_tranfee char(1) DEFAULT '0',
	province_code varchar(6) DEFAULT '00'
) ;
COMMENT ON TABLE sc_acc_m_ucf_bank_branch IS E'!N????????????????? - ??????????N!!MM!';
COMMENT ON COLUMN sc_acc_m_ucf_bank_branch.bank_branch_id IS E'!N??????????????N!!MM!';
COMMENT ON COLUMN sc_acc_m_ucf_bank_branch.bank_id IS E'!N??????????N!!MM!';
COMMENT ON COLUMN sc_acc_m_ucf_bank_branch.bank_name IS E'!N????????N!!MM!';
COMMENT ON COLUMN sc_acc_m_ucf_bank_branch.cheque_code IS E'!N?????N!!MM!';
COMMENT ON COLUMN sc_acc_m_ucf_bank_branch.ignor_tranfee IS E'!N??????? ?/? ??????N!!MM!';
COMMENT ON COLUMN sc_acc_m_ucf_bank_branch.province_code IS E'!N???????????N!!MM!';
CREATE INDEX idx_acc_bankbr_bank_id ON sc_acc_m_ucf_bank_branch (bank_id);
ALTER TABLE sc_acc_m_ucf_bank_branch ADD PRIMARY KEY (bank_id,bank_branch_id);


