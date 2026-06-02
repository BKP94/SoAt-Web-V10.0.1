CREATE TABLE sc_lon_m_ucf_material (
	material_type varchar(6) NOT NULL,
	materialg_desc varchar(100)
) ;
ALTER TABLE sc_lon_m_ucf_material ADD PRIMARY KEY (material_type);
ALTER TABLE sc_lon_m_ucf_material ALTER COLUMN material_type SET NOT NULL;


