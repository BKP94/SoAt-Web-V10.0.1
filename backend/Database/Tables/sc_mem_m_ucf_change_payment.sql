CREATE TABLE sc_mem_m_ucf_change_payment (
	reason_code varchar(6) NOT NULL,
	description_detail varchar(50),
	vs_path varchar(60)
) ;
COMMENT ON TABLE sc_mem_m_ucf_change_payment IS E'!NN!';
ALTER TABLE sc_mem_m_ucf_change_payment ADD PRIMARY KEY (reason_code);


