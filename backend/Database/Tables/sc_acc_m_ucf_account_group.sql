CREATE TABLE sc_acc_m_ucf_account_group (
	account_group_id varchar(6) NOT NULL,
	account_group_name varchar(100)
) ;
COMMENT ON TABLE sc_acc_m_ucf_account_group IS E'!NN!';
COMMENT ON COLUMN sc_acc_m_ucf_account_group.account_group_id IS E'!N?????????????N!!MM!';
COMMENT ON COLUMN sc_acc_m_ucf_account_group.account_group_name IS E'!N?????????????N!!MM!';
ALTER TABLE sc_acc_m_ucf_account_group ADD PRIMARY KEY (account_group_id);


