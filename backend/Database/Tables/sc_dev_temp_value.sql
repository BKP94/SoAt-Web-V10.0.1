CREATE TABLE sc_dev_temp_value (
	code varchar(30) NOT NULL,
	val varchar(100)
) ;
ALTER TABLE sc_dev_temp_value ADD PRIMARY KEY (code);
ALTER TABLE sc_dev_temp_value ALTER COLUMN code SET NOT NULL;


