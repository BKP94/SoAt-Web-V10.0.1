CREATE TABLE sc_wef_ucf_edu_class (
	class_type varchar(6) NOT NULL,
	class_desc varchar(50),
	paid_rate decimal(15,2) DEFAULT '0',
	age_limit integer DEFAULT 0
) ;
ALTER TABLE sc_wef_ucf_edu_class ADD PRIMARY KEY (class_type);
ALTER TABLE sc_wef_ucf_edu_class ALTER COLUMN class_type SET NOT NULL;


