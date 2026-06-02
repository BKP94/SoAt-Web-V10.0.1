CREATE TABLE sc_mem_m_ucf_loan_group (
	group_loan varchar(6) NOT NULL,
	group_loan_name varchar(50),
	group_control varchar(6)
) ;
COMMENT ON TABLE sc_mem_m_ucf_loan_group IS E'!NN!';
ALTER TABLE sc_mem_m_ucf_loan_group ADD PRIMARY KEY (group_loan);


