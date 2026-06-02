CREATE TABLE sc_acc_m_ucf_bank_accno (
	bank_branch_id varchar(6) NOT NULL,
	acc_bank_no varchar(15) NOT NULL,
	mask varchar(3)
) ;
COMMENT ON TABLE sc_acc_m_ucf_bank_accno IS E'!NN!';
ALTER TABLE sc_acc_m_ucf_bank_accno ADD PRIMARY KEY (bank_branch_id,acc_bank_no);


