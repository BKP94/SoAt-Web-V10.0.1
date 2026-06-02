CREATE TABLE sc_lon_property_ucf_bond (
	bond_type char(1) NOT NULL DEFAULT '0',
	bond_desc varchar(50)
) ;
COMMENT ON TABLE sc_lon_property_ucf_bond IS E'!NN!';
ALTER TABLE sc_lon_property_ucf_bond ADD PRIMARY KEY (bond_type);


