CREATE TABLE sc_lon_property_company (
	company_code varchar(6) NOT NULL DEFAULT '00',
	company_name varchar(50)
) ;
COMMENT ON TABLE sc_lon_property_company IS E'!NN!';
ALTER TABLE sc_lon_property_company ADD PRIMARY KEY (company_code);


