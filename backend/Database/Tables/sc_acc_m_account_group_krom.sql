CREATE TABLE sc_acc_m_account_group_krom (
	group_krom varchar(10) NOT NULL,
	group_krom_control varchar(10) NOT NULL,
	group_krom_desc varchar(100)
) ;
ALTER TABLE sc_acc_m_account_group_krom ADD PRIMARY KEY (group_krom);
ALTER TABLE sc_acc_m_account_group_krom ALTER COLUMN group_krom SET NOT NULL;
ALTER TABLE sc_acc_m_account_group_krom ALTER COLUMN group_krom_control SET NOT NULL;


