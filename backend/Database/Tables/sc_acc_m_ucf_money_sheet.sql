CREATE TABLE sc_acc_m_ucf_money_sheet (
	data_type varchar(6) NOT NULL DEFAULT '00',
	data_type_description varchar(100)
) ;
ALTER TABLE sc_acc_m_ucf_money_sheet ADD PRIMARY KEY (data_type);
ALTER TABLE sc_acc_m_ucf_money_sheet ALTER COLUMN data_type SET NOT NULL;


