CREATE TABLE sc_lon_m_ucf_building (
	building_type varchar(6) NOT NULL,
	building_desc varchar(100)
) ;
ALTER TABLE sc_lon_m_ucf_building ADD PRIMARY KEY (building_type);
ALTER TABLE sc_lon_m_ucf_building ALTER COLUMN building_type SET NOT NULL;


