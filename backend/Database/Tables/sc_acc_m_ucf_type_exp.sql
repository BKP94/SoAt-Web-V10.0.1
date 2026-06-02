CREATE TABLE sc_acc_m_ucf_type_exp (
	type_exp varchar(5) NOT NULL,
	type_name varchar(100)
) ;
COMMENT ON TABLE sc_acc_m_ucf_type_exp IS E'!NN!';
ALTER TABLE sc_acc_m_ucf_type_exp ADD PRIMARY KEY (type_exp);


