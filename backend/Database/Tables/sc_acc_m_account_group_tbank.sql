CREATE TABLE sc_acc_m_account_group_tbank (
	group_trans_bank char(10) NOT NULL,
	group_trans_control char(10),
	group_trans_desc char(100)
) ;
ALTER TABLE sc_acc_m_account_group_tbank ADD PRIMARY KEY (group_trans_bank);


