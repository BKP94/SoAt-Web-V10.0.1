CREATE TABLE sc_acc_m_ucf_group_exp (
	group_exp varchar(5) NOT NULL,
	group_name varchar(100),
	balance_zero char(1) DEFAULT '0'
) ;
COMMENT ON TABLE sc_acc_m_ucf_group_exp IS E'!NN!';
ALTER TABLE sc_acc_m_ucf_group_exp ADD PRIMARY KEY (group_exp);


