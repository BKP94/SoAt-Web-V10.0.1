CREATE TABLE sc_mobile_ucf_method_uri (
	method_uri varchar(30) NOT NULL,
	method_desc varchar(100) NOT NULL
) ;
ALTER TABLE sc_mobile_ucf_method_uri ADD PRIMARY KEY (method_uri);
ALTER TABLE sc_mobile_ucf_method_uri ALTER COLUMN method_uri SET NOT NULL;
ALTER TABLE sc_mobile_ucf_method_uri ALTER COLUMN method_desc SET NOT NULL;


