CREATE TABLE sc_fin_ucf_cheque_status (
	cheque_status char(1) NOT NULL DEFAULT '0',
	description varchar(50)
) ;
COMMENT ON TABLE sc_fin_ucf_cheque_status IS E'!NN!';
ALTER TABLE sc_fin_ucf_cheque_status ADD PRIMARY KEY (cheque_status);


