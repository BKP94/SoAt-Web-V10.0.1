CREATE TABLE sc_lon_m_ucf_land (
	land_type varchar(6) NOT NULL,
	land_desc varchar(50)
) ;
COMMENT ON TABLE sc_lon_m_ucf_land IS E'!NN!';
ALTER TABLE sc_lon_m_ucf_land ADD PRIMARY KEY (land_type);


