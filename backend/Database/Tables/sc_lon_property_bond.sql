CREATE TABLE sc_lon_property_bond (
	loan_requestment_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	bond_type char(1) DEFAULT '0',
	bond_no varchar(25),
	age double precision DEFAULT 0,
	amount decimal(15,2) DEFAULT 0,
	type_of_jumnum char(1) DEFAULT '0',
	of_year varchar(4)
) ;
COMMENT ON TABLE sc_lon_property_bond IS E'!NN!';
ALTER TABLE sc_lon_property_bond ADD PRIMARY KEY (loan_requestment_no,seq_no);


