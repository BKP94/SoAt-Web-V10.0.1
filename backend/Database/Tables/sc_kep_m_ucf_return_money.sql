CREATE TABLE sc_kep_m_ucf_return_money (
	return_method varchar(3) NOT NULL,
	return_desc varchar(100),
	return_order numeric(38) DEFAULT 0,
	active_status char(1)
) ;
COMMENT ON TABLE sc_kep_m_ucf_return_money IS E'!NN!';
COMMENT ON COLUMN sc_kep_m_ucf_return_money.active_status IS E'!N??????????N!!MM!';
COMMENT ON COLUMN sc_kep_m_ucf_return_money.return_desc IS E'!N????????N!!MM!';
COMMENT ON COLUMN sc_kep_m_ucf_return_money.return_method IS E'!N???????????N!!MM!';
COMMENT ON COLUMN sc_kep_m_ucf_return_money.return_order IS E'!N???????????N!!MM!';
ALTER TABLE sc_kep_m_ucf_return_money ADD PRIMARY KEY (return_method);


