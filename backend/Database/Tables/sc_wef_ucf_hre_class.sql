CREATE TABLE sc_wef_ucf_hre_class (
	class_type varchar(6) NOT NULL,
	class_desc varchar(200),
	paid_rate decimal(15,2),
	age_limit integer,
	hre_type varchar(6)
) ;
ALTER TABLE sc_wef_ucf_hre_class ADD PRIMARY KEY (class_type);


