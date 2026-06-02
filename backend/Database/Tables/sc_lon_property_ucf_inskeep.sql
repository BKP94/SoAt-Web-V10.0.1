CREATE TABLE sc_lon_property_ucf_inskeep (
	keep_type varchar(6) NOT NULL DEFAULT '00',
	keep_desc varchar(30)
) ;
COMMENT ON TABLE sc_lon_property_ucf_inskeep IS E'!NN!';
ALTER TABLE sc_lon_property_ucf_inskeep ADD PRIMARY KEY (keep_type);


