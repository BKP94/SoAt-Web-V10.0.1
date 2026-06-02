CREATE TABLE sc_acc_m_ucf_account_type (
	account_type_id char(1) NOT NULL,
	account_type_name varchar(100)
) ;
COMMENT ON TABLE sc_acc_m_ucf_account_type IS E'!N???????????N!!MM!';
COMMENT ON COLUMN sc_acc_m_ucf_account_type.account_type_id IS E'!N???????????????N!!MM!';
COMMENT ON COLUMN sc_acc_m_ucf_account_type.account_type_name IS E'!N???????????????N!!MM!';
ALTER TABLE sc_acc_m_ucf_account_type ADD PRIMARY KEY (account_type_id);


