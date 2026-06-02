CREATE TABLE sc_dep_m_deposit_group (
	deposit_group_code varchar(6) NOT NULL,
	deposit_group_name varchar(50)
) ;
COMMENT ON TABLE sc_dep_m_deposit_group IS E'!NN!';
ALTER TABLE sc_dep_m_deposit_group ADD PRIMARY KEY (deposit_group_code);


