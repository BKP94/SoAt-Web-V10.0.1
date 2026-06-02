CREATE TABLE sc_lon_property_ground_type (
	ground_type varchar(6) NOT NULL DEFAULT '00',
	ground_desc varchar(35)
) ;
COMMENT ON TABLE sc_lon_property_ground_type IS E'!NN!';
ALTER TABLE sc_lon_property_ground_type ADD PRIMARY KEY (ground_type);


