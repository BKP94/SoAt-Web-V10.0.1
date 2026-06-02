CREATE TABLE sc_mem_m_member_bank_accno (
	membership_no varchar(15) NOT NULL,
	seq_no numeric(38) NOT NULL DEFAULT 0,
	bank_id varchar(6),
	bank_acc_no varchar(15),
	paid_loan char(1) DEFAULT '0',
	paid_dividen char(1) DEFAULT '0',
	atm_lon char(1) DEFAULT '0',
	atm_dep char(1) DEFAULT '0',
	bank_branch_id varchar(6),
	mustcoll_loan char(1) DEFAULT '0',
	share_withdraw char(1),
	money_return char(1),
	paid_salary char(1) DEFAULT '0',
	paid_agent char(1) DEFAULT '0',
	keep_monthly char(1) DEFAULT '0',
	entry_id varchar(16),
	entry_date timestamp,
	main_acc char(1)
) ;
COMMENT ON TABLE sc_mem_m_member_bank_accno IS E'!N???????????????????????N!';
COMMENT ON COLUMN sc_mem_m_member_bank_accno.bank_acc_no IS E'!N???????????N!';
COMMENT ON COLUMN sc_mem_m_member_bank_accno.bank_id IS E'!N??????N!';
COMMENT ON COLUMN sc_mem_m_member_bank_accno.membership_no IS E'!N?????????????N!';
COMMENT ON COLUMN sc_mem_m_member_bank_accno.seq_no IS E'!N?????N!';
CREATE INDEX idx_mem_bankaccno ON sc_mem_m_member_bank_accno (membership_no);
CREATE INDEX idx_mem_bankaccno_bank_id ON sc_mem_m_member_bank_accno (bank_id);
ALTER TABLE sc_mem_m_member_bank_accno ADD PRIMARY KEY (membership_no,seq_no);


