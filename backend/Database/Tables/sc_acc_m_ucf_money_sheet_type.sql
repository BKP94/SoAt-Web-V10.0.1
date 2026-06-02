CREATE TABLE sc_acc_m_ucf_money_sheet_type (
	data_type varchar(6) NOT NULL,
	data_type_description varchar(100)
) ;
COMMENT ON TABLE sc_acc_m_ucf_money_sheet_type IS E'!NN!';
ALTER TABLE sc_acc_m_ucf_money_sheet_type ADD PRIMARY KEY (data_type);


