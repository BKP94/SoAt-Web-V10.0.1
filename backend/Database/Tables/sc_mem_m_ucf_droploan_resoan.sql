CREATE TABLE sc_mem_m_ucf_droploan_resoan (
	item_code varchar(6) NOT NULL,
	droploan_resoan varchar(100)
) ;
COMMENT ON TABLE sc_mem_m_ucf_droploan_resoan IS E'!NN!';
COMMENT ON COLUMN sc_mem_m_ucf_droploan_resoan.droploan_resoan IS E'!N??????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_ucf_droploan_resoan.item_code IS E'!N????N!!MM!';
ALTER TABLE sc_mem_m_ucf_droploan_resoan ADD PRIMARY KEY (item_code);


