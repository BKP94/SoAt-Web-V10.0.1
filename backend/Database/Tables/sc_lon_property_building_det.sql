CREATE TABLE sc_lon_property_building_det (
	loan_requestment_no varchar(15) NOT NULL,
	coll_ref varchar(50) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	floor double precision NOT NULL DEFAULT 0,
	ground_type varchar(6) DEFAULT '00',
	ground_wide decimal(15,2) DEFAULT 0,
	ground_deep decimal(15,2) DEFAULT 0,
	floor_desc varchar(30),
	floor_wide double precision DEFAULT 0,
	floor_deep double precision DEFAULT 0,
	ground_type_1 varchar(6) DEFAULT '00',
	ground_deep_2 decimal(15,2) DEFAULT 0,
	ground_wide_2 decimal(15,2) DEFAULT 0,
	ground_deep_1 decimal(15,2) DEFAULT 0,
	ground_wide_1 decimal(15,2) DEFAULT 0,
	ground_type_2 varchar(6) DEFAULT '00',
	floor_float char(1) DEFAULT '0'
) ;
COMMENT ON TABLE sc_lon_property_building_det IS E'!NN!';
ALTER TABLE sc_lon_property_building_det ADD PRIMARY KEY (loan_requestment_no,coll_ref,seq_no,floor);


