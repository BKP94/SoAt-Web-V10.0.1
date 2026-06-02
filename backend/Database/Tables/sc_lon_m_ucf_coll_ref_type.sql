CREATE TABLE sc_lon_m_ucf_coll_ref_type (
	coll_ref_type varchar(2) NOT NULL,
	coll_ref_description varchar(100),
	dw_detail_support varchar(100),
	coll_type char(2),
	active_status char(1)
) ;
ALTER TABLE sc_lon_m_ucf_coll_ref_type ADD PRIMARY KEY (coll_ref_type);
ALTER TABLE sc_lon_m_ucf_coll_ref_type ALTER COLUMN coll_ref_type SET NOT NULL;


