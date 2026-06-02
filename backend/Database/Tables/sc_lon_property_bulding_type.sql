CREATE TABLE sc_lon_property_bulding_type (
	building_type varchar(6) NOT NULL DEFAULT '00',
	building_desc varchar(50)
) ;
COMMENT ON TABLE sc_lon_property_bulding_type IS E'!NN!';
ALTER TABLE sc_lon_property_bulding_type ADD PRIMARY KEY (building_type);


