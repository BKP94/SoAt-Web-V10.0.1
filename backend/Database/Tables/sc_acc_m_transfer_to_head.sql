CREATE TABLE sc_acc_m_transfer_to_head (
	account_id varchar(8) NOT NULL,
	branch_id varchar(6) NOT NULL DEFAULT '00',
	transfer_from_branch varchar(8),
	transfer_to_head varchar(8)
) ;
COMMENT ON TABLE sc_acc_m_transfer_to_head IS E'!NN!';
ALTER TABLE sc_acc_m_transfer_to_head ADD PRIMARY KEY (account_id,branch_id);


