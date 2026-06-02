CREATE TABLE sc_lon_m_ucf_coll_type (
	coll_type varchar(2) NOT NULL,
	coll_description varchar(100)
) ;
ALTER TABLE sc_lon_m_ucf_coll_type ADD PRIMARY KEY (coll_type);
ALTER TABLE sc_lon_m_ucf_coll_type ALTER COLUMN coll_type SET NOT NULL;


