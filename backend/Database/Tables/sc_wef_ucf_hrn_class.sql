CREATE TABLE sc_wef_ucf_hrn_class (
	class_type varchar(6) NOT NULL,
	class_desc varchar(50)
) ;
ALTER TABLE sc_wef_ucf_hrn_class ADD PRIMARY KEY (class_type);
ALTER TABLE sc_wef_ucf_hrn_class ALTER COLUMN class_type SET NOT NULL;


