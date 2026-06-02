CREATE TABLE sc_dev_dbstr_tab_columns (
	table_name varchar(30) NOT NULL,
	column_name varchar(30) NOT NULL,
	column_id double precision DEFAULT 0,
	data_type varchar(106),
	data_length double precision DEFAULT 0,
	data_precision double precision DEFAULT 0,
	data_scale double precision DEFAULT 0,
	nullable varchar(1),
	data_default varchar(50),
	comments varchar(4000)
) ;
ALTER TABLE sc_dev_dbstr_tab_columns ADD PRIMARY KEY (table_name,column_name);


