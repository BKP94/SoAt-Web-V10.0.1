CREATE TABLE sc_lon_spec_type_coll (
	mark_status varchar(6) NOT NULL DEFAULT '00',
	mark_descrip varchar(50)
) ;
ALTER TABLE sc_lon_spec_type_coll ADD PRIMARY KEY (mark_status);
ALTER TABLE sc_lon_spec_type_coll ALTER COLUMN mark_status SET NOT NULL;


