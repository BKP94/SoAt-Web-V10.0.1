CREATE TABLE sc_mem_edit_bank (
	membership_no varchar(15) NOT NULL,
	entry_date timestamp NOT NULL,
	entry_id varchar(16) NOT NULL,
	operate_date timestamp NOT NULL,
	seq_no double precision NOT NULL,
	pre_bank_id varchar(6),
	pre_bank_acc_no varchar(15),
	pre_bank_branch_id varchar(6),
	bank_id varchar(6),
	bank_acc_no varchar(15),
	bank_branch_id varchar(6),
	entry_br varchar(6),
	doc_edit varchar(15),
	pre_paid_loan char(1) DEFAULT '0',
	pre_paid_dividen char(1) DEFAULT '0',
	pre_atm_lon char(1) DEFAULT '0',
	pre_atm_dep char(1) DEFAULT '0',
	pre_share_withdraw char(1) DEFAULT '0',
	pre_paid_agent char(1) DEFAULT '0',
	pre_paid_salary char(1) DEFAULT '0',
	paid_loan char(1) DEFAULT '0',
	paid_dividen char(1) DEFAULT '0',
	atm_lon char(1) DEFAULT '0',
	atm_dep char(1) DEFAULT '0',
	share_withdraw char(1) DEFAULT '0',
	paid_agent char(1) DEFAULT '0',
	paid_salary char(1) DEFAULT '0'
) ;
ALTER TABLE sc_mem_edit_bank ADD PRIMARY KEY (membership_no,entry_date,seq_no);
ALTER TABLE sc_mem_edit_bank ALTER COLUMN membership_no SET NOT NULL;
ALTER TABLE sc_mem_edit_bank ALTER COLUMN entry_date SET NOT NULL;
ALTER TABLE sc_mem_edit_bank ALTER COLUMN entry_id SET NOT NULL;
ALTER TABLE sc_mem_edit_bank ALTER COLUMN operate_date SET NOT NULL;
ALTER TABLE sc_mem_edit_bank ALTER COLUMN seq_no SET NOT NULL;


