CREATE TABLE sc_lon_property_loof_type (
	loof_type char(1) NOT NULL,
	loof_desc varchar(35)
) ;
COMMENT ON TABLE sc_lon_property_loof_type IS E'!NN!';
ALTER TABLE sc_lon_property_loof_type ADD PRIMARY KEY (loof_type);


