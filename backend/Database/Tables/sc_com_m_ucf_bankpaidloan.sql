CREATE TABLE sc_com_m_ucf_bankpaidloan (
	branch_id varchar(6) NOT NULL,
	bank_acc varchar(6) NOT NULL,
	bank_fin varchar(6) NOT NULL,
	print_cheque char(1) DEFAULT '0',
	paid_div char(1)
) ;
COMMENT ON TABLE sc_com_m_ucf_bankpaidloan IS E'!NN!';
ALTER TABLE sc_com_m_ucf_bankpaidloan ADD PRIMARY KEY (branch_id,bank_acc,bank_fin);
ALTER TABLE sc_com_m_ucf_bankpaidloan ALTER COLUMN bank_fin SET NOT NULL;


