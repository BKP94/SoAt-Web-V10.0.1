CREATE TABLE sc_lon_property_ucf_load (
	load_code varchar(6) NOT NULL DEFAULT '00',
	load_desc varchar(50)
) ;
COMMENT ON TABLE sc_lon_property_ucf_load IS E'!NN!';
ALTER TABLE sc_lon_property_ucf_load ADD PRIMARY KEY (load_code);


