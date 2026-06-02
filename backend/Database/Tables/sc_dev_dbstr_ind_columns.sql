CREATE TABLE sc_dev_dbstr_ind_columns (
	index_name varchar(30) NOT NULL,
	column_position double precision NOT NULL DEFAULT 0,
	table_name varchar(30),
	column_name varchar(4000)
) ;
ALTER TABLE sc_dev_dbstr_ind_columns ADD PRIMARY KEY (index_name,column_position);


