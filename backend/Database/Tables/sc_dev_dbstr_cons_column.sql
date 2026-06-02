CREATE TABLE sc_dev_dbstr_cons_column (
	constraint_name varchar(30) NOT NULL,
	position bigint NOT NULL,
	table_name varchar(30),
	column_name varchar(30)
) ;
ALTER TABLE sc_dev_dbstr_cons_column ADD PRIMARY KEY (constraint_name,position);


