CREATE TABLE sc_dep_m_ucf_dep_money_type (
	deposit_money_type_code varchar(6) NOT NULL,
	deposit_money_type_desc varchar(50)
) ;
ALTER TABLE sc_dep_m_ucf_dep_money_type ADD PRIMARY KEY (deposit_money_type_code);
ALTER TABLE sc_dep_m_ucf_dep_money_type ALTER COLUMN deposit_money_type_code SET NOT NULL;


