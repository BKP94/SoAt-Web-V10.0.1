CREATE TABLE sc_lon_property_building_mod (
	loan_requestment_no varchar(15) NOT NULL,
	coll_ref varchar(50) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	mod_seq double precision NOT NULL DEFAULT 0,
	floor_desc varchar(25),
	modify_desc varchar(50),
	ground_wide decimal(15,2) DEFAULT 0,
	ground_deep decimal(15,2) DEFAULT 0,
	create_year varchar(4)
) ;
COMMENT ON TABLE sc_lon_property_building_mod IS E'!NN!';
ALTER TABLE sc_lon_property_building_mod ADD PRIMARY KEY (loan_requestment_no,coll_ref,seq_no,mod_seq);


