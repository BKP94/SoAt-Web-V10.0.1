CREATE TABLE sc_lon_property_road_type (
	road_type varchar(6) NOT NULL DEFAULT '00',
	road_desc varchar(35)
) ;
COMMENT ON TABLE sc_lon_property_road_type IS E'!NN!';
ALTER TABLE sc_lon_property_road_type ADD PRIMARY KEY (road_type);


