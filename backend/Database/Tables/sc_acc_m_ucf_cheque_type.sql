CREATE TABLE sc_acc_m_ucf_cheque_type (
	cheque_code varchar(6) NOT NULL,
	cheque_type varchar(50),
	clearing_days double precision
) ;
COMMENT ON TABLE sc_acc_m_ucf_cheque_type IS E'!NN!';
ALTER TABLE sc_acc_m_ucf_cheque_type ADD PRIMARY KEY (cheque_code);


